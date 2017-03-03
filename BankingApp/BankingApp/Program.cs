using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class Program {
        static void Main(string[] args)
        {
            Person person1 = new Person
            {
                Firstname = "bob",
                Lastname = "smith",
                Birthdate = new DateTime(1990, 6, 20),
            };

            Account account1 = new Account
            {
                BSB = "062620",
                Accountnumber = "12341234",
                Balance = 500.00,
                AccountHolder = person1,
            };
            account1.PrintBankDetails();
            Console.WriteLine(account1.Balance);
            Console.WriteLine("Type amount to withdraw:");
            double withdrawalAmount = Convert.ToDouble(Console.ReadLine());
            account1.withdrawMoney(withdrawalAmount);
            Console.WriteLine(account1.Balance);
            Console.ReadKey();
        }

        
    }
    class Person {
        public Person() { }
        // customer first name

        // if the getter or setter is private only the instance of the class can get/set its own value
        public string Firstname { get; set; }
        /* the line above is equivalent to this:
        private string lastName;
        public string LastName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        */
        public string Lastname { get; set; }
        // Add the persons date of birth too
        public DateTime Birthdate { get; set; }

    }
    class Account {
        // account BSB
        // account number
        // account balance
        // account holder

        public string BSB { get; set; }
        public string Accountnumber { get; set; }
        public double Balance { get; set; }

        public Person AccountHolder { get; set; }

        public void withdrawMoney( double amount) {
            if (amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal");
            }
        }
        public void PrintBankDetails()
        {
            Console.WriteLine("Bank Details");
            Console.WriteLine("BSB: {0}", BSB);
            Console.WriteLine("number: {0}", Accountnumber);
            Console.WriteLine("balance: {0}", Balance);
            Console.WriteLine("owner: {0} {1}", AccountHolder.Firstname, AccountHolder.Lastname);
        }
    }
}
