using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerlineCarTest
{
    public class Automobile_SportCar : Automobile
    {
        public Automobile_SportCar(decimal _avgFuelConsumption, decimal _fuelTankSize, decimal _avgSpeed) 
            : base(_avgFuelConsumption, _fuelTankSize, _avgSpeed)
        {
            this.Type = AutomobileType.sportcar;
        }
    }
}
