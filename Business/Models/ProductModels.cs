namespace Business.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public string? ProductDescription { get; set; }
    public decimal Price { get; set; }

}
