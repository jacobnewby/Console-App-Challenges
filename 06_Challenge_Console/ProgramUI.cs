using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06_Challenge_Repository;

namespace _06_Challenge_Console
{
    class ProgramUI
    {
        CarRepository _carRepo = new CarRepository();
        CarContent _content = new CarContent();

        public ProgramUI()
        {

        }

        public void Run()
        {
            _carRepo.SeedList();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("\nEnter a menu item: \n" +
                    "1. See all cars\n" +
                    "2. Create a car\n" +
                    "3. Update a car\n" +
                    "4. Remove a car\n" +
                    "5. Exit\n");
                string userInput = Console.ReadLine();
                int userNumber = int.Parse(userInput);

                switch (userNumber)
                {
                    case 1:
                        SeeAllCars();
                        break;
                    case 2:
                        CreateCar();
                        break;
                    case 3:
                        UpdateCar();
                        break;
                    case 4:
                        RemoveCar();
                        break;
                    case 5:
                        continueToRun = false;
                        break;
                }
            }
        }

        public void SeeAllCars()
        {
            List<CarContent> carList = _carRepo.GetCarList();

            foreach (CarContent content in carList)
            {
                Console.WriteLine($"\nCar Name: {content.CarName}\n" +
                    $"Car Type: {content.Type}\n" +
                    $"Car Engine: {content.CarEngine}\n" +
                    $"Gas Mileage: {content.GasMileage}\n" +
                    $"Driving Type: {content.DrivingType}\n");
            }
            Console.WriteLine("Please hit any key to continue... ");
            Console.ReadKey();
        }

        public void CreateCar()
        {
            Console.WriteLine("Enter car name: ");
            string carName = Console.ReadLine();

            Console.WriteLine("Enter car type: \n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n");
            string typeAsString = Console.ReadLine();
            int typeInt = int.Parse(typeAsString);
            CarType type = (CarType)typeInt;

            Console.WriteLine("Enter car engine: ");
            string carEngine = Console.ReadLine();

            Console.WriteLine("Enter gas mileage: ");
            string gasMileage = Console.ReadLine();

            Console.WriteLine("Enter driving type: ");
            string drivingType = Console.ReadLine();

            CarContent content = new CarContent(carName, type, carEngine, gasMileage, drivingType);
            _carRepo.AddToList(content);
        }

        public void UpdateCar()
        {
            SeeAllCars();

            Console.WriteLine("What car would you like to update? Please enter the name of the car: ");
            string userChoice = Console.ReadLine();

            UpdateMenu(userChoice);
        }

        public void UpdateMenu(string userChoice)
        {
            CarContent content = _carRepo.GetCarByName(userChoice);

            Console.WriteLine("Here are your options: \n" +
                "1. Change car name.\n" +
                "2. Change car type.\n" +
                "3. Change car engine.\n" +
                "4. Change car mileage.\n" +
                "5. Change driving type.\n");
            string userResponse = Console.ReadLine();
            int response = int.Parse(userResponse);

            switch (response)
            {
                case 1:
                    Console.WriteLine("Enter new car name: ");
                    string carName = Console.ReadLine();
                    content.CarName = carName;
                    break;
                case 2:
                    Console.WriteLine("Enter new car type: \n" +
                        "1. Electric\n" +
                        "2. Hybrid\n" +
                        "3. Gas\n");
                    string typeString = Console.ReadLine();
                    int typeInt = int.Parse(typeString);
                    CarType type = (CarType)typeInt;
                    content.Type = type;
                    break;
                case 3:
                    Console.WriteLine("Enter new car engine: ");
                    string carEngine = Console.ReadLine();
                    content.CarEngine = carEngine;
                    break;
                case 4:
                    Console.WriteLine("Enter new gas mileage: ");
                    string gasMileage = Console.ReadLine();
                    content.GasMileage = gasMileage;
                    break;
                case 5:
                    Console.WriteLine("Enter new driving type: ");
                    string drivingType = Console.ReadLine();
                    content.DrivingType = drivingType;
                    break;
            }
        }

        public void RemoveCar()
        {
            SeeAllCars();

            Console.WriteLine("Enter the name of the car you would like to remove: ");
            string carName = Console.ReadLine();

            _carRepo.RemoveCarFromList(carName);

            SeeAllCars(); 
        }
    }
}
