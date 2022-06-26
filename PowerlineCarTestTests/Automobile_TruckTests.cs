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
    public class Automobile_TruckTests
    {
        [TestMethod()]
        public void maxDistanceFullTank_0kg_distance500()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar(_loadWeight: 0);

            decimal maxDistance = truck.maxDistance();

            Assert.AreEqual(500, maxDistance);
        }
        [TestMethod()]
        public void maxDistanceFullTank_200kg_distance480()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar(_loadWeight: 200);

            decimal maxDistance = truck.maxDistance();

            Assert.AreEqual(480, maxDistance);
        }

        [TestMethod()]
        public void maxDistance_20liter0kg_distance100()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar(_loadWeight: 0);

            decimal maxDistance = truck.maxDistance(fuelOnHand: 20);

            Assert.AreEqual(100, maxDistance);
        }
        [TestMethod()]
        public void maxDistance_20liter200kg_distance96()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar(_loadWeight: 200);

            decimal maxDistance = truck.maxDistance(fuelOnHand: 20);

            Assert.AreEqual(100M * 0.96M, maxDistance);
        }
        [TestMethod()]
        public void maxDistance_20liter600kg_distance96()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar(_loadWeight: 600);

            decimal maxDistance = truck.maxDistance(fuelOnHand: 20);

            Assert.AreEqual(100M * 0.96M * 0.96M * 0.96M, maxDistance);
        }

        [TestMethod()]
        public void travelTime_1liter1000km0kg_fail()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar(_loadWeight: 0);

            TravelTimeCalculationResult calcResult = truck.calcTravelTime(fuelOnHand: 1, distance: 1000);

            Assert.AreEqual("Недостаточно топлива", calcResult.FailReason);
        }
        [TestMethod()]
        public void travelTime_20liter100km0kg_2h()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar(_loadWeight: 0);

            TravelTimeCalculationResult calcResult = truck.calcTravelTime(fuelOnHand: 20, distance: 100);

            Assert.AreEqual(2, calcResult.TravelTime);
        }
        [TestMethod()]
        public void travelTime_20liter100km1000000kg_fail()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar(_loadWeight: 1000000);

            TravelTimeCalculationResult calcResult = truck.calcTravelTime(fuelOnHand: 20, distance: 100);

            Assert.AreEqual("Недостаточно топлива", calcResult.FailReason);
        }
        [TestMethod()]
        public void travelTime_100liter100km200kg_2h()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar(_loadWeight: 200);

            TravelTimeCalculationResult calcResult = truck.calcTravelTime(fuelOnHand: 100, distance: 100);

            Assert.AreEqual(2, calcResult.TravelTime);
        }

        public static Automobile_Truck constructTestCar(decimal _loadWeight)
        {
            return new Automobile_Truck(_avgFuelConsumption: 0.2m, 
                                        _fuelTankSize: 100, 
                                        _avgSpeed: 50, 
                                        _loadWeight: _loadWeight);
        }
    }
}