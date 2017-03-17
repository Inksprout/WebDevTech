using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AccountApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountManager manager = new AccountManager();
            manager.readJson();
            manager.displayAccounts();
            manager.withdrawMoney();

            Console.ReadKey();
        }
    }
}
