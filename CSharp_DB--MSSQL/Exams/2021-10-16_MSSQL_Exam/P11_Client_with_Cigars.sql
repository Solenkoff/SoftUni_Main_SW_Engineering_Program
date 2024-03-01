
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
     DECLARE @result INT;
	  SELECT @result = COUNT(cc.CigarId)
        FROM Clients AS c
        JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
       WHERE c.FirstName = @name 

	  RETURN @result
END

