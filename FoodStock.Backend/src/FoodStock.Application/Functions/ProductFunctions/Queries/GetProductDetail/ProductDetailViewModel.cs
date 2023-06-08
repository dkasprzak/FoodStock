using FoodStock.Core;

namespace FoodStock.Application.Functions.ProductFunctions.Queries.GetProductDetail;

public sealed record ProductDetailViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public Guid ProducentId { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Quantity { get; set; }
    public string? BarCode { get; set; }
    public DateTime AddedDate { get; set; }
    public Guid UserId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public Guid SupplierId { get; set; }
}
