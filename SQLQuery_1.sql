USE Azil;
SET IDENTITY_INSERT Azil ON;
INSERT INTO Azil(ID, naziv, kontaktTelefon, email, brZaposlenih, brZivotinja)
    VALUES(1,'Zoospas', 022239449, 'zoospas123@gmail.com', 11, 20)
INSERT INTO Azil(ID, naziv, kontaktTelefon, email, brZaposlenih, brZivotinja)
    VALUES(2,'Pomoc sapicama', 027352690, 'pomocsapicama@gmail.com', 18, 30)
SET IDENTITY_INSERT Azil OFF;

SET IDENTITY_INSERT Cip ON;
INSERT INTO Cip(ID, polZ, brGodina, vrstaZ)
    VALUES(1, 'z', 3, 'pas')
INSERT INTO Cip(ID, polZ, brGodina, vrstaZ)
    VALUES(2,'m', 6, 'pas')
INSERT INTO Cip(ID, polZ, brGodina, vrstaZ)
    VALUES(3, 'z', 2, 'macka')
INSERT INTO Cip(ID, polZ, brGodina, vrstaZ)
    VALUES(4, 'm', 4, 'macka')
SET IDENTITY_INSERT Cip OFF;

SET IDENTITY_INSERT KartonVakcinacije ON;
INSERT INTO KartonVakcinacije(ID, nazivVakcine, datumVakcinacije)
    VALUES(1, 'parvo virus', convert(datetime,'18-03-22 10:00:00 AM',5))
INSERT INTO KartonVakcinacije(ID, nazivVakcine, datumVakcinacije)
    VALUES(2, 'panleukopenija', convert(datetime,'06-03-21 12:00:00 AM',5))
INSERT INTO KartonVakcinacije(ID, nazivVakcine, datumVakcinacije)
    VALUES(3, 'leptospiroza', convert(datetime,'05-02-20 11:00:00 AM',5))
SET IDENTITY_INSERT KartonVakcinacije OFF;

SET IDENTITY_INSERT Udomitelj ON;
INSERT INTO Udomitelj(ID, imeU, prezimeU, adresaU, brTelefonaU, brLicneKarte, JMBG)
    VALUES(1, 'Mila', 'Milic', 'Lole Ribara 4', 018265235, 111111111, 1111111111111)
INSERT INTO Udomitelj(ID, imeU, prezimeU, adresaU, brTelefonaU, brLicneKarte, JMBG)
    VALUES(2, 'Marko', 'Markovic', 'Branka Radicevica 15', 018265562, 222222222, 2222222222222)
INSERT INTO Udomitelj(ID, imeU, prezimeU, adresaU, brTelefonaU, brLicneKarte, JMBG)
    VALUES(3, 'Luka', 'Lukic', 'Branka Miljkovica 1', 018245235, 333333333, 3333333333333)
INSERT INTO Udomitelj(ID, imeU, prezimeU, adresaU, brTelefonaU, brLicneKarte, JMBG)
    VALUES(4, 'Ivana', 'Ivanovic', 'Ljubomira Nikolica 24', 018295235, 444444444, 4444444444444)
SET IDENTITY_INSERT Udomitelj OFF;

SET IDENTITY_INSERT Zaposleni ON;
INSERT INTO Zaposleni(ID, ime, prezime, adresa, jmbg, AzilID)
    VALUES(1, 'Maja', 'Majic', 'Njegoseva 2', 5555555555555, 1)
INSERT INTO Zaposleni(ID, ime, prezime, adresa, jmbg, AzilID)
    VALUES(2, 'Marinka', 'Marinkovic', 'Cvijiceva 3', 6666666666666, 1)
INSERT INTO Zaposleni(ID, ime, prezime, adresa, jmbg, AzilID)
    VALUES(3, 'Jovana', 'Jovanovic', 'Cemernicka 1', 7777777777777, 2)
INSERT INTO Zaposleni(ID, ime, prezime, adresa, jmbg, AzilID)
    VALUES(4, 'Dusan', 'Dusanovic', 'Lole Stojanovic 8', 8888888888888, 2)
SET IDENTITY_INSERT Zaposleni OFF;

SET IDENTITY_INSERT Zivotinja ON;
INSERT INTO Zivotinja(ID, imeZ, brKartonaVakc, brCipa, ZaposleniID, CipID, KartonVakcinacijeID, AzilID, UdomiteljID)
    VALUES(1, 'Mara', 1111, 111, 1, 1, 1, 1, 1)
INSERT INTO Zivotinja(ID, imeZ, brKartonaVakc, brCipa, ZaposleniID, CipID, KartonVakcinacijeID, AzilID, UdomiteljID)
    VALUES(2, 'Mia', 2222, 222, 2, 3, 2, 1, NULL)
INSERT INTO Zivotinja(ID, imeZ, brKartonaVakc, brCipa, ZaposleniID, CipID, KartonVakcinacijeID, AzilID, UdomiteljID)
    VALUES(3, 'Bak', 3333, 333, 3, 2, 1, 1, 4)
INSERT INTO Zivotinja(ID, imeZ, brKartonaVakc, brCipa, ZaposleniID, CipID, KartonVakcinacijeID, AzilID, UdomiteljID)
    VALUES(4, 'Barni', 44444, 444, 4, 4, 1, 2, NULL)
INSERT INTO Zivotinja(ID, imeZ, brKartonaVakc, brCipa, ZaposleniID, CipID, KartonVakcinacijeID, AzilID, UdomiteljID)
    VALUES(5, 'Bela', 5555, 555, 2, 1, 3, 2, 3)
SET IDENTITY_INSERT Zivotinja OFF;