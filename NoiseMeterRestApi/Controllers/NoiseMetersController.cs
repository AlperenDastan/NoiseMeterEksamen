using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoiseMeterLib.Contexts;
using NoiseMeterLib.Models;
using NoiseMeterLib.BusinessModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoiseMeterRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoiseMetersController : ControllerBase
    {
        private readonly InMemoryDBContext context;
        public NoiseMetersController(InMemoryDBContext context)
        {
            this.context = context;
        }


        // GET: api/<NoiseMetersController>
        [HttpGet]
        public async Task<ActionResult <List<NoiseMeter>>> Get()
        {

            return Ok(await context.NoiseMeters.ToListAsync());
        }

        // GET: api/<NoiseMetersController>
        [Route("{date:datetime}", Name = "GetByDate")]
        [HttpGet]
        public async Task<ActionResult<List<NoiseMeter>>> GetByDate(DateTime date)
        {
            var defaultdate = new DateTime(year: date.Year, month: date.Month, day: date.Day, hour: 0, minute: 0, second: 0);
            var result = context.NoiseMeters.Where(x => x.Timestamp > defaultdate && x.Timestamp < defaultdate.AddDays(1));
            return Ok(await result.ToListAsync());
        }


        // POST api/<NoiseMetersController>
        [HttpPost]
        public async Task<ActionResult <NoiseMeter>> Post([FromBody] NoiseMeterBusiness value)
        {
            if (value == null)
            {
                return BadRequest("Provided data is null");
            }
            var result = new NoiseMeter
            {
                dBvolume = value.dBvolume,
                DeviceId = value.DeviceId,
                Timestamp = value.Timestamp
            };

            context.NoiseMeters.Add(result);
            await context.SaveChangesAsync();
            return Ok(value);

        }
    }
}
