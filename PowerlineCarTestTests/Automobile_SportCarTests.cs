﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void new_zeroes_fail()
        {
            Automobile_SportCar sportCar = new Automobile_SportCar(_avgFuelConsumption: 0.1M, _fuelTankSize: 50M, _avgSpeed: 0);

            string exceptionText = "";
            try
            {
                decimal maxDistance = sportCar.maxDistance();
            }
            catch (Exception ex)
            {
                exceptionText = ex.Message;
            }

            Assert.AreEqual(exceptionText, "Не указана средняя скорость");
        }

        
        [TestMethod()]
        public void maxDistanceFullTank_50liters_500km()
        {
            Automobile_SportCar sportCar = Automobile_SportCarTests.constructTestCar();

            decimal maxDistance = sportCar.maxDistance();

            Assert.AreEqual(maxDistance, 500);
        }
        [TestMethod()]
        public void maxDistance_50liters_500km()
        {
            Automobile_SportCar sportCar = Automobile_SportCarTests.constructTestCar();

            decimal maxDistance = sportCar.maxDistance(fuelOnHand: 50);

            Assert.AreEqual(maxDistance, 500);
        }
        [TestMethod()]
        public void travelTime_0liters_fail()
        {
            Automobile_SportCar sportCar = Automobile_SportCarTests.constructTestCar(); ;

            TravelTimeCalculationResult calcResult = sportCar.calcTravelTime(fuelOnHand: 0, distance: 100);

            Assert.AreEqual(calcResult.Success, false);
        }
        [TestMethod()]
        public void travelTime_50liters100km_1h()
        {
            Automobile_SportCar sportCar = Automobile_SportCarTests.constructTestCar();

            TravelTimeCalculationResult calcResult = sportCar.calcTravelTime(fuelOnHand: 50, distance: 100);

            Assert.AreEqual(calcResult.TravelTime, 1);
        }
        public static Automobile_SportCar constructTestCar()
        {
            return new Automobile_SportCar(_avgFuelConsumption: 0.1M, _fuelTankSize: 50M, _avgSpeed: 100M);
        }

    }
}