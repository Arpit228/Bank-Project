using System;
using System.Collections.Generic;
using BankLibrary;

namespace BankProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Program o = new Program();
            BankRepository obj = new BankRepository();
            Console.WriteLine("Banking Application");
            System.Console.WriteLine("1. Add New Account\n2. Get an Account Detail\n3. Get All Account Details");
            System.Console.WriteLine("4. Deposit Amount\n5. Withdraw Amount\n6. Get All Transactions\n7. Menu\n8. Exit");
            
            int c = 0, n;
            double am;
            do{
                System.Console.WriteLine("\nEnter your choice: ");
                c = int.Parse(Console.ReadLine());
                switch(c)
            {
                case 1: System.Console.WriteLine("Enter Account No.: ");
                        n = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Enter Name: ");
                        string name = Console.ReadLine();
                        System.Console.WriteLine("Enter Address: ");
                        string addr = Console.ReadLine();
                        System.Console.WriteLine("Enter Balance: ");
                        double b = double.Parse(Console.ReadLine());
                        obj.NewAccount(new SBAccount(n, name, addr, b)); break;
                case 2: System.Console.WriteLine("Enter Account No.:");
                        n = int.Parse(Console.ReadLine());
                        System.Console.WriteLine(obj.GetAccountDetails(n)); break;
                case 3: List<SBAccount> list_ac = obj.GetAllAccounts();
                        if(list_ac.Count == 0)
                        {
                            System.Console.WriteLine("No accounts to display...");
                            break;
                        } 
                        foreach(SBAccount ac in list_ac)
                            System.Console.WriteLine(ac);
                        break;
                case 4: System.Console.WriteLine("Enter Account No. and Deposit Amount:");
                        n = int.Parse(Console.ReadLine());
                        am = double.Parse(Console.ReadLine()); 
                        obj.DepositAmount(n, am); break;
                case 5: System.Console.WriteLine("Enter Account No. and Withdraw Amount:");
                        n = int.Parse(Console.ReadLine());
                        am = double.Parse(Console.ReadLine()); 
                        obj.WithdrawAmount(n, am); break;
                case 6: System.Console.WriteLine("Enter Account No.:");
                        n = int.Parse(Console.ReadLine());
                        List<SBTransaction> list_tr = obj.GetTransactions(n); 
                        if(list_tr.Count == 0)
                        {
                            System.Console.WriteLine("No transactions to display...");
                            break;
                        } 
                        foreach(SBTransaction t in list_tr)
                            System.Console.WriteLine(t);break;
                case 7: System.Console.WriteLine("1. Add New Account\n2. Get an Account Detail\n3. Get All Account Details");
                        System.Console.WriteLine("4. Deposit Amount\n5. Withdraw Amount\n6. Get All Transactions\n7. Menu\n8. Exit"); break;
                case 8: System.Console.WriteLine("Exiting Application..."); break;
                default: System.Console.WriteLine("Invalid input"); break;
            }

            } while(c != 8);
            System.Console.WriteLine("");
        }
    }
}
