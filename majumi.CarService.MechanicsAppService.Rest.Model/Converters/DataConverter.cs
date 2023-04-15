using majumi.CarService.MechanicsAppService.Model;

namespace majumi.CarService.MechanicsAppService.Rest.Model;

public static class DataConverter
{
    public static MechanicData ConvertToMechanicData(this Mechanic mechanic)
    {
        return new MechanicData
        {
            MechanicID = mechanic.MechanicID,
            Name = mechanic.Name,
            Surname = mechanic.Surname,
            BirthDate = mechanic.BirthDate,
            HireDate = mechanic.HireDate,
            Specialty = mechanic.Specialty,
            Address = mechanic.Address,
            Phone = mechanic.Phone,
            Email = mechanic.Email
        };
    }

    public static CarData ConvertToCarData(this Car car)
    {
        return new CarData
        {
            CarID = car.CarID,
            Make = car.Make,
            Model = car.Model,
            Year = car.Year,
            Mileage = car.Mileage,
            EngineSize = car.EngineSize,
            VIN = car.VIN,
            LicensePlate = car.LicensePlate,
            ClientID = car.ClientID
        };
    }

    public static VisitData ConvertToVisitData(this Visit visit)
    {
        return new VisitData
        {
            VisitID = visit.VisitID,
            ClientID = visit.ClientID,
            ServiceType = visit.ServiceType,
            ServiceDate = visit.ServiceDate,
            ServiceCost = visit.ServiceCost,
            ServiceStatus = visit.ServiceStatus,
            Notes = visit.Notes,
            MechanicID = visit.MechanicID,
            CarID = visit.CarID
        };
    }


    public static Car ConvertToCar(this CarData car)
    {
        return new Car
        {
            CarID = car.CarID,
            Make = car.Make,
            Model = car.Model,
            Year = car.Year,
            Mileage = car.Mileage,
            EngineSize = car.EngineSize,
            VIN = car.VIN,
            LicensePlate = car.LicensePlate,
            ClientID = car.ClientID
        };
    }


    public static Visit ConvertToVisit(this VisitData visit)
    {
        return new Visit
        {
            VisitID = visit.VisitID,
            ClientID = visit.ClientID,
            ServiceType = visit.ServiceType,
            ServiceDate = visit.ServiceDate,
            ServiceCost = visit.ServiceCost,
            ServiceStatus = visit.ServiceStatus,
            Notes = visit.Notes,
            MechanicID = visit.MechanicID,
            CarID = visit.CarID
        };
    }


}