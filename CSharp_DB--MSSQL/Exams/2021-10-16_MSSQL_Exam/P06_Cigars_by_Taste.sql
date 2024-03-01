SELECT  c.Id
	  , c.CigarName
	  , FORMAT(c.PriceForSingleCigar, 'F2')
	  , t.TasteType
	  , t.TasteStrength
   FROM Cigars AS c
   JOIN Tastes AS t ON c.TastId = t.Id
  WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
  ORDER BY c.PriceForSingleCigar DESC