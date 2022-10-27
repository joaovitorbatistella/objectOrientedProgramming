using System;

namespace programmingObjectOrientedExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
                Console.WriteLine("Banking system project is running!");

                Customer c1 = new Customer("João Vítor Batistella",
                                           "02227168005",
                                           new DateTime(2002, 02, 18, 16, 45, 0),
                                           "Rua Almirante Barroso, nº 128 - Centro, Tapera - RS, Brasil",
                                           "+5554991798405");

                if (!c1.majority())
                {
                    throw new HandleErrorException("Customer is underage");
                }

                BankAccount ba1 = new BankAccount("phisic person", "010032-1", c1, 5000, 2000, true, 500);
                Console.WriteLine("Successfully created bank account");
                ba1.showBalance();



                Customer c2 = new Customer("Lucas Lammel",
                                           "02526525633",
                                           new DateTime(2002, 08, 26, 0, 00, 0),
                                           "Rua de Tapera, nº 24 - Progresso, Tapera - RS, Brasil",
                                           "+5554999898999");

                if (!c2.majority())
                {
                    throw new HandleErrorException($"Customer is underage");
                }

                BankAccount ba2 = new BankAccount("phisic person", "020141-2", c2, 5500, 1900, false, 400);
                Console.WriteLine("Successfully created bank account");
                ba2.showBalance();


                ba1.transferBalance(100, ba2);

                ba1.showBalance();
                ba2.showBalance();


                ba1.deposit(500);

                ba1.showBalance();
                ba2.showBalance();


                ba2.withdraw(50);

                ba1.showBalance();
                ba2.showBalance();
            }
            catch (HandleErrorException ex)
            {
                Console.WriteLine($"Error: { ex.Message }");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }
    }
}
