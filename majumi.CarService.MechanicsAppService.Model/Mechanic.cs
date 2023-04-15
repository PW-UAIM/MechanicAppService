namespace majumi.CarService.MechanicsAppService.Model;

public class Mechanic
{
    public int MechanicID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public string Specialty { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public Mechanic() { }
    public Mechanic(int mechanicID, string name, string surname, DateTime birthDate, DateTime hireDate, string speciality,
                    string address, string phone, string email)
    {
        MechanicID = mechanicID;
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
        HireDate = hireDate;
        Specialty = speciality;
        Address = address;
        Phone = phone;
        Email = email;
    }
}