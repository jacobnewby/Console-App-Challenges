using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _06_Challenge_Repository;

namespace _06_ChallengeTests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void ObjTest()
        {
            CarContent contentOne = new CarContent();

            contentOne.CarName = "Buick";

            string expected = "Buick";

            Assert.AreEqual(expected, contentOne.CarName);

            CarContent contentTwo = new CarContent("Buick", CarType.Gas, "V6", "30mpg", "Front Wheel");

            string expectedName = "Buick";
            CarType expectedType = CarType.Gas;
            string expectedEngine = "V6";
            string expectedMileage = "30mpg";
            string expectedDrivingType = "Front Wheel";

            Assert.AreEqual(expectedName, contentTwo.CarName);
            Assert.AreEqual(expectedType, contentTwo.Type);
            Assert.AreEqual(expectedEngine, contentTwo.CarEngine);
            Assert.AreEqual(expectedMileage, contentTwo.GasMileage);
            Assert.AreEqual(expectedDrivingType, contentTwo.DrivingType);
        }

        [TestMethod]
        public void AddToListTest()
        {
            CarRepository carRepo = new CarRepository();
            List<CarContent> content = carRepo.GetCarList();

            CarContent contentTwo = new CarContent("Buick", CarType.Gas, "V6", "30mpg", "Front Wheel");

            int expected = 1;

            carRepo.AddToList(contentTwo);

            Assert.AreEqual(expected, content.Count);
        }

        [TestMethod]
        public void RemoveTest()
        {
            CarRepository carRepo = new CarRepository();
            List<CarContent> content = carRepo.GetCarList();

            CarContent contentTwo = new CarContent("Buick", CarType.Gas, "V6", "30mpg", "Front Wheel");

            int expected = 0;

            carRepo.AddToList(contentTwo);

            carRepo.RemoveCarFromList("Buick");

            Assert.AreEqual(expected, content.Count);
        }
    }
}
