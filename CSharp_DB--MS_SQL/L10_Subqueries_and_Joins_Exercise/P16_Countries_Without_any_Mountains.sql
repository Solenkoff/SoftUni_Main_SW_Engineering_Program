
SELECT COUNT(a.[CountryName]) AS [Count]
FROM
  (
     SELECT  c.[CountryName]
          FROM [Countries] AS c
     LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
     LEFT JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
       WHERE m.[Id] IS NULL
    GROUP BY c.[CountryName]
  ) AS a

--Variant 2
--SELECT COUNT(NoRiverCountries.CountryCode) AS [Count]
-- FROM
--    (SELECT c.CountryCode
--       FROM Countries AS c
--  LEFT JOIN MountainsCountries AS mc ON c.CountryCode=mc.CountryCode
--      WHERE mc.MountainId IS NULL
--    ) AS NoRiverCountries