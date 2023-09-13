namespace OnlineShopCRM.Entities;

//mijoz! sotib olgan va yoki sotib olmagan
public class Customer
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public required string PhoneNumber { get; set; }
    public User? User { get; set; }
    public int UserId { get; set; }
    public List<Sale>? Sales { get; set; }
    public List<Interest>? Interests { get; set; }
}
