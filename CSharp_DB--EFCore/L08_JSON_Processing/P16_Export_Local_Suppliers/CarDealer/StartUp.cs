namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using Castle.Core.Resource;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(GetLocalSuppliers(context));                         // P16

        }


        public static string GetLocalSuppliers(CarDealerContext context)           // P16
        {
            var nonImporters = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var nonImportersJson = JsonConvert.SerializeObject(nonImporters, Formatting.Indented);

            return nonImportersJson;
        }

    }
}