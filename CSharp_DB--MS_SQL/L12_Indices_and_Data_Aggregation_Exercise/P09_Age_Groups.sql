SELECT  [AgeGroup]
      , COUNT([Id]) AS [WizardCount]
FROM 
   (
      SELECT * 
         , CASE 
	       WHEN [AGE] BETWEEN 0 AND 10 THEN '[0-10]'
	       WHEN [AGE] BETWEEN 11 AND 20 THEN '[11-20]'
	       WHEN [AGE] BETWEEN 21 AND 30 THEN '[21-30]'
	       WHEN [AGE] BETWEEN 31 AND 40 THEN '[31-40]'
	       WHEN [AGE] BETWEEN 41 AND 50 THEN '[41-50]'
	       WHEN [AGE] BETWEEN 51 AND 60 THEN '[51-60]'
	       ELSE '[61+]'
	       END AS [AgeGroup]
    FROM [WizzardDeposits] 
   ) 
	  AS [AgeGroupQuery]
GROUP BY [AgeGroup]