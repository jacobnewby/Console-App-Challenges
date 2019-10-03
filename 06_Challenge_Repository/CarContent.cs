using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge_Repository
{
    public enum CarType { Electic = 1, Hybrid, Gas }
    public class CarContent
    {
        public CarContent()
        {

        }

        public CarContent(string carName, CarType type, string carEngine, string gasMileage, string drivingType)
        {
            CarName = carName;
            Type = type;
            CarEngine = carEngine;
            GasMileage = gasMileage;
            DrivingType = drivingType;  
        }

        public string CarName { get; set; }
        public CarType Type { get; set; }
        public string CarEngine { get; set; }
        public string GasMileage { get; set; }
        public string DrivingType { get; set; }
    }
}
