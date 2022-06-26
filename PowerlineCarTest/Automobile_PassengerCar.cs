using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerlineCarTest
{
    public class Automobile_PassengerCar : Automobile
    {
        public static decimal distanceLossPerPassanger = 6; //процент потерь запаса хода
        public Automobile_PassengerCar(decimal _avgFuelConsumption, decimal _fuelTankSize, decimal _avgSpeed) : base(_avgFuelConsumption, _fuelTankSize, _avgSpeed)
        {
            this.Type = AutomobileType.passenger;
        }
        public decimal maxDistance(int numberOfPassengers)
        {
            return this.maxDistance(FuelTankSize, numberOfPassengers);
        }
        public decimal maxDistance(decimal fuelOnHand, int numberOfPassengers)
        {
            decimal ret = base.maxDistance(fuelOnHand);

            return ret * (decimal)Math.Pow((double)(1 - distanceLossPerPassanger / 100), numberOfPassengers);
        }


    }
}
