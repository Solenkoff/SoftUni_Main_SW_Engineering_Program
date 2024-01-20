CREATE PROCEDURE usp_SearchByTown (@townName VARCHAR(30))
AS
BEGIN
     SELECT 
            p.[Name] AS PassengerName
		  , t.DateOfDeparture
		  , tr.HourOfDeparture
       FROM Passengers AS p
       JOIN Tickets AS t ON p.Id = t.PassengerId
       JOIN Trains AS tr ON t.TrainId = tr.Id
       JOIN Towns AS tw ON tr.ArrivalTownId = tw.Id
      WHERE tw.[Name] = @townName
   ORDER BY t.DateOfDeparture DESC, PassengerName
END;
          

