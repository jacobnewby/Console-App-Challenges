using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public class ClaimRepository
    {
        List<ClaimContent> _contentList = new List<ClaimContent>();

        public void AddToList(ClaimContent content)
        {
            _contentList.Add(content);
        }

        public List<ClaimContent> GetContentList()
        {
            return _contentList;
        }

        public void RemoveContentFromList(int claimID)
        {
            foreach(ClaimContent contents in _contentList)
            {
                if(contents.ClaimID == claimID)
                {
                    _contentList.Remove(contents);
                    break;
                }
            }
        }

        public void SeedList()
        {
            ClaimContent content = new ClaimContent(1, ClaimType.Car, 300m, 9 / 1 / 09, 9 / 4 / 09, true);
            ClaimContent contentTwo = new ClaimContent(2, ClaimType.Home, 2000m, 9 / 5 / 09, 9 / 7 / 08, true);

            AddToList(content);
            AddToList(contentTwo);

        }
    }
}
