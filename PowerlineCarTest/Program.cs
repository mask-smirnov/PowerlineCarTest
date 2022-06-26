using PowerlineCarTest;

Automobile_SportCar sportCar = new Automobile_SportCar(_avgFuelConsumption: 0.1M, _fuelTankSize: 50M, _avgSpeed: 100M);

Console.WriteLine("Maxumum distance on full tank: {0} km", sportCar.maxDistance());
Console.WriteLine("Maxumum distance on 10 liters: {0} km", sportCar.maxDistance(10));

TravelTimeCalculationResult ttcr = sportCar.calcTravelTime(fuelOnHand: 10, distance: 100);

Console.WriteLine("Travel is {0}", ttcr.Success ? "possible" : "not possible");
if (!ttcr.Success)
    Console.WriteLine("The reason travel is not possible is {0}", ttcr.FailReason);
Console.WriteLine("Travel time is {0} h", ttcr.TravelTime);



