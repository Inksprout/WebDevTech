using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace AccountApplication
{
    class AccountManager
    {
        List<Account> accounts;
        public void readJson()
        {
            using (StreamReader file = new StreamReader("../../../accountData.json"))
            {
                string json = file.ReadToEnd();
                accounts = JsonConvert.DeserializeObject<List<Account>>(json);
            }
        }

        public void displayAccounts()
        {
            foreach(Account account in accounts)
            {
                Console.WriteLine("id: {0}, name: {1}, balance: {2}", account.id, account.name, account.balance);
            }
        }

        public void withdrawMoney()
        {
            Console.WriteLine("Which account to withdraw from?");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How much to withdraw?");
            double amount = Double.Parse(Console.ReadLine());

            foreach (Account account in accounts)
            {
                if (account.id == id)
                {
                    if(amount <= account.balance)
                    {
                        Console.WriteLine("you withdrew ${0}", amount);
                        account.balance = account.balance - amount;
                        updateAccounts();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("not enough money");
                        return;
                    }
                }
            }
            Console.WriteLine("no account for this id");
        }

        public void updateAccounts()
        {
                File.WriteAllText(@"../../../accountData.json", JsonConvert.SerializeObject(accounts, Formatting.Indented));    
        }
    }       
}
