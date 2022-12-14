using System;
using System.Collections.Generic;
using System.Text;

namespace programmingObjectOrientedExcercise
{
    class BankAccount
    {
        public BankAccount(string customer_type,
            string account_number,
            Customer holder,
            int balance,
            int total_limit,
            bool free_pix,
            int daily_pix_limit
        )
        {
            this.customer_type = customer_type;
            this.account_number = account_number;
            this.holder = holder;
            this.balance = balance;
            this.total_limit = total_limit;
            this.limit_available = total_limit;
            this.free_pix= free_pix;
            this.daily_pix_limit = daily_pix_limit;
        }

        string customer_type { get; set; }
        string account_number { get; set; }
        Customer holder { get; set; }
        int balance { get; set; }
        int total_limit { get; set; }
        int limit_available { get; set; }
        bool free_pix { get; set; }
        int daily_pix_limit { get; set; }

        public string deposit(int receive)
        {
            try
            {
                if (this.balance < 0)
                {
                    this.limit_available += receive;
                }

                this.balance += receive;
                return "Successfully deposit value.";
            }
            catch (Exception ex)
            {
                return $"Error on deposit value, error: {ex.Message}";
            }
        }

        public string withdraw(int value)
        {
            try
            {
                if (value > 200)
                {
                    throw new HandleErrorException("The withdraw limit is $200");
                }

                if (balance < 0 || this.balance < value)
                {
                    if (value <= this.limit_available)
                    {
                        this.limit_available -= value;
                    }
                    else
                    {
                        throw new HandleErrorException("Limit not available to withdraw.");
                    }
                }
                else
                {
                    this.balance -= value;
                }
                return "Succesfully withdraw";
            }
            catch (HandleErrorException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return $"Error on withdraw value, error: {ex.Message}";
            }
        }

        public void showBalance()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine($"Account: {this.account_number}");
            Console.WriteLine($"Balance: {this.balance}");
            Console.WriteLine($"Total limit: {this.total_limit}");
            Console.WriteLine($"Available limit: {this.limit_available}");
            Console.WriteLine("\n");
        }

        public string transferBalance(int value, BankAccount toAccount)
        {
            try
            {
                if (value > 150)
                {
                    throw new HandleErrorException("The transfer limit is $200");
                }

                // enter transfer type
                int transferOption = 0;

                Console.WriteLine("Enter transfer option.");
                Console.WriteLine("0 -> PIX");
                Console.WriteLine("1 -> TED");
                transferOption = int.Parse(Console.ReadLine());

                if (transferOption == 0)
                {
                    //PIX
                    if (!this.free_pix)
                    {
                        throw new HandleErrorException("The PIX transfer is unavailable");
                    }

                    // check daily limit
                    if (this.daily_pix_limit < value)
                    {
                        throw new HandleErrorException("The PIX transfer is unavailable, daily limit blocked this action");
                    }

                    this.balance -= value;
                    toAccount.balance += value;
                    Console.WriteLine("PIX has been successfully performed.");
                }
                else if (transferOption == 1)
                {
                    this.balance -= value;
                    toAccount.balance += value;
                    Console.WriteLine("TED has been successfully performed.");
                }
                else
                {
                    //error
                    throw new HandleErrorException("Invalid option");
                }

                return $"Succesfully transfer to {toAccount.account_number}";
            }
            catch (HandleErrorException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return $"Error on transfer value, error: {ex.Message}";
            }

        }
    }
}
