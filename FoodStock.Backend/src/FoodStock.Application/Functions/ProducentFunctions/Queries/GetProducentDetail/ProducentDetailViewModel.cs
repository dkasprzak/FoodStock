using MediatR;

namespace FoodStock.Application.Functions.ProducentFunctions.Queries.GetProducentDetail;

public sealed record ProducentDetailViewModel : IRequest<List<ProducentDetailViewModel>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
