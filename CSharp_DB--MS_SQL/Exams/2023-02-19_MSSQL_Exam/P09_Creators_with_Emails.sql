SELECT   CONCAT_WS(' ', c.FirstName, c.LastName) AS FullName
       , c.Email
	   , MAX(b.Rating) AS Rating
    FROM Creators AS c
    JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
    JOIN Boardgames AS b ON cb.BoardgameId = b.Id
GROUP BY c.Id, CONCAT_WS(' ', c.FirstName, c.LastName), c.Email
  HAVING RIGHT(c.Email, 4) = '.com'
ORDER BY FullName