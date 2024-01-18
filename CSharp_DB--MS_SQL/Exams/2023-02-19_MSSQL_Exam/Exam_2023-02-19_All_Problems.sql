
--------------------------------

--   P01_CreateDLL_Boardgames


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

----------------------------

--   P02_Insert

INSERT INTO Boardgames([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId) VALUES
('Deep Blue', 2019, 5.67,1, 15,	7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2);


INSERT INTO Publishers([Name], AddressId, Website, Phone) VALUES
('Agman Games',5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907');

---------------------------------

--   P03_Update

UPDATE PlayersRanges 
SET PlayersMAX = PlayersMAX + 1
WHERE PlayersMin = 2 AND PlayersMAX = 2;

UPDATE Boardgames
SET [Name] = CONCAT([Name], 'V2')
WHERE YearPublished >= 2020

---------------------------------

--   P04_Delete

DELETE 
FROM CreatorsBoardgames 
WHERE BoardgameId IN(1, 6, 16, 21,31, 36, 47)

DELETE 
FROM Boardgames 
WHERE PublisherId IN(1, 16)

DELETE
FROM Publishers 
WHERE AddressId = 5

DELETE
FROM Addresses
WHERE LEFT(Town, 1) = 'L';

DELETE
FROM Publishers 
WHERE AddressId = 5

------------------------------

--   P05_Boardgames_by_Year_of_Publication

SELECT  [Name]
      , Rating
   FROM Boardgames
  ORDER BY YearPublished ASC, [Name] DESC

-------------------------------

--   P06_Boardgames_by_Category

SELECT   b.Id
       , b.[Name]
	   , b.YearPublished
	   , c.[Name] AS CategoryName
    FROM Boardgames AS b
	JOIN Categories AS c ON b.CategoryId = c.Id 
   WHERE CategoryId IN (6, 8)
ORDER BY YearPublished DESC

-------------------------------

--   P07_Creators_without_Boardgames

SELECT   c.Id
       , CONCAT_WS(' ',c.FirstName, c.LastName) AS CreatorName 
	   , c.Email
    FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
   WHERE cb.BoardgameId IS NULL
ORDER BY CreatorName ASC

-------------------------------

--   P08_First_5_Boardgames

SELECT TOP(5)
         b.[Name]
       , b.Rating
	   , c.[Name] AS CategoryName
    FROM Boardgames AS b
    JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
    JOIN Categories AS c ON b.CategoryId = c.Id
  WHERE (b.Rating > 7.00 AND b.[Name] LIKE '%a%') OR 
        (b.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMAX = 5)
ORDER BY b.[Name] ASC, b.Rating DESC

-------------------------------

--   P09_Creators_with_Emails

SELECT   CONCAT_WS(' ', c.FirstName, c.LastName) AS FullName
       , c.Email
	   , MAX(b.Rating) AS Rating
    FROM Creators AS c
    JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
    JOIN Boardgames AS b ON cb.BoardgameId = b.Id
GROUP BY c.Id, CONCAT_WS(' ', c.FirstName, c.LastName), c.Email
  HAVING RIGHT(c.Email, 4) = '.com'
ORDER BY FullName

-------------------------------

--   P10_Creators_by_Rating

SELECT   c.LastName
       , CEILING(AVG(b.Rating)) AS AverageRating
	   , p.[Name] AS PublisherName
    FROM Creators AS c
    JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
    JOIN Boardgames AS b ON cb.BoardgameId = b.Id
    JOIN Publishers AS p ON b.PublisherId = p.Id
   WHERE cb.BoardgameId IS NOT NULL
GROUP BY c.Id, c.LastName, p.[Name]
  HAVING p.[Name] = 'Stonemaier Games'
ORDER BY AVG(b.Rating) DESC

-------------------------------

--   P11_Creator_with_Boardgames

CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
    DECLARE @result INT;
	 SELECT @result = COUNT(cb.BoardgameId)
	   FROM Creators AS c
	   JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
	WHERE c.FirstName = @name
	
	RETURN @result
END
--------------------------

--   P12_Search_for_Boardgame_with_Specific_Category

CREATE PROCEDURE usp_SearchByCategory 
       @category VARCHAR(50)
AS
   SELECT  b.[Name]
         , b.YearPublished
		 , b.Rating
		 , c.[Name]
		 , p.[Name]
		 , CONCAT_WS(' ', pr.PlayersMin, 'people')
		 , CONCAT_WS(' ', pr.PlayersMAX, 'people')
      FROM Boardgames AS b
      JOIN Categories AS c ON b.CategoryId = c.Id
      JOIN Publishers AS p ON b.PublisherId = p.Id
      JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
     WHERE c.[Name] = @category
  ORDER BY p.[Name] ASC, b.YearPublished DESC

