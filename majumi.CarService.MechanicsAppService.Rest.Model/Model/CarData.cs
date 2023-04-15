namespace majumi.CarService.MechanicsAppService.Rest.Model;

public class CarData
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

}
