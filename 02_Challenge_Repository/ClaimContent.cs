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
        public ClaimContent(int claimID, ClaimType type, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            Type = type;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = (dateOfClaim - dateOfIncident).Days <= 30;
        }
        public ClaimContent()
        {

        }

        public int ClaimID { get; set; }
        public ClaimType Type { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

    }
}