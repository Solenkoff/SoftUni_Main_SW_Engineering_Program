CREATE VIEW V_EmployeeNameJobTitle
AS 
SELECT 
   (CASE 
	   WHEN [MiddleName] IS NULL THEN CONCAT([FirstName], ' ', '', ' ', [LastName])
       ELSE  CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName])
   END)  
	 AS [Full Name]
      , [JobTitle]
FROM [Employees];


--   Variant_02
--CREATE VIEW V_EmployeeNameJobTitle
--AS
--SELECT 
--     CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name]
--     , JobTitle 
--FROM Employees;


--   Variant_03
--CREATE VIEW V_EmployeeNameJobTitle
--AS
--SELECT 
--     CONCAT(FirstName, ' ', ISNULL(MiddleName, ''), ' ', LastName) AS [Full Name]
--     , JobTitle 
--FROM Employees;