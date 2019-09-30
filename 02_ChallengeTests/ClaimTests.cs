using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _02_Challenge_Repository;

namespace _02_ChallengeTests
{
    [TestClass]
    public class ClaimTests
    {
        [TestMethod]
        public void ClaimContentObject()
        {
            ClaimContent contentOne = new ClaimContent();

            contentOne.ClaimAmount = 200m;
            decimal expected = 200m;

            Assert.AreEqual(expected, contentOne.ClaimAmount);

            ClaimContent content = new ClaimContent(1, ClaimType.Car, 300m, DateTime.Today, DateTime.Today);

            int expectedID = 1;
            ClaimType expectedType = ClaimType.Car;
            decimal expectedClaimAmount = 300m;
            DateTime expectedDateOfIncident = DateTime.Today;
            DateTime expectedDateOfClaim = DateTime.Today;
            bool expectedIsValid = true;

            Assert.AreEqual(expectedID, content.ClaimID);
            Assert.AreEqual(expectedType, content.Type);
            Assert.AreEqual(expectedClaimAmount, content.ClaimAmount);
            Assert.AreEqual(expectedDateOfIncident, content.DateOfIncident);
            Assert.AreEqual(expectedDateOfClaim, content.DateOfClaim);
            Assert.AreEqual(expectedIsValid, content.IsValid);
        }

        [TestMethod]
        public void AddToList_ClaimContentObject()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<ClaimContent> content = claimRepo.GetContentQueue();

            ClaimContent contentOne = new ClaimContent(1, ClaimType.Car, 300m, DateTime.Today, DateTime.Today);
            ClaimContent contentTwo = new ClaimContent(2, ClaimType.Home, 2000m, DateTime.Today, DateTime.Today);

            int expected = 2;

            claimRepo.AddToList(contentOne);
            claimRepo.AddToList(contentTwo);

            Assert.AreEqual(expected, content.Count);
        }

        [TestMethod]
        public void RemoveProductContentFromQueueTest()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<ClaimContent> content = claimRepo.GetContentQueue();

            ClaimContent contentOne = new ClaimContent(1, ClaimType.Car, 300m, DateTime.Today, DateTime.Today);
            ClaimContent contentTwo = new ClaimContent(2, ClaimType.Home, 2000m, DateTime.Today, DateTime.Today);

            int expected = 1;

            claimRepo.AddToList(contentOne);
            claimRepo.AddToList(contentTwo);

            claimRepo.RemoveContentFromQueue(2);

            int actual = content.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
