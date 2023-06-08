using majumi.CarService.MechanicsAppService.Model;
using majumi.CarService.MechanicsAppService.Rest.Model;
using System.Text.Json;

namespace majumi.CarService.MechanicsAppService.Rest;

public class MechanicRESTClient
{
    private string CarDataServiceURL = "https://localhost:5000/";
    private string MechanicDataServiceURL = "https://localhost:5002/";
    private string VisitDataServiceURL = "https://localhost:5003/";

    private JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
    };

    public MechanicRESTClient()
    {
        if (System.Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
        {
            CarDataServiceURL = "http://carsdataservice:5000/";
            MechanicDataServiceURL = "https://mechanicsdataservice:5002/";
            VisitDataServiceURL = "http://visitsdataservice:5003/";
        }
    }

    public async Task<MechanicLoginStatus> MechanicLogIn(int id)
    {
        MechanicData mechanicData;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(MechanicDataServiceURL);

            var result = await client.GetAsync($"getMechanic/{id}");

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
        var carResult = new List<Car>();

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(CarDataServiceURL);

            var result = await client.GetAsync($"getAllCars");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                List<CarData> carData = JsonSerializer.Deserialize<CarData[]>(resultContent, options).ToList();
                foreach(CarData car in carData)
                {
                    carResult.Add(DataConverter.ConvertToCar(car));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return carResult;
    }
    public async Task<Car?> GetCar(int id)
    {
        Car carResult;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var result = await httpClient.GetAsync($"getCar/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();
            if (!result.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                return null;
            try
            {
                CarData carData = JsonSerializer.Deserialize<CarData>(resultContent, options);
                carResult = DataConverter.ConvertToCar(carData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Car();
            }
        }
        return carResult;
    }
    public async Task<Visit> GetVisit(int id)
    {
        Visit visitResult;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"getVisit/{id}");
            if (!result.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                return null;
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                VisitData visitData = JsonSerializer.Deserialize<VisitData>(resultContent, options);
                visitResult = DataConverter.ConvertToVisit(visitData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Visit();
            }
        }

        return visitResult;
    }

    public async Task<List<Visit>> GetMechanicScheduleAt(int id, int year, int month, int day)
    {
        var visitResult = new List<Visit>();

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"getAllVisits");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                List<VisitData> visitData = JsonSerializer.Deserialize<VisitData[]>(resultContent, options).ToList();
                foreach(VisitData visit in visitData)
                {
                    visitResult.Add(DataConverter.ConvertToVisit(visit));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return visitResult.Where(visit => (visit.ServiceDate == new DateTime(year, month, day) && visit.MechanicID == id)).ToList();
    }

    public async Task<List<Visit>> GetMechanicSchedule(int mechanicID)
    {
        var visitResult = new List<Visit>();

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.GetAsync($"getAllVisits");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                List<VisitData> visitData = JsonSerializer.Deserialize<VisitData[]>(resultContent, options).ToList();
                foreach (VisitData visit in visitData)
                {
                    visitResult.Add(DataConverter.ConvertToVisit(visit));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return visitResult.Where(visit => visit.MechanicID == mechanicID || visit.MechanicID == -1).ToList();
    }

    
    public async Task<bool> UpdateVisitStatus(int id, int mechanicid, string new_status, int cost)
    {
        VisitData visitData;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(VisitDataServiceURL);

            var result = await client.PatchAsync($"updateVisitStatus/{id}/{mechanicid}/{new_status}/{cost}", null);
            if (!result.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                return false;
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                visitData = JsonSerializer.Deserialize<VisitData>(resultContent, options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        if (visitData == null)
            return false;

        return visitData.ServiceStatus == new_status;
    }
}