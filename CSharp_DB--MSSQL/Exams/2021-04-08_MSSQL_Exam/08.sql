SELECT  u.[UserName]
       --,u.[Birthdate]
       --,r.[OpenDate]
       ,c.[Name]
FROM [Users] AS u
LEFT JOIN [Reports] AS r ON u.[Id] = r.[UserId]
LEFT JOIN [Status] AS s ON r.[StatusId] = s.[Id]
LEFT JOIN [Categories] AS c ON r.[CategoryId] = c.[Id]
WHERE (DATEPART(mm,u.[Birthdate]) = DATEPART(mm,r.[OpenDate]))
AND (DATEPART(d,u.[Birthdate]) = DATEPART(d,r.[OpenDate]))
ORDER BY u.[Username], c.[Name]