using majumi.CarService.MechanicsAppService.Model;
using majumi.CarService.MechanicsAppService.Rest.Model;
using System.Text.Json;

namespace majumi.CarService.MechanicsAppService.Rest;

public class MechanicRESTClient
{
    private const string CarDataServiceURL = "https://localhost:5000/";
    private const string MechanicDataServiceURL = "https://localhost:5002/";
    private const string VisitDataServiceURL = "https://localhost:5003/";

    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
    };
    public MechanicRESTClient() { }

    public async Task<MechanicLoginStatus> MechanicLogIn(int id)
    {
        MechanicData mechanicData;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(MechanicDataServiceURL);

            var result = await client.GetAsync($"mechanic/{id}");

            string resultContent = await result.Content.ReadAsStringAsync();

            if (!result.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                return new MechanicLoginStatus(false, null);

            try
            {
                mechanicData = JsonSerializer.Deserialize<MechanicData>(resultContent, options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new MechanicLoginStatus(false, null);
            }
        }

        return new MechanicLoginStatus(true, mechanicData);
    }
    public async Task<List<Car>> GetAllCars()
    {
        var car = new List<Car>();

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(CarDataServiceURL);

            var result = await client.GetAsync($"car/all");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                List<CarData> carData = JsonSerializer.Deserialize<CarData[]>(resultContent, options).ToList();
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

        return car;
    }
    public async Task<Car?> GetCar(int id)
    {
        Car car;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var result = await httpClient.GetAsync($"car/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();
            if (!result.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                return null;
            try
            {
                CarData carData = JsonSerializer.Deserialize<CarData>(resultContent, options);
                car = DataConverter.ConvertToCar(carData);
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
            if (!result.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                return null;
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                VisitData visitData = JsonSerializer.Deserialize<VisitData>(resultContent, options);
                visit = DataConverter.ConvertToVisit(visitData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Visit();
            }
        }

        return visit;
    }

    public async Task<List<Visit>> GetMechanicScheduleAt(int id, int year, int month, int day)
    {
        var visit = new List<Visit>();

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"visit/all");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                List<VisitData> visitData = JsonSerializer.Deserialize<VisitData[]>(resultContent, options).ToList();
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

        return visit.Where(visit => (visit.ServiceDate == new DateTime(year, month, day) && visit.MechanicID == id)).ToList();
    }

    public async Task<List<Visit>> GetMechanicSchedule(int mechanicID)
    {
        var visit = new List<Visit>();

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"visit/all");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                List<VisitData> visitData = JsonSerializer.Deserialize<VisitData[]>(resultContent, options).ToList();
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

        return visit.Where(visit => visit.MechanicID == mechanicID).ToList();
    }

    
    public async Task<bool> visitStatusUpdate(int id, string new_status)
    {
        bool status;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"visit/{id}/status/{new_status}");
            if (!result.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                return false;
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




