using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Repository
{
    public enum OutingType { Golf = 1, Bowling, AmusementPark, Concert}

    public class OutingContent
    {
        public OutingContent()
        {
        }

        public OutingContent(OutingType type, int peopleAttended, DateTime date, decimal costPerPerson, decimal costForEvent)
        {
            Type = type;
            PeopleAttended = peopleAttended;
            Date = date;
            CostPerPerson = costPerPerson;
            CostForEvent = costForEvent;
        }

        public OutingType Type { get; set; }
        public int PeopleAttended { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostForEvent { get; set; }
    }
}
