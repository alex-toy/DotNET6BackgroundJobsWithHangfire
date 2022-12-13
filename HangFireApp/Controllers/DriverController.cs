using HangFireApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HangFireApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        public static List<Driver> Drivers = new List<Driver>();
        public readonly ILogger<DriverController> _logger;

        public DriverController(ILogger<DriverController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddDriver(Driver driver)
        {
            if (ModelState.IsValid)
            {
                Drivers.Add(driver);
                return CreatedAtAction(nameof(AddDriver), driver);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetDriver(Guid id)
        {
            var driver = Drivers.FirstOrDefault(x => x.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        [HttpDelete]
        public IActionResult DeleteDriver(Guid id)
        {
            var driver = Drivers.FirstOrDefault(x => x.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            driver.Status = 0;

            return NoContent();
        }
    }
}
