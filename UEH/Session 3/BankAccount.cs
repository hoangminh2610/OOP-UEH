using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2.Session_3
{
    public class BankAccount
    {
        // TODO 1: Declare private fields (_balance, _pin, _failedAttempts)
        private decimal _balance;
        private string _pin;
        private int _failedAttempts;

        // TODO 2: Declare public AccountHolder property (read-only)
        public string AccountHolder { get; }
        // TODO 3: Declare IsLocked property with a private setter
        public bool IsLocked
        {
            get 
            { 
                return _failedAttempts >= 3; 
            }
            private set { }
        }
        // Constructor
        public BankAccount(string accountHolder, decimal initialBalance, string initialPin)
        {
            AccountHolder = accountHolder;
            _balance = initialBalance > 0 ? initialBalance : 0;
            _pin = initialPin;
            _failedAttempts = 0;
            IsLocked = false;
        }

        // TODO 4: Implement Deposit method
        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error: Deposit amount must be positive.");
                return false;
            }
            _balance += amount;
            Console.WriteLine($"Successfully deposited {amount:C}.");
            return true;
        }

        // TODO 5: Implement Withdraw method
        public bool Withdraw(decimal amount, string inputPin)
        {
            if (IsLocked)
            {
                Console.WriteLine("Error: Account is locked due to multiple failed PIN attempts.");
                return false;
            }
            if (inputPin != _pin)
            {
                _failedAttempts++;
                if (_failedAttempts >= 3)
                {
                    Console.WriteLine("Error: Invalid PIN code. Account has been LOCKED for security!");
                }
                else
                {
                    Console.WriteLine($"Error: Invalid PIN code. (Attempt {_failedAttempts}/3)");
                }
                return false;
            }
            // Correct PIN -> reset failed attempts
            _failedAttempts = 0;
            if (amount <= 0)
            {
                Console.WriteLine("Error: Withdraw amount must be positive.");
                return false;
            }
            if (_balance < amount)
            {
                Console.WriteLine("Error: Insufficient funds.");
                return false;
            }
            _balance -= amount;
            Console.WriteLine($"Withdraw successful: {amount:C} withdrawn. New balance: {_balance:C}");
            return true;
        }

        // TODO 6: Implement GetBalance method (PIN required)
        public decimal GetBalance(string inputPin)
        {
            if (inputPin != _pin)
            {
                Console.WriteLine("Error: Invalid PIN code.");
                return -1m;
            }
            return _balance;
        }

        // TODO 7: Implement ChangePin method
        public bool ChangePin(string currentPin, string newPin)
        {
            if (currentPin != _pin)
            {
                Console.WriteLine("Change PIN failed: current PIN is incorrect.");
                return false;
            }
            if (string.IsNullOrEmpty(newPin) || newPin.Length != 4 || !newPin.All(char.IsDigit))
            {
                Console.WriteLine("Change PIN failed: new PIN must be exactly 4 numeric digits.");
                return false;
            }
            _pin = newPin;
            Console.WriteLine("PIN changed successfully.");
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            BankAccount account = new BankAccount("John Doe", 500.00m, "1234");

            Console.WriteLine($"Account Holder: {account.AccountHolder}");

            // Direct field access is impossible! (Uncommenting below will cause compiler errors)
            // account._balance = 1000000m; 
            // account._pin = "0000";

            Console.WriteLine("\n--- 1. Testing Deposit ---");
            account.Deposit(-50m); // Should fail
            account.Deposit(200m); // Should succeed

            Console.WriteLine("\n--- 2. Testing Protected Balance View ---");
            account.GetBalance("9999"); // Wrong PIN
            decimal currentBalance = account.GetBalance("1234"); // Correct PIN
            Console.WriteLine($"Verified Balance: {currentBalance:C}");

            Console.WriteLine("\n--- 3. Testing Lockout Mechanism ---");
            account.Withdraw(100m, "0000"); // Attempt 1 (Wrong)
            account.Withdraw(100m, "1111"); // Attempt 2 (Wrong)
            account.Withdraw(100m, "2222"); // Attempt 3 (Wrong -> Locks Account)

            // Further attempts should fail immediately due to lock
            account.Withdraw(100m, "1234"); // Correct PIN, but account is now locked!

            Console.WriteLine("\n--- 4. Account Lock Status ---");
            Console.WriteLine($"Is account locked? {account.IsLocked}");
        }
    }
}
