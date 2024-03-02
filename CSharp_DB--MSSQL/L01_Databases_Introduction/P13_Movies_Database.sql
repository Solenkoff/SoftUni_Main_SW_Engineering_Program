CREATE DATABASE [Movies]

GO

CREATE TABLE [Directors](
 [Id] INT PRIMARY KEY IDENTITY
 ,[DirectorName] NVARCHAR(50) NOT NULL
 ,[Notes] NVARCHAR(2000)
 );



 INSERT INTO [Directors]([DirectorName]) VALUES
 ('Gosho')
 ,('Tosho')
 ,('Bosho')
 ,('Mosho')
 ,('Rosho');

 

 CREATE TABLE [Genres](
 [Id] INT PRIMARY KEY IDENTITY
 ,[GenreName] NVARCHAR(50) NOT NULL
 ,[Notes] NVARCHAR(2000)
 );

 

 INSERT INTO [Genres]([GenreName]) VALUES
 ('Drama')
 ,('Criminal')
 ,('Action')
 ,('Horror')
 ,('Anime');

 

 CREATE TABLE [Categories](
 [Id] INT PRIMARY KEY IDENTITY
 ,[CategoryName] NVARCHAR(50) NOT NULL
 ,[Notes] NVARCHAR(2000)
 );

 

  INSERT INTO [Categories]([CategoryName]) VALUES
 ('Kids')
 ,('Teens')
 ,('GeneralPublic')
 ,('Adults')
 ,('Internal');

 

 CREATE TABLE [Movies](
 [Id] INT PRIMARY KEY IDENTITY
 ,[Title] NVARCHAR(100) NOT NULL
 ,[DirectorId] INT FOREIGN KEY REFERENCES [Directors](Id) NOT NULL
 ,[CopyrightYear] DATE NOT NULL
 ,[Length] TIME
 ,[GenreId] INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL
 ,[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
 ,[Rating] TINYINT
 ,[Notes] NVARCHAR(MAX)
 );

 

 INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [GenreId], [CategoryId]) VALUES
 ('FirstMovie', 1, '2003-05-23', 5, 3)
 ,('SecondMovie', 2, '2023-03-13', 4, 2)
 ,('ThirdMovie', 3, '2014-08-02', 3, 1)
 ,('FourthMovie', 4, '2010-11-25', 2, 4)
 ,('FifthMovie', 5, '2008-07-03', 1, 5);



 