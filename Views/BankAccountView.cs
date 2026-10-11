using wt_lab3_3mvc_vinnik.Models;

namespace wt_lab3_3mvc_vinnik.Views;

public class BankAccountView
{
    // Вывод списка банковских счетов
    public void ShowAccounts(List<BankAccount> accounts)
    {
        Console.WriteLine("=== СПИСОК БАНКОВСКИХ СЧЕТОВ ===");

        foreach (var account in accounts)
        {
            Console.WriteLine(
                $"{account.Id}. " +
                $"{account.OwnerName} | " +
                $"{account.AccountType} | " +
                $"{account.Balance} BYN | " +
                $"Активен: {account.IsActive}"
            );
        }
    }

    // Вывод одного банковского счета
    public void ShowAccount(BankAccount account)
    {
        Console.WriteLine("=== БАНКОВСКИЙ СЧЕТ ===");

        Console.WriteLine($"ID: {account.Id}");
        Console.WriteLine($"Владелец: {account.OwnerName}");
        Console.WriteLine($"Тип счета: {account.AccountType}");
        Console.WriteLine($"Баланс: {account.Balance} BYN");
        Console.WriteLine($"Активен: {account.IsActive}");
    }

    // Вывод сообщений пользователю
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
