ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC07C7365C51;

ALTER TABLE [Users]
ADD CONSTRAINT PK_User PRIMARY KEY (Id, Username);

ALTER TABLE [Users]
ADD CONSTRAINT ValidPasswordLength
CHECK (DATALENGTH(Password) >= 5)

ALTER TABLE [Users]
ADD CONSTRAINT DF_TimeIsNow
DEFAULT GETDATE() 
FOR [LastLoginTime];

UPDATE [Users]
SET [LastLoginTime] = '2020-05-01 07:22:11'
WHERE [Username] = 'Gosho'


ALTER TABLE [Users]
DROP CONSTRAINT CK__Users__ProfilePi__34C8D9D1;

ALTER TABLE [Users]
DROP CONSTRAINT PK_User;

ALTER TABLE [Users]
DROP CONSTRAINT UQ__Users__536C85E4D4D89EA5;


ALTER TABLE [Users]
ADD CONSTRAINT PK_User 
PRIMARY KEY(Id);



ALTER TABLE [Users]
ADD CONSTRAINT ValidUsername UNIQUE([Username])
,CHECK (DATALENGTH([Username]) >= 3);

TRUNCATE TABLE [Users];

INSERT INTO [Users]([Username],[Password], [IsDeleted]) VALUES
 ('Gosho', 'Passward01', 0),
 ('Tosho', 'Passward02', 0),
 ('Pesho', 'Passward03', 1),
 ('Gana', 'Passward04', 0),
 ('Vula', 'Passward05', 1)

 ALTER TABLE [Users]
DROP CONSTRAINT ValidUsernameLength;
