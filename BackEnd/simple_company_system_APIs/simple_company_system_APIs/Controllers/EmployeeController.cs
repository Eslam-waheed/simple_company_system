using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple_company_system_APIs.DTO.Employee;
using simple_company_system_APIs.Models;

namespace simple_company_system_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ITIContext _ITIContext = new ITIContext();

        [HttpGet]
        public async Task<IActionResult> getAllEmployees()
        {
            try
            {
                var Employees = await _ITIContext.Employees.Include(D => D.Department).ToListAsync();
                List<DisplayEmployees> EmpDeptDTO = new List<DisplayEmployees>();
                foreach (var employee in Employees)
                {
                    EmpDeptDTO.Add(new DisplayEmployees() {
                        Name = employee.Name,
                        Address = employee.Address,
                        Salary = employee.Salary,
                        DeptName = employee.Department.Name }
                    );
                }

                return Ok(EmpDeptDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getEmployee(int id)
        {
            try
            {
                var employee = await _ITIContext.Employees.Include(D => D.Department).FirstOrDefaultAsync(x => x.Id == id);
                if (employee == null) return NotFound();

                DisplayEmployees EmpDeptDTO = new DisplayEmployees()
                {
                    Name = employee.Name,
                    Address = employee.Address,
                    Salary = employee.Salary,
                    DeptName = employee.Department.Name
                };
                return Ok(EmpDeptDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewEmployee(CreateAndEditEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _ITIContext.Employees.Add(new Employee()
                {
                    Name = emp.Name,
                    Address = emp.Address,
                    Salary = emp.Salary,
                    Dept_id = emp.Dept_id
                });
                await _ITIContext.SaveChangesAsync();
                return Created();
            }
            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditEmployee(int id, CreateAndEditEmployee emp)
        {
            try
            {
                Employee oldEmp = _ITIContext.Employees.FirstOrDefault(x => x.Id == id);
                if (oldEmp == null) return NotFound();

                oldEmp.Name = emp.Name;
                oldEmp.Address = emp.Address;
                oldEmp.Salary = emp.Salary;
                oldEmp.Dept_id = emp.Dept_id;

                _ITIContext.Entry(oldEmp).State = EntityState.Modified;
                await _ITIContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _ITIContext.Employees.FindAsync(id);
            if (emp == null) return NotFound();

            _ITIContext.Employees.Remove(emp);
            await _ITIContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
