using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using autoMapperTask.DataAccess;
using autoMapperTask.DTOs.DepartmentDtos;
using autoMapperTask.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace autoMapperTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {


        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepartmentsController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Department> departmentsDb = await _dbContext.Departments.ToListAsync();
            List<DepartmentGetDto> departments = _mapper.Map<List<DepartmentGetDto>>(departmentsDb);
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            Department? department = await _dbContext.Departments.FindAsync(id);
            if (department is null) return NotFound();
            DepartmentGetDto dto = _mapper.Map<DepartmentGetDto>(department);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id)
        {
            Department? department = await _dbContext.Departments.FindAsync(id);
            if (department == null) return NotFound();

            department.Name = "D 6";

            //_dbContext.Departments.Update(new Department
            //{
            //    Name = "D 2"
            //});
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            Department? departmentDb = await _dbContext.Departments.FindAsync(id);
            if (departmentDb is null) return NotFound();
            DepartmentGetDto dto = _mapper.Map<DepartmentGetDto>(departmentDb);
            _dbContext.Departments.Remove(departmentDb);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "Department Deleted",
                StatusCode = StatusCodes.Status200OK,
                departmentDb.Id
            });
        }


    }
}

