CREATE TABLE [Students](
[StudentID] INT PRIMARY KEY IDENTITY NOT NULL
,[Name] NVARCHAR(50) NOT NULL
);


CREATE TABLE [Exams](
[ExamID] INT PRIMARY KEY IDENTITY(101,1) NOT NULL
,[Name] NVARCHAR(100) NOT NULL
);



CREATE TABLE [StudentsExams](
[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])NOT NULL
,[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID])NOT NULL
,CONSTRAINT PK_StudentsExams PRIMARY KEY([StudentID], [ExamID])
);

INSERT INTO [Students] VALUES
('Mila')                                      
,('Toni')
,('Ron');


INSERT INTO [Exams] VALUES
('SpringMVC')
,('Neo4j')
,('Oracle 11g');