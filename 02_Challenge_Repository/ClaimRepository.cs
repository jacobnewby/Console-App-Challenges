using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public class ClaimRepository
    {
        Queue<ClaimContent> _contentQueue = new Queue<ClaimContent>();

        public void AddToList(ClaimContent content)
        {
            _contentQueue.Enqueue(content);
        }

        public Queue<ClaimContent> GetContentQueue()
        {
            return _contentQueue;
        }

        public void RemoveContentFromQueue(int claimID)
        {
            foreach (ClaimContent contents in _contentQueue)
            {
                if (contents.ClaimID == claimID)
                {
                    _contentQueue.Dequeue();
                    break;
                }
            }
        }

        public void RemoveFirstItemFromQueue()
        {
            _contentQueue.Dequeue();
        }

        public void SeedList()
        {
            ClaimContent content = new ClaimContent(1, ClaimType.Car, 300m, DateTime.Today, DateTime.Today);
            ClaimContent contentTwo = new ClaimContent(2, ClaimType.Home, 2000m,DateTime.Today, DateTime.Today);

            AddToList(content);
            AddToList(contentTwo);

        }
    }
}
