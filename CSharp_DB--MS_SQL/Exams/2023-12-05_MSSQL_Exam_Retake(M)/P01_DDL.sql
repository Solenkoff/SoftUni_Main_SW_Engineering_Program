
-- CREATE DATABASE RailwaysDb


CREATE TABLE Passengers(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , [Name] NVARCHAR(80) NOT NULL
);
 

CREATE TABLE Towns(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , [Name] VARCHAR(30) NOT NULL
);


CREATE TABLE RailwayStations(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , [Name] VARCHAR(50) NOT NULL
   , TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
);

CREATE TABLE Trains(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , HourOfDeparture VARCHAR(5) NOT NULL
   , HourOfArrival VARCHAR(5) NOT NULL
   , DepartureTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
   , ArrivalTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
);

CREATE TABLE TrainsRailwayStations(
     TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
   , RailwayStationId INT FOREIGN KEY REFERENCES RailwayStations(Id) NOT NULL
   , CONSTRAINT PK_TrainsRailwayStations PRIMARY KEY (TrainId, RailwayStationId)
);

CREATE TABLE MaintenanceRecords(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , DateOfMaintenance DATETIME2 NOT NULL
   , Details VARCHAR(2000) NOT NULL
   , TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
);

CREATE TABLE Tickets(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , Price DECIMAL(18,2) NOT NULL	 
   , DateOfDeparture DATETIME2 NOT NULL
   , DateOfArrival DATETIME2 NOT NULL
   , TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
   , PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
);