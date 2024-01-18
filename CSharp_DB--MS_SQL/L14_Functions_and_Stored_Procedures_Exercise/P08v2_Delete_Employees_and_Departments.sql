ALTER TABLE [Employees]
ADD [IsDeleted] BIT

GO

CREATE PROCEDURE usp_RealDeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
     UPDATE [Employees]
	 SET [IsDeleted] = 0

	 UPDATE [Employees]
	 SET [IsDeleted] = 1
	 WHERE [DepartmentID] = @departmentId
END

-- 5 Is just a random num for the example
--EXEC  usp_RealDeleteEmployeesFromDepartment 5  


--SELECT To verify that the Department( Table Data ) was deleted
--SELECT SELECT(*) FROM [Employees]
--WHERE [DepartmentID] = 5 AND [IsDeleted] = 0