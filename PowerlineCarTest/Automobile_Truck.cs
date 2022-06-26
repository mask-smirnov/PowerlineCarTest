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
        public override decimal maxDistance(decimal fuelOnHand)
        {
            decimal ret = base.maxDistance(fuelOnHand);

            return ret * (decimal) Math.Pow((double)(1M - distanceLossPerUnit / 100M), (double)(loadWeight / weightUnit));
        }
    }
}
