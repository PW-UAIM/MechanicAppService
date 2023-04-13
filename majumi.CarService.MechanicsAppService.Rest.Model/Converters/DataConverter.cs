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
            VacationDays = mechanic.VacationDays,
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
            Color = car.Color,
            Mileage = car.Mileage,
            Transmission = car.Transmission,
            FuelType = car.FuelType,
            EngineSize = car.EngineSize,
            Horsepower = car.Horsepower,
            Torque = car.Torque,
            Drivetrain = car.Drivetrain,
            SeatingCapacity = car.SeatingCapacity,
            VehicleType = car.VehicleType,
            Location = car.Location,
            VIN = car.VIN,
            LicensePlate = car.LicensePlate,
            Warranty = car.Warranty
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
            ServiceTime = visit.ServiceTime,
            ServiceLocation = visit.ServiceLocation,
            ServiceCost = visit.ServiceCost,
            ServiceStatus = visit.ServiceStatus,
            Notes = visit.Notes,
            Rating = visit.Rating,
            MechanicID = visit.MechanicID,
            CarID = visit.CarID
        };
    }
}