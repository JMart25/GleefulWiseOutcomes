using System;

namespace GreenvilleRevenue
{
    class Program
    {
        const int REVENUE_PER_CONTESTANT = 25;
        const int MIN_CONTESTANTS = 0;
        const int MAX_CONTESTANTS = 30;

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMotto();
                DisplayMenu();
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    CalculateRevenue();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Thank you for using the Greenville Revenue App, good-bye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void DisplayMotto()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("*  The stars shine in Greenville.  *");
            Console.WriteLine("************************************");
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nPlease Enter the following number below from the following menu:");
            Console.WriteLine("1. CALCULATE Greenville Revenue Year-Over-Year");
            Console.WriteLine("2. Exit");
        }

        static void CalculateRevenue()
        {
            int lastYearContestants = GetValidContestants("last");
            int thisYearContestants = GetValidContestants("this");

            int thisYearRevenue = thisYearContestants * REVENUE_PER_CONTESTANT;

            Console.WriteLine($"\nLast year's competition had {lastYearContestants} contestants, and this year's has {thisYearContestants} contestants");
            Console.WriteLine($"Revenue expected this year is ${thisYearRevenue}");

            if (thisYearContestants > 2 * lastYearContestants)
            {
                Console.WriteLine("The competition is bigger than ever!");
            }
            else if (thisYearContestants > lastYearContestants)
            {
                Console.WriteLine("The competition is more than twice as big this year!");
            }
            else
            {
                Console.WriteLine("A tighter race this year! Come out and cast your vote!");
            }

            Console.WriteLine();
        }

        static int GetValidContestants(string year)
        {
            int contestants;
            do
            {
                Console.Write($"Enter number of contestants {year} year (between {MIN_CONTESTANTS} and {MAX_CONTESTANTS}): ");
                bool isValid = int.TryParse(Console.ReadLine(), out contestants);

                if (!isValid || contestants < MIN_CONTESTANTS || contestants > MAX_CONTESTANTS)
                {
                    Console.WriteLine($"Invalid input. Please enter a number between {MIN_CONTESTANTS} and {MAX_CONTESTANTS}.");
                    contestants = -1; // Force re-entry
                }
            } while (contestants < MIN_CONTESTANTS || contestants > MAX_CONTESTANTS);

            return contestants;
        }
    }
}
