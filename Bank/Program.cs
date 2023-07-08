using Bank;

var bank = new BankDB();
Account? currentAccount = null;

ConsoleHelper.PrintInfo("*** BANK ADMIN ***");
Console.WriteLine();

bool exit = false;
do
{
    AdminConsole.PrintMenu();

    var input = ConsoleHelper.Input("Введите пунк меню: ");
    switch (input)
    {
        case "0":
            exit = true;
            break;
        case "1": //1. Показать все счета банка
            AdminConsole.PrintAccounts(bank.Accounts);
            break;
        case "2": //2. Поиск счетов по имени
        {
            var name = ConsoleHelper.Input("Введите имя: ");
            var accounts = bank.FindAllByName(name);
            AdminConsole.PrintAccounts(accounts);
        }
            break;
        case "3": //3. Поиск счета по ID
        {
            currentAccount = AdminConsole.GetAccount(bank);
            if (currentAccount is not null)
            {
                AdminConsole.PrintAccount(currentAccount);
            }
        }
            break;
        case "4": //4. Открыть счёт
        {
            var name = ConsoleHelper.Input("Введите имя: ");
            var money = Convert.ToDouble(ConsoleHelper.Input("Введите начальный баланс: "));
            currentAccount = bank.OpenAccount(name, money);
            AdminConsole.PrintAccount(currentAccount);
        }
            break;
        case "5": //5. Закрыть счёт
        {
            if (currentAccount is not null)
            {
                bank.CloseAccount(currentAccount.Id);
                AdminConsole.PrintAccountAll(currentAccount);
            }
        }
            break;
        case "6": //6. Внести деньги на счёт
        {
            var money = Convert.ToDouble(ConsoleHelper.Input("Введите количество денег для внесения на счёт: "));
            currentAccount?.Deposit(money);
            /*
            if (currentAccount is not null)
            {
                currentAccount.Deposit(money);
            }
            */
            
            AdminConsole.PrintAccount(currentAccount);
        }
            break;
        case "7": //7. Снять деньги со счёта
        {
            var money = Convert.ToDouble(ConsoleHelper.Input("Введите количество денег для снятия со счёта: "));
            currentAccount?.Withdraw(money);
            AdminConsole.PrintAccount(currentAccount);
        }
            break;
        case "8": //8. Перевести с одного счёта на другой
        {
            var source = AdminConsole.GetAccount(bank);
            var distance = AdminConsole.GetAccount(bank);
            var money = Convert.ToDouble(ConsoleHelper.Input("Введите количество денег для перевода на другой счёт: "));
            var result = BankDB.Transaction(source, distance, money);
            if (result)
            {
                ConsoleHelper.PrintInfo("OK");
                AdminConsole.PrintAccount(source);
                AdminConsole.PrintAccount(distance);
            }
            else
            {
                ConsoleHelper.PrintError("Error");
            }
        }
            break;
    }
    
} while(!exit);

ConsoleHelper.PrintInfo("До свидания...");