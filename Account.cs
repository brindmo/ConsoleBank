using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

class Account
{
    private String password;
    private int accountNumber;
    private decimal balance;
    private List<decimal> history;

    public Account(String Pass, int Name)
    {
        accountNumber = Name;
        password = Pass;
        balance = 0;
        history = new List<decimal>();
    }

    public bool LogIn (String Pass, int Name)
    {
        if (Name == accountNumber && Pass == password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public decimal checkBalance ()
    {
        return balance;
    }

    public bool Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance = balance + amount;
            decimal record = amount;
            history.Add(record);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Withdrawal(decimal amount)
    {
        if (amount <= balance && amount > 0)
        {
            balance = (balance - amount);
            decimal record = (amount * -1);
            history.Add(record);
            return true;
        }
        else
        {
            return false;
        }
    }

    public int getAccountNumber()
    {
        return accountNumber;
    }

    public List<decimal> getHistory()
    {
        return history;
    }

    public bool checkPassword(String enteredPassword)
    {
        if (enteredPassword == password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
