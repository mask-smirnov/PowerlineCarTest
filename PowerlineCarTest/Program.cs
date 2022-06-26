using PowerlineCarTest;

Automobile_Truck truck = new Automobile_Truck(_avgFuelConsumption: 0.2M, _fuelTankSize: 100M, _avgSpeed: 50M);

Console.WriteLine("Maxumum distance on full tank: {0} km", truck.maxDistanceFullTank());
Console.WriteLine("Maxumum distance on full tank with 100 kg load: {0} km", truck.maxDistanceFullTank(100));
Console.WriteLine("Maxumum distance on 10 liters: {0} km", truck.maxDistance(10));
Console.WriteLine("Maxumum distance on 10 liters with 100 kg load: {0} km", truck.maxDistance(10, 100));

TravelTimeCalculationResult ttcr = truck.calcTravelTime(fuelOnHand: 10, distance: 100, loadWeight: 400);

Console.WriteLine("Travel is {0}", ttcr.Success ? "possible" : "not possible");
if (!ttcr.Success)
    Console.WriteLine("The reason travel is not possible is {0}", ttcr.FailReason);
Console.WriteLine("Travel time is {0} h", ttcr.TravelTime);



