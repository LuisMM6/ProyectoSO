
// - - - - - - - - - - - - - - - - - LIBRERIAS - - - - - - - - - - - - - - - - - - - - - - - -

#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

// - - - - - - - - - - - - - - - - - ESTRUCTURAS - - - - - - - - - - - - - - - - - - - - - - - 


typedef struct
{
	char nombre[20];
	int socket;
}Conectado;


typedef struct
{
	Conectado conectados[100];
	int num;
}ListaConectados;


typedef struct
{
	int ocupado; //0 indica que la entrada esta libre y 1 que esta ocupada
	int socket_creador;
	int socket_jugador2;
	int socket_jugador3;
	int socket_jugador4;
	int respuestas;
	int acceptaciones;
}Partida;


typedef Partida TablaPartidas [100];







// - - - - - - - - - - - - - - - - - VARIABLES GLOBALES - - - - - - - - - - - - - - - - - - -


ListaConectados lista;
TablaPartidas partidas;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i;
int sockets[100];
MYSQL *conn;



// - - - - - - - - - - - - - - - - - - FUNCIONES CONECTADOS - - - - - - - - - - - - - - - - - - - - - - - - 



int AnadirConectado (ListaConectados *lista, char nombre[20], int socket)
	//Retorna -1 si la lista supera el máximo declarado (100).
	//Retorna 0 si se ha anadido a la lista correctamente el nombre y socket.
{	
	if (lista->num == 100)
		return -1;
	else
	{
		
		strcpy (lista->conectados[lista->num].nombre, nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		
		return 0;
	}
}



int DamePosicion (ListaConectados *lista, char nombre[20])
	//Retorna la posicion en lista del nombre en cuestiOn.
	//Retorna -1 si no encuentra el nombre.
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



int DameSocket (ListaConectados *lista, char nombre[20])
	//Busca en la lista el nombre y devuelve el socket associado.
	//Retorna -1 si no encuentra el nombre.
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



void DameConectados (ListaConectados *lista, char conectados[300])
	//Anade en la lista de conectados el numero y los nombres de los conectados
	//("2/Maria/Pedro")
{
	sprintf (conectados, "%d", lista->num);
	int i;
	for (i=0; i< lista->num; i++)
	{
		
		sprintf (conectados, "%s/%s", conectados, lista->conectados[i].nombre);
		
	}
	
}


int Eliminar (ListaConectados *lista, char nombre[20])
	//Retorna 0 si eliminado correctamente.
	//Retorna -1 si no existe el nombre en la lista.
{
	int pos = DamePosicion (lista, nombre);
	if (pos == -1)
		return -1;
	else{
		int i;
		for (i=pos; i < lista->num-1; i++)
		{
			lista->conectados[i] = lista->conectados[i+1];
			strcpy (lista->conectados[i].nombre, lista->conectados[i+1].nombre);
			lista->conectados[i].socket = lista->conectados[i+1].socket;
			
		}
		lista->num--;
		return 0;
	}
}



// - - - - - - - - - - - - - - - - - - - - - FUNCIONES PARTIDAS - - - - - - - - - - - - - - - - - - - - - -


void Inicializar (TablaPartidas partidas)
{
	int i;
	for (i=0; i<100; i++)
		partidas[i].ocupado=0;
}


int AnadirPartida(TablaPartidas partidas, int socket_creador, int socket_jugador2, int socket_jugador3, int socket_jugador4)
//Busca si hay partidas disponibles (ocupado ==0). Retorn -1 si no encuentra
// Si encuentra, retorna posicion (i) partida en la tabla
{
	
	int encontrado =0;
	int i=0;
	
	
	while ((i<100) && !encontrado)
	{
		if (partidas[i].ocupado==0)
			encontrado = 1;
		else
			i=i+1;
	}
	
	if (!encontrado)
		return -1;
	
	else
	{
		partidas[i].socket_creador = socket_creador;
		partidas[i].socket_jugador2 = socket_jugador2;
		partidas[i].socket_jugador3 = socket_jugador3;
		partidas[i].socket_jugador4 = socket_jugador4;
		partidas[i].ocupado=1;
		return i;
	}
	
}


void DameSockets (TablaPartidas partidas , int id_partida, char socketsjugadores[50])
//guarda en la variable socketsjugadores los sockets de los jugadores de esa patida
	
{
	sprintf(socketsjugadores, "%d/%d/%d/%d", partidas[id_partida].socket_creador,  partidas[id_partida].socket_jugador2,
			partidas[id_partida].socket_jugador3,  partidas[id_partida].socket_jugador4);
	
}



void Modificar_Respuestas(TablaPartidas partidas, int id_partida)
{
	
	partidas[id_partida].respuestas = partidas[id_partida].respuestas + 1;
}

void Modificar_Acceptaciones(TablaPartidas partidas, int id_partida)
{
	partidas[id_partida].acceptaciones = partidas[id_partida].acceptaciones + 1; 
}


int Mirar_Respuestas(TablaPartidas partidas, int id_partida)
// devuleve el numero de repsuestas
	
{
	return partidas[id_partida].respuestas;
}

int Mirar_Acceptaciones(TablaPartidas partidas, int id_partida)
// devuleve el numero de repsuestas
	
{
	return partidas[id_partida].acceptaciones;
	
}




// - - - - - - - - - - - - - - - - - - - - - - - - - FUNCIONES SERVIDOR - - - - - - - - - - - - - - - - - - - - - - - - - -


int NumeroJugadores ()
//Retorn numero jugadores registrados en la base de datos
{
	char consulta [1000];
	int err;

	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	
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
	
}



int SignIn (char username[20], char contrasena[20])
//Retorn un 0 si el sigin es correcto
{
	
	char consulta [1000];
	char idj [3];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
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

}



int Login (char username[20], char contra[20])
//Retorna 0 si es correcto, -1 si es incorrecto
{	
	char consulta [1000];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;

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
	
	
}	



//- - - - - - - - - - - - - - - - - - - - - - - - - - - CONSULTAS - - - - - - - - - - - - - - - - - - - 


int PosicionJugador (char jugador[20], char fecha[20])
//Retorna la posicion del jugador o -1 si no encuentra informacion sobre la partida
{
	char consulta [1000];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	
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

}


int PartidasGanadas (char jugador[20])
//Retorna el numero de partidas ganadas
{
	char consulta [1000];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;

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

}



int GanadorContra(char nombre[50], char perdedores[100])
//consulta para obtener los jugadores a los que ha ganado el jugador introducido
{
	int err;
	int cont;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	char consulta[1000];
	
	strcpy(consulta, "SELECT IDj FROM Jugadores WHERE username = '");
	strcat(consulta, nombre);
	strcat(consulta, "';");
	
	err = mysql_query (conn, consulta);
	if (err!=0)
	{
		exit(1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	printf("%s\n", row[0]);
	
	if(row != NULL)
	{ 
		strcpy(consulta, "SELECT distinct(username) from (Jugadores,Participacion,Partidas) where Jugadores.IDj = Participacion.Jugador and Partidas.IDp = Participacion.Partida and Partidas.ganador='");
		strcat(consulta, nombre);
		strcat(consulta, "'and Participacion.IDj='");
		strcat(consulta, row[0]);
		strcat(consulta, "';");
		
		err = mysql_query (conn, consulta);
		if (!err)
		{
			
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			while (row != NULL)
			{
				cont = cont + 1;
				strcat (perdedores, row[0]);
				strcat (perdedores, ";");
				row = mysql_fetch_row(resultado);
			}
			
			if ((strlen(perdedores))!=0)
			{
				perdedores[strlen(perdedores)-1]='\0';
				return cont;
			}
			
		}	
			
	}
	else
	{
		return -1;
	}

}



// - - - - - - - - - - - - - - - - - - - ATENDER CLIENTE - - - - - - - - - - - - - - - -


void *AtenderCliente (void *socket)
// Entramos en un bucle para atender todas las peticiones de este cliente
//hasta que se desconecte
{
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	
	char peticion[512];
	char respuesta[512];
	int ret;
	int terminar =0;

	while (terminar ==0)
	{
		// Ahora recibimos la peticion
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que anadirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		//Escribimos la peticion en la consola
		printf ("La peticion es: %s\n",peticion);
		char *p = strtok(peticion, "/");
		int codigo =  atoi (p);
		
		char nombre[20];
		
		if ((codigo !=0) && (codigo !=8) && (codigo !=7) && (codigo !=9))
		{
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			printf ("Codigo: %d, Nombre: %s, socket: %d\n", codigo, nombre, sock_conn);
			
			
		}
		
		if (codigo ==0)
		/*Desconexion: Envia respuesta de la desconexion
		y envia una notificacion para actualizar la lista de conectados*/
			
		{
			
			terminar=1;
			
			int eliminar;
			
			pthread_mutex_lock(&mutex);
			eliminar =  Eliminar(&lista, nombre);
			pthread_mutex_unlock(&mutex);
			
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
		/*SigIn: Envia respuesta operacion signIn*/
			
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
		/*Login: Envia respuesta operacion Login 
		y envia una notificación para actualizar la lista de conectados*/	
			
		{
			char password[20];
			int login;
			int anadirconectado;
			
			p = strtok( NULL, "/");
			strcpy (password, p);
			
			login = Login (nombre,password);
			
			if (login == 0)
			{
				pthread_mutex_lock(&mutex);
				anadirconectado = AnadirConectado(&lista, nombre, sock_conn);
				pthread_mutex_unlock(&mutex);
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
		/*PosicionJugador: Envia respuesta operacion PosicionJugador*/
		
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
		/*PartidasGanadas: Envia respuesta operacion PartidasGanadas*/
			
		{
			int resultado;
			
			resultado = PartidasGanadas (nombre);
			
			if (resultado == 0)
				sprintf (respuesta, "4/%s no ha ganada ninguna partida \n", nombre);
			else
				sprintf(respuesta, "4/El numero de partidas ganadas por %s es: %d \n", nombre, resultado);
		}
		
		else if (codigo == 5)
		/*Jugadores ganados: Envia respuesta operacion GanadorContra*/
			
		{
			char perdedores [500];
			
			int res = GanadorContra(nombre,perdedores);
			if(res != -1)
			{
				sprintf (respuesta,"5/%s",perdedores);
			}
			else
			{
				sprintf (respuesta,"5/Error");
			}
			
			
		}
		
		
		else if (codigo ==6)
		// Recoge la peticion de invitacion, mira si hay partidas disponibles
		// y envia una notifiacion a los invitados ("7/") 
		{
			char notification [50];
			char jugador2[20];
			char jugador3[20];
			char jugador4[20];
			char creador[20];
			
			strcpy(creador, nombre);
			
			
			p = strtok( NULL, "/");
			strcpy(jugador2,p);
			p = strtok( NULL, "/");
			strcpy(jugador3,p);
			p = strtok( NULL, "/");
			strcpy(jugador4,p);
			
			
			
			int socket_jugador2 = DameSocket(&lista, jugador2);
			int socket_jugador3 = DameSocket(&lista, jugador3);
			int socket_jugador4 = DameSocket(&lista, jugador4);
			
			
			if ( (socket_jugador2== -1) ||  (socket_jugador2 == -1) ||  (socket_jugador3 == -1) ||  (socket_jugador4 == -1) )
			{
				printf(" Jugador no encontrado\n ");
				sprintf(notification, "7/No");
				write(sock_conn, notification, strlen(notification));
			}
			else
			{
				pthread_mutex_lock(&mutex);
			    int id_partida = AnadirPartida(partidas, sock_conn, socket_jugador2, socket_jugador3, socket_jugador4);
				pthread_mutex_unlock(&mutex);
				
				if (id_partida == -1)
					printf("Lista de partidas llena\n");
				
				else
				{
					printf("Partida a�adida correctamente\n");
					
					sprintf(notification, "7/Si/%d/%s", id_partida, creador);
					write(socket_jugador2, notification, strlen(notification));
					write(socket_jugador3, notification, strlen(notification));
					write(socket_jugador4, notification, strlen(notification));
				}
			
			}
		
		}
		
		else if (codigo == 7)
		//se envia mensaje al invitado y cliente de si se va iniciar o no la partida
	
		{
			char respuesta[20];
			char notification[50];
			char sockets_jugadores[50];
			int id_partida;
			int num_respuestas;
			int num_acceptaciones;
			
			p = strtok( NULL, "/");
			strcpy(respuesta,p);
			p = strtok( NULL, "/");
			id_partida = atoi(p);
			
			
			int socket_creador;
			int socket_jugador2;
			int socket_jugador3;
			int socket_jugador4;
			
			DameSockets(partidas, id_partida, sockets_jugadores);
			
			p = strtok( sockets_jugadores, "/");
			socket_creador = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador2 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador3 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador4 = atoi(p);
			
		
			pthread_mutex_lock(&mutex);
			Modificar_Respuestas(partidas, id_partida);
			pthread_mutex_unlock(&mutex);
			
			if (strcmp(respuesta, "Si") == 0)
			{
				pthread_mutex_lock(&mutex);
				Modificar_Acceptaciones(partidas, id_partida);
				pthread_mutex_unlock(&mutex);
				
				num_respuestas = Mirar_Respuestas(partidas, id_partida);
				printf("%d\n", num_respuestas);
				
				if( num_respuestas == 3)
				{
					num_acceptaciones = Mirar_Acceptaciones(partidas, id_partida);
					if ( num_acceptaciones == 3)
					{
						sprintf(notification, "8/Si");
						write(socket_creador, notification, strlen(notification));
						write(socket_jugador2, notification, strlen(notification));
						write(socket_jugador3, notification, strlen(notification));
						write(socket_jugador4, notification, strlen(notification));
					}
					
					else
					{
						sprintf(notification, "8/No");
						write(socket_creador, notification, strlen(notification));
						write(socket_jugador2, notification, strlen(notification));
						write(socket_jugador3, notification, strlen(notification));
						write(socket_jugador4, notification, strlen(notification));
					}
						
					
				}
				
				else
				{
					
				}
			}
			
			else
			{
				num_respuestas = Mirar_Respuestas(partidas, id_partida);
				if (num_respuestas == 3)
				{
					sprintf(notification, "8/No");
					write(socket_creador, notification, strlen(notification));
					write(socket_jugador2, notification, strlen(notification));
					write(socket_jugador3, notification, strlen(notification));
					write(socket_jugador4, notification, strlen(notification));
				}
				else
				{
					
					
				}
			}
			
			
		}
		
		else if (codigo == 8)
		//notificar la lista de conectados a todos los usuarios conectados	
			
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
		
		else if (codigo == 9)
		//recibir mensaje chat y enviarlo a todos los jugadores conectados
			
		{
			
			int id_partida;
			char jugador[20];
			char mensaje[80];
			char sockets_jugadores[50];
			char notification[100];
			
			p = strtok(NULL, "/");
			id_partida = atoi(p);
			p = strtok(NULL, "/");
			strcpy(jugador, p);
			p = strtok(NULL, "/");
			strcpy(mensaje,p);
			
			
			int socket_creador;
			int socket_jugador2;
			int socket_jugador3;
			int socket_jugador4;
			
			DameSockets(partidas, id_partida, sockets_jugadores);
			
			p = strtok( sockets_jugadores, "/");
			socket_creador = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador2 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador3 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador4 = atoi(p);

			
			sprintf(notification, "9/%s/%s",jugador, mensaje);
			printf("%s\n", notification);
			
			write(socket_creador, notification, strlen(notification));
			write(socket_jugador2, notification, strlen(notification));
			write(socket_jugador3, notification, strlen(notification));
			write(socket_jugador4, notification, strlen(notification));
			
		}
		
		if ((codigo !=0) && (codigo !=8) && (codigo !=6) && (codigo !=7) && (codigo !=9)) 	
			// Enviamos la respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		
	}
	
	write (sock_conn,respuesta, strlen(respuesta));
	close(sock_conn);
	
}

int main(int argc, char *argv[])
{


	Inicializar(partidas);
	
	
	
	conn = mysql_init(NULL); 
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn,"localhost","root", "mysql", "T2_Monopoly",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	
	
	
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
	serv_adr.sin_port = htons(9200);
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

