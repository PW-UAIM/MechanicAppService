using majumi.CarService.MechanicsAppService.Model;
using majumi.CarService.MechanicsAppService.Rest.Model;
using System.ComponentModel;
using System.Text.Json;

namespace majumi.CarService.MechanicsAppService.Rest;

public class MechanicRESTClient
{
    private const string CarDataServiceURL = "http://localhost:5000/";
    private const string ClientsDataServiceURL = "http://localhost:5001/";
    private const string MechanicDataServiceURL = "http://localhost:5002/";
    private const string VisitDataServiceURL = "http://localhost:5003/";

    public MechanicRESTClient()
    {

    }

    public async Task<MechanicLoginStatus> MechanicLogIn(int id)
    {
        Mechanic mechanic;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(MechanicDataServiceURL);

            var result = await client.GetAsync($"mechanic/{id}");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                mechanic = JsonSerializer.Deserialize<Mechanic>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new MechanicLoginStatus(false, null);
            }
        }

        return new MechanicLoginStatus(true, mechanic);
    }
    public async Task<Car[]> GetAllCars()
    {
        Car[] cars;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(CarDataServiceURL);

            var result = await client.GetAsync($"car/all");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                cars = JsonSerializer.Deserialize<Car[]>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return cars;
    }
    public async Task<Car> GetCar(int id)
    {
        Car car;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(CarDataServiceURL);

            var result = await client.GetAsync($"car/{id}");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                car = JsonSerializer.Deserialize<Car>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return car;
    }
    public async Task<Visit> GetVisit(int id)
    {
        Visit visit;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"visit/{id}");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                visit = JsonSerializer.Deserialize<Visit>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return visit;
    }

    public async Task<Visit[]> GetMechanicScheduleAt(int id, int year, int month, int day)
    {
        Visit[] visits;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"visit/all");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                visits = JsonSerializer.Deserialize<Visit[]>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return (Visit[]) visits.Where(visit => (visit.ServiceDate == new DateTime(year, month, day) && visit.MechanicID == id));
    }

    public async Task<Visit[]> GetMechanicSchedule(int mechanicID)
    {
        Visit[] visits;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"visit/all");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                visits = JsonSerializer.Deserialize<Visit[]>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return (Visit[])visits.Where(visit => visit.MechanicID == mechanicID);
    }

    
    public async Task<bool> visitUpdate(int id)
    {
        bool status;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"visit/{id}/update");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                status = JsonSerializer.Deserialize<bool>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        return status;
    }
}




