// See https://aka.ms/new-console-template for more information

string finishTransaction;

BankAccout myAccount = new BankAccout(2500);

string endTransaction()
{
    Console.WriteLine("Do you want to continue with another transaction? ");
    return finishTransaction = Console.ReadLine();
};


do { 

Console.WriteLine("How much money do you want to get ?");

double withdraw = Int32.Parse(Console.ReadLine());

double resutl = myAccount.withdrawMoney(withdraw);

Console.WriteLine($"Your current balance: {resutl}$");

finishTransaction = endTransaction();

} while (finishTransaction != "No") ;



public class BankAccout
{
    public double money { get; set; }

    public BankAccout(double money)
    {
        this.money = money;
    }

    public double withdrawMoney(double getMoney)
    {
        double currentBalance;

        if (this.money < getMoney)
        {
            Console.WriteLine("There isn't enough money in your account, current balance");
            return this.money;
        }

        if(this.money >= getMoney)
        {
            currentBalance  = this.money - getMoney;

            Console.WriteLine($"Current Balance: {currentBalance}$");
            
            this.money = currentBalance;
            return currentBalance;
        }
        
        Console.WriteLine($"Current Balance: {this.money}$");
        return this.money;
    }



} 
