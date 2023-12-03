SELECT * FROM
(
SELECT  Peaks.PeakName
       ,Rivers.RiverName
       ,LOWER(CONCAT(LEFT(PeakName, LEN(PeakName)-1), RiverName )) 
	AS Mix
  FROM Peaks
  JOIN Rivers ON LOWER(RIGHT(PeakName,1)) = LOWER(LEFT(RiverName,1))
)
    AS ResultTable
ORDER BY Mix