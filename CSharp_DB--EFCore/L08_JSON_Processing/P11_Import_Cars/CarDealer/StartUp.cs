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

            string carsJson = File.ReadAllText("../../../Datasets/cars.json");             // P11
            Console.WriteLine(ImportCars(context, carsJson));

        }


        public static string ImportCars(CarDealerContext context, string inputJson)        // P11
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            CarDTO[] carDTOs = JsonConvert.DeserializeObject<CarDTO[]>(inputJson);

            ICollection<Car> cars = new HashSet<Car>();
            ICollection<PartCar> partCars = new HashSet<PartCar>();

            foreach (var carDTO in carDTOs)
            {
                Car currCar = mapper.Map<Car>(carDTO);

                foreach (var partId in carDTO.PartsId.Distinct())
                {
                    var partCar = new PartCar
                    {
                        PartId = partId,
                        Car = currCar
                    };

                    partCars.Add(partCar);
                }

                cars.Add(currCar);
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

    }
}