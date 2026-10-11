namespace wt_lab3_3mvc_vinnik.Models;

public class BankAccount
{
    public int Id { get; set; }

    public string OwnerName { get; set; } = "";

    public string AccountType { get; set; } = "";

    public decimal Balance { get; set; }

    public bool IsActive { get; set; }
}
