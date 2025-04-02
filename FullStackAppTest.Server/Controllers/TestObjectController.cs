using FullStackAppTest.Server.Application.Abstractions;
using FullStackAppTest.Server.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackAppTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestObjectController : ControllerBase
    {
        private readonly ITestObjectService _testObjectService;

        public TestObjectController(ITestObjectService objectService)
        {
            _testObjectService = objectService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveTestObjects([FromBody] IEnumerable<TestObjectDto> objects) 
        {
            if (objects is null) 
            {
                return BadRequest("Objets list is empty.");
            }

            await _testObjectService.SaveTestObjectsAsync(objects);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetTestObjects(
            [FromQuery] int? code, 
            [FromQuery] string? value)
        {
            var result = await _testObjectService.GetTestObjects(code, value);
            return Ok(result);
        }
    }
}
