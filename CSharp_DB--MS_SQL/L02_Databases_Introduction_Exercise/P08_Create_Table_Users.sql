CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)


INSERT INTO [Users]([Username],[Password], [ProfilePicture], [LastLoginTime], [IsDeleted]) VALUES
    ('Gosho', 'password01', '2023-10-04 14:23:12', 'false'),
    ('Tosho', 'Passward02', NULL, 'false'),
    ('Pesho', 'Passward03', '2023-06-18 11:43:02', 'false'),
    ('Gana', 'Passward04', NULL, 'true'),
    ('Vula', 'Passward05', '2023-09-28 07:09:52', 'false')