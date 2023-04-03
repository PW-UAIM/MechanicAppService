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
        throw new NotImplementedException();
    }

    public static VisitData ConvertToVisitData(this Visit visit)
    {
        throw new NotImplementedException();
    }
}