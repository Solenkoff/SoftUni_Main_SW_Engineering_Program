  SELECT [MountainRange],[PeakName], [Elevation]
    FROM [Mountains] AS m
    JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
   WHERE m.[MountainRange] = 'Rila'
ORDER BY p.[Elevation] DESC