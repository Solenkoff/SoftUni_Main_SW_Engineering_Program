using System;

namespace _07_Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            double studioPriceMayOct = 50;
            double apartmentPriceMayOct = 65;
            double studioPriceJuneSept = 75.20;
            double apartmentPriceJuneSept = 68.70;
            double studioJulyAug = 76;
            double apartmentJulyAug = 77;
            double totalStudioPrice = 0;
            double totalApartmPrice = 0;

            string month = Console.ReadLine();
            int numberNights = int.Parse(Console.ReadLine());

            switch (month)
            {
                case "May":
                    totalStudioPrice = numberNights * studioPriceMayOct;
                    totalApartmPrice = numberNights * apartmentPriceMayOct;
                    if (numberNights > 7 && numberNights < 14)
                    {
                        totalStudioPrice -= totalStudioPrice * 0.05;
                    }
                    else if (numberNights > 14)
                    {
                        totalStudioPrice -= totalStudioPrice * 0.30;
                    }
                    break;
                case "October":
                    totalStudioPrice = numberNights * studioPriceMayOct;
                    totalApartmPrice = numberNights * apartmentPriceMayOct;
                    if (numberNights > 7 && numberNights < 14)
                    {
                        totalStudioPrice -= totalStudioPrice * 0.05;
                    }
                    else if (numberNights > 14)
                    {
                        totalStudioPrice -= totalStudioPrice * 0.30;
                    }
                    break;
                case "June":
                case "September":

                    totalStudioPrice = numberNights * studioPriceJuneSept;
                    totalApartmPrice = numberNights * apartmentPriceJuneSept;
                    if (numberNights > 14)
                    {
                        totalStudioPrice -= totalStudioPrice * 0.20;
                    }
                    break;

                case "July":
                case "August":

                    totalStudioPrice = numberNights * studioJulyAug;
                    totalApartmPrice = numberNights * apartmentJulyAug;
                    break;

            }

            if (numberNights > 14)
            {
                totalApartmPrice -= totalApartmPrice * 0.10;
            }

            Console.WriteLine($"Apartment: {totalApartmPrice:f2} lv.");
            Console.WriteLine($"Studio: {totalStudioPrice:f2} lv.");
        }
    }
}
