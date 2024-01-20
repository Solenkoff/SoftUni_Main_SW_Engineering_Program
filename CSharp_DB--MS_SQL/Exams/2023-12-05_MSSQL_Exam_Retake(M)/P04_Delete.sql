
DELETE
FROM Tickets
WHERE TrainId IN (             --   WHERE TrainId = 7
    SELECT Id 
    FROM Trains 
    WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin')
);

DELETE
FROM MaintenanceRecords
WHERE TrainId IN (             --   WHERE TrainId = 7
    SELECT Id 
    FROM Trains 
    WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin')
);

DELETE
FROM TrainsRailwayStations
WHERE TrainId IN (             --   WHERE TrainId = 7
    SELECT Id 
    FROM Trains 
    WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin')
);

DELETE
FROM Trains
WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin');   --   WHERE DepartureTownId = 7