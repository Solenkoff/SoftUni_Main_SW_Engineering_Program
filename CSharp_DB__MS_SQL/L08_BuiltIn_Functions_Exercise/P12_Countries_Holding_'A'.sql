  SELECT [CountryName] AS [Country Name], 
         [IsoCode] AS [Iso Code]
    FROM [Countries]
   WHERE [CountryName] LIKE '%[A,a]%[A,a]%[A,a]%'
ORDER BY [IsoCode]