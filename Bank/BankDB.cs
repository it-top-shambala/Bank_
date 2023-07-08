namespace Bank;

public class BankDB
{
    public List<Account> Accounts { get; }

    public BankDB()
    {
        Accounts = new List<Account>();
    }

    public Account? FindById(Guid id)
    {
        foreach (var account in Accounts)
        {
            if (account.Id == id)
            {
                return account;
            }
        }

        return null;
    }

    public IEnumerable<Account> FindAllByName(string name)
    {
        var list = new List<Account>();

        foreach (var account in Accounts)
        {
            if (account.Name == name)
            {
                list.Add(account);
            }
        }

        return list;
        
        /*
        foreach (var account in Accounts)
        {
            if (account.Name == name)
            {
                yield return account;
            }
        }
        */
    }

    public Account OpenAccount(string name, double balance = 0)
    {
        var account = new Account(name, balance);
        Accounts.Add(account);
        return account;
    }

    public void CloseAccount(Guid id)
    {
        var account = FindById(id);
        if (account is not null)
        {
            account.IsDelete = true;
        }
    }

    public static bool Transaction(Account sourceAccount, Account distanceAccount, double money)
    {
        if (!sourceAccount.Withdraw(money)) return false;
        
        distanceAccount.Deposit(money);
        return true;
    }
}