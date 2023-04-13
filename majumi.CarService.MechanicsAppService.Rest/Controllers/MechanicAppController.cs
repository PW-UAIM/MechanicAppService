using Microsoft.AspNetCore.Mvc;
using majumi.CarService.MechanicsAppService.Rest.Model;
using majumi.CarService.MechanicsAppService.Rest.Tests;
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
    [Route("/mechanic/{id:int}/login")]
    public MechanicLoginStatus MechanicLogIn(int id)
    {
        return client.MechanicLogIn(id).Result;
    }

    [HttpPost]
    [Route("/visit/{id:int}/update")]
    public bool visitUpdate(int id)
    {
        return client.visitUpdate(id).Result;
    }

    [HttpGet]
    [Route("/visit/mechanic/{id:int}")]
    public Visit[] GetMechanicSchedule(int id)
    {
        return client.GetMechanicSchedule(id).Result;
    }

    [HttpGet]
    [Route("/visit/mechanic/{id:int}/date/{year:int}/{month:int}/{day:int}")]
    public Visit[] GetMechanicScheduleAt(int id, int year, int month, int day)
    {
        return client.GetMechanicScheduleAt(id, year, month, day).Result;
    }
    
    [HttpGet]
    [Route("/car/all")]
    public Car[] GetAllCars()
    {
        return client.GetAllCars().Result;
    }

    [HttpGet]
    [Route("/car/{id:int}")]
    public Car GetCar(int id)
    {
        return client.GetCar(id).Result;
    }

    [HttpGet]
    [Route("/visit/{id:int}")]
    public Visit GetVisit(int id)
    {
        return client.GetVisit(id).Result;
    }

    /*
    [HttpGet]
    [Route("/runTests")]
    public string RunTests(string host, int port)
    {
        Tests.Tests test = new Tests.Tests();
        return test.RunTests(host, port);
    }
    */
};