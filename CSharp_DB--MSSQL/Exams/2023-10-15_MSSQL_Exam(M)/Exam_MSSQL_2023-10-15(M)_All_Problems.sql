
-- Databases MSSQL Server Regular Exam - 15 Oct 2023

-- ================================================= --


--   P01_DDL

  -- CREATE DATABASE TouristAgency

CREATE TABLE Countries(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , [Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE Destinations(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , [Name] VARCHAR(50) NOT NULL
   , CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
);

CREATE TABLE Rooms(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , [Type] VARCHAR(40) NOT NULL
   , Price DECIMAL(18,2) NOT NULL
   , BedCount INT NOT NULL
   CHECK (BedCount > 0 AND Bedcount <= 10)
);

CREATE TABLE Hotels(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , [Name] VARCHAR(50) NOT NULL
   , DestinationId INT FOREIGN KEY REFERENCES Destinations(Id) NOT NULL
);

CREATE TABLE Tourists(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , [Name] NVARCHAR(80) NOT NULL
   , PhoneNumber VARCHAR(20) NOT NULL
   , Email VARCHAR(80)
   , CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
);

CREATE TABLE Bookings(
     Id INT PRIMARY KEY IDENTITY NOT NULL
   , ArrivalDate DATETIME2 NOT NULL
   , DepartureDate DATETIME2 NOT NULL
   , AdultsCount INT NOT NULL
   CHECK (AdultsCount >= 1 AND AdultsCount <= 10)
   , ChildrenCount INT NOT NULL
   CHECK (ChildrenCount >= 0 AND ChildrenCount <= 9)
   , TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL
   , HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
   , RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL
);

CREATE TABLE HotelsRooms(
     HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
   , RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL
   , CONSTRAINT PK_HotelsRooms PRIMARY KEY (HotelId, RoomId)
);

---------------------------------------------

--   P02_Insert

INSERT INTO Tourists ([Name], PhoneNumber, Email, CountryId) VALUES
    ('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
    ('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
    ('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
    ('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
    ('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)


INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId) VALUES
    ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),  
    ('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),  
    ('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
    ('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),  	
    ('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)


----------------------------------------------

--   P03_Update

UPDATE Bookings 
   SET DepartureDate = DATEADD(day, 1, DepartureDate)
 WHERE YEAR(ArrivalDate) = 2023 AND MONTH(ArrivalDate) = 12;

UPDATE Tourists
   SET Email = NULL
 WHERE [Name] LIKE '%MA%';


----------------------------------------------

--   P04_Delete


DELETE
  FROM Bookings
 WHERE TouristId IN (6, 16, 25);

DELETE
  FROM Tourists
 WHERE [Name] LIKE '%Smith';


----------------------------------------------

--   P05_Bookings_by_Price_of_Room_and_Arrival_Date

SELECT   FORMAT(b.ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate
       , b.AdultsCount
	   , b.ChildrenCount
    FROM Bookings AS b
    JOIN Rooms AS r ON b.RoomId = r.Id
ORDER BY r.Price DESC, b.ArrivalDate

----------------------------------------------

--   P06_Hotels_by_Count_of_Bookings

SELECT   h.Id
       , h.[Name]
    FROM Hotels AS h
    JOIN HotelsRooms AS hr ON h.Id = hr.HotelId
    JOIN Rooms AS r ON hr.RoomId = r.Id
    JOIN Bookings AS b ON b.HotelId = h.Id
   WHERE r.Type = 'VIP Apartment' 
GROUP BY h.Id, h.[Name]
ORDER BY COUNT(b.HotelId)DESC

----------------------------------------------

--   P07_Tourists_without_Bookings

SELECT    t.Id
        , t.[Name]
	    , t.PhoneNumber
     FROM Tourists AS t
LEFT JOIN Bookings AS b ON t.Id = b.TouristId
    WHERE b.Id IS NULL
 ORDER BY t.[Name] ASC

----------------------------------------------

--   P08_First_10_Bookings

SELECT TOP(10) 
           h.[Name] AS HotelName
		 , d.[Name] AS DestinationName
		 , c.[Name] AS CountryName
    FROM Bookings AS b
    JOIN Hotels AS h ON b.HotelId = h.Id
    JOIN Destinations AS d ON h.DestinationId = d.Id
    JOIN Countries AS c ON d.CountryId = c.Id
   WHERE ArrivalDate < '2023-12-31' AND (h.Id % 2 = 1)
ORDER BY c.[Name], b.ArrivalDate

----------------------------------------------

--   P09_Tourists_Booked_in_Hotels

SELECT 
         h.[Name] AS HotelName
	   , r.Price AS RoomPrice
    FROM Tourists AS t
    JOIN Bookings AS b ON t.Id = b.TouristId
    JOIN Hotels AS h ON b.HotelId = h.Id
    JOIN Rooms AS r ON b.RoomId = r.Id
   WHERE t.[Name] NOT LIKE '%EZ'
ORDER BY r.Price DESC

----------------------------------------------

--   P10_Hotels_Revenue

SELECT    
         h.[Name] AS HotelName
       , SUM(DATEDIFF(DAY, b.ArrivalDate, b.DepartureDate) * r.Price) 
	  AS HotelRevenue
    FROM Bookings AS b
    JOIN Hotels AS h ON b.HotelId = h.Id
    JOIN Rooms AS r ON b.RoomId = r.Id
GROUP BY h.[Name]
ORDER BY HotelRevenue DESC

----------------------------------------------

--   P11_Rooms_with_Tourists

CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(40)) 
RETURNS INT
AS
BEGIN
    DECLARE @result INT;
	 SELECT @result = SUM(b.AdultsCount + b.ChildrenCount )
       FROM Bookings AS b
       JOIN Rooms AS r ON b.RoomId = r.Id
       WHERE r.[Type] = @name
	
	RETURN @result
END

----------------------------------------------

--   P12_Search_for_Tourists_from_a_Specific_Country


  CREATE PROCEDURE usp_SearchByCountry
       @country NVARCHAR(50)
AS
   SELECT
           t.[Name]
         , t.PhoneNumber
		 , t.Email 
		 , COUNT(b.Id) AS CountOfBookings 
      FROM Tourists AS t
      JOIN Countries AS c ON t.CountryId = c.Id
      JOIN Bookings AS b ON t.Id = b.TouristId
     WHERE c.[Name] = @country
  GROUP BY t.[Name], t.PhoneNumber, t.Email 
  ORDER BY t.[Name] ASC


-- ================================================ --



