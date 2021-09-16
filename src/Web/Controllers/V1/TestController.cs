using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Contracts.V1.Requests;
using Web.Models;
using Web.Repositories.Interfaces;
using Web.Services.Interfaces;

namespace Web.Controllers.V1
{
    [ApiController]
    [Route("api/v1/tests")]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tests = await _testRepository.GetTestsAsync();
            return Ok(tests);
        }
        
        [HttpGet("{testId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int testId)
        {
            var test = await _testRepository.GetTestByIdAsync(testId);
            return test is null ? BadRequest() : Ok(test);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTestRequest testRequest)
        {
            var test = new Test {Text = testRequest.Text};
            
            var testId = await _testRepository.CreateTestAsync(test);
        
            if (testId <= 0)
                return BadRequest();
            
            return CreatedAtAction(nameof(GetById), new { testid = testId }, testRequest);
        }
    }
}