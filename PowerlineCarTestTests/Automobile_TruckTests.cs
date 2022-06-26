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
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar();

            decimal maxDistance = truck.maxDistanceFullTank();

            Assert.AreEqual(maxDistance, 500);
        }
        [TestMethod()]
        public void maxDistanceFullTank_200kg_distance480()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar();

            decimal maxDistance = truck.maxDistanceFullTank(loadWeight: 200);

            Assert.AreEqual(maxDistance, 480M);
        }

        [TestMethod()]
        public void maxDistance_20liter0kg_distance100()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar();

            decimal maxDistance = truck.maxDistance(fuelOnHand: 20);

            Assert.AreEqual(maxDistance, 100);
        }
        [TestMethod()]
        public void maxDistance_20liter200kg_distance96()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar();

            decimal maxDistance = truck.maxDistance(fuelOnHand: 20, loadWeight: 200);

            Assert.AreEqual(maxDistance, 100M * 0.96M);
        }
        [TestMethod()]
        public void maxDistance_20liter600kg_distance96()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar();

            decimal maxDistance = truck.maxDistance(fuelOnHand: 20, loadWeight: 600);

            Assert.AreEqual(maxDistance, 100M * 0.96M * 0.96M * 0.96M);
        }

        [TestMethod()]
        public void travelTime_1liter1000km0kg_fail()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar();

            TravelTimeCalculationResult calcResult = truck.calcTravelTime(fuelOnHand: 1, distance: 1000);

            Assert.AreEqual(calcResult.FailReason, "Недостаточно топлива");
        }
        [TestMethod()]
        public void travelTime_20liter100km0kg_2h()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar();

            TravelTimeCalculationResult calcResult = truck.calcTravelTime(fuelOnHand: 20, distance: 100);

            Assert.AreEqual(calcResult.TravelTime, 2);
        }
        [TestMethod()]
        public void travelTime_20liter100km1000000kg_fail()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar();

            TravelTimeCalculationResult calcResult = truck.calcTravelTime(fuelOnHand: 20, distance: 100, loadWeight: 1000000);

            Assert.AreEqual(calcResult.FailReason, "Недостаточно топлива при такой массе груза");
        }
        [TestMethod()]
        public void travelTime_100liter100km200kg_2h()
        {
            Automobile_Truck truck = Automobile_TruckTests.constructTestCar();

            TravelTimeCalculationResult calcResult = truck.calcTravelTime(fuelOnHand: 100, distance: 100, loadWeight: 200);

            Assert.AreEqual(calcResult.TravelTime, 2);
        }

        public static Automobile_Truck constructTestCar()
        {
            return new Automobile_Truck(_avgFuelConsumption: 0.2m, _fuelTankSize: 100, _avgSpeed: 50);
        }
    }
}