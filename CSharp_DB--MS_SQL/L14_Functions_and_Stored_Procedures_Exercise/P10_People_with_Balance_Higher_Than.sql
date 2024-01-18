CREATE PROC usp_GetHoldersWithBalanceHigherThan(@threshold MONEY)
AS
BEGIN
	SELECT [FirstName] AS [First Name]
	     , [LastName] AS [Last Name]
	FROM dbo.[AccountHolders] AS ah
	JOIN dbo.[Accounts] AS a ON a.[AccountHolderId] = ah.[Id]
	GROUP BY ah.[FirstName], ah.[LastName]
	HAVING SUM(a.[Balance]) > @threshold
	ORDER BY [FirstName], [LastName]
END