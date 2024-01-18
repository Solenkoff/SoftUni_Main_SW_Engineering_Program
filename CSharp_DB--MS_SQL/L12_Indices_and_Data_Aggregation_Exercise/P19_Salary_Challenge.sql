SELECT TOP(10)
           e.[FirstName]
         , e.[LastName]
         , e.[DepartmentID]
FROM [Employees] AS e
WHERE e.[Salary] >  
         (          
            SELECT AVG([Salary]) AS [DepAvgSalary]
	        FROM [Employees] AS subE
	        WHERE subE.[DepartmentID] = e.[DepartmentID]
	        GROUP BY subE.[DepartmentID]
         )
ORDER BY e.[DepartmentID]
 
