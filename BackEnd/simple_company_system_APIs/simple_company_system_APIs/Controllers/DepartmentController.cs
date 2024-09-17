using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple_company_system_APIs.DTO.Department;
using simple_company_system_APIs.Models;

namespace simple_company_system_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        ITIContext _ITIContext = new ITIContext();

        [HttpGet]
        public async Task<IActionResult> getAllDepartments()
        {
            try {
                var departments = await _ITIContext.Departments.Select(x => new { name = x.Name, description = x.Description }).ToListAsync();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getDepartment(int id)
        {
            try
            {
                var department = await _ITIContext.Departments.FirstOrDefaultAsync(x=>x.Id == id).Select(x => new { name = x.Name, description = x.Description });
                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDepartment(CreateAndEditDepartment dept)
        {
            if (ModelState.IsValid)
            {
                _ITIContext.Departments.Add(new Department()
                {
                    Name = dept.Name,
                    Description = dept.Description,
                });
                await _ITIContext.SaveChangesAsync();
                return Created();
            }
            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditDepartment(int id, CreateAndEditDepartment dept)
        {
            try
            {
                Department olddept = _ITIContext.Departments.FirstOrDefault(x => x.Id == id);
                if (olddept == null) return NotFound();

                olddept.Name = dept.Name;
                olddept.Description = dept.Description;
                _ITIContext.Entry(olddept).State = EntityState.Modified;
                await _ITIContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var dept = await _ITIContext.Departments.FindAsync(id);
            if (dept == null) return NotFound();

            _ITIContext.Departments.Remove(dept);
            await _ITIContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
