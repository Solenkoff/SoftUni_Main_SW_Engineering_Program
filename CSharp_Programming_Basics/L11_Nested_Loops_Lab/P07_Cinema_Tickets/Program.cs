using System;

namespace _07_Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentTicket = 0;
            int standardTicket = 0;
            int kidTicket = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Finish")
                {
                    break;
                }
                int freeSpots = int.Parse(Console.ReadLine());
                int cuurentFreeSpot = freeSpots;
                while (cuurentFreeSpot > 0)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }
                    cuurentFreeSpot--;

                    if (ticketType == "standard")
                    {
                        standardTicket++;
                    }
                    else if (ticketType == "student")
                    {
                        studentTicket++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidTicket++;
                    }
                }
                double freeSpotInPercentages = 100 - (cuurentFreeSpot * 1.0 / freeSpots * 100);
                Console.WriteLine($"{input} - {freeSpotInPercentages:f2}% full.");
            }
            int totalTickets = standardTicket + studentTicket + kidTicket;
            double studentTicketsPer = studentTicket * 1.0 / totalTickets * 100;
            double standardTicketPer = standardTicket * 1.0 / totalTickets * 100;
            double kidsTicketPer = kidTicket * 1.0 / totalTickets * 100;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentTicketsPer:f2}% student tickets.");
            Console.WriteLine($"{standardTicketPer:f2}% standard tickets.");
            Console.WriteLine($"{kidsTicketPer:f2}% kids tickets.");
        }
    }
}
