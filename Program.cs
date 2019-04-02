using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingLedger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            Account currAccount = null;
            bool initial = true;
            bool finished = false;

            while (finished == false)
            {
                if (initial == true)
                {
                    printInitialMessage();
                    String input = Console.ReadLine().ToUpper();
                    if (input == "X")
                    {
                        finished = true;
                        Console.WriteLine("Banking session closed out. Press enter to close the window");
                        Console.ReadLine();
                    }
                    else if (input == "N")
                    {
                        int newAccountNumber = accounts.Count() + 1;
                        Console.WriteLine("Congratulations, your new account number will be " + newAccountNumber + ".");
                        Console.WriteLine("Please enter a password below: ");
                        Console.WriteLine("");
                        String newPassword = Console.ReadLine();

                        currAccount = new Account(newPassword, newAccountNumber);
                        accounts.Add(currAccount);
                        Console.WriteLine("Your account has been created. Returning to the main menu.");
                        Console.WriteLine("");
                    }
                    else if(input == "B")
                    {
                        Console.WriteLine("Please enter your account number below: ");
                        Console.WriteLine("");

                        bool accountFound = false;
                        int accountNumber = -1;

                        String rawAccountNumber = Console.ReadLine();

                        try
                        {
                            accountNumber = int.Parse(rawAccountNumber);

                            for (int i = 0; i < accounts.Count(); i++)
                            {
                                if (accounts[i].getAccountNumber() == accountNumber)
                                {
                                    accountFound = true;
                                    currAccount = accounts[i];
                                }
                            }

                            if (accountFound == true)
                            {
                                Console.WriteLine("Account found. Please enter password.");
                                Console.WriteLine("");

                                String currPassword = Console.ReadLine();
                                bool passwordValid = currAccount.checkPassword(currPassword);

                                if (passwordValid == true)
                                {
                                    initial = false;
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid password. Returning to main menu.");
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account number not found. Returning to main menu.");
                                Console.WriteLine("");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please enter a valid account number. Returning to main menu.");
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid input. Returning to the main menu.");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    if (currAccount == null)
                    {
                        initial = true;
                    }
                    else
                    {
                        Console.WriteLine("WELCOME TO EBANK.");
                        Console.WriteLine("/////////////////");
                        Console.WriteLine("You are logged into account #" + currAccount.getAccountNumber() + ".");
                        Console.WriteLine("Enter B to check this account's balance.");
                        Console.WriteLine("Enter H to view this account's transaction history.");
                        Console.WriteLine("Enter D to make a deposit.");
                        Console.WriteLine("Enter W to make a withdrawal.");
                        Console.WriteLine("Enter L to log out of this account.");
                        Console.WriteLine("/////////////////");
                        Console.WriteLine("");

                        String input = Console.ReadLine().ToUpper();
                        if (input == "L")
                        {
                            currAccount = null;
                            initial = true;
                        }
                        else if (input == "B")
                        {
                            Console.WriteLine("Current balance of this account is " + string.Format("{0:C}", currAccount.checkBalance()) + ".");
                        }
                        else if (input == "H")
                        {
                            List<decimal> currHistory = currAccount.getHistory();
                            Console.WriteLine("Transaction History: ");
                            Console.WriteLine("");
                            if (currHistory.Count() == 0)
                            {
                                Console.WriteLine("This account has no transaction history.");
                            }
                            else
                            {
                                for (int i = 0; i < currHistory.Count(); i++)
                                {
                                    Console.WriteLine("{0:C}", currHistory[i]);
                                }

                                Console.WriteLine("");
                                Console.WriteLine("End of Transaction History");
                            }
                            Console.WriteLine("");
                        }
                        else if (input == "D")
                        {
                            Console.WriteLine("Deposits are rounded to the nearest cent. Please enter the amount you are depositing: ");
                            String rawDepositAmount = Console.ReadLine();
                            try
                            {
                                decimal depositAmount = decimal.Parse(rawDepositAmount);
                                depositAmount = Math.Round(depositAmount, 2);
                                bool depositSuccess = currAccount.Deposit(depositAmount);
                                if (depositSuccess == true)
                                {
                                    Console.WriteLine("Thank you for your deposit. Returning to account menu.");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.WriteLine("Deposit failed. Please enter a positive number when making deposits.");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a valid amount. Returning to account menu.");
                                Console.WriteLine("");
                            }
                            Console.WriteLine("");
                        }
                        else if (input == "W")
                        {
                            Console.WriteLine("Withdrawals are rounded to the nearest cent. Please enter the amount you wish to withdraw: ");
                            String rawWithdrawalAmount = Console.ReadLine();
                            try
                            {
                                decimal withdrawalAmount = decimal.Parse(rawWithdrawalAmount);
                                withdrawalAmount = Math.Round(withdrawalAmount, 2);
                                bool withdrawalSuccess = currAccount.Withdrawal(withdrawalAmount);
                                if (withdrawalSuccess == true)
                                {
                                    Console.WriteLine("Withdrawal successful. Returning to account menu.");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.WriteLine("Withdrawal failed. Do you have sufficient funds? Please check your account balance and enter a positive number when making withdrawals.");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a valid amount. Returning to account menu.");
                                Console.WriteLine("");
                            }
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid input. Returning to the main menu.");
                            Console.WriteLine("");
                        }
                    }
                }
            }

        }

        static void printInitialMessage()
        {
            Console.WriteLine("WELCOME TO EBANK.");
            Console.WriteLine("/////////////////");
            Console.WriteLine("Enter X to exit the application.");
            Console.WriteLine("Enter B to log in to your account.");
            Console.WriteLine("Enter N to create a new account with us.");
            Console.WriteLine("/////////////////");
            Console.WriteLine("");
        }
    }
}
