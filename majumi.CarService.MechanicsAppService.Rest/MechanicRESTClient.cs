using majumi.CarService.MechanicsAppService.Model;
using majumi.CarService.MechanicsAppService.Rest.Model;
using System.Text.Json;

namespace majumi.CarService.MechanicsAppService.Rest;

public class MechanicRESTClient
{
    private const string CarDataServiceURL = "http://localhost:5000/";
    private const string MechanicDataServiceURL = "http://localhost:5002/";
    private const string VisitDataServiceURL = "http://localhost:5003/";

    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
    };
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
                mechanic = JsonSerializer.Deserialize<Mechanic>(resultContent, options);
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
        var car = new List<Car>();

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(CarDataServiceURL);

            var result = await client.GetAsync($"car/all");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                CarData[] carData = JsonSerializer.Deserialize<CarData[]>(resultContent, options);
                foreach(CarData c in carData)
                {
                   car.Add(DataConverter.ConvertToCar(c));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return car.ToArray();
    }
    public async Task<Car> GetCar(int id)
    {
        Car car;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var result = await httpClient.GetAsync($"car/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);
            try
            {
                CarData c = JsonSerializer.Deserialize<CarData>(resultContent, options);
                car = DataConverter.ConvertToCar(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Car();
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
                VisitData v = JsonSerializer.Deserialize<VisitData>(resultContent, options);
                visit = DataConverter.ConvertToVisit(v);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Visit();
            }
        }

        return visit;
    }

    public async Task<Visit[]> GetMechanicScheduleAt(int id, int year, int month, int day)
    {
        var visit = new List<Visit>();

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"visit/all");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                VisitData[] visitData = JsonSerializer.Deserialize<VisitData[]>(resultContent, options);
                foreach(VisitData v in visitData)
                {
                    visit.Add(DataConverter.ConvertToVisit(v));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return (visit.Where(visit => (visit.ServiceDate == new DateTime(year, month, day) && visit.MechanicID == id)).ToArray());
    }

    public async Task<Visit[]> GetMechanicSchedule(int mechanicID)
    {
        var visit = new List<Visit>();

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"visit/all");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                VisitData[] visitData = JsonSerializer.Deserialize<VisitData[]>(resultContent, options);
                foreach (VisitData v in visitData)
                {
                    visit.Add(DataConverter.ConvertToVisit(v));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return (visit.Where(visit => visit.MechanicID == mechanicID).ToArray());
    }

    
    public async Task<bool> visitStatusUpdate(int id, string new_status)
    {
        bool status;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"visit/{id}/status/{new_status}");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                status = JsonSerializer.Deserialize<bool>(resultContent, options);
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




