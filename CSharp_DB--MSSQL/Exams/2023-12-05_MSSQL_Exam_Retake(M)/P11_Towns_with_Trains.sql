CREATE FUNCTION udf_TownsWithTrains(@townName VARCHAR(30)) 
RETURNS INT
AS
BEGIN
    DECLARE @result INT;

     SELECT @result = COUNT(DISTINCT tr.Id)
       FROM Trains AS tr 
       JOIN Towns AS tw ON tr.ArrivalTownId = tw.Id
         OR                tr.DepartureTownId = tw.Id
      WHERE tw.[Name] = @townName 
   
   	 RETURN @result
END
