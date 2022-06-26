using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerlineCarTest
{
    public class Automobile_Truck : Automobile
    {
        public static decimal distanceLossPerUnit = 4M; //процент потерь запаса хода в % на условную единицу веса
        public static decimal weightUnit = 200; //условная единица веса, на которую считается процент потерь, кг

        public decimal loadWeight { get; set; } //загрузка в кг

        public Automobile_Truck(decimal _avgFuelConsumption, decimal _fuelTankSize, decimal _avgSpeed, decimal _loadWeight)
            : base(_avgFuelConsumption, _fuelTankSize, _avgSpeed)
        {
            this.Type = AutomobileType.truck;
            this.loadWeight = _loadWeight;
        }
        public decimal maxDistanceFullTank()
        {
            return this.maxDistance(FuelTankSize);
        }
        public new decimal maxDistance(decimal fuelOnHand)
        {
            decimal ret = base.maxDistance(fuelOnHand);

            return ret * (decimal) Math.Pow((double)(1M - distanceLossPerUnit / 100M), (double)(loadWeight / weightUnit));
        }
        public new TravelTimeCalculationResult calcTravelTime(decimal fuelOnHand, decimal distance)
        {
            //сначала вызываем базовую проверку. Таким образом мы различаем нехватку топлива в принципе и нехватку топлива при заданной массе груза
            TravelTimeCalculationResult ret = base.calcTravelTime(fuelOnHand, distance);

            if (!ret.Success)
                return ret;
            else
            {
                if (this.maxDistance(fuelOnHand) < distance)
                    return new TravelTimeCalculationResult(_success: false,
                                                            _travelTime: 0,
                                                            _failReason: "Недостаточно топлива при такой массе груза");

                return new TravelTimeCalculationResult(_success: true,
                                                        _travelTime: distance / AvgSpeed);
            }
        }

    }
}
