DROP DATABASE IF EXISTS T2_Monopoly;
CREATE DATABASE T2_Monopoly;

USE T2_Monopoly;

CREATE TABLE Jugadores (
 	
	username VARCHAR(60),
	IDj INT PRIMARY KEY NOT NULL,
	contra VARCHAR(60)
	

)ENGINE=InnoDB;

CREATE TABLE Partidas (

	fecha VARCHAR(60),
	ganador VARCHAR(60),
	IDp INT PRIMARY KEY NOT NULL
	
)ENGINE=InnoDB;

CREATE TABLE Participacion (

	Jugador INT NOT NULL,
	Partida INT NOT NULL,
	Posicion INT NOT NULL,
        Puntos INT NOT NULL,
	FOREIGN KEY (Jugador) REFERENCES Jugadores (IDj),
	FOREIGN KEY (Partida) REFERENCES Partidas (IDp)

)ENGINE=InnoDB;
				








