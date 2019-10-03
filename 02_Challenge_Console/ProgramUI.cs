
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_Challenge_Repository;

namespace _02_Challenge_Console
{
    internal class ProgramUI
    {
        ClaimRepository _claimRepo = new ClaimRepository();
        ClaimContent _content = new ClaimContent();

        public ProgramUI()
        {

        }

        public void Run()
        {
            _claimRepo.SeedList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Enter a menu item: \n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit\n");
                string userInput = Console.ReadLine();
                int userNumber = int.Parse(userInput);

                switch (userNumber)
                {
                    case 1:
                        SeeAllClaims();
                        break;
                    case 2:
                        TakeCareOfClaim();
                        break;
                    case 3:
                        EnterNewClaim();
                        break;
                    case 4:
                        continueToRun = false;
                        break;
                }
            }
        }

        public void SeeAllClaims()
        {
            Queue<ClaimContent> contentList = _claimRepo.GetContentQueue();

            foreach (ClaimContent content in contentList)
            {
                Console.WriteLine($"\nClaim ID: {content.ClaimID}\n" +
                    $"Claim Type: {content.Type}\n" +
                    $"Claim Amount: {content.ClaimAmount}\n" +
                    $"Date of Incident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Is it Valid: {content.IsValid}\n");
            }
            Console.WriteLine("Please hit any key to continue... ");
            Console.ReadKey();
        }

        public void EnterNewClaim()
        {
            Console.WriteLine("Enter claim id: ");
            string claimIDString = Console.ReadLine();
            int claimID = int.Parse(claimIDString);

            Console.WriteLine("Enter claim type: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            ClaimType type = (ClaimType)typeAsInt;

            Console.WriteLine("Enter claim amount: ");
            string claimAmountString = Console.ReadLine();
            decimal claimAmount = decimal.Parse(claimAmountString);

            Console.WriteLine("Enter date of incident: (Example: 9/8/2009) ");
            string dateOfIncidentString = Console.ReadLine();
            DateTime dateOfIncident = DateTime.Parse(dateOfIncidentString);

            Console.WriteLine("Enter date of claim: (Example: 9/8/2009) ");
            string dateOfClaimString = Console.ReadLine();
            DateTime dateOfClaim = DateTime.Parse(dateOfClaimString);

            ClaimContent content = new ClaimContent(claimID, type, claimAmount, dateOfIncident, dateOfClaim);
            _claimRepo.AddToList(content);
        }

        public void TakeCareOfClaim()
        {
            Queue<ClaimContent> contentQueue = _claimRepo.GetContentQueue();
            ClaimContent nextClaim = contentQueue.Peek();

            Console.WriteLine("Would you like to take care of this claim?");
            Console.WriteLine($"\nClaim ID: {nextClaim.ClaimID}\n" +
                    $"Claim Type: {nextClaim.Type}\n" +
                    $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                    $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                    $"Date of Claim: {nextClaim.DateOfClaim}\n" +
                    $"Is it Valid: {nextClaim.IsValid}\n");
            Console.WriteLine("Y/N");
            string response = Console.ReadLine();
            response.ToUpper();

            switch (response)
            {
                case "Y":
                    _claimRepo.RemoveFirstItemFromQueue();
                    Console.WriteLine("Item has been removed.");
                    Console.WriteLine("Please enter any key to continue... ");
                    Console.ReadKey();
                    break;
                case "N":
                    break;
            }
        }
    }
}
