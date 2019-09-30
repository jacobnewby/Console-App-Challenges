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

            ClaimContent content = new ClaimContent(1, ClaimType.Car, 300m, 9 / 1 / 09, 9 / 4 / 09, true);

            int expectedID = 1;
            ClaimType expectedType = ClaimType.Car;
            decimal expectedClaimAmount = 300m;
            int expectedDateOfIncident = 9 / 1 / 09;
            int expectedDateOfClaim = 9 / 4 / 09;
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
            List<ClaimContent> content = claimRepo.GetContentList();

            ClaimContent contentOne = new ClaimContent(1, ClaimType.Car, 300m, 9 / 1 / 09, 9 / 4 / 09, true);
            ClaimContent contentTwo = new ClaimContent(2, ClaimType.Home, 2000m, 9 / 5 / 09, 9 / 7 / 08, true);

            int expected = 2;

            claimRepo.AddToList(contentOne);
            claimRepo.AddToList(contentTwo);

            Assert.AreEqual(expected, content.Count);
        }

        [TestMethod]
        public void RemoveProductContentFromListTest()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            List<ClaimContent> content = claimRepo.GetContentList();

            ClaimContent contentOne = new ClaimContent(1, ClaimType.Car, 300m, 9 / 1 / 09, 9 / 4 / 09, true);
            ClaimContent contentTwo = new ClaimContent(2, ClaimType.Home, 2000m, 9 / 5 / 09, 9 / 7 / 08, true);

            int expected = 1;

            claimRepo.AddToList(contentOne);
            claimRepo.AddToList(contentTwo);

            claimRepo.RemoveContentFromList(2);

            int actual = content.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
