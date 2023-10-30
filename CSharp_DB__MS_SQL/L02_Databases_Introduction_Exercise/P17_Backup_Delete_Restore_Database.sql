USE [master]
BACKUP DATABASE SoftUni
 TO DISK = 'D:\C#\softuni-backup.bak'
    WITH FORMAT;
GO


USE [master]
DROP DATABASE [SoftUni]
GO


USE [master]
RESTORE DATABASE [SoftUni] 
FROM DISK = 'D:\C#\softuni-backup.bak'
GO