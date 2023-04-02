Wnamespace majumi.CarService.MechanicsAppService.Rest.Model;

public class MechanicLoginStatus
{
    public bool IsLoggedIn { get; set; }
    public int MechanicID { get; set; }

    public MechanicLoginStatus(bool isLoggedIn, int mechanicID)
    {
        IsLoggedIn = isLoggedIn;
        MechanicID = mechanicID;
    }

    public MechanicLoginStatus()
    {
    }
}