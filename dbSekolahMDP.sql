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