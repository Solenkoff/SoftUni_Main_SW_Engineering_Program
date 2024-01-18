SELECT   b.Id
       , b.[Name]
	   , b.YearPublished
	   , c.[Name] AS CategoryName
    FROM Boardgames AS b
	JOIN Categories AS c ON b.CategoryId = c.Id 
   WHERE CategoryId IN (6, 8)
ORDER BY YearPublished DESC