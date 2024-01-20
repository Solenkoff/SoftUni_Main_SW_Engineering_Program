UPDATE Tickets
   SET DateOfDeparture = DATEADD(WEEK, 1, DateOfDeparture),
       DateOfArrival = DATEADD(WEEK, 1, DateOfArrival)
 WHERE DateOfDeparture > '2023-10-31';

 