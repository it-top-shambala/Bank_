namespace Bank;

public class Account
{
    public Guid Id { get; }
    public string Name { get; init; }

    private double _balance;
    public double Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
            {
                return;
            }

            _balance = value;
        }
    }

    public bool IsDelete { get; set; }

    public Account(string name, double balance = 0)
    {
        Id = Guid.NewGuid();
        Name = name;
        Balance = balance;
        IsDelete = false;
    }

    public void Deposit(double money)
    {
        Balance += money;
    }

    public bool Withdraw(double money)
    {
        if (!(money <= Balance)) return false;
        
        Balance -= money;
        return true;

    }
}