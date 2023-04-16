using majumi.CarService.MechanicsAppService.Model;

namespace majumi.CarService.MechanicsAppService.Rest.Model;

public class MechanicLoginStatus
{
    public bool IsSuccesfull { get; set; }
    public MechanicData? Mechanic { get; set; }

    public MechanicLoginStatus() { }
    public MechanicLoginStatus(bool isSuccesfull, MechanicData? mechanicData)
    {
        IsSuccesfull = isSuccesfull;
        Mechanic = mechanicData;
    }   
}