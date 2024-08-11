class Car : Vehicle, IFuelEfficient
{
    public int ProducedYear {get;set;}
    private int fuelEfficiency;

    public Car(int vin, string brand, string model, int year):base(vin,brand, model)
    {
        ProducedYear = year;
    }
    public int DisplayFuelEfficiency()=> fuelEfficiency;

    public void SetFuelEfficiency(int efficiency)
    {
        fuelEfficiency = efficiency;
    }
    public override string DisplayInfo()
    {
         var details =  base.DisplayInfo();
        details += $"\nReleased Year:{ProducedYear}\nFuel Efficiency:{fuelEfficiency} Km/l";
        return details;
    }
    
}

public abstract class Vehicle
{
    public int VIN {get;}
    public string Brand { get; set;}
    string model = string.Empty;
    public string Model
    {
        get { return model; }
        set {model = value; }
    }
    public Vehicle(int vin,string brand ,string model)
    {
        VIN = vin;
        Brand = brand;
        Model = model;
    }
    public virtual string DisplayInfo()
    {
        var vehicleInfo = $"Brand name:{Brand}\nModel:{Model}\nVIN:{VIN}";
        return vehicleInfo;
    }
}

interface IFuelEfficient
{
    public int DisplayFuelEfficiency();
    void SetFuelEfficiency(int efficiency);
}

class ElectricCar:Car
{
    public static int BatteryCapacity;
    public ElectricCar(int vin,string brand, string model, int year, int range)
    :base(vin, brand,model,year)
    {
        BatteryCapacity = range;
    }
    public void ChargeCar()
    {
        Console.WriteLine("Car is charging");
    }
    public override string DisplayInfo()
    {
        var details = base.DisplayInfo();
        details += $"\nBattery capacity: {BatteryCapacity} kwh";
        return details;
    }
}