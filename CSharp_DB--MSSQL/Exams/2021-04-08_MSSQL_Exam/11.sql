---11. Hours to Complete
 
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
BEGIN
 
RETURN (SELECT ISNULL(CASE WHEN DATEDIFF(HOUR,@StartDate, @EndDate)=0 THEN 0
					ELSE DATEDIFF(HOUR,@StartDate, @EndDate) END,0))
 
END