using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge_Repository
{
    public class CarRepository
    {
        List<CarContent> _carList = new List<CarContent>();

        public void AddToList(CarContent content)
        {
            _carList.Add(content);
        }

        public List<CarContent> GetCarList()
        {
            return _carList;
        }

        public void RemoveCarFromList(string carName)
        {
            foreach (CarContent contents in _carList)
            {
                if (contents.CarName == carName)
                {
                    _carList.Remove(contents);
                    break;
                }
            }
        }

        public CarContent GetCarByName(string userChoice)
        {
            foreach (CarContent content in _carList)
            {
                if(userChoice == content.CarName)
                {
                    return content;
                }
            }
            return null;
        }

        public void SeedList()
        {
            CarContent contentOne = new CarContent("Buick", CarType.Gas, "V6", "30mpg", "Front Wheel");
            CarContent contentTwo = new CarContent("Smart Car", CarType.Electic, "battery", "40mppg", "Front Wheel");
            CarContent contentThree = new CarContent("Hybrid Car", CarType.Hybrid, "Battery, 4 cylinder", "40mpg", "Four Wheel");

            AddToList(contentOne);
            AddToList(contentTwo);
            AddToList(contentThree);
        }
    }
}
