using majumi.CarService.MechanicsAppService.Model;
using System.Text.Json;

namespace majumi.CarService.MechanicsAppService.Rest;

public class MechanicRESTClient
{
    private const string MechanicDataServiceURL = "http://localhost:5001/";
    private const string CarDataServiceURL = null;
    private const string VisitDataServiceURL = null;

    public MechanicRESTClient()
    {
        if (MechanicDataServiceURL == null || CarDataServiceURL == null || VisitDataServiceURL == null)
            throw new NotImplementedException();
        // Leave empty constructor after implementation
    }

    public async Task<Mechanic> MechanicLogIn(int id)
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
                return null;
            }
        }

        return mechanic;
    }
    public async Task<Car> GetCar(int id)
    {
        throw new NotImplementedException();
    }
    public async Task<Visit> GetVisit(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Visit[]> GetVisitsAt(int month, int day)
    {
        throw new NotImplementedException();
    }
}




