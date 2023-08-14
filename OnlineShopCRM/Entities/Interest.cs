namespace OnlineShopCRM.Entities;

public class Interest
{
    public int Id { get; set; }
    public required string InterestDescription { get; set; }
    public Customer? Customer { get; set; }
    public int CustomerId { get; set; }
    public DateOnly? Date { get; set; }
    public required string HashTags { get; set; }
    public bool IsActual { get; set; }
}
