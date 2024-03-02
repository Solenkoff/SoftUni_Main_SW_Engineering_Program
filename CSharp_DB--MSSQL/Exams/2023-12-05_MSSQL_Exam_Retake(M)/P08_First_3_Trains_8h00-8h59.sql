 SELECT 
     TOP(3) 
         tr.Id AS TrainId,
         tr.HourOfDeparture,
         ti.Price AS TicketPrice,
         dT.[Name] AS Destination
    FROM Trains tr
    JOIN Tickets ti ON tr.Id = ti.TrainId
    JOIN Towns dT ON tr.ArrivalTownId = dT.Id
   WHERE tr.HourOfDeparture LIKE '08:[0-5][0-9]'
     AND ti.Price > 50.00
ORDER BY ti.Price ASC
