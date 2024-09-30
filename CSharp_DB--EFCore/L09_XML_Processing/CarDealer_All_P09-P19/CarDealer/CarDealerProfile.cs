using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDto, Supplier>();
            CreateMap<ImportPartDto, Part>();
            CreateMap<ImportCarDto, Car>();
            CreateMap<ImportCustomerDto,  Customer>();  
            CreateMap<ImportSaleDto, Sale>();
            CreateMap<Car, ExportCarDistanceDto>();
            CreateMap<Customer, ExportSalesByCustomerDto>();
            CreateMap<Sale, ExportAllSalesDto>();
            CreateMap<Car, ExportBMWCarDto>();
            CreateMap<Supplier, ExportLocalSuppliersDto>();
            CreateMap<Car, ExportAllCarsWithPartsDto>();
        }
    }
}
