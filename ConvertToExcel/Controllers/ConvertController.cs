using ConvertToExcel.Dtos;
using ConvertToExcel.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConvertToExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly ConvertToExcelService _excelService;

        public ConvertController(ConvertToExcelService convertToExcelService)
        {
            _excelService = convertToExcelService;
        }

        [HttpPost("Excel")]
        public IActionResult ConvertToExcel(List<GetOrganizationDto> organizations)
        {
            var stopwatch = Stopwatch.StartNew(); // Vaqtni boshlash
            var fileContents = _excelService.GenerateExcel(organizations);
            stopwatch.Stop(); // Vaqtni to'xtatish

            var executionTime = stopwatch.Elapsed.TotalSeconds;

            Console.WriteLine($"Excel faylni yaratish davomiyligi: {executionTime} second");

            Response.Headers.Add("X-Execution-Time-ms", executionTime.ToString() + " second"); // HTTP header qo'shish

            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Organizations.xlsx");

        }
    }
}
