﻿using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;

namespace EmployeeManagement.Controller;
  
      
    [Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase

{
    public readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository _employeeRepository)
    {
        this._employeeRepository = _employeeRepository;

    }
    [HttpGet]
     public async Task<ActionResult<IEnumerable<Employee>>> GetAllAsync()
        {
        var allEmployee = await _employeeRepository.GetAllAsync();
        return Ok(allEmployee);

    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployeeById(int id)

    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]

    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
        if(ModelState.IsValid == false)
        {
            return BadRequest();    
        }
        await _employeeRepository.ADDEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new {id= employee.Id},employee);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployeeById(int id)

    {
        await _employeeRepository.DeleteEmployeeAsync(id);
        return NoContent();
    } 
    [HttpPut("{id}")]
     public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id , Employee employee)
    {
        if(id != employee.Id)
        {
            return BadRequest();
        }
        if (ModelState.IsValid == false)
        {
            return BadRequest();
        }
        await _employeeRepository.UpdateEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }
}







