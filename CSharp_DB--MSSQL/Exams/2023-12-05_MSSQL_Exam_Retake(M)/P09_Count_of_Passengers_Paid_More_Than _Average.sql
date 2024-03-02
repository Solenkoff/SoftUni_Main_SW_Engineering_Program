  SELECT   
         tw.Name AS TownName
       , COUNT(*) AS PassengersCount
    FROM Passengers AS p
    JOIN Tickets AS t ON p.Id = t.PassengerId
    JOIN Trains AS tr ON t.TrainId = tr.Id
    JOIN Towns AS tw ON tr.ArrivalTownId = tw.Id
   WHERE t.Price > 76.99
GROUP BY tw.Name
ORDER BY tw.Name