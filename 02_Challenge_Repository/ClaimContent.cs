using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class ClaimContent
    {
        //claimid, claimtype, description, claimamount, deateofincident, dateofclaim, isvalid type- Car, home, theft
        public ClaimContent(int claimID, ClaimType type, decimal claimAmount, int dateOfIncident, int dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            Type = type;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
        public ClaimContent()
        {

        }

        public int ClaimID { get; set; }
        public ClaimType Type { get; set; }
        public decimal ClaimAmount { get; set; }
        public int DateOfIncident { get; set; }
        public int DateOfClaim { get; set; }
        public bool IsValid { get; set; }

    }
}