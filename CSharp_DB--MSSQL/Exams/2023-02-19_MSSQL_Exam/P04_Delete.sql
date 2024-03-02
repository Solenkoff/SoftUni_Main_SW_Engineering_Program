
DELETE 
FROM CreatorsBoardgames 
WHERE BoardgameId IN(1, 6, 16, 21,31, 36, 47)

DELETE 
FROM Boardgames 
WHERE PublisherId IN(1, 16)

DELETE
FROM Publishers 
WHERE AddressId = 5

DELETE
FROM Addresses
WHERE LEFT(Town, 1) = 'L';

DELETE
FROM Publishers 
WHERE AddressId = 5

