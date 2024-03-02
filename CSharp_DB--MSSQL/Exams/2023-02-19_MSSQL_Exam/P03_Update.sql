UPDATE PlayersRanges 
SET PlayersMAX = PlayersMAX + 1
WHERE PlayersMin = 2 AND PlayersMAX = 2;

UPDATE Boardgames
SET [Name] = CONCAT([Name], 'V2')
WHERE YearPublished >= 2020

