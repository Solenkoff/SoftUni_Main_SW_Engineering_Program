CREATE PROC usp_GetEmployeesFromTown(@TownName NVARCHAR(100))
AS
BEGIN
     SELECT [FirstName] AS [First Name]
          , [LastName] AS [Last Name]
       FROM [Employees] AS e
 INNER JOIN [Addresses] AS a ON e.AddressID = a.AddressID
 INNER JOIN [Towns] AS t ON a.TownID = t.TownID
    WHERE t.[Name] = @TownName
END

--EXEC dbo.usp_GetEmployeesFromTown 'Sofia'