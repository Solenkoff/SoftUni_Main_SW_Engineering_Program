CREATE DATABASE [SoftUni]

GO


CREATE TABLE [Towns](
[Id] INT PRIMARY KEY IDENTITY
,[Name] NVARCHAR(100) NOT NULL
);

CREATE  TABLE [Addresses](
[Id] INT PRIMARY KEY IDENTITY
,[AddressText] NVARCHAR(500) NOT NULL
,[TownId] INT FOREIGN KEY REFERENCES [Towns](Id)
);


CREATE TABLE [Departments](
[Id] INT PRIMARY KEY IDENTITY
,[Name] NVARCHAR(50) NOT NULL
);


CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY
,[FirstName] NVARCHAR(50) NOT NULL
,[MiddleName] NVARCHAR(50) NOT NULL
,[LastName] NVARCHAR(50) NOT NULL
,[JobTitle] NVARCHAR(50) NOT NULL
,[DepartmentId] INT FOREIGN KEY REFERENCES [Departments](Id)
,[HireDate] DATE NOT NULL
,[Salary] DECIMAL(9,2) NOT NULL
,[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id)
);