CREATE PROC dbo.usp_GetTownsStartingWith (@stringToMatch NVARCHAR(MAX))
AS 
BEGIN
    SELECT [Name] AS [Town]
	  FROM [Towns]
	 WHERE [Name] LIKE @stringToMatch + '%'
END


--EXEC dbo.usp_GetTownsStartingWith 'b'