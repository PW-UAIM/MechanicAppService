namespace majumi.CarService.MechanicsAppService.Rest.Model;

public class VisitData
{
    public int VisitID { get; set; }
    public int ClientID { get; set; }
    public string ServiceType { get; set; }
    public DateTime ServiceDate { get; set; }
    public string ServiceTime { get; set; }
    public string ServiceLocation { get; set; }
    public int ServiceCost { get; set; }
    public string ServiceStatus { get; set; }
    public string Notes { get; set; }
    public int Rating { get; set; }
    public int MechanicID { get; set; }
    public int CarID { get; set; }
}