DROP DATABASE IF EXISTS BBDDJuego;
CREATE DATABASE BBDDJuego;

USE BBDDJuego;

CREATE TABLE Jugadores (
 	
	username TEXT NOT NULL,
	IDj INTEGER PRIMARY KEY NOT NULL,
	contra TEXT NOT NULL
	

)ENGINE=InnoDB;

CREATE TABLE Partidas (

	fecha TEXT NOT NULL ,
	IDp INTEGER PRIMARY KEY NOT NULL,
	ganador TEXT NOT NULL
	
	
)ENGINE=InnoDB;

CREATE TABLE Participacion (

	Jugador INTEGER NOT NULL,
	Partida INTEGER NOT NULL,
	Posicion INTEGER NOT NULL,
	FOREIGN KEY (Jugador) REFERENCES Jugadores(IDj),
  	FOREIGN KEY (Partida) REFERENCES Partidas(IDp)

)ENGINE=InnoDB;
				
INSERT INTO Jugadores VALUES ('Pedro',1,'pedro1234');
INSERT INTO Jugadores VALUES ('Juan',2,'juan1234');
INSERT INTO Jugadores VALUES ('Marta',3,'marta1234');
INSERT INTO Jugadores VALUES ('Maria',4,'maria1234');


INSERT INTO Partidas VALUES ('Lunes',1,'Pedro');
INSERT INTO Partidas VALUES ('Martes',2,'Marta');
INSERT INTO Partidas VALUES ('Sabado',3,'Pedro');
INSERT INTO Partidas VALUES ('Domingo',4,'Juan');

INSERT INTO Participacion VALUES (1,1,1);
INSERT INTO Participacion VALUES (2,3,3);
INSERT INTO Participacion VALUES (3,2,2);
INSERT INTO Participacion VALUES (1,2,3);
INSERT INTO Participacion VALUES (2,2,4);
INSERT INTO Participacion VALUES (4,3,2);
INSERT INTO Participacion VALUES (3,3,4);
INSERT INTO Participacion VALUES (1,3,1);
INSERT INTO Participacion VALUES (2,4,3);












