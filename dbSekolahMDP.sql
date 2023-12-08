--Buatlah database dengan nama dbMDPSchool

--Buatlah tabel dengan nama User,
--dengan field sbb :
--username varchar(10) primary key
--pasword varchar(10)
--level varchar(15)

CREATE DATABASE dbMDPSchool
GO
USE dbMDPSchool
GO
CREATE TABLE Users (
	username VARCHAR(10) PRIMARY KEY,
	password VARCHAR(10),
	level VARCHAR(15)
)
GO
SELECT * FROM Users

INSERT INTO Users values ('admin', 'admin','admin')
INSERT INTO Users values ('siswa', 'siswa','siswa')

--Buatlah tabel dengan nama Siswa,
--dengan field sbb :
CREATE TABLE Siswa (
	nis	CHAR(20) PRIMARY KEY,
	nama VARCHAR(50),
	jeniskelamin CHAR(1),
	tempat VARCHAR(20),
	tanggallahir DATE,
	alamat VARCHAR(100),
	asalsekolah VARCHAR(50),
	agama VARCHAR(20),
	nohp VARCHAR(15),
	alamatfoto VARCHAR(1000)
)

INSERT INTO Siswa VALUES ('', '', '', '', '', '', '', '', '', '')