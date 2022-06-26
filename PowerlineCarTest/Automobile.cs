using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerlineCarTest
{
    public enum AutomobileType { passenger, truck, sportcar };

    public abstract class Automobile
    {
        public AutomobileType Type { get; set; }        //тип ТС    
        public decimal AvgFuelConsumption { get; set; } //ср. расход топлива, л/км
        public decimal FuelTankSize { get; set; }       //V бака, л
        public decimal AvgSpeed { get; set; }           //средняя скорость км/ч

        public Automobile(decimal _avgFuelConsumption, decimal _fuelTankSize, decimal _avgSpeed)
        {
            AvgFuelConsumption = _avgFuelConsumption;
            FuelTankSize = _fuelTankSize;
            AvgSpeed = _avgSpeed;
        }
        public TravelTimeCalculationResult calcTravelTime(decimal fuelOnHand, decimal distance)
        {
            this.validateParameters();

            if (this.maxDistance(fuelOnHand) < distance)
                return new TravelTimeCalculationResult( _success: false, 
                                                        _travelTime: 0, 
                                                        _failReason: "Недостаточно топлива");

            return new TravelTimeCalculationResult(_success: true,
                                                    _travelTime: distance / AvgSpeed);
        }

        public decimal maxDistance()
        {
            return this.maxDistance(FuelTankSize);
        }
        public decimal maxDistance(decimal fuelOnHand)
        {
            this.validateParameters();

            return fuelOnHand / AvgFuelConsumption;
        }

        private void validateParameters()
        {
            if (AvgSpeed == 0)
                throw new Exception("Не указана средняя скорость");
            if (AvgFuelConsumption == 0)
                throw new Exception("Не указан средний расход топлива");

        }
    }
}
