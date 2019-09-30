using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _03_Challenge_Repository;
namespace _03_ChallengeTests
{
    [TestClass]
    public class BadegeTests
    {
        [TestMethod]
        public void BadgeObjectTest()
        {
            BadgeContent contentOne = new BadgeContent();

            contentOne.BadgeID = 1;
            int expected = 1;

            Assert.AreEqual(expected, contentOne.BadgeID);

            BadgeContent content = new BadgeContent("A7");
            content.BadgeID = 1;

            int expectedID = 1;
            string expectedDoorName = "A7";

            Assert.AreEqual(expectedID, content.BadgeID);
            Assert.AreEqual(expectedDoorName, content.DoorNames);
        }

        [TestMethod]
        public void AddToDoorListTest()
        {
            BadgeRepo badgeRepo = new BadgeRepo();
            List<BadgeContent> content = badgeRepo.GetContentList();

            BadgeContent contentOne = new BadgeContent("A7");

            int expected = 1;

            badgeRepo.AddToDoorList(contentOne);

            Assert.AreEqual(expected, content.Count);
        }

        [TestMethod]
        public void AddToDictionaryTest()
        {
            BadgeRepo badgeRepo = new BadgeRepo();
            Dictionary<int, List<BadgeContent>> content = badgeRepo.GetContentDictionary();

            List<BadgeContent> badgeDoors = badgeRepo.GetContentList();

            BadgeContent doorName = new BadgeContent("A7");
            badgeRepo.AddToDoorList(doorName);
            badgeRepo.AddToDictionary(1, badgeDoors);

            int expected = 1;

            Assert.AreEqual(expected, content.Count);
        }

        [TestMethod]
        public void RemoveContentFromDictionaryTest()
        {
            BadgeRepo badgeRepo = new BadgeRepo();
            Dictionary<int, List<BadgeContent>> content = badgeRepo.GetContentDictionary();

            List<BadgeContent> badgeDoors = badgeRepo.GetContentList();

            BadgeContent doorName = new BadgeContent("A7");
            badgeRepo.AddToDoorList(doorName);
            badgeRepo.AddToDictionary(1, badgeDoors);

            int expected = 0;

            badgeRepo.RemoveContentFromDictionary(1);

            Assert.AreEqual(expected, content.Count);
        }
    }
}
