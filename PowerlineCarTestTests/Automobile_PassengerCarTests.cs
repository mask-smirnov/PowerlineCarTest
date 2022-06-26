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
        public void maxDistance_fullTank_distance1000()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            decimal maxDistance = passengerCar.maxDistance();

            Assert.AreEqual(maxDistance, 1000);
        }
        [TestMethod()]
        public void maxDistance_5liter_distance100()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            decimal maxDistance = passengerCar.maxDistance(fuelOnHand: 5);

            Assert.AreEqual(maxDistance, 100);
        }
        [TestMethod()]
        public void travelTime_1liter1000km_fail()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            TravelTimeCalculationResult calcResult = passengerCar.calcTravelTime(fuelOnHand: 1, distance: 1000);

            Assert.AreEqual(calcResult.FailReason, "Недостаточно топлива");
        }
        [TestMethod()]
        public void travelTime_5liter100km_2h()
        {
            Automobile_PassengerCar passengerCar = Automobile_PassengerCarTests.constructTestCar();

            TravelTimeCalculationResult calcResult = passengerCar.calcTravelTime(fuelOnHand: 5, distance: 100);

            Assert.AreEqual(calcResult.TravelTime, 2);
        }



        public static Automobile_PassengerCar constructTestCar()
        {
            return new Automobile_PassengerCar(_avgFuelConsumption: 0.05m, _fuelTankSize: 50, _avgSpeed: 50);
        }
    }
}