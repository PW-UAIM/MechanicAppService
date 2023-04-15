namespace majumi.CarService.MechanicsAppService.Model;

public class Car
{
    public int CarID { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }
    public string EngineSize { get; set; }
    public string VIN { get; set; }
    public string LicensePlate { get; set; }
    public int ClientID { get; set; }


    public Car() { }

    public Car(int carID, string make, string model, int year, int mileage, string engineSize,
        string vin, string licensePlate, int clientID)
    {
        CarID = carID;
        Make = make;
        Model = model;
        Year = year;
        Mileage = mileage;
        EngineSize = engineSize;
        VIN = vin;
        LicensePlate = licensePlate;
    }
}
