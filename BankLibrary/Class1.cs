using System;
using System.Collections;
using System.Collections.Generic;

namespace BankLibrary
{
    public class SBAccount
    {
        public int AccountNumber {get; set;}
        public string CustomerName {get; set;}
        public string CustomerAddress {get; set;}
        public double CurrentBalance {get; set;}

        public SBAccount() {}

        public SBAccount(int acno, string name, string addr, double bal)
        {
            AccountNumber = acno;
            CustomerAddress = addr;
            CustomerName = name;
            CurrentBalance = bal;
        }

        public override string ToString()
        {
            return "A/c No.: " + AccountNumber + "  Name: " + CustomerName + "  Address: " + CustomerAddress + "  Balance: " + CurrentBalance;
        }
    }

    public class SBTransaction
    {
        public int TransactionId {get; set;}
        public DateTime TransactionDate {get; set;}
        public int AccountNumber {get; set;}
        public double Amount {get; set;}
        public string TransactionType {get; set;}

        public SBTransaction() {}

        public SBTransaction(int id, DateTime date, int acno, double amt, string type)
        {
            TransactionId = id;
            TransactionDate = date;
            TransactionType = type;
            AccountNumber = acno;
            Amount = amt;
        }

        public override string ToString()
        {
            return "ID.: " + TransactionId + "  A/c No.: " + AccountNumber + "  Amount: " + Amount + "  Type: " + TransactionType + "  Date: " + TransactionDate;
        }
    }

    public interface IBankRepository
    {
        void NewAccount(SBAccount acc);
        List<SBAccount> GetAllAccounts();
        SBAccount GetAccountDetails(int accno);
        void DepositAmount(int accno, double amt);
        void WithdrawAmount(int accno, double amt);
        List<SBTransaction> GetTransactions(int accno);
    }

    public class BankException : ApplicationException
    {
        public BankException(string message):base(message)
        {

        }
    }

}
