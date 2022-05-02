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
	duracion FLOAT,
	ganador VARCHAR(60),
	IDp INT PRIMARY KEY NOT NULL
	
)ENGINE=InnoDB;

CREATE TABLE Participacion (

	Jugador INT NOT NULL,
	Partida INT NOT NULL,
	Posicion INT NOT NULL,
	FOREIGN KEY (Jugador) REFERENCES Jugadores (IDj),
	FOREIGN KEY (Partida) REFERENCES Partidas (IDp)

)ENGINE=InnoDB;
				
INSERT INTO Jugadores VALUES ('Pedro', 1, 'pedro1234');
INSERT INTO Jugadores VALUES ('Juan', 2, 'juan1234');
INSERT INTO Jugadores VALUES ('Marta', 3, 'marta1234');
INSERT INTO Jugadores VALUES ('Maria', 4, 'maria1234');


INSERT INTO Partidas VALUES ('Lunes', 10, 'Pedro', 1);
INSERT INTO Partidas VALUES ('Martes', 25, 'Maria', 2);
INSERT INTO Partidas VALUES ('Sabado', 32, 'Marta', 3);
INSERT INTO Partidas VALUES ('Domingo', 12, 'Juan', 4);

INSERT INTO Participacion VALUES (1,1,1);
INSERT INTO Participacion VALUES (2,3,3);
INSERT INTO Participacion VALUES (3,2,2);
INSERT INTO Participacion VALUES  (4,2,1);










