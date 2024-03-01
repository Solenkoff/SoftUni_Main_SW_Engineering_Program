SELECT CigarName,
	   FORMAT(PriceForSingleCigar, 'F2'),
	   ImageURL
  FROM Cigars
 ORDER BY PriceForSingleCigar , CigarName DESC