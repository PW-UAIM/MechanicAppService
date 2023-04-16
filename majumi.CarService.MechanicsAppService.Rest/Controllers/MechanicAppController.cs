using Microsoft.AspNetCore.Mvc;
using majumi.CarService.MechanicsAppService.Rest.Model;
using majumi.CarService.MechanicsAppService.Rest.Tests;
using majumi.CarService.MechanicsAppService.Model;
using System;


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
    public ActionResult<MechanicLoginStatus> MechanicLogIn(int id)
    {
        MechanicLoginStatus mechanicLoginStatus = client.MechanicLogIn(id).Result;
        if (mechanicLoginStatus.IsSuccesfull == false)
            return Unauthorized();

        return Ok(mechanicLoginStatus);
    }

    [HttpPatch]
    [Route("/visit/{id:int}/update/{status}")]
    public ActionResult<bool> visitStatusUpdate(int id, string status)
    {
        return Ok(client.visitStatusUpdate(id, status).Result);
    }

    [HttpGet]
    [Route("/visit/mechanic/{id:int}")]
    public ActionResult<List<VisitData>> GetMechanicSchedule(int id)
    {
        List<Visit> visits = client.GetMechanicSchedule(id).Result;
        List<VisitData> visitData = new();
        foreach(Visit v in visits)
        {
            visitData.Add(DataConverter.ConvertToVisitData(v));
        }

        return Ok(visitData);
    }

    [HttpGet]
    [Route("/visit/mechanic/{id:int}/date/{year:int}/{month:int}/{day:int}")]
    public ActionResult<List<VisitData>> GetMechanicScheduleAt(int id, int year, int month, int day)
    {
        List<Visit> visits = client.GetMechanicScheduleAt(id, year, month, day).Result;
        List<VisitData> visitData = new();
        foreach (Visit v in visits)
        {
            visitData.Add(DataConverter.ConvertToVisitData(v));
        }

        return Ok(visitData);
    }
    
    [HttpGet]
    [Route("/car/all")]
    public ActionResult<List<CarData>> GetAllCars()
    {
        List<Car> cars = client.GetAllCars().Result;
        List<CarData> carData = new();
        foreach (Car c in cars)
        {
            carData.Add(DataConverter.ConvertToCarData(c));
        }

        return Ok(carData);
    }

    [HttpGet]
    [Route("/car/{id:int}")]
    public ActionResult<CarData> GetCar(int id)
    {
        Car car = client.GetCar(id).Result;
        if (car == null)
            return NotFound();

        CarData carData = DataConverter.ConvertToCarData(car);

        return Ok(carData);
    }

    [HttpGet]
    [Route("/visit/{id:int}")]
    public ActionResult<VisitData> GetVisit(int id)
    {
        Visit visit = client.GetVisit(id).Result;
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