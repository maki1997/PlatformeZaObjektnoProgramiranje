﻿CREATE TABLE TipNamestaja (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Naziv VARCHAR(80),
	Obrisan BIT
)
GO

CREATE TABLE Namestaj (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	TipNamestajaId INT,
	Naziv VARCHAR(100),
	Cena NUMERIC(9,2),
	Obrisan BIT,
	Kolicina INT,
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id)
)