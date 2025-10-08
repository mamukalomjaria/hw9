using System.Linq.Expressions;

internal class Program
{
    public abstract class Animal
    {
        public string Name { get; set; }

        protected Animal(string name)
        {
            this.Name = name;
        }

        public abstract void MakeSound();
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Dog barks: Woof!");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Cat meows: Meow!");
        }
    }

    ///next

    public abstract class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; protected set; }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");

            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public abstract void Withdraw(decimal amount);

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");
            Balance += amount;
        }
    }

    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountNumber, decimal initialBalance) : base(accountNumber, initialBalance)
        {
        }

        public override void Withdraw(decimal amount)
        {
            if (Balance > amount)
            {
                throw new InvalidOperationException("No funds!");
            }
           Balance -= amount;
        }
    }

    public class LoanAccount : BankAccount
    {
        public LoanAccount(string accountNumber, decimal initialBalance) : base(accountNumber, initialBalance)
        {

        }

        public override void Withdraw(decimal amount)
        {
            throw new InvalidOperationException("Withdrawals are not allowed from a loan account.");
        }

        public override void Deposit(decimal amount)
        {
            Balance -= amount;
        }
    }

    public class TransactionService
    {
        public void Transfer(BankAccount from, BankAccount to, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Transfer amount must be positive.");

            try
            {
                from.Withdraw(amount);
                to.Deposit(amount);
                Console.WriteLine($"Transfer of {amount:C} from {from.AccountNumber} to {to.AccountNumber} successful.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Transfer failed: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid transaction: {ex.Message}");
            }

        }
    }


    public abstract class Weapon
    {

    }

    public class Piston : Weapon { }
    public class Sniper : Weapon { }
    public class SMG : Weapon { }

    public class Player
    {

    }


    public static void Main(string[] args)
    {
        //try
        //{
        //    Animal[] animals = new Animal[]{
        //    new Dog("Ruby"),
        //    new Cat("Fiso")
        //};

        //    foreach (var anim in animals)
        //    {
        //        anim.MakeSound();
        //    }
        //}
        //catch (ArgumentException ex)
        //{
        //    Console.WriteLine($"{ex.Message}");
        //}

        //try
        //{
        //    var checking1 = new CheckingAccount("CHK1001", 500);
        //    var checking2 = new CheckingAccount("CHK2002", 300);
        //    var loan1 = new LoanAccount("LOAN3003", 1000);

        //    var service = new TransactionService();

        //    Console.WriteLine($"Starting balances:");
        //    Console.WriteLine($"Checking1: {checking1.Balance}");
        //    Console.WriteLine($"Checking2: {checking2.Balance}");
        //    Console.WriteLine($"Loan1: {loan1.Balance}");
        //    Console.WriteLine();

        //    service.Transfer(checking1, checking2, 200);

        //    service.Transfer(checking2, loan1, 100);

        //    service.Transfer(loan1, checking1, 50);

        //    Console.WriteLine();
        //    Console.WriteLine("Final balances:");
        //    Console.WriteLine($"Checking1: {checking1.Balance}");
        //    Console.WriteLine($"Checking2: {checking2.Balance}");
        //    Console.WriteLine($"Loan1: {loan1.Balance}");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Unexpected error: {ex.Message}");
        //}
        //finally
        //{
        //    Console.WriteLine("Program finished.");
        //}



    }
}