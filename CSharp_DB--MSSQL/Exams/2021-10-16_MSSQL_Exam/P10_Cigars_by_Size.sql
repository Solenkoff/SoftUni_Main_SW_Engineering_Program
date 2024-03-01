SELECT   c.LastName
	   , avg(s.Length) AS CiagrLength
	   , CEILING(AVG(s.RingRange)) AS CiagrRingRange
    FROM Clients AS c
    LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
    LEFT JOIN Cigars AS cg ON cc.CigarId = cg.Id
    JOIN Sizes AS s ON cg.SizeId = s.Id
   WHERE cc.CigarId IS NOT NULL
GROUP BY c.LastName
ORDER BY CiagrLength DESC

