 SELECT e.FirstName +' '+ e.LastName AS [Employee]
       , IIF(d.[Name] IS NULL , 'None', d.[Name]) AS [Department]
       , c.[Name] AS Category
       ,r.[Description]
       , FORMAT( r.OpenDate, 'dd.MM.yyyy') AS [OpenDate] 
       , s.[Label] AS [Status]
       , u.[Name]  
 FROM Employees AS e
 LEFT JOIN Reports AS r ON r.EmployeeId= e.Id
  LEFT JOIN Users AS u ON u.Id= r.UserId
LEFT JOIN Departments AS d ON d.Id =e.DepartmentId
LEFT JOIN Categories AS c ON r.CategoryId= c.Id
 JOIN Status AS s ON r.StatusId= s.Id 
 ORDER BY e.FirstName DESC,
		 e.LastName DESC,
		 Department ASC,
		 Category ASC,
		 Description ASC,
		 OpenDate ASC,
		 Status ASC,
		 User ASC