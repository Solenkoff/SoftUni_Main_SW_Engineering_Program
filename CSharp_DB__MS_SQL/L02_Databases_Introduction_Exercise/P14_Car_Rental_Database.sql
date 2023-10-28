CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY
,[CategoryName] NVARCHAR(50) NOT NULL
,[DailyRate] DECIMAL(9,2) NOT NULL
,[WeeklyRate] DECIMAL(9,2) NOT NULL
,[MonthlyRate] DECIMAL(9,2) NOT NULL
,[WeekendRate] DECIMAL(9,2) NOT NULL
);


INSERT INTO [Categories] VALUES
('Car', 5.50, 28.55, 118, 9.45)
,('Bus', 9, 36.50, 145, 15.6)
,('Bike', 4, 22.5, 99, 7.45);


CREATE TABLE [Cars](
[Id] INT PRIMARY KEY IDENTITY
,[PlateNumber] NVARCHAR(10) NOT NULL
,[Manufacturer] NVARCHAR(50) NOT NULL
,[Model] NVARCHAR(50) NOT NULL
,[CarYear] DATE
,[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
,[Doors] TINYINT
,[Picture] VARBINARY(MAX)
,[Condition] NVARCHAR(500)
,[Available] BIT NOT NULL
);


INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CategoryId], [Available]) VALUES
('SO3556KG', 'Ford', 'Scorpio', 1, 1)
,('KF3974UG', 'Opel', 'Cadet', 1, 0)
,('SK9856LD', 'Lada', 'Niva', 2, 1);


CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY
,[FirstName] NVARCHAR(50) NOT NULL
,[LastName] NVARCHAR(50) NOT NULL
,[Title] NVARCHAR(50) NOT NULL
,[Notes] NVARCHAR(MAX) 
);


INSERT INTO [Employees]([FirstName], [LastName], [Title]) VALUES
('Gosho', 'Goshev', 'Shef')
,('Tosho', 'Toshev', 'Boss')
,('Gana', 'Ganeva', 'Admistrator');


CREATE TABLE [Customers](
[Id] INT PRIMARY KEY IDENTITY
,[DriverLicenceNumber] NVARCHAR(20) NOT NULL
,[FullName] NVARCHAR(200) NOT NULL
,[Address] NVARCHAR(200) NOT NULL
,[City] NVARCHAR(50) NOT NULL
,[ZIPCode] INT NOT NULL
,[Notes] NVARCHAR(MAX)
);


INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode]) VALUES
('SG99559955', 'Pesho Peshev', 'Iantra 22', 'Varna', 3850)
,('JK44004400', 'Minio Minev', 'Varfar 14', 'Sofia', 1000)
,('SL66226622', 'Lina Linova', 'Ogosta 55', 'Plovdiv', 1450)


CREATE TABLE [RentalOrders](
[Id] INT PRIMARY KEY IDENTITY
,[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL
,[CustomerId] INT FOREIGN KEY REFERENCES [Customers](Id) NOT NULL
,[CarId] INT FOREIGN KEY REFERENCES [Cars](Id) NOT NULL
,[TankLevel] SMALLINT NOT NULL
,[KilometrageStart] INT NOT NULL
,[KilometrageEnd] INT NOT NULL
,[TotalKilometrage] AS KilometrageEnd - KilometrageStart
,[StartDate] DATETIME2 NOT NULL
,[EndDate] DATETIME2 NOT NULL
,[TotalDays] AS DATEDIFF(DAY, StartDate, EndDate)
,[RateApplied] DECIMAL(9,2)
,[TaxRate] DECIMAL(9,2) 
,[OrderStatus] NVARCHAR(100)
,[Notes] NVARCHAR(MAX)
);


INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate]) VALUES
(1, 1, 1, 45.65, 14550,14780, '2020-06-18 9:45:00', '2020-06-21 15:55:00')
,(2, 2, 2, 22.25, 165500,166770, '2010-06-22 9:30:00', '2010-06-27 18:45:00')
,(3, 3, 3, 33, 222550,223840, '2017-11-18 10:15:00', '2017-11-21 21:10:00')