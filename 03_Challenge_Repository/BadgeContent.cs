using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge_Repository
{
    public class BadgeContent
    {

        public BadgeContent()
        {
        }

        //public BadgeContent(string doorNames)
        //{
        //    DoorNames = doorNames;
        //}

        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
    }
}
