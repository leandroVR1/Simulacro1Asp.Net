-- Active: 1716925402048@@b05zkxfjxj2g7efqovk6-mysql.services.clever-cloud.com@3306@b05zkxfjxj2g7efqovk6
CREATE TABLE Authors (
    Id INT  PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Name VARCHAR(125),
    LastName VARCHAR(45),
    Email VARCHAR(125),
    Nationality VARCHAR(125)    
)

CREATE TABLE Books(
    Id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Title VARCHAR(125),
    Pages INT,
    Language VARCHAR(125),
    PublicationDate DATE,
    Description TEXT
)

CREATE TABLE Editorials(
    Id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Name VARCHAR(125),
    Address VARCHAR(125),
    Phone VARCHAR(125),
    Email VARCHAR(125)
)

INSERT INTO Authors (`Name`,`LastName`,`Email`,`Nationality`)
VALUES ('Juan','Perez','jperez@','Mexican')

INSERT INTO Editorials (`Name`,`Address`,`Phone`,`Email`)



/*Añadir columna IsDeleted a la tabla Authors*/
ALTER TABLE Authors ADD IsDeleted BOOLEAN DEFAULT FALSE

/*Añadir columna IsDeleted a la tabla Books*/
ALTER TABLE Books ADD IsDeleted BOOLEAN DEFAULT FALSE

/*Añadir columna IsDeleted a la tabla Editorials*/
ALTER TABLE Editorials ADD IsDeleted BOOLEAN DEFAULT FALSE

ALTER TABLE `Books`
ADD  IdAuthor INT;

ALTER TABLE `Books`
ADD FOREIGN KEY (IdAuthor) REFERENCES Authors(Id);