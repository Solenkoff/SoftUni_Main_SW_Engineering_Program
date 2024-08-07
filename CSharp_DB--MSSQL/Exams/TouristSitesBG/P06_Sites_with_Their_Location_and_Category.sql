SELECT    s.[Name] AS [Site]
		, l.[Name] AS [Location]
		, s.Establishment 
		,c.[Name] AS Category
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
JOIN Categories AS c ON s.CategoryId = c.Id
ORDER BY Category DESC, [Location], [Site]