using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_Challenge_Repository;
using System.Collections.Generic;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        [TestMethod]
        public void MenuObjectTest()
        {
            Menu content = new Menu();

            content.MealName = "McDouble";
            string expected = "McDouble";

            Assert.AreEqual(expected, content.MealName);

            Menu contentTwo = new Menu(1, "McChicken", "It's alright", "You don't want to know", 1.89m);

            int expectedNumber = 1;
            string expectedName = "McChicken";
            string expectedDescription = "It's alright";
            string expectedIngredients = "You don't want to know";
            decimal expectedPrice = 1.89m;

            Assert.AreEqual(expectedNumber, contentTwo.MealNumber);
            Assert.AreEqual(expectedName, contentTwo.MealName);
            Assert.AreEqual(expectedDescription, contentTwo.Description);
            Assert.AreEqual(expectedIngredients, contentTwo.Ingredients);
            Assert.AreEqual(expectedPrice, contentTwo.Price);

        }

        [TestMethod]
        public void AddToMenuList_AddMenuContentObject()
        {
            MenuRepository menuRepo = new MenuRepository();
            List<Menu> content = menuRepo.GetMenuList();

            Menu contentOne = new Menu(1, "McChicken", "It's alright", "You don't want to know", 1.89m);
            Menu contentTwo = new Menu(2, "McDouble", "It's alright", "You don't want to know", 1.89m);

            int expected = 2;

            menuRepo.AddToMenu(contentOne);
            menuRepo.AddToMenu(contentTwo);

            int actual = content.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveContentFromMenuListTest()
        {
            MenuRepository menuRepo = new MenuRepository();
            List<Menu> content = menuRepo.GetMenuList();

            Menu contentOne = new Menu(1, "McChicken", "It's alright", "You don't want to know", 1.89m);
            Menu contentTwo = new Menu(2, "McDouble", "It's alright", "You don't want to know", 1.89m);

            int expected = 1;

            menuRepo.AddToMenu(contentOne);
            menuRepo.AddToMenu(contentTwo);

            menuRepo.RemoveContentFromMenuList(1);

            int actual = content.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
