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
    public class Automobile_SportCarTests
    {
        [TestMethod()]
        public void maxDistance_FullTank50_500()
        {
            Automobile_SportCar sportCar = new Automobile_SportCar(_avgFuelConsumption: 0.1M, _fuelTankSize: 50M, _avgSpeed: 100M);

            decimal maxDistance = sportCar.maxDistance();

            Assert.AreEqual(maxDistance, 500);
        }
        [TestMethod()]
        public void maxDistance_50_500()
        {
            Automobile_SportCar sportCar = new Automobile_SportCar(_avgFuelConsumption: 0.1M, _fuelTankSize: 50M, _avgSpeed: 100M);

            decimal maxDistance = sportCar.maxDistance(fuelOnHand: 50);

            Assert.AreEqual(maxDistance, 500);
        }
        [TestMethod()]
        public void travelTime_0_fail()
        {
            Automobile_SportCar sportCar = new Automobile_SportCar(_avgFuelConsumption: 0.1M, _fuelTankSize: 50M, _avgSpeed: 100M);

            TravelTimeCalculationResult calcResult = sportCar.calcTravelTime(fuelOnHand: 0, distance: 100);

            Assert.AreEqual(calcResult.Success, false);
        }
        [TestMethod()]
        public void travelTime_100and1_1()
        {
            Automobile_SportCar sportCar = new Automobile_SportCar(_avgFuelConsumption: 0.1M, _fuelTankSize: 50M, _avgSpeed: 100M);

            TravelTimeCalculationResult calcResult = sportCar.calcTravelTime(fuelOnHand: 50, distance: 100);

            Assert.AreEqual(calcResult.TravelTime, 1);
        }

    }
}