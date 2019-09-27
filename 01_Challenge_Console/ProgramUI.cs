using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Challenge_Repository;

namespace _01_Challenge_Console
{
    internal class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();
        Menu _content = new Menu();

        public ProgramUI()
        {

        }

        public void Run()
        {
            _menuRepo.SeedList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Enter the number of function you would like to do: \n" +
                    "1. Add Menu Item\n" +
                    "2. Remove Menu Item\n" +
                    "3. See All Menu Items\n" +
                    "4. Update Menu Item\n" +
                    "5. Exit\n" +
                    "");
                string userInput = Console.ReadLine();
                int userNumber = int.Parse(userInput);

                switch (userNumber)
                {
                    case 1:
                        AddNewMenuItem();
                        break;
                    case 2:
                        RemoveMenuItem();
                        break;
                    case 3:
                        SeeAllMenuItems();
                        break;
                    case 4:
                        UpdateMenuUI();
                        break;
                    case 5:
                        continueToRun = false;
                        break;
                }
            }
        }

        public void AddNewMenuItem()
        {
            Console.WriteLine("Enter the meal number: ");
            string mealNumberAsString = Console.ReadLine();
            int mealNumber = int.Parse(mealNumberAsString);

            Console.WriteLine("Enter the name of the meal: ");
            string mealName = Console.ReadLine();

            Console.WriteLine("Enter a description of the meal: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the ingredients of the meal: ");
            string ingredients = Console.ReadLine();

            Console.WriteLine("Enter the price of the meal: ");
            string priceAsString = Console.ReadLine();
            decimal price = decimal.Parse(priceAsString);

            Menu content = new Menu(mealNumber, mealName, description, ingredients, price);
            _menuRepo.AddToMenu(content);
        }

        public void RemoveMenuItem()
        {
            SeeAllMenuItems();

            Console.WriteLine("Please enter the number of the meal that you would like to remove: ");
            string mealNumberAsString = Console.ReadLine();
            int mealNumber = int.Parse(mealNumberAsString);

            _menuRepo.RemoveContentFromMenuList(mealNumber);

            SeeAllMenuItems();
        }

        public void SeeAllMenuItems()
        {
            List<Menu> menuList = _menuRepo.GetMenuList();

            foreach (Menu item in menuList)
            {
                Console.WriteLine($"\n{item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"Price: {item.Price}\n");
            }
            Console.WriteLine("Please hit any key to continue... ");
            Console.ReadKey();
        }

        public void UpdateMenuUI()
        {
            SeeAllMenuItems();

            Console.WriteLine("What meal would you like to update? Please enter the meal number: ");
            int userChoice = int.Parse(Console.ReadLine());

            UpdateMenu(userChoice);

        }

        public void UpdateMenu(int userChoice)
        {
            Menu content = _menuRepo.GetMenuItemById(userChoice);

            Console.WriteLine("Here are your options: \n" +
                "1. Change meal number.\n" +
                "2. Change meal name.\n" +
                "3. Change meal description.\n" +
                "4. Change meal ingredients.\n" +
                "5. Change meal price.\n");
            string userResponse = Console.ReadLine();
            int userNumberResponse = int.Parse(userResponse);
            switch (userNumberResponse)
            {
                case 1:
                    Console.WriteLine("Enter new meal number: ");
                    string mealNumber = Console.ReadLine();
                    int mealNumberInt = int.Parse(mealNumber);
                    content.MealNumber = mealNumberInt;
                    break;
                case 2:
                    Console.WriteLine("Enter new meal name: ");
                    content.MealName = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Enter new meal description: ");
                    content.Description = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Enter new meal ingredients: ");
                    content.Ingredients = Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Enter new meal price: ");
                    string mealPriceAsString = Console.ReadLine();
                    decimal mealPrice = decimal.Parse(mealPriceAsString);
                    content.Price = mealPrice;
                    break;
            }
        }
    }
}
