using ConvertToExcel.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConvertToExcel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RandomDataController : ControllerBase
    {
        private readonly RandomData _randomData;
        public RandomDataController(RandomData randomData)
        {
            _randomData = randomData;
        }

        [HttpPost("CreateRandomData")]
        public async Task<IActionResult> CreateRandomData(int count = 1000)
        {
            var stopwatch = Stopwatch.StartNew();

            var data = await _randomData.CreateRandomData(count);

            stopwatch.Stop();

            Console.WriteLine($"Ma'lumotlar yaratish vaqti: {stopwatch.Elapsed.TotalSeconds} sekund.");

            Response.Headers.Add("X-Execution-Time-ms", stopwatch.Elapsed.TotalSeconds.ToString() + " second");

            return Ok(data);
        }
    }
}
