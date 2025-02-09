﻿using AspDotNetCrud.Data;
using AspDotNetCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController( EmployeeContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View( employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        { 
            if(id == null || id <= 0 )
            {
                return BadRequest();
            }
            var employeeinDb = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employeeinDb == null)
                return NotFound();

            return View(employeeinDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
             if (!ModelState.IsValid)
                {
                    return View(employee);
                }
                //_context.Entry(employee).State = EntityState.Modified;
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || id <= 0)
            {
                return BadRequest();
            }
            var employeeInDB = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employeeInDB == null)
                return NotFound();

            _context.Employees.Remove(employeeInDB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
