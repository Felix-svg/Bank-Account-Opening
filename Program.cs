using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BankAccountOpening;

class Program
{
    static void Main(string[] args)
    {
        bool banking = false;

        do
        {
            User user = new();
            MainMenu(user);

            Console.WriteLine("Wish to continue? (Y/N)");
            string userChoice = Console.ReadLine().ToUpper().Trim();
            if (userChoice == "Y")
            {
                banking = true;
            }
        } while (banking == true);
    }

    static public List<User> users = new List<User>();

    static void MainMenu(User user)
    {
        Console.WriteLine("Choose an option");
        Console.WriteLine("1. Registration");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Exit");

        string userChoice = Console.ReadLine();
        if (userChoice == "1")
        {
            Registration(user);
        }
        else if (userChoice == "2")
        {
            Login(user);
        }
        else if (userChoice == "3")
        {
            Environment.Exit(1);
        }
    }

    static void SubMenu(User user)
    {
        Console.WriteLine("Choose an option");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Check balance");
        Console.WriteLine("4. Exit");

        string userChoice = Console.ReadLine();
        if (userChoice == "1")
        {
            Deposit(user);
        }
        else if (userChoice == "2")
        {
            Withdraw(user);
        }
        else if (userChoice == "3")
        {
            CheckBalance(user);
        }
        else if (userChoice == "4")
        {
            MainMenu(user);
        }
    }

    static void Registration(User user)
    {
        Console.WriteLine("Enter your name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter your initial balance");
        decimal balance = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter your gender");
        string gender = Console.ReadLine();
        Console.WriteLine("Enter your phone number");
        string phone = Console.ReadLine();
        Console.WriteLine("Enter your mail id");
        string mailId = Console.ReadLine();
        Console.WriteLine("Enter your date of birth");
        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        // enter user details
        user.ID = GenerateId(user);
        user.Balance = balance;
        user.Gender = gender;
        user.Phone = phone;
        user.MailId = mailId;
        user.DateOfBirth = dob;

        // save the user to list
        users.Add(user);
    }

    static string validatedId;

    static string Login(User user)
    {
        Console.WriteLine("Enter ID");
        string userId = Console.ReadLine();
        foreach (User user1 in users)
        {
            if (user1.ID == userId)
            {
                validatedId = userId;
                SubMenu(user);
                break;
            }
            else
            {
                Console.WriteLine("Invalid user ID");
            }
        }
        return validatedId;
    }

    static void Deposit(User user)
    {
        string id = validatedId;
        foreach (User user1 in users)
        {
            if (user1.ID == id)
            {
                Console.WriteLine("Enter amount to deposit");
                decimal depositAmount = decimal.Parse(Console.ReadLine());
                user1.Balance += depositAmount;
                Console.WriteLine($"Your new balance is {user1.Balance}");
            }
        }
    }

    static void Withdraw(User user)
    {
        string id = validatedId;
        foreach (User user1 in users)
        {
            if (user1.ID == id)
            {
                Console.WriteLine("Enter amount to withdraw");
                decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                user1.Balance -= withdrawAmount;
                Console.WriteLine($"Your new balance is {user1.Balance}");
            }
        }
    }

    static void CheckBalance(User user)
    {
        string id = validatedId;
        foreach (User user1 in users)
        {
            if (user1.ID == id)
            {
                Console.WriteLine($"Your balance is {user1.Balance}");
            }
        }
    }

    static string GenerateId(User user)
    {
        string ID = $"HDFC100{1 + users.Count}";
        user.ID = ID;
        return user.ID;
    }
}