#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>



int NumeroJugadores ()
{
	char consulta [1000];
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	strcpy (consulta, "SELECT Jugadores.IDj from (Jugadores)");
	
	
	err = mysql_query(conn, consulta);
	if (err!=0) 
	{
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	int cont=0;
	
	while (row !=NULL)
	{
		cont=cont+1;
		row = mysql_fetch_row (resultado);
	}
	
	return cont;
	// cerrar la conexion con el servidor MYSQL 
	mysql_close (conn);
	exit(0);
}


int SignIn (char username[20], char contrasena[20])
{
	
	char consulta [1000];
	char idj [3];
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	int numjugadores = NumeroJugadores();
	
	int identificador = numjugadores + 1;
	
	strcpy (consulta, "INSERT INTO Jugadores VALUES('");
	//strcpy (consulta, "INSERT INTO Jugadores(username,IDj,contra) VALUES('");
	
	strcat (consulta, username); 
	strcat (consulta, "',");
	
	sprintf(idj, "%d", identificador);
	
	strcat (consulta, idj); 
	strcat (consulta, ",'");
	
	strcat (consulta, contrasena); 
	strcat (consulta, "');");
	
		
	err = mysql_query(conn, consulta);
	if (err!=0) 
	{
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
		return -1;
	}
	
	return 0;
	
// cerrar la conexion con el servidor MYSQL 
mysql_close (conn);
exit(0);
}	




int Login (char username[20], char contra[20])
{
	char consulta [1000];
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}

	strcpy (consulta,"SELECT Jugadores.username from Jugadores WHERE Jugadores.username = '"); 
	strcat (consulta, username);
	strcat (consulta,"' AND Jugadores.contra = '");
	strcat (consulta, contra);
	strcat (consulta, "'");
	printf("consulta: %s\n", consulta);
	//strcpy (consulta, "select Jugadores.username from Jugadores where Jugadores.contra = 'pedro1234'");
	
	err = mysql_query(conn, consulta);
	if (err!=0) 
	{
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}

	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	if (row[0] != NULL)
	{
	
		return 0;
	}
	
	else
		return -1;	
	
	mysql_close (conn);
	exit(0);
}	











int PosicionJugador (char jugador[20],char fecha[20])
{
	char consulta [1000];
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	strcpy (consulta,"SELECT Participacion.Posicion from (Jugadores,Partidas,Participacion) WHERE Jugadores.username = '"); 
	strcat (consulta, jugador);
	strcat (consulta,"'AND Jugadores.IDj = Participacion.Jugador AND Partidas.fecha = '");
	strcat (consulta, fecha);
	strcat (consulta, "'AND Participacion.Partida = Partidas.IDp");
	// hacemos la consulta 
	err=mysql_query (conn, consulta);
	
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	if (row[0] != NULL)
	{
	   int posicion = atoi(row[0]);
	   return posicion;
	}
	
	else
	return -1;	
		
	mysql_close (conn);
	exit(0);
}

int PartidasGanadas (char jugador[20])
{
	char consulta [1000];
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	strcpy (consulta,"SELECT Partidas.IDp FROM (Jugadores,Partidas,Participacion) WHERE Jugadores.username = '"); 
	strcat (consulta, jugador);
	strcat (consulta,"' AND Jugadores.IDj = Participacion.Jugador AND Participacion.Partida = Partidas.IDp");
	
	err=mysql_query (conn, consulta);
	
	if (err!=0)
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);

	int cont=0;

	while (row !=NULL)
	{
		cont= cont + 1;
		row = mysql_fetch_row (resultado);	
	}
	
	return cont;
	
	
	mysql_close (conn);
	exit(0);
}

int GanadorPartidaX (int partida, char ganador[20]){
	char consulta [1000];
	char idp[20];
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexi??n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexi??n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}	
	strcpy (consulta,"SELECT Partidas.ganador from Partidas WHERE Partidas.IDp = '");
	
	sprintf(idp, "%d", partida);
	
	strcat (consulta, idp);
	strcat (consulta, "'");
	
	printf(": %s",consulta);
	
	err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	
	if (row[0] != NULL)
	{
		strcpy (ganador,row[0]);
		return 0;
	}
	
	else
		return -1;	
		
	mysql_close (conn);
	exit(0);
}




int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9555);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	int i;
	//bucle infinito
	for(;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
	
		
		//Bucle de atencion al cliente
		
	    int terminar = 0;
		while (terminar == 0)
		{
			// Ahora recibimos su peticion
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibida una peticion\n");
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			//Escribimos la peticion en la consola
			printf ("La peticion es: %s\n",peticion);
			char *p = strtok(peticion, "/");
			int codigo =  atoi (p);
				
				if (codigo ==0)
				{
					terminar=1;
				    
				}    
		
			    
				
				else if (codigo ==1)
				{
					char password[20];
					char nombre[20];
					int signin;
					
					p = strtok( NULL, "/");
					strcpy (nombre, p);
					
					p = strtok( NULL, "/");
					strcpy (password, p);
					
					signin = SignIn (nombre,password);
					if (signin ==0)
						sprintf (respuesta, "Correcto");
					else
						sprintf (respuesta, "Incorrecto");
				}
				
				
				else if (codigo ==2)
				{
					char password[20];
					char nombre[20];
					int login;
					
					p = strtok( NULL, "/");
					strcpy (nombre, p);
					
					p = strtok( NULL, "/");
					strcpy (password, p);
					
					login = Login (nombre,password);
					
					if (login ==0)
						sprintf (respuesta, "Correcto");
					else
						sprintf (respuesta, "Incorrecto");
				}
				
				else if (codigo ==3)
				{
					char fecha[20];
					char nombre[20];
					int resultado;
					
					p = strtok( NULL, "/");
					strcpy (nombre, p);
					
					p = strtok( NULL, "/");
					strcpy (fecha, p);
					
					resultado = PosicionJugador (nombre,fecha);

					
					if (resultado == -1)
						sprintf (respuesta, "No se han obtenido datos en la consulta");
					else
						sprintf (respuesta, "La posici??n del jugador es: %d \n", resultado);
				}	
				
				
				
				else if (codigo == 4)
				{
					char nombre[20];
					int resultado;
					
					p = strtok( NULL, "/");
					strcpy (nombre, p);
					
					resultado = PartidasGanadas (nombre);
					
					if (resultado == 0)
						sprintf (respuesta, " %s no ha ganada ninguna partida \n", nombre);
					else
						sprintf(respuesta, " El numero de partidas ganadas por %s es: %d \n", nombre, resultado);
				}
				
				else
				{
					char ganador[20];
					int resultado;
					int num_partida;
					
					p = strtok( NULL, "/");
					num_partida = atoi(p); 
				
					
					
					resultado = GanadorPartidaX (num_partida,ganador);
					
					if (resultado == -1)
						sprintf (respuesta,"No se han obtenido datos en la consulta\n");
					else
						
						sprintf(respuesta, " El ganador de la partida %d es: %s \n", num_partida, ganador);
				}
		
				if (codigo !=0)	
					// Enviamos la respuesta
					write (sock_conn,respuesta, strlen(respuesta));
				

		}
		// Se acabo el servicio para este cliente*/
		close(sock_conn);
	}
}
