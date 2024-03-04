 
---12. Assign Employee
 
 
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
 
UPDATE Reports SET EmployeeId=@EmployeeId
WHERE Reports.Id IN (
SELECT  Tbl02.RaportId
FROM(SELECT E.DepartmentId, D1.Name,E.Id
FROM Departments AS D1
JOIN Employees AS E
ON E.DepartmentId=D1.Id) AS Tbl01
JOIN 
(SELECT C.DepartmentId,D2.Name,R.Id AS [RaportId]
FROM Departments AS D2
JOIN Categories AS C
ON C.DepartmentId=D2.Id
JOIN Reports AS R
ON R.CategoryId=C.Id) AS Tbl02
ON Tbl02.DepartmentId=Tbl01.DepartmentId
WHERE Tbl01.Id=@EmployeeId AND TBL02.RaportId=@ReportId)
BEGIN TRY
   IF NOT EXISTS (
 
  SELECT  Tbl02.RaportId
FROM(SELECT E.DepartmentId, D1.Name,E.Id
FROM Departments AS D1
JOIN Employees AS E
ON E.DepartmentId=D1.Id) AS Tbl01
JOIN 
(SELECT C.DepartmentId,D2.Name,R.Id AS [RaportId]
FROM Departments AS D2
JOIN Categories AS C
ON C.DepartmentId=D2.Id
JOIN Reports AS R
ON R.CategoryId=C.Id) AS Tbl02
ON Tbl02.DepartmentId=Tbl01.DepartmentId
WHERE Tbl01.Id=@EmployeeId AND TBL02.RaportId=@ReportId
 
   )
        THROW 51000, 'Employee doesn''t belong to the appropriate department!', 1;
 
 
END TRY
BEGIN CATCH
    THROW;
END CATCH