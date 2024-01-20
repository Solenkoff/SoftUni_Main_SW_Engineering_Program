SELECT   t.DateOfDeparture
       , t.Price AS TicketPrice
    FROM Tickets AS t
ORDER BY t.Price, t.DateOfDeparture DESC