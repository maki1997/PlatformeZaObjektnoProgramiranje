
insert into TipNamestaja(Naziv,Obrisan) values ('Krevet',0);
insert into TipNamestaja(Naziv,Obrisan) values ('Fotelja',0);
insert into TipNamestaja(Naziv,Obrisan) values ('Sto',0);

Insert into Korisnik(ime,Prezime,KorisnickoIme,Lozinka,TipKorisnika,Obrisan) values('a','a','a','a',0,0);
Insert into Korisnik(ime,Prezime,KorisnickoIme,Lozinka,TipKorisnika,Obrisan) values('aa','aa','aa','aa',0,0);
Insert into Korisnik(ime,Prezime,KorisnickoIme,Lozinka,TipKorisnika,Obrisan) values('s','s','s','s',1,0);

insert into Akcija(Popust,Dp,Dk,Obrisan) values(10,'1-2-2017','2-3-2018',0);

insert into Namestaj (TipnamestajaId,Naziv,Cena,Kolicina,Obrisan,AkcijaId) values (1,'Francuski krevet',120.5,22,0,1);
insert into Namestaj (TipnamestajaId,Naziv,Cena,Kolicina,Obrisan) values (2,'Lazy bag',140.5,25,0);
insert into Namestaj (TipnamestajaId,Naziv,Cena,Kolicina,Obrisan) values (3,'Kuhinjski sto',20.5,12,0);


insert into DodatnaUsluga(Naziv,Cena,Obrisan) values ('Transport',1000,0)
insert into DodatnaUsluga(Naziv,Cena,Obrisan) values ('Postavljanje',2500,0)

insert into Racun(Dp,Kupac,UkupnaCena) values ('1-2-2018','Nikola',50000)
insert into Racun(Dp,Kupac,UkupnaCena) values ('2-2-2018','Jabucilo',20000)

insert into StavkaNamestaja(RacunId,NamestajId,Kolicina) values(1,1,5)
insert into StavkaNamestaja(RacunId,NamestajId,Kolicina) values(1,2,3)
insert into StavkaNamestaja(RacunId,NamestajId,Kolicina) values(2,3,1)

insert into StavkaDUsluge(RacunId,DUId) values(1,1)
insert into StavkaDUsluge(RacunId,DUId) values(1,2)
insert into StavkaDUsluge(RacunId,DUId) values(2,1)