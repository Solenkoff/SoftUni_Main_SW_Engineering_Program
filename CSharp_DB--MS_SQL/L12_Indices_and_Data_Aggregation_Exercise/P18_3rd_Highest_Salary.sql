SELECT DISTINCT [DepartmentID]
              , [Salary] AS [ThirdHighestSalary]
FROM 
     (
         SELECT [DepartmentID]
              , [Salary]
              , DENSE_RANK() OVER(PARTITION BY [DepartmentID] 
			    ORDER BY [Salary] DESC) AS [Ranking]
         FROM [Employees]
     ) AS [SalaryRanking]
WHERE [Ranking] = 3
