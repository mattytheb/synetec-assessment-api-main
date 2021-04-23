using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SynetecAssessmentApi.Services.Interfaces;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(Name = "GetAllEmployees"), Consumes("application/json")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok( await _employeesService.GetEmployeesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to get find employees: {ex}");
            }
        }
    }
}