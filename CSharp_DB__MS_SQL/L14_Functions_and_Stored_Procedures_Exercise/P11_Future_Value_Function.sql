CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL, @interestRate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
     DECLARE @futureValue DECIMAL(18, 4)
    
      SET @futureValue = @sum * (POWER((1 + @interestRate), @years))
    
      RETURN @futureValue
END



