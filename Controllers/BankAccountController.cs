
using wt_lab3_3mvc_vinnik.Models;
using wt_lab3_3mvc_vinnik.Views;

namespace wt_lab3_3mvc_vinnik.Controllers;

public class BankAccountController
{
    private readonly List<BankAccount> accounts;
    private readonly BankAccountView view;

    public BankAccountController()
    {
        accounts = new List<BankAccount>
        {
            new BankAccount
            {
                Id = 1,
                OwnerName = "Иван Иванов",
                AccountType = "Обычный",
                Balance = 1500m,
                IsActive = true
            },
            new BankAccount
            {
                Id = 2,
                OwnerName = "Анна Петрова",
                AccountType = "Сберегательный",
                Balance = 3200m,
                IsActive = true
            },
            new BankAccount
            {
                Id = 3,
                OwnerName = "Мария Сидорова",
                AccountType = "Кредитный",
                Balance = 500m,
                IsActive = false
            }
        };

        view = new BankAccountView();
    }

    // Вывод всех счетов
    public void Index()
    {
        view.ShowAccounts(accounts);
    }

    // Поиск счета по ID
    public void Show(int id)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id);

        if (account == null)
        {
            view.ShowMessage("Счет не найден.");
            return;
        }

        view.ShowAccount(account);
    }

    // Добавление счета
    public void Add(BankAccount account)
    {
        accounts.Add(account);
        view.ShowMessage("Счет успешно добавлен.");
    }

    // Удаление счета
    public void Delete(int id)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id);

        if (account == null)
        {
            view.ShowMessage("Счет не найден.");
            return;
        }

        accounts.Remove(account);
        view.ShowMessage("Счет успешно удален.");
    }

    
    // Главное меню
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=== МЕНЮ БАНКА ===");
            Console.WriteLine("1. Показать все счета");
            Console.WriteLine("2. Найти счет по ID");
            Console.WriteLine("3. Добавить счет");
            Console.WriteLine("4. Удалить счет");
            Console.WriteLine("5. Найти счета по имени владельца");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            string? command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Index();
                    break;

                case "2":
                    ShowAccountByUserInput();
                    break;

                case "3":
                    AddAccountByUserInput();
                    break;

                case "4":
                    DeleteAccountByUserInput();
                    break;

                case "5":
                    SearchByOwnerUserInput();
                    break;

                case "0":
                    return;

                default:
                    view.ShowMessage("Неизвестная команда.");
                    break;
            }
        }
    }

    // Поиск счета по введенному ID
    private void ShowAccountByUserInput()
    {
        Console.Write("Введите ID счета: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Show(id);
    }

    // Добавление счета через консоль
    private void AddAccountByUserInput()
    {
        Console.Write("Введите ID нового счета: ");

        if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        if (accounts.Any(a => a.Id == id))
        {
            view.ShowMessage("Счет с таким ID уже существует.");
            return;
        }

        Console.Write("Введите имя владельца: ");
        string ownerName = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(ownerName))
        {
            view.ShowMessage("Имя владельца не может быть пустым.");
            return;
        }

        Console.Write("Введите тип счета: ");
        string accountType = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(accountType))
        {
            view.ShowMessage("Тип счета не может быть пустым.");
            return;
        }

        Console.Write("Введите баланс: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal balance)
            || balance < 0)
        {
            view.ShowMessage("Некорректный баланс.");
            return;
        }

        BankAccount account = new BankAccount
        {
            Id = id,
            OwnerName = ownerName,
            AccountType = accountType,
            Balance = balance,
            IsActive = true
        };

        Add(account);
    }

    // Удаление счета через консоль
    private void DeleteAccountByUserInput()
    {
        Console.Write("Введите ID счета для удаления: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Delete(id);
    }


    // Дополнительная операция: поиск по имени владельца
    public void SearchByOwner(string name)
    {
        var result = accounts
            .Where(a => a.OwnerName.Contains(
                name,
                StringComparison.OrdinalIgnoreCase
            ))
            .ToList();

        if (result.Count == 0)
        {
            view.ShowMessage("Счета не найдены.");
            return;
        }

        view.ShowAccounts(result);
    }

    // Ввод имени владельца пользователем
    private void SearchByOwnerUserInput()
    {
        Console.Write("Введите имя владельца: ");

        string name = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            view.ShowMessage("Имя не может быть пустым.");
            return;
        }

        SearchByOwner(name);
    }


}
