 
CREATE PROCEDURE usp_SearchByCategory 
       @category VARCHAR(50)
AS
   SELECT  b.[Name]
         , b.YearPublished
		 , b.Rating
		 , c.[Name]
		 , p.[Name]
		 , CONCAT_WS(' ', pr.PlayersMin, 'people')
		 , CONCAT_WS(' ', pr.PlayersMAX, 'people')
      FROM Boardgames AS b
      JOIN Categories AS c ON b.CategoryId = c.Id
      JOIN Publishers AS p ON b.PublisherId = p.Id
      JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
     WHERE c.[Name] = @category
  ORDER BY p.[Name] ASC, b.YearPublished DESC

