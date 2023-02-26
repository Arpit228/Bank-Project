using System;
using System.Collections.Generic;
using BankLibrary;

namespace BankProject
{
    class BankRepository : IBankRepository
    {
        static List<SBAccount> account = new List<SBAccount>();
        static List<SBTransaction> transaction = new List<SBTransaction>();
        static int t_count = 0;
        public void NewAccount(SBAccount acc)
        {
            account.Add(acc);
            System.Console.WriteLine("Account Added Successfully");
        }

        public List<SBAccount> GetAllAccounts(){
            return account;
        }

        public SBAccount GetAccountDetails(int accno)
        {
            
            foreach(SBAccount s in account)
            {
                if(s.AccountNumber == accno)
                {
                    return s;
                }
            }
            throw new BankException("Invalid Account Number...");
        }
        public void DepositAmount(int accno, double amt)
        {
            SBAccount account;
            try{
                account = GetAccountDetails(accno);

            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
                return;
            }
            account.CurrentBalance += amt;
            transaction.Add(new SBTransaction(t_count++, DateTime.Now, accno, account.CurrentBalance, "Deposit"));
            System.Console.WriteLine("Transaction Successful...");
        }

        public void WithdrawAmount(int accno, double amt)
        {
            SBAccount account;
            try{
                account = GetAccountDetails(accno);
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
                return;
            }

            if(account.CurrentBalance < amt)
            {
                throw new BankException("Insufficient Balance");
                return;
            }
                
            account.CurrentBalance -= amt;
            transaction.Add(new SBTransaction(t_count++, DateTime.Now, accno, account.CurrentBalance, "Withdraw"));
            System.Console.WriteLine("Transaction Successful...");
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
            List<SBTransaction> list = new List<SBTransaction>();
            foreach(SBTransaction t in transaction)
            {
                if(t.AccountNumber == accno)
                list.Add(t);
            }
            return list;
        }
    }
}