CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX)
	CHECK (DATALENGTH([Picture]) <= 1000000),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR
	CHECK ([Gender] = 'f' OR [Gender] = 'm') NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
	)


	INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate]) VALUES
	('Gosho', 1.87, 55.3, 'm', '1997-05-04'),
	('Tosho', NULL, NULL, 'm', '1999-12-05'),
	('Pesho', 1.85, 67.5, 'm', '2004-08-23'),
	('Gina', 1.65, 43.5, 'f', '1995-02-03'),
	('Gunsa', 1.72, 54.4, 'f', '1995-11-22')