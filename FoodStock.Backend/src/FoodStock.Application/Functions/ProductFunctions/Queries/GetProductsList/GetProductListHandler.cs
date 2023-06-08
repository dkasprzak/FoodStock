using AutoMapper;
using FoodStock.Application.Repositories;
using FoodStock.Core.Entities;
using MediatR;

namespace FoodStock.Application.Functions.ProductFunctions.Queries.GetProductsList;

public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<ProductListViewModel>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductListHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ProductListViewModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllOrderByExpirationDateAscAsync();
        return _mapper.Map<List<ProductListViewModel>>(products);
    }
}
