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
        public TravelTimeCalculationResult calcTravelTime(decimal fuelOnHand, decimal distance, int numberOfPassengers)
        {
            //сначала вызываем базовую проверку. Таким образом мы различаем нехватку топлива в принципе и нехватку топлива при заданном количестве пассажиров
            TravelTimeCalculationResult ret = base.calcTravelTime(fuelOnHand, distance); 

            if (!ret.Success)
                return ret;
            else
            {
                if (this.maxDistance(fuelOnHand, numberOfPassengers) < distance)
                    return new TravelTimeCalculationResult(_success: false,
                                                            _travelTime: 0,
                                                            _failReason: "Недостаточно топлива при таком количестве пассажиров");

                return new TravelTimeCalculationResult(_success: true,
                                                        _travelTime: distance / AvgSpeed);
            }
        }

    }
}
