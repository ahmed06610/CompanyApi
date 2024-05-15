using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IRepository<Employee> employeeRepsitory;
        public EmployeeController(IRepository<Employee> _employeeRepsitory) 
        { 
            employeeRepsitory = _employeeRepsitory;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            List<Employee> empslist =employeeRepsitory.GetAall();
               
            return Ok(empslist);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            Employee employee = employeeRepsitory.GetById(id);
            return Ok(employee);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetbyName(string name)
        {
            Employee employee = employeeRepsitory.GetByName(name);
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult New(Employee newemp)
        {
            if (ModelState.IsValid)
            {
                employeeRepsitory.insert(newemp);
                /* return Ok("Create");*/
                return new StatusCodeResult(StatusCodes.Status201Created);

            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Employee newemp)
        {
            if (ModelState.IsValid)
            {
                employeeRepsitory.update(id, newemp);
                return Ok("Updated");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
               employeeRepsitory.delete(id);
                /* return Ok("Deleted");*/
                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
