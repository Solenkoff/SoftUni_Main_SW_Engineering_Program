CREATE DATABASE [University];

GO

CREATE TABLE [Majors](
[MajorID] INT PRIMARY KEY IDENTITY NOT NULL
,[Name] NVARCHAR(100) NOT NULL
);



CREATE TABLE [Students](
[StudentID] INT PRIMARY KEY IDENTITY NOT NULL
,[StudentNumber] BIGINT NOT NULL
,[StudentName] VARCHAR(50) NOT NULL
,[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
);


CREATE TABLE [Subjects](
[SubjectID] INT PRIMARY KEY IDENTITY NOT NULL
,[SubjectName] NVARCHAR(100) NOT NULL
);

CREATE TABLE [Agenda](
[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
,[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]) NOT NULL
,CONSTRAINT PK_Agenda PRIMARY KEY([StudentID], [SubjectID])
);


CREATE TABLE [Payments](
[PaymentID] INT PRIMARY KEY IDENTITY NOT NULL
,[PaymentDate] DATETIME2 NOT NULL
,[PaymentAmount] DECIMAL(9,2) NOT NULL
,[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
);