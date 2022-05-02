#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i;
int sockets[100];


typedef struct {
	char nombre[20];
	int socket;
}Conectado;

typedef struct {
	Conectado conectados[100];
	int num;
}ListaConectados;

ListaConectados lista;


int NumeroJugadores ()
{
	char consulta [1000];
	int err;
	MYSQL *conn;
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T2_Monopoly",0, NULL, 0);
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
	
	
	mysql_close (conn);
	exit(0);
	
	
}

int SignIn (char username[20], char contrasena[20])
{
	
	char consulta [1000];
	char idj [3];
	int err;
	MYSQL *conn;
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
		conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T2_Monopoly",0, NULL, 0);
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
		
		printf("%s", consulta);
		
		err = mysql_query(conn, consulta);
		if (err!=0) 
		{
			printf ("Error al introducir datos la base %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
			
		}

		return 0;
		
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T2_Monopoly",0, NULL, 0);
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





int PosicionJugador (char jugador[20], char fecha[20])
{
	char consulta [1000];
	int err;
	MYSQL *conn;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T2_Monopoly",0, NULL, 0);
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
	

	
	if (row == NULL)
	{
		
		return -1;
	}
	
	else
	{
		int posicion = atoi(row[0]);
		return posicion;
	}
	mysql_close (conn);
	exit(0);

}





int PartidasGanadas (char jugador[20])
{
	char consulta [1000];
	int err;
	MYSQL *conn;
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T2_Monopoly",0, NULL, 0);
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
	
	mysql_close (conn);
	exit(0);
	
	int cont=0;
	
	while (row !=NULL)
	{
		cont= cont + 1;
		row = mysql_fetch_row (resultado);	
	}
	
	return cont;

}



int GanadorPartidaX (int partida, char ganador[20])
{
	char consulta [1000];
	char idp[20];
	int err;
	MYSQL *conn;
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T2_Monopoly",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
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
	
	mysql_close (conn);
	exit(0);
	
	if (row[0] != NULL)
	{
		strcpy (ganador,row[0]);
		return 0;
	}
	
	else
		return -1;	

}



int AnadirConectado (ListaConectados *lista, char nombre[20], int socket)
{
	//Añade nuevo Conectado.
	if (lista->num == 100)
		return -1;
	else
	{
		pthread_mutex_lock(&mutex);
		strcpy (lista->conectados[lista->num].nombre, nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		pthread_mutex_unlock(&mutex);
		return 0;
	}
}

int DameSocket (ListaConectados *lista, char nombre[20])
{
	int i=0;
	int encontrado = 0;
	while ((i < lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre, nombre) ==0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
	}
	if (encontrado)
		return lista->conectados[i].socket;
	else 
		return -1;
}

int DamePosicion (ListaConectados *lista, char nombre[20])
{
	int i=0;
	int encontrado = 0;
	while ((i < lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre, nombre) ==0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else 
		return -1;
}

int Eliminar (ListaConectados *lista, char nombre[20])
{
	int pos = DamePosicion (lista, nombre);
	if (pos == -1)
		return -1;
	else{
		int i;
		for (i=pos; i < lista->num-1; i++)
		{
			pthread_mutex_lock(&mutex);
			lista->conectados[i] = lista->conectados[i+1];
			strcpy (lista->conectados[i].nombre, lista->conectados[i+1].nombre);
			lista->conectados[i].socket = lista->conectados[i+1].socket;
			pthread_mutex_unlock(&mutex);
		}
		lista->num--;
		return 0;
	}
}

void DameConectados (ListaConectados *lista, char conectados[300])
{
	sprintf (conectados, "%d", lista->num);
	int i;
	for (i=0; i< lista->num; i++)
	{
		pthread_mutex_lock(&mutex);
		sprintf (conectados, "%s/%s", conectados, lista->conectados[i].nombre);
		pthread_mutex_unlock(&mutex);
	}
	
}





void *AtenderCliente (void *socket)
{
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	//int socket_conn = * (int *) socket;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	int terminar =0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		//Escribimos la peticion en la consola
		printf ("La peticion es: %s\n",peticion);
		char *p = strtok(peticion, "/");
		int codigo =  atoi (p);
		
		char nombre[20];
		
		if ((codigo !=0) && (codigo !=5) && (codigo !=8))
		{
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
			
			
		}
		
		if (codigo ==0)
		{
			
			terminar=1;
			
			
			int eliminar;
			eliminar =  Eliminar(&lista, nombre);
			
			if ( eliminar == 0)
			{
				
				
				printf(" Usuario eliminado correctamente\n ");
				sprintf (respuesta, "0/Correcto");
				
				char notification [300];
				char conectados[300];
				DameConectados(&lista, conectados);
				sprintf(notification, "6/%s", conectados);
				
				int i;
				
				for (i = 0; i < lista.num; i++)
				{
					write(lista.conectados[i].socket, notification, strlen(notification));
				}
			}
			
			else
			{
				
				printf(" Usuario no encontrado\n ");
				sprintf (respuesta, "0/No encontrado");
			}
			
			
		}  
		
		
		else if (codigo ==1)
		{
			
			char password[20];
			int signin;
			
			p = strtok( NULL, "/");
			strcpy (password, p);
			
			signin = SignIn(nombre,password);
			
			
			if (signin == 0)
				sprintf(respuesta, "1/Correcto" );
			
			else
				sprintf(respuesta, "1/Incorrecto" );
			
		}
		
		
		else if (codigo ==2)
		{
			char password[20];
			int login;
			int anadirconectado;
			
			p = strtok( NULL, "/");
			strcpy (password, p);
			
			login = Login (nombre,password);
			
			if (login == 0)
			{
				anadirconectado = AnadirConectado(&lista, nombre, sock_conn);
				if(anadirconectado == 0)
				{
					sprintf (respuesta, "2/Correcto");
				
				}
				else
				   sprintf (respuesta, "2/LLeno");
				
			}	
			
			
			else
				sprintf (respuesta, "2/Incorrecto");
			
		}
		
		else if (codigo ==3)
		{
			char fecha[20];
			int resultado;
			
			p = strtok( NULL, "/");
			strcpy (fecha, p);
			
			resultado = PosicionJugador (nombre,fecha);
			
			
			if (resultado == -1)
				sprintf (respuesta, "3/%s no jugo ninguna partida el %s \n", nombre, fecha);
			else
				sprintf (respuesta, "3/La posicion del jugador es: %d \n", resultado);
			
		}	
		
		
		
		else if (codigo == 4)
		{
			int resultado;
			
			resultado = PartidasGanadas (nombre);
			
			if (resultado == 0)
				sprintf (respuesta, "4/%s no ha ganada ninguna partida \n", nombre);
			else
				sprintf(respuesta, "4/El numero de partidas ganadas por %s es: %d \n", nombre, resultado);
		}
		
		else if (codigo == 5)
		{
			char ganador[20];
			int resultado;
			int num_partida;
			
			p = strtok( NULL, "/");
			num_partida = atoi(p); 
			
			
			
			resultado = GanadorPartidaX (num_partida,ganador);
			
			if (resultado == -1)
				sprintf (respuesta,"5/No se han obtenido datos en la consulta\n");
			else
				
				sprintf(respuesta, "5/El ganador de la partida %d es: %s \n", num_partida, ganador);
		}
		else if (codigo == 8)
		{
			
			char notification [300];
			char conectados[300];
			DameConectados(&lista, conectados);
			sprintf(notification, "6/%s", conectados);
			
			printf("%s\n", notification);
			
			
			int i;
			
			for (i = 0; i < lista.num; i++)
			{
				write(lista.conectados[i].socket, notification, strlen(notification));
			}
		}	
		
		
		if ((codigo !=0) && (codigo !=8))	
			// Enviamos la respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		
	}
	
	write (sock_conn,respuesta, strlen(respuesta));
	close(sock_conn);
	
}

int main(int argc, char *argv[])
{
	

	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	MYSQL *conn;
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
	serv_adr.sin_port = htons(50053);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");

	pthread_t thread;
	i=0;
	//bucle infinito
	for(;;)
	{
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
		
	}
}

