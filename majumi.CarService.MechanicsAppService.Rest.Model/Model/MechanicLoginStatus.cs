using majumi.CarService.MechanicsAppService.Model;

namespace majumi.CarService.MechanicsAppService.Rest.Model;

public class MechanicLoginStatus
{
    public bool IsSuccesfull { get; set; }
    public Mechanic Mechanic { get; set; }

    public MechanicLoginStatus() { }
    public MechanicLoginStatus(bool isSuccesfull, Mechanic mechanic)
    {
        IsSuccesfull = isSuccesfull;
        Mechanic = mechanic;
    }   
}