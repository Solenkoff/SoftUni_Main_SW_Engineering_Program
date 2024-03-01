SELECT  CONCAT(c.FirstName, ' ', c.LastName) AS FullName
      , a.Country
	  , a.ZIP
	  , CONCAT('$', FORMAT(MAX(cg.PriceForSingleCigar), 'F2') ) AS CigarPrice
   FROM Clients AS c
   JOIN Addresses AS a ON c.AddressId = a.Id
   JOIN ClientsCigars AS cs ON c.Id = cs.ClientId
   JOIN Cigars AS cg ON cs.CigarId = cg.Id
  WHERE a.ZIP NOT LIKE '%[^0-9]%'
  GROUP BY c.Id, c.FirstName, c.LastName,a.Country, a.ZIP
  ORDER BY FullName
