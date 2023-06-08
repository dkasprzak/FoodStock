using AutoMapper;
using FoodStock.Application.Functions.ProducentFunctions.Queries.GetProducentDetail;
using FoodStock.Application.Functions.ProducentFunctions.Queries.GetProducentListQuery;
using FoodStock.Application.Functions.ProductFunctions.Commands.CreateProduct;
using FoodStock.Application.Functions.ProductFunctions.Commands.UpdateProduct;
using FoodStock.Application.Functions.ProductFunctions.Queries.GetProductDetail;
using FoodStock.Application.Functions.ProductFunctions.Queries.GetProductsList;
using FoodStock.Application.Functions.SupplierFunctions.Queries.GetSupplierDetail;
using FoodStock.Application.Functions.SupplierFunctions.Queries.GetSupplierList;
using FoodStock.Core.Entities;

namespace FoodStock.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Product Mapper
        CreateMap<Product, ProductListViewModel>();
        CreateMap<Product, ProductDetailViewModel>();
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        
        //Producent Mapper
        CreateMap<Producent, ProducentListViewModel>();
        CreateMap<Producent, ProducentDetailViewModel>();
        
        //SupplierMapper
        CreateMap<Supplier, SupplierDetailViewModel>();
        CreateMap<Supplier, SupplierListViewModel>();
    }
}
