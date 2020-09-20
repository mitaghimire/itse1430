/*
 * Mita Ghimire
 * ITSE 1430 
 * Lab 1 
 */
using System;
using System.Linq;

namespace Budget
{
    class Program
    {
        private static string AccountName, AccountNumber;
        private static decimal AccountBalance;

        static void Main ( string[] args )
        {
            Console.WriteLine("Mita-Budget");

            UntilValueCorrect();

            Menu();
        }




        private static void Menu ()
        {
            Console.WriteLine($"\nAdd Income : AI \nAdd Expense: AE \nQuit : Q");
            string keyPress;
            bool exit = false;
            do
            {
                keyPress = Console.ReadLine();

                switch (keyPress.ToUpper())
                {

                    case "AI":
                    AddIncomeValueCorrect();
                    exit = true;
                    break;
                    case "AE":
                    AddExpenseValueCorrect();
                    exit = true;
                    break;
                    case "Q":
                    Console.WriteLine($"Confirm to Quit? Y: N");
                    string quit = Console.ReadLine();
                    if (quit.ToUpper().Equals("Y"))
                        Environment.Exit(-1);
                    break;
                    default:
                    Console.WriteLine("Press correct key!!!\n");
                    break;
                }
            }
            while (exit != true);

        }
        
        private static void UntilValueCorrect ()
        {
            Console.WriteLine("AccountName:");
            string error = string.Empty;
            do
            {
                AccountName = Console.ReadLine();
                error = ReturnAlphaError(AccountName);
                if (!error.Equals(string.Empty))
                {
                    Console.WriteLine($"Error :{error}\n Please enter again!!!");
                }

            } while (error != string.Empty);

            Console.WriteLine("Account Number:");
            do
            {
                AccountNumber = Console.ReadLine();
                error = ReturnNumericError(AccountNumber);
                if (!error.Equals(string.Empty))
                {
                    Console.WriteLine($"Error :{error}\n Please enter again!!!");
                }

            } while (error != string.Empty);

            string accountBalance;

            Console.WriteLine("Balance:");
            do
            {
                accountBalance = Console.ReadLine();
                error = ReturnNumericError(accountBalance);
                if (!error.Equals(string.Empty))
                {
                    Console.WriteLine($"Error :{error}\n Please enter again!!!");
                }
            } while (error != string.Empty);

            AccountBalance = Convert.ToDecimal(accountBalance);

            DisplayAccountInfo();


        }



        private static void AddIncomeValueCorrect ()
        {
            Console.WriteLine("Amount +:");
            string error = string.Empty;
            string addIncome;
            do
            {
                addIncome = Console.ReadLine();
                error = ReturnNumericError(addIncome);
                if (!error.Equals(string.Empty))
                {
                    Console.WriteLine($"Error :{error}\n Please enter again!!!");
                }

            } while (error != string.Empty);

            AccountBalance = AccountBalance + Convert.ToDecimal(addIncome);

            Console.WriteLine("Description +:");
            string description;
            do
            {
                description = Console.ReadLine();
                error = ReturnAlphaError(description);
                if (!error.Equals(string.Empty))
                {
                    Console.WriteLine($"Error :{error}\n Please enter again!!!");
                }

            } while (error != string.Empty);



            Console.WriteLine("Category +:");
            string category = Console.ReadLine();


            string date = DateTime.Now.ToString("MM/dd/yyyy");


            DisplayAccountUpdated(description, category, date);
        }

        private static void AddExpenseValueCorrect ()
        {
            Console.WriteLine("Amount -:");
            string error = string.Empty;
            string addExpense;
            do
            {
                addExpense = Console.ReadLine();
                error = ReturnNumericError(addExpense);
                if (!error.Equals(string.Empty))
                {
                    Console.WriteLine($"Error :{error}\n Please enter again!!!");
                }

            } while (error != string.Empty);

            AccountBalance = AccountBalance - Convert.ToDecimal(addExpense);

            Console.WriteLine("Description +:");
            string description;
            do
            {
                description = Console.ReadLine();
                error = ReturnAlphaError(description);
                if (!error.Equals(string.Empty))
                {
                    Console.WriteLine($"Error :{error}\n Please enter again!!!");
                }

            } while (error != string.Empty);



            Console.WriteLine("Category +:");
            string category = Console.ReadLine();


            string date = DateTime.Now.ToString("MM/dd/yyyy");


            DisplayAccountUpdated(description, category, date);
        }

        private static void DisplayAccountUpdated ( string description, string category, string date )
        {
            Console.WriteLine($"Name:{AccountName} Account Number: {AccountNumber} Balance : {AccountBalance.ToString("C")} \n Description :{description} \n Category : {category} \n Date:{date}");
            Menu();
        }

        private static void DisplayAccountInfo ()
        {
            Console.WriteLine($"Name:{AccountName} Account Number: {AccountNumber} Balance : {AccountBalance.ToString("C")}");
        }
        private static bool CheckAlpha ( string value )
        {
            return value.All(char.IsLetter);
        }

        private static bool CheckNumeric ( string value )
        {
            return value.All(char.IsDigit);
        }

        private static bool CheckGreaterThanZero ( string value )
        {
            if (CheckNumeric(value))
                return Convert.ToDecimal(value) > 0;

            return false;
        }

        private static bool CheckBlank ( string value )
        {
            return String.IsNullOrEmpty(value);
        }

        private static string ReturnAlphaError ( string value )
        {
            if (CheckBlank(value))
                return "Field is required";
            if (!CheckAlpha(value))
                return "Only Alphabets are alllowed";
            return string.Empty;
        }



        private static string ReturnNumericError ( string value )
        {
            if (CheckBlank(value))
                return "Field is required";
            if (!CheckNumeric(value))
                return "Only Numerics are alllowed";
            if (!CheckGreaterThanZero(value))
                return "Should be greater than zero";
            return string.Empty;
        }


    }
}
