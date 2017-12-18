CREATE TABLE TipNamestaja (
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
GO

CREATE TABLE DodatnaUsluga (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Naziv VARCHAR(100),
	Cena NUMERIC(9,2),
	Obrisan BIT
)
GO

CREATE TABLE AkcijskaProdaja (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	DatumPocetka datetime,
	DatumKraja datetime,
	Obrisan BIT
)
GO

CREATE TABLE Korisnik (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Ime varchar(50),
	Prezime varchar(50),
	KorisnickoIme varchar(50),
	Lozinka varchar(50),
	Obrisan BIT
)


/*validacija*/