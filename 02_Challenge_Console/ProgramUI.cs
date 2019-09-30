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
                Console.WriteLine("Enter a menu items: \n" +
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
            List<ClaimContent> contentList = _claimRepo.GetContentList();

            foreach (ClaimContent content in contentList)
            {
                Console.WriteLine($"\nClaim ID: {content.ClaimID}\n" +
                    $"Claim Type: {content.Type}\n" +
                    $"Claim Amount: {content.ClaimAmount}\n" +
                    $"Date of Incident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Is it Valid: {content.IsValid}\n");
                Console.WriteLine("Please hit any key to continue... ");
                Console.ReadKey();
            }
        }

        public void EnterNewClaim()
        {
            Console.WriteLine("Enter claim id: ");
            string claimIDString = Console.ReadLine();
            int claimID = int.Parse(claimIDString);

            Console.WriteLine("Enter claim type: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "Theft\n");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            ClaimType type = (ClaimType)typeAsInt;

            Console.WriteLine("Enter claim amount: ");
            string claimAmountString = Console.ReadLine();
            decimal claimAmount = decimal.Parse(claimAmountString);

            Console.WriteLine("Enter date of incident: (Example: 9 / 8 / 09) ");
            string dateOfIncidentString = Console.ReadLine();
            int dateOfIncident = int.Parse(dateOfIncidentString);

            Console.WriteLine("Enter date of claim: (Example: 9 / 8 / 09) ");
            string dateOfClaimString = Console.ReadLine();
            int dateOfClaim = int.Parse(dateOfClaimString);

            Console.WriteLine("Is claim valid: true or false");
            string isValidString = Console.ReadLine();
            bool isValid = bool.Parse(isValidString);

            ClaimContent content = new ClaimContent(claimID, type, claimAmount, dateOfIncident, dateOfClaim, isValid);
        }
    }
}
