using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repository.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        DepartmentStuff departmentRepository;
        public DepartmentController(DepartmentStuff _departmentRepository)
        {
            departmentRepository = _departmentRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> deptlist =departmentRepository.GetAall();
            return Ok(deptlist);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            Department department =departmentRepository.GetById(id);

            StuffDTO stuff = new StuffDTO();
            stuff.ManagerName = department.ManagerName;
            stuff.Name = department.Name;
            stuff.empsname = departmentRepository.GetEmployees(id);
            return Ok(stuff);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetbyName(string name)
        {
            Department department = departmentRepository.GetByName(name);
            return Ok(department);
        }
        /*[HttpGet]
        public IActionResult GetAllEmployeesindept(int id)
        {
            List < Employee > employees= departmentRepository.GetEmployees(id);
            return Ok(employees);
        }*/
        [HttpPost]
        public IActionResult New(Department newdept)
        {
            if (ModelState.IsValid)
            {
               departmentRepository.insert(newdept);
                /* return Ok("Create");*/
                return new StatusCodeResult(StatusCodes.Status201Created);

            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id,Department newdept)
        {
            if (ModelState.IsValid)
            {
               departmentRepository.update(id, newdept);
                return Ok("Updated");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
               departmentRepository.delete(id);
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
