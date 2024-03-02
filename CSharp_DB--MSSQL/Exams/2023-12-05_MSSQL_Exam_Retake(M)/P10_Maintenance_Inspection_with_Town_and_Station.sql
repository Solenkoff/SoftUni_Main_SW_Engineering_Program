  SELECT 
         t.Id AS TrainID
       , tw.[Name] AS DepartureTown
	   , mr.Details
    FROM Trains AS t
    JOIN Towns AS tw ON t.DepartureTownId = tw.Id
    JOIN MaintenanceRecords AS mr ON t.Id = mr.TrainId
   WHERE mr.Details LIKE '%inspection%'
ORDER BY t.Id