--CREATE DATABASE Boardgames


CREATE TABLE Categories(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   ,[Name] VARCHAR(50) NOT NULL
);


CREATE Table Addresses(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , StreetName NVARCHAR(100) NOT NULL
   , StreetNumber INT NOT NULL
   , Town VARCHAR(30) NOT NULL
   , Country VARCHAR(50) NOT NULL
   , ZIP INT  NOT NULL
);
 

CREATE TABLE Publishers(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   ,[Name] VARCHAR(30) UNIQUE NOT NULL
   , AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
   , Website NVARCHAR(40) NOT NULL
   , Phone NVARCHAR(20) NOT NULL
);


CREATE TABLE PlayersRanges(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , PlayersMin INT  NOT NULL
   , PlayersMAX INT  NOT NULL
);


CREATE TABLE Boardgames(
   Id INT PRIMARY KEY IDENTITY NOT NULL
   ,[Name] NVARCHAR(30) NOT NULL
   , YearPublished INT NOT NULL
   , Rating DECIMAL(9,2) NOT NULL
   , CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
   , PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL
   , PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL
);


CREATE TABLE Creators(
   Id INT PRIMARY KEY IDENTITY NOT NULL
  , FirstName NVARCHAR(30) NOT NULL
  , LastName NVARCHAR(30) NOT NULL
  , Email NVARCHAR(30) NOT NULL
);


CREATE TABLE CreatorsBoardgames(
   CreatorId INT FOREIGN KEY REFERENCES Creators(Id) NOT NULL
   ,BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id) NOT NULL
   , CONSTRAINT PK_CreatorsBoardgames PRIMARY KEY (CreatorId, BoardgameId)
);