using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerAPIwithDb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly DataContext _db;

    public CarsController(DataContext db)
    {
        _db = db;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<Car>>> GetAll()
    {
        return Ok(_db.Cars.ToList());
    }
    
    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var car = _db.Cars.ToList().FirstOrDefault(x => x.Id == id);
        if (car is null)
        {
            return BadRequest();
        }
        return Ok(car);
    }
    
    [HttpPost("add")]
    public IActionResult Add(Car model)
    {
        _db.Cars.Add(model);
        _db.SaveChanges();
        return Ok(_db.Cars.ToList());
    }
    
    [HttpPut("update")]
    public IActionResult Update(Car model)
    {
        _db.Cars.Update(model);
        _db.SaveChanges();
        return Ok(_db.Cars.ToList());
    }
    
    [HttpDelete("delete/{id:int}")]
    public IActionResult Delete(int id)
    {
        var car = _db.Cars.FirstOrDefault(x => x.Id == id);
        if (car is null)
        {
            return BadRequest("nothing can be deleted");
        }

        _db.Cars.Remove(car);
        _db.SaveChanges();
        return Ok(_db.Cars.ToList());
    }
    
}