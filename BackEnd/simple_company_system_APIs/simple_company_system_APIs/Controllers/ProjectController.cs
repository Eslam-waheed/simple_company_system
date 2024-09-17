using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple_company_system_APIs.DTO.Project;
using simple_company_system_APIs.Models;

namespace simple_company_system_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        ITIContext _ITIContext = new ITIContext();

        [HttpGet]
        public async Task<IActionResult> getAllProjects()
        {
            try
            {
                var projects = await _ITIContext.Projects.Select(x => new { name = x.Name, description = x.Description }).ToListAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProject(CreateAndEditProject project)
        {
            if (ModelState.IsValid)
            {
                _ITIContext.Projects.Add(new Project()
                {
                    Name = project.Name,
                    Description = project.Description,
                });
                await _ITIContext.SaveChangesAsync();
                return Created();
            }
            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditProject(int id, CreateAndEditProject project)
        {
            try
            {
                Project oldproject = _ITIContext.Projects.FirstOrDefault(x => x.Id == id);
                if (oldproject == null) return NotFound();

                oldproject.Name = project.Name;
                oldproject.Description = project.Description;
                _ITIContext.Entry(oldproject).State = EntityState.Modified;
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
            var project = await _ITIContext.Projects.FindAsync(id);
            if (project == null) return NotFound();

            _ITIContext.Projects.Remove(project);
            await _ITIContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
