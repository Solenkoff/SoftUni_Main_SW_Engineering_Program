 
 SELECT  Id
	   , CONCAT(FirstName, ' ', LastName) AS ClientName
	   , Email
    FROM Clients AS c
    LEFT JOIN ClientsCigars AS cs ON c.Id = cs.ClientId
   WHERE cs.CigarId IS NULL
ORDER BY ClientName 