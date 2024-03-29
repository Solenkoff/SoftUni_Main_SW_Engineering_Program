SELECT [ContinentCode], [CurrencyCode], [CurrencyCount]
  FROM
    (SELECT *
    , DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CurrencyCount] DESC ) 
                AS [CurrencyRank]
       FROM
           (SELECT [ContinentCode]
		         , [CurrencyCode]
		         , COUNT([CurrencyCode]) AS [CurrencyCount]
              FROM [Countries]
          GROUP BY [ContinentCode], [CurrencyCode]
		    )   AS [CurrencyCountSubquery]
       WHERE [CurrencyCount] > 1
    ) AS [CurrencyRankingSubquery]
   WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]
