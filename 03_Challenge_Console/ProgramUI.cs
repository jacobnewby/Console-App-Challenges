using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Challenge_Repository;

namespace _03_Challenge_Console
{
    internal class ProgramUI
    {
        BadgeRepo _badgeRepo = new BadgeRepo();
        BadgeContent _content = new BadgeContent();
        Dictionary<int, List<BadgeContent>> _badgeDictionary = new Dictionary<int, List<BadgeContent>>();
        public ProgramUI()
        {

        }

        public void Run()
        {
            _badgeRepo.SeedList();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("\nEnter a menu item: \n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. See all badges\n" +
                    "4. Exit\n");
                string userInput = Console.ReadLine();
                int userNumber = int.Parse(userInput);

                switch (userNumber)
                {
                    case 1:
                        AddBadge();
                        break;
                    //case 2:
                    //    EditBadge();
                    //    break;
                    case 3:
                        SeeAllBadges();
                        break;
                    case 4:
                        continueToRun = false;
                        break;
                }
            }
        }

        public void SeeAllBadges()
        {
            Dictionary<int, List<BadgeContent>> badgeDictionary = _badgeRepo.GetContentDictionary();
            //List<BadgeContent> doorList = _badgeRepo.GetContentList();

            foreach (KeyValuePair<int, List<BadgeContent>> contentID in badgeDictionary)
            {
                Console.WriteLine($"\nBadgeID: {contentID.Key}\n");
                foreach (List<BadgeContent> contentDoor in badgeDictionary.Values)
                {
                    Console.WriteLine($"Doors: {contentDoor[0].DoorNames}");
                }
            }
            Console.WriteLine("\nPlease hit any key to continue... ");
            Console.ReadKey();
        }

        public void AddBadge()
        {
            List<BadgeContent> badgeDoors = new List<BadgeContent>();
            Console.WriteLine("Enter badge ID: ");
            string badgeIDString = Console.ReadLine();
            int badgeID = int.Parse(badgeIDString);

            Console.WriteLine("Enter a door it needs access to: ");
            BadgeContent content = new BadgeContent(Console.ReadLine());
            badgeDoors.Add(content);
            Console.WriteLine("Do you want to add another door? Y/N");
            string response = Console.ReadLine();
            response.ToUpper();

            bool continueAddDoors = true;
            while (continueAddDoors)
            {
                switch (response)
                {
                    case "Y":
                        Console.WriteLine("Enter a door it needs access to: ");
                        BadgeContent contentTwo = new BadgeContent(Console.ReadLine());
                        badgeDoors.Add(contentTwo);
                        Console.WriteLine("Do you want to add another door? Y/N");
                        response = Console.ReadLine();
                        break;
                    case "N":
                        continueAddDoors = false;
                        break;
                }
            }
            _badgeRepo.AddToDictionary(badgeID, badgeDoors);
        }
    }
}
