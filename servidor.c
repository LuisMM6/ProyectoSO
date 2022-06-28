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
	//Retorna -1 si la lista supera el maximo declarado (100).
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
	
	if (row != NULL)
	{
		int resultado = DamePosicion (&lista, row[0]);
		
		if (resultado == -1)
			return 0;
		else
			return 2;
	}
	
	else
		return 1;	
	
	
}	




int EliminaUsuario (char username[20])
	//Retorna 0 si lo elimina correctamente
{	
	char mensaje [1000];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	/*	strcpy (consulta,"DELETE from Jugadores WHERE Jugadores.username = '"); */
	/*	strcat (consulta, username);*/
	/*	strcat (consulta, "'");*/
	
	//strcpy (consulta, "select Jugadores.username from Jugadores where Jugadores.contra = 'pedro1234'");
	
	strcpy(mensaje, "DELETE FROM (Jugadores,Partidas,Participacion) WHERE Jugadores.username='");
	strcat(mensaje, username);
	strcat(mensaje, "'");
	err = mysql_query (conn, mensaje);
	
	
	err = mysql_query(conn, mensaje);
	if (err!=0) 
	{
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	return 0;
	
}	


int Buscar_identificador(char jugador[20])
{
	
	char consulta [1000];
	int err;
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy (consulta,"SELECT Jugadores.IDj from Jugadores WHERE Jugadores.username = '"); 
	strcat (consulta, jugador);
	strcat (consulta, "'");
	
	printf("consulta: %s\n", consulta);
	
	
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
	
	if (row != NULL)
	{
		int id = atoi(row[0]);
		
		return id;
	}
	
	else
		return -1;	
	
}









// - - - - - - - - - - - - - - - - - - - - - FUNCIONES PARTIDAS - - - - - - - - - - - - - - - - - - - - - -


void Inicializar (TablaPartidas partidas)
{
	int i;
	for (i=0; i<100; i++)
		partidas[i].ocupado = 0;
}


int AnadirPartida(TablaPartidas partidas, int socket_creador, int socket_jugador2, int socket_jugador3, int socket_jugador4)
//Busca si hay partidas disponibles (ocupado ==1). Retorn -1 si no encuentra
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


void PartidaFinalizada (char ganador[20], char idp[20], char fecha[20])
{
	// guardar nombres  y dinero en una nueva partida en base de datos
	
	
	char consulta [1000];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy (consulta, "INSERT INTO Partidas  VALUES('");
	
	
	
	strcat (consulta, fecha);
	strcat (consulta, "','");
	
	strcat (consulta, ganador);			
	strcat (consulta, "',");			
	
	strcat (consulta, idp);
	strcat (consulta, ");");
	
	
	printf("%s", consulta);
	
	err = mysql_query(conn, consulta);
	if (err!=0) 
	{
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
}

void Participacion_Jugador1(int idp, char jug1[20], int p1)
{
	// buscar el identificador del jugador en la base de datos
	
	int idj = Buscar_identificador(jug1);
	
	// guardar cada participacion de los jugadores en la partida correspondiente
	
	int puesto = 1;
	char idpartida[20];
	char posicion[20];
	char idjugador[20];
	char puntos1[20];
	char consulta [1000];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy (consulta, "INSERT INTO Participacion  VALUES(");
	
	sprintf(idpartida, "%d", idp);
	sprintf(idjugador, "%d", idj);
	sprintf(posicion, "%d", puesto);
	sprintf(puntos1,"%d", p1);
	
	strcat (consulta, idjugador);
	
	strcat (consulta, ",");
	
	strcat (consulta, idpartida);			
	strcat (consulta, ",");			
	
	strcat (consulta, posicion);
	strcat (consulta, ",");		
	
	strcat (consulta, puntos1);
	
	strcat (consulta, ");");
	
	
	printf("%s", consulta);
	
	err = mysql_query(conn, consulta);
	if (err!=0) 
	{
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
	

}



void Participacion_Jugador2(int idp, char jug2[20], int p2)
{
	// buscar el identificador del jugador en la base de datos
	
	int idj = Buscar_identificador(jug2);
	
	// guardar cada participacion de los jugadores en la partida correspondiente
	
	int puesto = 2;
	char idpartida[20];
	char posicion[20];
	char idjugador[20];
	char puntos2[20];
	char consulta [1000];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy (consulta, "INSERT INTO Participacion  VALUES(");
	
	sprintf(idpartida, "%d", idp);
	sprintf(idjugador, "%d", idj);
	sprintf(posicion, "%d", puesto);
	sprintf(puntos2,"%d", p2);
	
	strcat (consulta, idjugador);
	
	strcat (consulta, ",");
	
	strcat (consulta, idpartida);			
	strcat (consulta, ",");			
	
	strcat (consulta, posicion);
	strcat (consulta, ",");		
	
	strcat (consulta, puntos2);
	
	
	strcat (consulta, ");");
	
	
	printf("%s", consulta);
	
	err = mysql_query(conn, consulta);
	if (err!=0) 
	{
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
	
	
}


 void Participacion_Jugador3(int idp, char jug3[20], int p3)
{
	// buscar el identificador del jugador en la base de datos
	
	int idj = Buscar_identificador(jug3);
	
	// guardar cada participacion de los jugadores en la partida correspondiente
	
	int puesto = 3;
	char idpartida[20];
	char posicion[20];
	char idjugador[20];
	char puntos3[20];
	char consulta [1000];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy (consulta, "INSERT INTO Participacion  VALUES(");
	
	sprintf(idpartida, "%d", idp);
	sprintf(idjugador, "%d", idj);
	sprintf(posicion, "%d", puesto);
	sprintf(puntos3,"%d", p3);
	
	strcat (consulta, idjugador);
	
	strcat (consulta, ",");
	
	strcat (consulta, idpartida);			
	strcat (consulta, ",");			
	
	strcat (consulta, posicion);
	strcat (consulta, ",");		
	
	strcat (consulta, puntos3);

	
	strcat (consulta, ");");
	
	
	printf("%s", consulta);
	
	err = mysql_query(conn, consulta);
	if (err!=0) 
	{
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
	
	
}


void Participacion_Jugador4(int idp, char jug4[20], int p4)
{
	// buscar el identificador del jugador en la base de datos
	
	int idj = Buscar_identificador(jug4);
	
	// guardar cada participacion de los jugadores en la partida correspondiente
	
	int puesto = 4;
	char idpartida[20];
	char posicion[20];
	char idjugador[20];
	char puntos4[20];
	char consulta [1000];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy (consulta, "INSERT INTO Participacion  VALUES(");
	
	sprintf(idpartida, "%d", idp);
	sprintf(idjugador, "%d", idj);
	sprintf(posicion, "%d", puesto);
	sprintf(puntos4,"%d", p4);
	
	strcat (consulta, idjugador);
	
	strcat (consulta, ",");
	
	strcat (consulta, idpartida);			
	strcat (consulta, ",");			
	
	strcat (consulta, posicion);
	strcat (consulta, ",");		
	
	strcat (consulta, puntos4);
	
	
	strcat (consulta, ");");
	
	
	printf("%s", consulta);
	
	err = mysql_query(conn, consulta);
	if (err!=0) 
	{
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
	
	
}


//- - - - - - - - - - - - - - - - - - - - - - - - - - - CONSULTAS - - - - - - - - - - - - - - - - - - - 
int NumPartidasJugadas (char jugador[50])
//	Retorna el numero de partidas jugadas
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
	strcat (consulta,"' AND Jugadores.IDj = Participacion.Jugador AND Participacion.Partida = Partidas.IDp AND Participacion.Posicion = 1");
	
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

int VecesPodio (char jugador[20])
	//Retorna el numero de partidas ganadas
{
	char consulta [1000];
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy (consulta,"SELECT Partidas.IDp FROM (Jugadores,Partidas,Participacion) WHERE Jugadores.username = '"); 
	strcat (consulta, jugador);
	strcat (consulta,"' AND Jugadores.IDj = Participacion.Jugador AND Participacion.Partida = Partidas.IDp AND Participacion.Posicion <4");
	
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
		
		int numForm;
		char nombre[20];
		
		if ((codigo !=0) && (codigo !=8) && (codigo !=7) && (codigo !=9) && (codigo !=10) && (codigo !=11) && (codigo !=12) && (codigo !=13) && (codigo !=14) && (codigo !=15) && (codigo !=17))
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
			int login;
			
			p = strtok( NULL, "/");
			strcpy (password, p);
			
			
			login = Login (nombre,password);
			
			
			if (login == 0)
			{ 
				sprintf(respuesta, "1/Incorrecto" );
				printf("Incorrecto\n");
			}	
			
			else
			{
				signin = SignIn(nombre,password);
				if(signin == 0)
				{
					sprintf(respuesta, "1/Correcto" );
					printf("Correcto\n");
				}	
			}	
			
			

		}
		
		
		else if (codigo ==2)
		/*Login: Envia respuesta operacion Login 
		y envia una notificacion para actualizar la lista de conectados*/	
			
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
					printf("Correcto\n");
				
				}
				else
				   sprintf (respuesta, "2/LLeno");
				
			}	
			
			else if (login == 1)
			{
				sprintf (respuesta, "2/Incorrecto");
				printf("Incorrecto\n");
			}	
			
			else
			{
				sprintf (respuesta, "2/Logueado");
				printf("Ya Logueado\n");
			}	
			
			
			
		}
		
		else if (codigo ==3)
		/*VecesPodio: Envia respuesta operacion VecesPodio*/
		
		{
			int resultado;
				
			
			resultado = VecesPodio (nombre);
			
			
			if (resultado == 0)
				sprintf (respuesta, "3/El jugador no ha quedado nunca en el podio.\n");
			else
				sprintf (respuesta, "3/%s ha quedado %d veces en el podio\n", nombre, resultado);
			
		}	
		
		
		
		else if (codigo == 4)
		/*PartidasGanadas: Envia respuesta operacion PartidasGanadas*/
			
		{
			int resultado;
			
			resultado = PartidasGanadas (nombre);
			
			if (resultado == 0)
				sprintf (respuesta, "4/%s no ha ganado ninguna partida \n", nombre);
			else
				sprintf(respuesta, "4/El numero de partidas ganadas por %s es: %d \n", nombre, resultado);
		}
		
		else if (codigo == 5)
			/*PartidasJugadas: Envia respuesta operacion PartidasJugadas*/
		
		{
			int resultado;
			
			
			resultado = NumPartidasJugadas (nombre);
			
			
			if (resultado == 0)
				sprintf (respuesta, "5/El jugador no ha jugado niguna partida.\n");
			else
				sprintf (respuesta, "5/Las partidas jugadas por %s son: %d\n", nombre, resultado);
			
			
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
					printf("Partida anadida correctamente\n");
					
					sprintf(notification, "7/Si/%d/%s/%s/%s/%s", id_partida, creador, jugador2, jugador3, jugador4);
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
			char jugador2[20];
			char jugador3[20];
			char jugador4[20];
			char creador[20];
			
			p = strtok( NULL, "/");
			strcpy(respuesta,p);
			p = strtok( NULL, "/");
			id_partida = atoi(p);
			p = strtok( NULL, "/");
			strcpy(creador,p);
			p = strtok( NULL, "/");
			strcpy(jugador2,p);
			p = strtok( NULL, "/");
			strcpy(jugador3,p);
			p = strtok( NULL, "/");
			strcpy(jugador4,p);
			
			
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

						sprintf(notification, "8/Si/%s/%s/%s/%s",creador, jugador2, jugador3, jugador4);
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
			numForm = atoi(p);
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

			
			sprintf(notification, "9/%d/%s/%s",numForm,jugador, mensaje);
			printf("%s\n", notification);
			
			write(socket_creador, notification, strlen(notification));
			write(socket_jugador2, notification, strlen(notification));
			write(socket_jugador3, notification, strlen(notification));
			write(socket_jugador4, notification, strlen(notification));
			
		}
		
		else if (codigo == 10)
		//enviar nueva posicion de un jugador a los demás jugadores
			
		{
			
			int id_partida;
			char jugador[20];
			int id_jugador;
			int num_form;
			char sockets_jugadores[50];
			char mensaje[50];
			int posX;
			int posY;
			int turno;
			

			p = strtok(NULL, "/");
			id_partida = atoi(p);
			p = strtok(NULL, "/");
			id_jugador = atoi(p);
			p = strtok(NULL, "/");
			posX = atoi(p);
			p = strtok(NULL, "/");
			posY = atoi(p);
			p = strtok(NULL, "/");
			turno = atoi(p);
			
			
			
			int socket_jugador;
			int socket_jugador2;
			int socket_jugador3;
			int socket_jugador4;
			
			DameSockets(partidas, id_partida, sockets_jugadores);
			
			p = strtok( sockets_jugadores, "/");
			socket_jugador = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador2 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador3 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador4 = atoi(p);
			
			sprintf(mensaje, "10/%d/%d/%d/%d",id_jugador,posX, posY, turno );
			printf("%s\n",mensaje);
			
			
			write(socket_jugador, mensaje, strlen(mensaje));
			write(socket_jugador2, mensaje, strlen(mensaje));
			write(socket_jugador3, mensaje, strlen(mensaje));
			write(socket_jugador4, mensaje, strlen(mensaje));
			
		}
		
		else if (codigo == 11)
		//recibir el nuevo turno cuando se pasa el turno a un jugador
			
		{
			int id_partida;
			int turno;
			char sockets_jugadores[50];
			char mensaje[50];
			
			p = strtok(NULL, "/");
			id_partida = atoi(p);
			p = strtok(NULL, "/");
			turno = atoi(p);
			
			int socket_jugador;
			int socket_jugador2;
			int socket_jugador3;
			int socket_jugador4;
			
			DameSockets(partidas, id_partida, sockets_jugadores);
			
			p = strtok( sockets_jugadores, "/");
			socket_jugador = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador2 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador3 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador4 = atoi(p);
			
			sprintf(mensaje, "11/%d",turno );
			printf("%s\n",mensaje);
			
			
			write(socket_jugador, mensaje, strlen(mensaje));
			write(socket_jugador2, mensaje, strlen(mensaje));
			write(socket_jugador3, mensaje, strlen(mensaje));
			write(socket_jugador4, mensaje, strlen(mensaje));
			
			
			
		}
		
		else if (codigo == 12)
		//actualizar dinero a los demas jugadores
			
		{
			
			
			int id_partida;
			int id_jugador;
			int dinero;
			char sockets_jugadores[50];
			char mensaje[50];
			
			
			p = strtok(NULL, "/");
			id_partida = atoi(p);
			p = strtok(NULL, "/");
			id_jugador = atoi(p);
			p = strtok(NULL, "/");
			dinero = atoi(p);
			
			
			int socket_jugador;
			int socket_jugador2;
			int socket_jugador3;
			int socket_jugador4;
			
			DameSockets(partidas, id_partida, sockets_jugadores);
			
			p = strtok( sockets_jugadores, "/");
			socket_jugador = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador2 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador3 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador4 = atoi(p);
			
			sprintf(mensaje, "12/%d/%d",id_jugador, dinero );
			printf("%s\n",mensaje);
			
			
			write(socket_jugador, mensaje, strlen(mensaje));
			write(socket_jugador2, mensaje, strlen(mensaje));
			write(socket_jugador3, mensaje, strlen(mensaje));
			write(socket_jugador4, mensaje, strlen(mensaje));
			
		}
		
		else if (codigo == 13)
		// avisar de una compra de carrera universitaria
			
		{
			
			int id_partida;
			int id_jugador;
			int dinero;
			int casilla;
			char jugador[20];
			char sockets_jugadores[50];
			char mensaje[50];
			
			
			p = strtok(NULL, "/");
			id_partida = atoi(p);
			p = strtok(NULL, "/");
			id_jugador = atoi(p);
			p = strtok(NULL, "/");
			dinero = atoi(p);
			p = strtok(NULL, "/");
			casilla = atoi(p);
			p = strtok( NULL, "/");
			strcpy(jugador,p);
			
			
			int socket_jugador;
			int socket_jugador2;
			int socket_jugador3;
			int socket_jugador4;
			
			DameSockets(partidas, id_partida, sockets_jugadores);
			
			p = strtok( sockets_jugadores, "/");
			socket_jugador = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador2 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador3 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador4 = atoi(p);
			
			sprintf(mensaje, "13/%d/%d/%d/%s",id_jugador, dinero, casilla, jugador );
			printf("%s\n",mensaje);
			
			
			write(socket_jugador, mensaje, strlen(mensaje));
			write(socket_jugador2, mensaje, strlen(mensaje));
			write(socket_jugador3, mensaje, strlen(mensaje));
			write(socket_jugador4, mensaje, strlen(mensaje));
			
		}
		
		else if (codigo == 14)
		// avisar de pagar al propietario de una casilla
			
		{
			
			int id_partida;
			int id_jugador;
			int preciocasilla;
			int casilla;
			char jugador[20];
			char sockets_jugadores[50];
			char mensaje[50];
			char owner[20];

			
			
			p = strtok(NULL, "/");
			id_partida = atoi(p);
			p = strtok(NULL, "/");
			id_jugador = atoi(p);
			p = strtok(NULL, "/");
			preciocasilla = atoi(p);
			p = strtok(NULL, "/");
			casilla = atoi(p);
			p = strtok( NULL, "/");
			strcpy(jugador,p);
			p = strtok( NULL, "/");
			strcpy(owner,p);

			
			
			int socket_jugador;
			int socket_jugador2;
			int socket_jugador3;
			int socket_jugador4;
			
			DameSockets(partidas, id_partida, sockets_jugadores);
			
			p = strtok( sockets_jugadores, "/");
			socket_jugador = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador2 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador3 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador4 = atoi(p);
			
			sprintf(mensaje, "14/%d/%d/%d/%s/%s",id_jugador, preciocasilla, casilla, jugador, owner);
			printf("%s\n",mensaje);
			
			
			write(socket_jugador, mensaje, strlen(mensaje));
			write(socket_jugador2, mensaje, strlen(mensaje));
			write(socket_jugador3, mensaje, strlen(mensaje));
			write(socket_jugador4, mensaje, strlen(mensaje));
			
		}
		
		
		else if (codigo == 15)
		// finalizar paartida si uno de los jugadores abandona
			
		{
			
			int id_partida;
			char sockets_jugadores[50];
			char mensaje[50];
	
			
			p = strtok(NULL, "/");
			id_partida = atoi(p);
			
			
			
			
			int socket_jugador;
			int socket_jugador2;
			int socket_jugador3;
			int socket_jugador4;
			
			DameSockets(partidas, id_partida, sockets_jugadores);
			
			p = strtok( sockets_jugadores, "/");
			socket_jugador = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador2 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador3 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador4 = atoi(p);
			
			sprintf(mensaje, "15/");
			printf("%s\n",mensaje);
			
			
			write(socket_jugador, mensaje, strlen(mensaje));
			write(socket_jugador2, mensaje, strlen(mensaje));
			write(socket_jugador3, mensaje, strlen(mensaje));
			write(socket_jugador4, mensaje, strlen(mensaje));
			
		}
		
		
		else if (codigo == 16)
		// eliminar Usuario	de la base datos	
		{
			int eliminausuario;
			 
			 eliminausuario = EliminaUsuario(nombre);
			
			if (eliminausuario == 0)
				sprintf(respuesta, "16/Correcto" );
			
			else
				sprintf(respuesta, "16/Incorrecto" );
			
		}
		
		else if (codigo == 17)
		
		// guarda los datos de la partida finalizada en la base de datos
			
		{
			int id_partida;
			char jugador1[20];
			int dinero1;
			char jugador2[20];
			int dinero2;
			char jugador3[20];
			int dinero3;
			char jugador4[20];
			int dinero4;
			char fecha[20];
			int dia;
			int mes;
			int ano;
			

			p = strtok(NULL, "/");
			id_partida = atoi(p);
			p = strtok( NULL, "/");
			strcpy(jugador1,p);
			p = strtok(NULL, "/");
			dinero1 = atoi(p);
			p = strtok( NULL, "/");
			strcpy(jugador2,p);
			p = strtok(NULL, "/");
			dinero2 = atoi(p);
			p = strtok( NULL, "/");
			strcpy(jugador3,p);
			p = strtok(NULL, "/");
			dinero3 = atoi(p);
			p = strtok( NULL, "/");
			strcpy(jugador4,p);
			p = strtok(NULL, "/");
			dinero4 = atoi(p);
			p = strtok( NULL, "/");
			dia = atoi(p);
			p = strtok( NULL, "/");
			mes = atoi(p);
			p = strtok( NULL, "/");
			ano = atoi(p);
			
			sprintf (fecha, "%d/%d/%d", dia, mes, ano);
			
		
			
			char idp[20];
			sprintf(idp,"%d", id_partida);
			
			
			// guardamos una nueva partida en la base de datos
			
			PartidaFinalizada(jugador1, idp, fecha);
			
			
			// guardar las participaciones de los cuatro jugadores con sus respectivos puntos
			
			Participacion_Jugador1(id_partida, jugador1, dinero1);
			Participacion_Jugador2(id_partida, jugador2, dinero2);
			Participacion_Jugador3(id_partida, jugador3, dinero3);
			Participacion_Jugador4(id_partida, jugador4, dinero4);
			
			
			int socket_jugador;
			int socket_jugador2;
			int socket_jugador3;
			int socket_jugador4;
			
			char sockets_jugadores[50];
			
			DameSockets(partidas, id_partida, sockets_jugadores);
			
			p = strtok( sockets_jugadores, "/");
			socket_jugador = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador2 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador3 = atoi(p);
			p = strtok( NULL, "/");
			socket_jugador4 = atoi(p);
			
			char mensaje[50];
			
			
			sprintf(mensaje, "17/%s/%s/%s", jugador1, jugador2, jugador3);
			printf("%s\n",mensaje);
			
			
			write(socket_jugador, mensaje, strlen(mensaje));
			write(socket_jugador2, mensaje, strlen(mensaje));
			write(socket_jugador3, mensaje, strlen(mensaje));
			write(socket_jugador4, mensaje, strlen(mensaje));
		}
		
		
		if ((codigo !=0) && (codigo !=8) && (codigo !=6) && (codigo !=7) && (codigo !=9) && (codigo!=10) && (codigo !=11) && (codigo!=12) && (codigo !=13) && (codigo !=14) && (codigo !=15) && (codigo !=17))	
			// Enviamos la respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		
	}
	
	write (sock_conn,respuesta, strlen(respuesta));
	close(sock_conn);
	
}



//- - - - - - - - - - - - - - - - - - - - - - - - - - - MAIN - - - - - - - - - - - - - - - - - - - - - - - - 


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
	
	
	//Producción
	conn = mysql_real_connect (conn,"shiva2.upc.es","root", "mysql", "T2_Monopoly",0, NULL, 0);
	
	
	//Desarollo 
	//conn = mysql_real_connect (conn,"localhost","root", "mysql", "T2_Monopoly",0, NULL, 0);
	
	
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
	//Desarollo
	//serv_adr.sin_port = htons(9700);
	
	//Producción
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
