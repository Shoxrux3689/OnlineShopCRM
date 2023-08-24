namespace OnlineShopCRM.Models.InterestModels;

public class UpdateInterestModel
{
    public required string InterestDescription { get; set; }
    public DateOnly? Date { get; set; }
    public required string HashTags { get; set; }
    public bool IsActual { get; set; }
}
