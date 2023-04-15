namespace majumi.CarService.MechanicsAppService.Model;

public class Visit
{
    public int VisitID { get; set; }
    public int ClientID { get; set; }
    public int CarID { get; set; }
    public int MechanicID { get; set; }
    public string ServiceType { get; set; }
    public DateTime ServiceDate { get; set; }
    public int ServiceCost { get; set; }
    public string ServiceStatus { get; set; }
    public string Notes { get; set; }



    public Visit() { }

    public Visit(int visitID, int clientID, string serviceType, DateTime serviceDate,
    int serviceCost, string serviceStatus, string notes, int mechanicID, int carID)
    {
        VisitID = visitID;
        ClientID = clientID;
        ServiceType = serviceType;
        ServiceDate = serviceDate;
        ServiceCost = serviceCost;
        ServiceStatus = serviceStatus;
        Notes = notes;
        MechanicID = mechanicID;
        CarID = carID;
    }
}