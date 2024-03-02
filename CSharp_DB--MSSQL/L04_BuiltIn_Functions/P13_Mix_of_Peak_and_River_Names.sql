SELECT p.[PeakName]
     , r.[RiverName]
     , CONCAT(LOWER(p.[PeakName]), SUBSTRING(LOWER(r.[RiverName]), 2, LEN(r.[RiverName]) - 1))
      AS [Mix] 
    FROM [Peaks] AS p, [Rivers] AS r 
   WHERE RIGHT(p.[PeakName], 1) = LEFT(LOWER(r.[RiverName]), 1)
ORDER BY [Mix] ASC