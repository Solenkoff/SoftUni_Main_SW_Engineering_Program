-- Databases MSSQL Server Retake Exam - 05 Dec 2023

-- ================================================= --


--   P01_DDL

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


---------------------------------------------

--   P02_Insert

INSERT INTO Trains(HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId) VALUES
	('07:00', '19:00', 1, 3), 
	('08:30', '20:30', 5, 6), 
	('09:00', '21:00', 4, 8), 
	('06:45', '03:55', 27, 7), 
	('10:15', '12:15', 15, 5) 


INSERT INTO TrainsRailwayStations (TrainId, RailwayStationId) VALUES
    (36,1),(36,4),(36,31),(36,57),(36,7	),
    (37,13),(37,54),(37,60),(37,16),
    (38,10),(38,50),(38,52),(38,22),
    (39,68),(39,3 ),(39,31),(39,19),
    (40,41),(40,7 ),(40,52),(40,13)


INSERT INTO Tickets (Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId) VALUES
	(90.00	, '2023-12-01', '2023-12-01', 36, 1),
    (115.00	, '2023-08-02', '2023-08-02', 37, 2),
    (160.00	, '2023-08-03', '2023-08-03', 38, 3),
	(255.00	, '2023-09-01', '2023-09-02', 39, 21),
    (95.00	, '2023-09-02', '2023-09-03', 40, 22)


----------------------------------------------

--   P03_Update

UPDATE Tickets
   SET DateOfDeparture = DATEADD(WEEK, 1, DateOfDeparture),
       DateOfArrival = DATEADD(WEEK, 1, DateOfArrival)
 WHERE DateOfDeparture > '2023-10-31';

 
----------------------------------------------

--   P04_Delete

DELETE
FROM Tickets
WHERE TrainId IN (             --   WHERE TrainId = 7
    SELECT Id 
    FROM Trains 
    WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin')
);

DELETE
FROM MaintenanceRecords
WHERE TrainId IN (             --   WHERE TrainId = 7
    SELECT Id 
    FROM Trains 
    WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin')
);

DELETE
FROM TrainsRailwayStations
WHERE TrainId IN (             --   WHERE TrainId = 7
    SELECT Id 
    FROM Trains 
    WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin')
);

DELETE
FROM Trains
WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin');   --   WHERE DepartureTownId = 7


----------------------------------------------

--   P05_Tickets_by_Price_and_Date_Departure

SELECT   t.DateOfDeparture
       , t.Price AS TicketPrice
    FROM Tickets AS t
ORDER BY t.Price, t.DateOfDeparture DESC


----------------------------------------------

--   P06_Passengers_with_their_Tickets

  SELECT 
         p.[Name] AS PassengerName
       , t.Price AS TicketPrice
	   , t.DateOfDeparture
	   , t.TrainId
    FROM Tickets AS t
    JOIN Passengers AS p ON t.PassengerId = p.Id
ORDER BY t.Price DESC, p.[Name]


----------------------------------------------

--   P07_Railway_Stations_without_Passing_Trains

   SELECT   
          t.[Name] AS Town
        , rs.[Name] AS RailwayStation
     FROM RailwayStations AS rs
     JOIN Towns AS t ON rs.TownId = t.Id
LEFT JOIN TrainsRailwayStations AS trs ON rs.Id = trs.RailwayStationId
    WHERE trs.TrainId IS NULL
 ORDER BY t.[Name], rs.[Name]

       
----------------------------------------------

--   P08_First_3_Trains_8h00-8h59

 SELECT 
     TOP(3) 
         tr.Id AS TrainId,
         tr.HourOfDeparture,
         ti.Price AS TicketPrice,
         dT.[Name] AS Destination
    FROM Trains tr
    JOIN Tickets ti ON tr.Id = ti.TrainId
    JOIN Towns dT ON tr.ArrivalTownId = dT.Id
   WHERE tr.HourOfDeparture LIKE '08:[0-5][0-9]'
     AND ti.Price > 50.00
ORDER BY ti.Price ASC


----------------------------------------------

--   P09_Count_of_Passengers_Paid_More_Than _Average

  SELECT   
         tw.Name AS TownName
       , COUNT(*) AS PassengersCount
    FROM Passengers AS p
    JOIN Tickets AS t ON p.Id = t.PassengerId
    JOIN Trains AS tr ON t.TrainId = tr.Id
    JOIN Towns AS tw ON tr.ArrivalTownId = tw.Id
   WHERE t.Price > 76.99
GROUP BY tw.Name
ORDER BY tw.Name


----------------------------------------------

--   P10_Maintenance_Inspection_with_Town_and_Station

  SELECT 
         t.Id AS TrainID
       , tw.[Name] AS DepartureTown
	   , mr.Details
    FROM Trains AS t
    JOIN Towns AS tw ON t.DepartureTownId = tw.Id
    JOIN MaintenanceRecords AS mr ON t.Id = mr.TrainId
   WHERE mr.Details LIKE '%inspection%'
ORDER BY t.Id


----------------------------------------------

--   P11_Towns_with_Trains

CREATE FUNCTION udf_TownsWithTrains(@townName VARCHAR(30)) 
RETURNS INT
AS
BEGIN
    DECLARE @result INT;

     SELECT @result = COUNT(DISTINCT tr.Id)
       FROM Trains AS tr 
       JOIN Towns AS tw ON tr.ArrivalTownId = tw.Id
         OR                tr.DepartureTownId = tw.Id
      WHERE tw.[Name] = @townName 
   
   	 RETURN @result
END


----------------------------------------------

--   P12_Search_Passengers_travelling_to_Specific_Town

CREATE PROCEDURE usp_SearchByTown (@townName VARCHAR(30))
AS
BEGIN
     SELECT 
            p.[Name] AS PassengerName
		  , t.DateOfDeparture
		  , tr.HourOfDeparture
       FROM Passengers AS p
       JOIN Tickets AS t ON p.Id = t.PassengerId
       JOIN Trains AS tr ON t.TrainId = tr.Id
       JOIN Towns AS tw ON tr.ArrivalTownId = tw.Id
      WHERE tw.[Name] = @townName
   ORDER BY t.DateOfDeparture DESC, PassengerName
END;
          

--  ==============================================  --