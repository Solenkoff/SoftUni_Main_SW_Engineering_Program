
-- Databases MSSQL Server Regular Exam - 16 Oct 2021

-- ================================================= --


--   P01_DDL


  --CREATE DATABASE CigarShop


CREATE TABLE Sizes(
	 Id INT PRIMARY KEY IDENTITY NOT NULL
	,[Length] INT NOT NULL
	  CHECK ([Length] >= 10 AND [Length] <= 25)
	,RingRange DECIMAL(18,2) NOT NULL
	  CHECK (RingRange >= 1.5 AND RingRange <= 7.5)
);

CREATE TABLE Tastes(
	 Id INT PRIMARY KEY IDENTITY NOT NULL
	,TasteType VARCHAR(20) NOT NULL
	,TasteStrength VARCHAR(15) NOT NULL
	,ImageURL NVARCHAR(100) NOT NULL
);

CREATE TABLE Brands(
	 Id INT PRIMARY KEY IDENTITY NOT NULL
	,BrandName VARCHAR(30) UNIQUE NOT NULL
	,BrandDescription VARCHAR(MAX) 
);

CREATE TABLE Cigars(
	 Id INT PRIMARY KEY IDENTITY NOT NULL
	,CigarName VARCHAR(80) NOT NULL
	,BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL
	,TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL
	,SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL
	,PriceForSingleCigar DECIMAL(19,4) NOT NULL
	,ImageURL NVARCHAR(100) NOT NULL
);

CREATE TABLE Addresses(
	 Id INT PRIMARY KEY IDENTITY NOT NULL
	,Town VARCHAR(30) NOT NULL
	,Country NVARCHAR(30) NOT NULL
	,Streat NVARCHAR(100) NOT NULL
	,ZIP VARCHAR(20) NOT NULL
);

CREATE TABLE Clients(
	 Id INT PRIMARY KEY IDENTITY NOT NULL
	,FirstName NVARCHAR(30) NOT NULL
	,LastName NVARCHAR(30) NOT NULL
	,Email NVARCHAR(50) NOT NULL
	,AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
);

CREATE TABLE ClientsCigars(
	 ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
	,CigarId INT FOREIGN KEY REFERENCES Cigars(Id) NOT NULL
	,CONSTRAINT PK_ClientsCigars PRIMARY KEY (ClientId, CigarId)
);


---------------------------------------------


--   P02_Insert

INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL) VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50,'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00,'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50,'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00,'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21,'trinidad-coloniales-stick_30.jpg')



INSERT INTO Addresses (Town, Country, Streat, ZIP) VALUES
('Sofia','Bulgaria','18 Bul. Vasil levski','1000'),
('Athens','Greece','4342 McDonald Avenue','10435'),
('Zagreb','Croatia','4333 Lauren Drive','10000')


----------------------------------------------

--   P03_Update

 UPDATE Cigars 
    SET PriceForSingleCigar *= 1.2
  WHERE TastId = 1;
   

 UPDATE Brands
    SET BrandDescription = 'New description'
  WHERE BrandDescription IS NULL


  ----------------------------------------------


--   P04_Delete


DELETE
   FROM Clients
  WHERE AddressId IN(7,8,10);

 DELETE
   FROM Addresses
  WHERE Country LIKE 'C%';


  ----------------------------------------------


--   P05_Cigars_by_Price

SELECT CigarName,
	   FORMAT(PriceForSingleCigar, 'F2'),
	   ImageURL
  FROM Cigars
 ORDER BY PriceForSingleCigar , CigarName DESC


----------------------------------------------


--   P06_Cigars_by_Taste

SELECT  c.Id
	  , c.CigarName
	  , FORMAT(c.PriceForSingleCigar, 'F2')
	  , t.TasteType
	  , t.TasteStrength
   FROM Cigars AS c
   JOIN Tastes AS t ON c.TastId = t.Id
  WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
  ORDER BY c.PriceForSingleCigar DESC
   

  ----------------------------------------------


--   P07_Clients_without_Cigars

 SELECT  Id
	   , CONCAT(FirstName, ' ', LastName) AS ClientName
	   , Email
    FROM Clients AS c
    LEFT JOIN ClientsCigars AS cs ON c.Id = cs.ClientId
   WHERE cs.CigarId IS NULL
ORDER BY ClientName 


----------------------------------------------


--   P08_First_5_Cigars

SELECT  TOP(5)
        c.CigarName
	  , FORMAT(c.PriceForSingleCigar, 'F2') AS PriceForSingleCigar
	  , c.ImageURL
   FROM Cigars AS c
   JOIN Sizes AS s ON c.SizeId = s.Id
  WHERE s.Length >= 12 AND (c.CigarName LIKE '%ci%' 
        OR (c.PriceForSingleCigar > 50 AND s.RingRange > 2.55))
  ORDER BY c.CigarName, PriceForSingleCigar DESC


  ----------------------------------------------


--   P09_Clients_with_ZIP_Codes

SELECT  CONCAT(c.FirstName, ' ', c.LastName) AS FullName
      , a.Country
	  , a.ZIP
	  , CONCAT('$', FORMAT(MAX(cg.PriceForSingleCigar), 'F2') ) AS CigarPrice
   FROM Clients AS c
   JOIN Addresses AS a ON c.AddressId = a.Id
   JOIN ClientsCigars AS cs ON c.Id = cs.ClientId
   JOIN Cigars AS cg ON cs.CigarId = cg.Id
  WHERE a.ZIP NOT LIKE '%[^0-9]%'
  GROUP BY c.Id, c.FirstName, c.LastName,a.Country, a.ZIP
  ORDER BY FullName


----------------------------------------------


--   P10_Cigars_by_Size

SELECT   c.LastName
	   , avg(s.Length) AS CiagrLength
	   , CEILING(AVG(s.RingRange)) AS CiagrRingRange
    FROM Clients AS c
    LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
    LEFT JOIN Cigars AS cg ON cc.CigarId = cg.Id
    JOIN Sizes AS s ON cg.SizeId = s.Id
   WHERE cc.CigarId IS NOT NULL
GROUP BY c.LastName
ORDER BY CiagrLength DESC


----------------------------------------------


--   P11_Client_with_Cigars


CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
     DECLARE @result INT;
	  SELECT @result = COUNT(cc.CigarId)
        FROM Clients AS c
        JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
       WHERE c.FirstName = @name 

	  RETURN @result
END


----------------------------------------------


--   P12_Search_for_Cigar_with_Specific_Taste


CREATE PROCEDURE usp_SearchByTaste
       @taste VARCHAR(20)
AS
   SELECT  c.CigarName
		   , CONCAT('$', FORMAT(c.PriceForSingleCigar, 'F2')) AS Price
		   , t.TasteType AS TasteType
		   , b.BrandName
		   , CONCAT(s.Length, ' ', 'cm') AS CigarLength
		   , CONCAT(s.RingRange, ' ', 'cm') AS CigarRingRange
        FROM Cigars AS c
        JOIN Brands AS b ON c.BrandId = b.Id
        JOIN Tastes AS t ON c.TastId = t.Id
        JOIN Sizes AS s ON c.SizeId = s.Id
       WHERE t.TasteType = @taste
    ORDER BY CigarLength, CigarRingRange DESC



