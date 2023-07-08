namespace Bank;

public static class AdminConsole
{
    public static void PrintAccounts(IEnumerable<Account> accounts)
    {
        foreach (var account in accounts)
        {
            PrintAccountAll(account);
        }
    }

    public static void PrintAccount(Account account)
    {
        ConsoleHelper.PrintInfo($"{account.Id} : {account.Name}, {account.Balance}");
    }
    public static void PrintAccountAll(Account account)
    {
        var a = account.IsDelete ? "DELETED" : "ACTIVE";
        ConsoleHelper.PrintInfo($"{account.Id} : {account.Name}, {account.Balance} <{a}>");
    }

    public static void PrintMenu()
    {
        ConsoleHelper.PrintInfo("= M E N U =");
        ConsoleHelper.PrintInfo("1. Показать все счета банка");
        ConsoleHelper.PrintInfo("2. Поиск счетов по имени");
        ConsoleHelper.PrintInfo("3. Поиск счета по ID");
        ConsoleHelper.PrintInfo("4. Открыть счёт");
        ConsoleHelper.PrintInfo("5. Закрыть счёт");
        ConsoleHelper.PrintInfo("6. Внести деньги на счёт");
        ConsoleHelper.PrintInfo("7. Снять деньги со счёта");
        ConsoleHelper.PrintInfo("8. Перевести с одного счёта на другой");
        ConsoleHelper.PrintInfo("0. Завершить работы");
    }

    public static Account? GetAccount(BankDB bank) //BUG
    {
        var inputId = ConsoleHelper.Input("Введите ID: ");
        Guid.TryParse(inputId, out var id);
        return bank.FindById(id);
    }
}