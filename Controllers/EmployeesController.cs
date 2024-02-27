using DotNet8WebAPI.Helpers;
using DotNet8WebAPI.Model;
using DotNet8WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Controller level
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool? isActive = null)
        {
            var employees = await _employeesService.GetAllEmployees(isActive);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        //[Route("{id}")] // /api/Employees/:id
        public async Task<IActionResult> Get(int id)
        {
            var employees = await _employeesService.GetEmployeesByID(id);
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUpdateEmployees employeesObject)
        {
            var employees = await _employeesService.AddEmployees(employeesObject);
            if (employees == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Employee Created Successfully",
                id = employees!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AddUpdateEmployees employeesObject)
        {
            var employees = await _employeesService.UpdateEmployees(id, employeesObject);
            if (employees == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Employee Updated Successfully",
                id = employees!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _employeesService.DeleteEmployeesByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Employee Deleted Successfully",
                id = id
            });
        }
        
    }
}
