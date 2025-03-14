SELECT  l.Province
		, l.Municipality
		, l.[Name] AS [Location]
        ,COUNT(*) AS CountOfSites
FROM Locations AS l
JOIN Sites AS s ON l.Id = s.LocationId
WHERE l.Province = 'Sofia'
GROUP BY l.Id, l.Province, l.Municipality, l.[Name]
ORDER BY CountOfSites DESC, [Location]