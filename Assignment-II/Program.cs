var car = new Car(1234,"Nissan","X-TRAIL",2018);
car.SetFuelEfficiency(38);
Console.WriteLine(car.DisplayInfo());

Console.WriteLine("----------------------------------");

var ecar = new ElectricCar(5678,"MG"," MG4 EV",2023, 450);
Console.WriteLine(ecar.DisplayInfo()); 

