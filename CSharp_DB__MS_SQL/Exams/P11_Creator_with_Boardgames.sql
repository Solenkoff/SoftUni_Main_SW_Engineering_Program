CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
    DECLARE @result INT;
	 SELECT @result = COUNT(cb.BoardgameId)
	   FROM Creators AS c
	   JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
	   JOIN Boardgames AS b ON cb.BoardgameId = b.Id
	WHERE c.FirstName = @name
	GROUP BY c.Id

	IF (@result IS NULL)
	  SET @result = 0;

	RETURN @result
END

------------
--CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30)) 
--RETURNS INT
--AS
--BEGIN
--    DECLARE @result INT;
--	 SELECT @result = COUNT(cb.BoardgameId)
--	   FROM Creators AS c
--	   JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
--	WHERE c.FirstName = @name
	
--	RETURN @result
--END

