using MaxSun.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaxSunAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunLocationController : ControllerBase
    {
        private readonly ISunLocation _sunLocation;
        public SunLocationController(ISunLocation sunLocation)
        {
            _sunLocation = sunLocation;                            
        }
        [HttpGet]
        public IActionResult GetSunLocation()
        {
            try
            {
                var res = _sunLocation.GetSunLocationData();
                return Ok(res);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
