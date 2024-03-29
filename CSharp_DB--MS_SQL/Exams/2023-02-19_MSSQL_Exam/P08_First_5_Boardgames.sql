SELECT TOP(5)
         b.[Name]
       , b.Rating
	   , c.[Name] AS CategoryName
    FROM Boardgames AS b
    JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
    JOIN Categories AS c ON b.CategoryId = c.Id
  WHERE (b.Rating > 7.00 AND b.[Name] LIKE '%a%') OR 
        (b.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMAX = 5)
ORDER BY b.[Name] ASC, b.Rating DESC
