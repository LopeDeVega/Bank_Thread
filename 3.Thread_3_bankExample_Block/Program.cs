// See https://aka.ms/new-console-template for more information

//string finishTransaction;

//BankAccount class iniciate
using System.Linq.Expressions;

BankAccout myAccount = new BankAccout(2500);

//List of Threads 
Thread[] listThread = new Thread[10]; 

//string endTransaction()
//{
   // Console.WriteLine("Do you want to continue with another transaction? ");
    
    //Each thread calling callWithraw method
    for(int i =0; i< listThread.Length; i++) {
        
        Thread t = new Thread(myAccount.callWithdraw);
        //Naming threads
        t.Name = i.ToString();
        listThread[i] = t;

    }

    //Starting threads
    for(int i =0; i<10; i++)
    {
        listThread[i].Start();
        Thread.Sleep(1000);
    }

    //return finishTransaction = Console.ReadLine();
//};


//do { 

//Console.WriteLine("How much money do you want to get ?");

//myAccount.amountWithDrawMoney = Int32.Parse(Console.ReadLine());

//finishTransaction = endTransaction();

//} while (finishTransaction != "No") ;



public class BankAccout
{
    private Object lockThread = new Object();
    public double money { get; set; }

    //public double amountWithDrawMoney { get; set; }

    public BankAccout(double money)
    {
        this.money = money;
    }

    public double withdrawMoney(double getMoney)
    {
        double currentBalance;

        if (this.money < getMoney)
        {
            Console.WriteLine("There isn't enough money in your account, current balance" + Thread.CurrentThread.Name);
            return this.money;
        }

        //lock the thread, so only one thread get execuated each time
        //When one is finish next get in.
        //Lock need a object as a parameter so we created a object from Object class
        lock (lockThread)
        {
            if (this.money >= getMoney)
            {
                currentBalance = this.money - getMoney;

                this.money = currentBalance;
            }
        }
        
        Console.WriteLine($"Current Balance: {this.money}$, {Thread.CurrentThread.Name}");
        return this.money;
    }

    public void callWithdraw()
    {
        Console.WriteLine($"Current Thread Withdrawing money: {Thread.CurrentThread.Name}");
        withdrawMoney(500);
    }



} 
