--UPDATE [Payments]
--SET [TaxRate] = 18
--WHERE [Id] = 3


UPDATE [Payments]
SET [TaxRate] -= [TaxRate] * 0.03 

SELECT [TaxRate]
FROM [Payments]


