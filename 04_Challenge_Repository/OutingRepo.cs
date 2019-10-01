using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Repository
{
    public class OutingRepo
    {
        List<OutingContent> _outingList = new List<OutingContent>();

        public void AddToList(OutingContent content)
        {
            _outingList.Add(content);
        }

        public List<OutingContent> GetOutingList()
        {
            return _outingList;
        }

        public decimal CombinedCostOfAllOutingsGet()
        {
            decimal sum = 0;
            foreach (OutingContent content in _outingList)
            {
                sum += content.CostForEvent;
            }
            return sum;
        }

        public decimal CombinedTypeCostAmusementParks()
        {
            decimal sum = 0;
            foreach (OutingContent content in _outingList)
            {
                if (content.Type == OutingType.AmusementPark)
                {
                    sum += content.CostForEvent;
                }
                else
                {
                    break;
                }
            }
            return sum;
        }

        public decimal CombinedTypeCostBowling()
        {
            decimal sum = 0;
            foreach (OutingContent content in _outingList)
            {
                if (content.Type == OutingType.Bowling)
                {
                    sum += content.CostForEvent;
                }
                else
                {
                    break;
                }
            }
            return sum;
        }

        public decimal CombinedTypeCostConcert()
        {
            decimal sum = 0;
            foreach (OutingContent content in _outingList)
            {
                if (content.Type == OutingType.Concert)
                {
                    sum += content.CostForEvent;
                }
                else
                {
                    break;
                }
            }
            return sum;
        }

        public decimal CombinedTypeCostGolf()
        {
            decimal sum = 0;
            foreach (OutingContent content in _outingList)
            {
                if (content.Type == OutingType.Golf)
                {
                    sum += content.CostForEvent;
                }
                else
                {
                    break;
                }
            }
            return sum;
        }

        public void SeedList()
        {
            OutingContent content = new OutingContent(OutingType.Concert, 10, DateTime.Today, 10m);

            AddToList(content);
        }
    }
}
