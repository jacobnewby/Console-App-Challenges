using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge_Repository
{
    public class BadgeRepo
    {
        List<BadgeContent> _doorAccessList = new List<BadgeContent>();
        Dictionary<int, List<BadgeContent>> _badgeDictionary = new Dictionary<int, List<BadgeContent>>();

        public void AddToDoorList(BadgeContent doorName)
        {
            _doorAccessList.Add(doorName);
        }

        public void AddToDictionary(int badgeID, List<BadgeContent> doorNames)
        {
            _badgeDictionary.Add(badgeID, doorNames);
        }

        public Dictionary<int, List<BadgeContent>> GetContentDictionary()
        {
            return _badgeDictionary;
        }
        
        public List<BadgeContent> GetContentList()
        {
            return _doorAccessList;
        }

        public void RemoveContentFromDictionary(int badgeID)
        {
            _badgeDictionary.Remove(badgeID);
        }

        public void SeedList()
        {
            BadgeContent content = new BadgeContent("A7");
            _doorAccessList.Add(content);

            _badgeDictionary.Add(1, _doorAccessList);
            _badgeDictionary.Add(2, _doorAccessList);
        }
    }
}
