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
        public override decimal maxDistance(decimal fuelOnHand)
        {
            decimal ret = base.maxDistance(fuelOnHand);

            return ret * (decimal)Math.Pow((double)(1 - distanceLossPerPassanger / 100), numberOfPassengers);
        }
    }
}
