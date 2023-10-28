CREATE DATABASE [Hotel]

GO

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY
,[FirstName] NVARCHAR(50) NOT NULL
,[LastName] NVARCHAR(50) NOT NULL
,[Title] NVARCHAR(50) NOT NULL
,[Notes] NVARCHAR(MAX) 
);



CREATE TABLE [Customers](
[Id] INT PRIMARY KEY IDENTITY
,[AccountNumber] INT 
,[FirstName] NVARCHAR(50) NOT NULL
,[LastName] NVARCHAR(50) NOT NULL
,[PhoneNumber] INT NOT NULL
,[EmergencyName] NVARCHAR(50) NOT NULL
,[EmergencyNumber] INT NOT NULL
,[Notes] NVARCHAR(MAX)
);

CREATE TABLE [RoomStatus](
[Id] INT PRIMARY KEY IDENTITY
,[RoomStatus] BIT NOT NULL
,[Notes] NVARCHAR(MAX)
);


CREATE TABLE [RoomTypes] (
[Id] INT PRIMARY KEY IDENTITY
,[RoomType] NVARCHAR(50) NOT NULL
,[Notes] NVARCHAR(MAX)
);

CREATE TABLE [BedTypes](
[Id] INT PRIMARY KEY IDENTITY
,[BedType] NVARCHAR(50) NOT NULL
,[Notes] NVARCHAR(MAX)
);


CREATE TABLE [Rooms](
[Id] INT PRIMARY KEY IDENTITY
,[RoomNumber] SMALLINT NOT NULL
,[RoomType] INT FOREIGN KEY REFERENCES [RoomTypes](Id)
,[BedType] INT FOREIGN KEY REFERENCES [BedTypes](Id)
,[Rate] DECIMAL(9,2) NOT NULL
,[RoomStatus] INT FOREIGN KEY REFERENCES [RoomStatus](Id) 
,[Notes] NVARCHAR(MAX)
);



CREATE TABLE [Payments](
[Id] INT PRIMARY KEY IDENTITY
,[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id)
,[PaymentDate] DATETIME2 
,[AccountNumber] INT
,[FirstDateOccupied] DATETIME2 
,[LastDateOccupied] DATETIME2 
,[TotalDays] AS DATEDIFF(DAY, [FirstDateOccupied], [LastDateOccupied])
,[AmountCharged] DECIMAL(9,2)
,[TaxRate] DECIMAL(9,2)
,[TaxAmount] DECIMAL(9,2) 
,[PaymentTotal] DECIMAL(9,2) NOT NULL
,[Notes] NVARCHAR(MAX)
);


CREATE TABLE [Occupancies](
[Id] INT PRIMARY KEY IDENTITY
,[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id)
,[DateOccupied] DATETIME2 
,[AccountNumber] INT
,[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms](Id)
,[RateApplied] DECIMAL(9,2) 
,[PhoneCharge] DECIMAL(9,2)
,[Notes] NVARCHAR(MAX)
);



INSERT INTO [Employees]([FirstName], [LastName], [Title]) VALUES
('Gosho', 'Goshev', 'Shef')
,('Tosho', 'Toshev', 'Boss')
,('Gana', 'Ganeva', 'Admistrator');


INSERT INTO [Customers]([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber]) VALUES
('Bobo', 'Bobov', 4564567, 'Gina', 8786473)
,('Tuni', 'Tunev', 75869485, 'Rada', 3874958)
,('Dodo', 'Dodov', 4758848, 'Lene', 2455714);


INSERT INTO [RoomStatus] (RoomStatus) VALUES
(1),(0),(1);


INSERT INTO [RoomTypes] (RoomType) VALUES
('Single')
,('Double')
,('Suit');


INSERT INTO [BedTypes] (BedType) VALUES
('Tween')
,('Queen')
,('King');


INSERT INTO [Rooms] ([RoomNumber],[RoomType],[BedType],[Rate],[RoomStatus]) VALUES
(001, 1, 1, 44, 1)
,(002, 2, 2, 66, 2)
,(003, 3, 3, 88, 3);


INSERT INTO [Payments] ([PaymentTotal]) VALUES
(44)
,(66)
,(88);


INSERT INTO [Occupancies] ([Notes]) VALUES
('Handicapped')
,('More towels')
,('Alarm');

