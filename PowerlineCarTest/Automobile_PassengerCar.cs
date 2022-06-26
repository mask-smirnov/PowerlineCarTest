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
        public int numberOfPassengers { get; set; }

        public Automobile_PassengerCar(decimal _avgFuelConsumption, decimal _fuelTankSize, decimal _avgSpeed, int _numberOfPassengers) : base(_avgFuelConsumption, _fuelTankSize, _avgSpeed)
        {
            this.Type = AutomobileType.passenger;
            this.numberOfPassengers = _numberOfPassengers;
        }
        public decimal maxDistanceFullTank()
        {
            return this.maxDistance(FuelTankSize);
        }
        public new decimal maxDistance(decimal fuelOnHand)
        {
            decimal ret = base.maxDistance(fuelOnHand);

            return ret * (decimal)Math.Pow((double)(1 - distanceLossPerPassanger / 100), numberOfPassengers);
        }
        public new TravelTimeCalculationResult calcTravelTime(decimal fuelOnHand, decimal distance)
        {
            //сначала вызываем базовую проверку. Таким образом мы различаем нехватку топлива в принципе и нехватку топлива при заданном количестве пассажиров
            TravelTimeCalculationResult ret = base.calcTravelTime(fuelOnHand, distance); 

            if (!ret.Success)
                return ret;
            else
            {
                if (this.maxDistance(fuelOnHand) < distance)
                    return new TravelTimeCalculationResult(_success: false,
                                                            _travelTime: 0,
                                                            _failReason: "Недостаточно топлива при таком количестве пассажиров");

                return new TravelTimeCalculationResult(_success: true,
                                                        _travelTime: distance / AvgSpeed);
            }
        }

    }
}
