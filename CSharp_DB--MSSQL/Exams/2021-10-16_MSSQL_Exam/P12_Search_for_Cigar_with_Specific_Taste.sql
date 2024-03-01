CREATE PROCEDURE usp_SearchByTaste
       @taste VARCHAR(20)
AS
   SELECT  c.CigarName
		   , CONCAT('$', FORMAT(c.PriceForSingleCigar, 'F2')) AS Price
		   , t.TasteType AS TasteType
		   , b.BrandName
		   , CONCAT(s.Length, ' ', 'cm') AS CigarLength
		   , CONCAT(s.RingRange, ' ', 'cm') AS CigarRingRange
        FROM Cigars AS c
        JOIN Brands AS b ON c.BrandId = b.Id
        JOIN Tastes AS t ON c.TastId = t.Id
        JOIN Sizes AS s ON c.SizeId = s.Id
       WHERE t.TasteType = @taste
    ORDER BY CigarLength, CigarRingRange DESC



