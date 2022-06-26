using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerlineCarTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerlineCarTest.Tests
{
    [TestClass()]
    public class Automobile_PassengerCarTests
    {
        [TestMethod()]
        public void maxDistanceFullTank_0passengers_distance1000()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            decimal maxDistance = passengerCar.maxDistanceFullTank();

            Assert.AreEqual(maxDistance, 1000);
        }
        [TestMethod()]
        public void maxDistanceFullTank_1passenger_distance940()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            decimal maxDistance = passengerCar.maxDistanceFullTank(numberOfPassengers: 1);

            Assert.AreEqual(maxDistance, 940);
        }

        [TestMethod()]
        public void maxDistance_5liter0passengers_distance100()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            decimal maxDistance = passengerCar.maxDistance(fuelOnHand: 5);

            Assert.AreEqual(maxDistance, 100);
        }
        [TestMethod()]
        public void maxDistance_5liter1passenger_distance94()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            decimal maxDistance = passengerCar.maxDistance(fuelOnHand: 5, numberOfPassengers: 1);

            Assert.AreEqual(maxDistance, 94);
        }

        [TestMethod()]
        public void travelTime_1liter1000km0passengers_fail()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            TravelTimeCalculationResult calcResult = passengerCar.calcTravelTime(fuelOnHand: 1, distance: 1000);

            Assert.AreEqual(calcResult.FailReason, "Недостаточно топлива");
        }
        [TestMethod()]
        public void travelTime_5liter100km0passengers_2h()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            TravelTimeCalculationResult calcResult = passengerCar.calcTravelTime(fuelOnHand: 5, distance: 100);

            Assert.AreEqual(calcResult.TravelTime, 2);
        }
        [TestMethod()]
        public void travelTime_5liter100km3passengers_fail()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            TravelTimeCalculationResult calcResult = passengerCar.calcTravelTime(fuelOnHand: 5, distance: 100, numberOfPassengers: 3);

            Assert.AreEqual(calcResult.FailReason, "Недостаточно топлива при таком количестве пассажиров");
        }
        [TestMethod()]
        public void travelTime_10liter100km3passengers_2h()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            TravelTimeCalculationResult calcResult = passengerCar.calcTravelTime(fuelOnHand: 10, distance: 100, numberOfPassengers: 3);

            Assert.AreEqual(calcResult.TravelTime, 2);
        }

        public static Automobile_PassengerCar constructTestCar()
        {
            return new Automobile_PassengerCar(_avgFuelConsumption: 0.05m, _fuelTankSize: 50, _avgSpeed: 50);
        }
    }
}