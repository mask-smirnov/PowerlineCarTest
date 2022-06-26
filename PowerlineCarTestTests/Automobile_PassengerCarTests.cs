using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerlineCarTest.Tests
{
    [TestClass()]
    public class Automobile_PassengerCarTests
    {
        [TestMethod()]
        public void maxDistanceFullTank_0passengers_distance1000()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar(_numberOfPassengers: 0);

            decimal maxDistance = passengerCar.maxDistance();

            Assert.AreEqual(1000, maxDistance);
        }
        [TestMethod()]
        public void maxDistanceFullTank_1passenger_distance940()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar(_numberOfPassengers: 1);

            decimal maxDistance = passengerCar.maxDistance();

            Assert.AreEqual(940, maxDistance);
        }

        [TestMethod()]
        public void maxDistance_5liter0passengers_distance100()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar(_numberOfPassengers: 0);

            decimal maxDistance = passengerCar.maxDistance(fuelOnHand: 5);

            Assert.AreEqual(100, maxDistance);
        }
        [TestMethod()]
        public void maxDistance_5liter1passenger_distance94()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar(_numberOfPassengers: 1);

            decimal maxDistance = passengerCar.maxDistance(fuelOnHand: 5);

            Assert.AreEqual(94, maxDistance);
        }

        [TestMethod()]
        public void travelTime_1liter1000km0passengers_fail()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar(_numberOfPassengers: 0);

            TravelTimeCalculationResult calcResult = passengerCar.calcTravelTime(fuelOnHand: 1, distance: 1000);

            Assert.AreEqual("Недостаточно топлива", calcResult.FailReason);
        }
        [TestMethod()]
        public void travelTime_5liter100km0passengers_2h()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar(_numberOfPassengers: 0);

            TravelTimeCalculationResult calcResult = passengerCar.calcTravelTime(fuelOnHand: 5, distance: 100);

            Assert.AreEqual(2, calcResult.TravelTime);
        }
        [TestMethod()]
        public void travelTime_5liter100km3passengers_fail()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar(_numberOfPassengers: 3);

            TravelTimeCalculationResult calcResult = passengerCar.calcTravelTime(fuelOnHand: 5, distance: 100);

            Assert.AreEqual("Недостаточно топлива", calcResult.FailReason);
        }
        [TestMethod()]
        public void travelTime_10liter100km3passengers_2h()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar(_numberOfPassengers: 3);

            TravelTimeCalculationResult calcResult = passengerCar.calcTravelTime(fuelOnHand: 10, distance: 100);

            Assert.AreEqual(2, calcResult.TravelTime);
        }

        public static Automobile_PassengerCar constructTestCar(int _numberOfPassengers)
        {
            return new Automobile_PassengerCar( _avgFuelConsumption: 0.05m, 
                                                _fuelTankSize: 50, 
                                                _avgSpeed: 50, 
                                                _numberOfPassengers: _numberOfPassengers);
        }
    }
}