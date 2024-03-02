SELECT *  
 INTO [UpdatedEmployeesSalaries]
 FROM [Employees]
WHERE [Salary] > 30000 

DELETE 
  FROM [UpdatedEmployeesSalaries]
 WHERE [ManagerID] = 42

UPDATE [UpdatedEmployeesSalaries]
   SET [Salary] = [Salary] + 5000
 WHERE [DepartmentID] = 1  

  SELECT [DepartmentID]
       , AVG([Salary]) AS [AverageSalary]
    FROM [UpdatedEmployeesSalaries]
GROUP BY [DepartmentID]