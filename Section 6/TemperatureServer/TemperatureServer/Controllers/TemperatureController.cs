using Microsoft.AspNetCore.Mvc;
using TemperatureServer.Data;
using TemperatureServer.Models;

namespace TemperatureServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ApiDbContext _db;

        public TemperatureController(ApiDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> PostTemperature([FromBody] Temperature temperature)
        {
            _db.Temperatures.Add(temperature);
            await _db.SaveChangesAsync();
            return Ok(new { status = "success", temperature });
        }
    }
}
