   SELECT   
          t.[Name] AS Town
        , rs.[Name] AS RailwayStation
     FROM RailwayStations AS rs
     JOIN Towns AS t ON rs.TownId = t.Id
LEFT JOIN TrainsRailwayStations AS trs ON rs.Id = trs.RailwayStationId
    WHERE trs.TrainId IS NULL
 ORDER BY t.[Name], rs.[Name]

       