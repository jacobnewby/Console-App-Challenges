using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_Challenge_Repository;

namespace _04_Challenge_Console
{
    internal class ProgramUI
    {
        OutingRepo _outingRepo = new OutingRepo();
        OutingContent _content = new OutingContent();

        public ProgramUI()
        {

        }

        public void Run()
        {
            _outingRepo.SeedList();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("\nEnter a menu choice: \n" +
                    "1. See all outings\n" +
                    "2. Add an outing\n" +
                    "3. Display cost for all outings\n" +
                    "4. Display cost for specific outings\n" +
                    "5. Exit\n");
                string userInput = Console.ReadLine();
                int userChoice = int.Parse(userInput);

                switch (userChoice)
                {
                    case 1:
                        SeeAllOutings();
                        break;
                    case 2:
                        AddOutingToList();
                        break;
                    case 3:
                        TotalCostAllOutings();
                        break;
                    case 4:
                        TotalCostSpecificOutings();
                        break;
                    case 5:
                        continueToRun = false;
                        break;
                }
            }
        }

        public void SeeAllOutings()
        {
            List<OutingContent> outingList = _outingRepo.GetOutingList();

            foreach (OutingContent content in outingList)
            {
                Console.WriteLine($"\nOuting Type: {content.Type}\n" +
                    $"People Attended: {content.PeopleAttended}\n" +
                    $"Date: {content.Date}\n" +
                    $"Cost Per Person: {content.CostPerPerson}\n" +
                    $"Cost For Event: {content.CostForEvent}\n");
            }
            Console.WriteLine("Please hit any key to continue... ");
            Console.ReadKey();
        }

        public void AddOutingToList()
        {
            Console.WriteLine("Enter Outing Type: \n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            string typeAsString = Console.ReadLine();
            int TypeAsInt = int.Parse(typeAsString);
            OutingType type = (OutingType)TypeAsInt;

            Console.WriteLine("Enter the Amount of People who Attended: ");
            string attendedAsString = Console.ReadLine();
            int peopleAttended = int.Parse(attendedAsString);

            Console.WriteLine("Enter Date of Outing: (Example: 9/1/2001) ");
            string dateString = Console.ReadLine();
            DateTime date = DateTime.Parse(dateString);

            Console.WriteLine("Enter Cost Per Person: ");
            string costPerPersonString = Console.ReadLine();
            decimal costPerPerson = decimal.Parse(costPerPersonString);

            //Console.WriteLine("Enter Cost of Event: ");
            //string costForEventString = Console.ReadLine();
            //decimal costForEvent = decimal.Parse(costForEventString);

            OutingContent content = new OutingContent(type, peopleAttended, date, costPerPerson);
            _outingRepo.AddToList(content);
        }

        public void TotalCostAllOutings()
        {
            decimal total = _outingRepo.CombinedCostOfAllOutingsGet();
            Console.WriteLine($"The total cost of all outings is: {total}");
            Console.WriteLine("Please hit any key to continue... ");
            Console.ReadKey();
        }

        public void TotalCostSpecificOutings()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("\nEnter which type of outings you would like to see the cost of: \n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n" +
                    "5. Exit\n");
                string userInput = Console.ReadLine();
                int userChoice = int.Parse(userInput);

                switch (userChoice)
                {
                    case 1:
                        decimal totalGolf = _outingRepo.CombinedTypeCostGolf();
                        Console.WriteLine($"The total cost for golf is: {totalGolf}");
                        break;
                    case 2:
                        decimal totalBowling = _outingRepo.CombinedTypeCostBowling();
                        Console.WriteLine($"The total cost for bowling is: {totalBowling}");
                        break;
                    case 3:
                        decimal totalPark = _outingRepo.CombinedTypeCostAmusementParks();
                        Console.WriteLine($"The total cost for Amusement Parks is: {totalPark}");
                        break;
                    case 4:
                        decimal totalConcert = _outingRepo.CombinedTypeCostConcert();
                        Console.WriteLine($"The total cost for concerts is: {totalConcert}");
                        break;
                    case 5:
                        continueToRun = false;
                        break;
                }
                Console.WriteLine("\nPlease hit any key to continue... ");
                Console.ReadKey();
            }
        }
    }
}
