using Microsoft.AspNetCore.Mvc;
using majumi.CarService.MechanicsAppService.Rest.Model;
using majumi.CarService.MechanicsAppService.Model;


namespace majumi.CarService.MechanicsAppService.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class MechanicAppController : ControllerBase
{
    private readonly ILogger<MechanicAppController> _logger;
    
    private MechanicRESTClient client;
    public MechanicAppController(ILogger<MechanicAppController> logger)
    {
        _logger = logger;
        client = new MechanicRESTClient();
    }

    [HttpGet]
    [Route("/login/{id:int}")]
    public async Task<ActionResult<MechanicLoginStatus>> MechanicLogIn(int id)
    {
        MechanicLoginStatus mechanicLoginStatus = await client.MechanicLogIn(id);
        if (!mechanicLoginStatus.IsSuccesfull)
            return Unauthorized();

        return Ok(mechanicLoginStatus);
    }

    [HttpPatch]
    [Route("/updateVisitStatus/{id:int}/{mechanicid:int}/{status}/{cost:int}")]
    public ActionResult<bool> UpdateVisitStatus(int id, int mechanicid, string status, int cost)
    {
        return Ok(client.UpdateVisitStatus(id, mechanicid, status, cost).Result);
    }

    [HttpGet]
    [Route("/getAllVisitsByMechanic/{id:int}")]
    public async Task<ActionResult<List<VisitData>>> GetMechanicSchedule(int id)
    {
        List<Visit> visits = await client.GetMechanicSchedule(id);
        List<VisitData> visitData = new();
        foreach(Visit visit in visits)
        {
            visitData.Add(DataConverter.ConvertToVisitData(visit));
        }

        return Ok(visitData);
    }

    [HttpGet]
    [Route("/getAllVisitsByMechanicInDay/{id:int}/{year:int}/{month:int}/{day:int}")]
    public async Task<ActionResult<List<VisitData>>> GetMechanicScheduleAt(int id, int year, int month, int day)
    {
        List<Visit> visits = await client.GetMechanicScheduleAt(id, year, month, day);
        List<VisitData> visitData = new();
        foreach (Visit visit in visits)
        {
            visitData.Add(DataConverter.ConvertToVisitData(visit));
        }

        return Ok(visitData);
    }
    
    [HttpGet]
    [Route("/getAllCars")]
    public async Task<ActionResult<List<CarData>>> GetAllCars()
    {
        List<Car> cars = await client.GetAllCars();
        List<CarData> carData = new();
        foreach (Car car in cars)
        {
            carData.Add(DataConverter.ConvertToCarData(car));
        }

        return Ok(carData);
    }

    [HttpGet]
    [Route("/getCar/{id:int}")]
    public async Task<ActionResult<CarData>> GetCar(int id)
    {
        Car car = await client.GetCar(id);
        if (car == null)
            return NotFound();

        CarData carData = DataConverter.ConvertToCarData(car);

        return Ok(carData);
    }

    [HttpGet]
    [Route("/getVisit/{id:int}")]
    public async Task<ActionResult<VisitData>> GetVisit(int id)
    {
        Visit visit = await client.GetVisit(id);
        if (visit == null)
            return NotFound();

        VisitData visitData = DataConverter.ConvertToVisitData(visit);

        return Ok(visitData);
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests(string host, int port)
    {
        throw new NotImplementedException();
    }
};