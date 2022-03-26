using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeStore EmployeeStore;

        public EmployeeController(SohilContext _context)
        {
            EmployeeStore = new EmployeeStore(_context);

        }
        [HttpGet("")]
        public ActionResult<List<Employee>> Get()
        {
            return EmployeeStore.Employees.ToList();
        }
        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            if (employee.Id > 0)
                await EmployeeStore.Update(employee);
            else
                await EmployeeStore.Create(employee);

            return Ok("Data Saved Successfully");
        }
        [HttpGet("FindByName")]
        public  ActionResult<Employee> FindByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return NotFound("parameter is Empty");

           return EmployeeStore.Employees.Where(w => w.Name.Contains(name)).FirstOrDefault();

           
        }
        [HttpDelete("")]
        public async Task<bool> Delete(int id)
        {
            return await EmployeeStore.Delete(id);
        }



    }
}
