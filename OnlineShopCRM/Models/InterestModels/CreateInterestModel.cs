using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Models.InterestModels;

public class CreateInterestModel
{
    public required string InterestDescription { get; set; }
    public int CustomerId { get; set; }
    public DateOnly? Date { get; set; }
    public required string HashTags { get; set; }
    public bool IsActual { get; set; }
}
