using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _04_Challenge_Repository;

namespace _04_ChallengeTests
{
    [TestClass]
    public class OutingTests
    {
        [TestMethod]
        public void ObjectTest()
        {
            OutingContent contentOne = new OutingContent();

            contentOne.CostForEvent = 100m;
            decimal expected = 100m;

            Assert.AreEqual(expected, contentOne.CostForEvent);

            OutingContent content = new OutingContent(OutingType.Concert, 10, DateTime.Today, 10m);

            OutingType expectedType = OutingType.Concert;
            int expectedAttended = 10;
            DateTime expectedTime = DateTime.Today;
            decimal expectedCostPerPerson = 10m;
            decimal expectedCostForEvent = 100m;

            Assert.AreEqual(expectedType, content.Type);
            Assert.AreEqual(expectedAttended, content.PeopleAttended);
            Assert.AreEqual(expectedTime, content.Date);
            Assert.AreEqual(expectedCostPerPerson, content.CostPerPerson);
            Assert.AreEqual(expectedCostForEvent, content.CostForEvent);
        }

        [TestMethod]
        public void AddToListTest()
        {
            OutingRepo outingRepo = new OutingRepo();
            List<OutingContent> outingList = outingRepo.GetOutingList();

            OutingContent content = new OutingContent(OutingType.Concert, 10, DateTime.Today, 10m);

            int expected = 1;

            outingRepo.AddToList(content);

            Assert.AreEqual(expected, outingList.Count);
        }

        [TestMethod]
        public void CombineCostAllTest()
        {
            OutingRepo outingRepo = new OutingRepo();
            OutingContent content = new OutingContent();
            content.CostForEvent = 100m;

            OutingContent contentOne = new OutingContent();
            contentOne.CostForEvent = 100m;

            outingRepo.AddToList(content);
            outingRepo.AddToList(contentOne);
            decimal expected = 200m;

            decimal actual = outingRepo.CombinedCostOfAllOutingsGet();

            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void CombinedCostAmusementParkTest()
        {
            OutingRepo outingRepo = new OutingRepo();
            OutingContent content = new OutingContent();
            content.CostForEvent = 100m;
            content.Type = OutingType.AmusementPark;

            OutingContent contentOne = new OutingContent();
            contentOne.CostForEvent = 100m;
            contentOne.Type = OutingType.AmusementPark;

            outingRepo.AddToList(content);
            outingRepo.AddToList(contentOne);
            decimal expected = 200m;
            decimal actual = outingRepo.CombinedTypeCostAmusementParks();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CombinedCostBowlingTest()
        {
            OutingRepo outingRepo = new OutingRepo();
            OutingContent content = new OutingContent();
            content.CostForEvent = 100m;
            content.Type = OutingType.Bowling;

            OutingContent contentOne = new OutingContent();
            contentOne.CostForEvent = 100m;
            contentOne.Type = OutingType.Bowling;
                ;

            outingRepo.AddToList(content);
            outingRepo.AddToList(contentOne);
            decimal expected = 200m;
            decimal actual = outingRepo.CombinedTypeCostBowling();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CombinedCostConcertTest()
        {
            OutingRepo outingRepo = new OutingRepo();
            OutingContent content = new OutingContent();
            content.CostForEvent = 100m;
            content.Type = OutingType.Concert;

            OutingContent contentOne = new OutingContent();
            contentOne.CostForEvent = 100m;
            contentOne.Type = OutingType.Concert;

            outingRepo.AddToList(content);
            outingRepo.AddToList(contentOne);
            decimal expected = 200m;
            decimal actual = outingRepo.CombinedTypeCostConcert();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CombineCostGolfTest()
        {
            OutingRepo outingRepo = new OutingRepo();
            OutingContent content = new OutingContent();
            content.CostForEvent = 100m;
            content.Type = OutingType.Golf;

            OutingContent contentOne = new OutingContent();
            contentOne.CostForEvent = 100m;
            contentOne.Type = OutingType.Golf;

            outingRepo.AddToList(content);
            outingRepo.AddToList(contentOne);
            decimal expected = 200m;
            decimal actual = outingRepo.CombinedTypeCostGolf();

            Assert.AreEqual(expected, actual);
        }
    }
}
