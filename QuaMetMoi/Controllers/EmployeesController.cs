using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuaMetMoi.Models;
using QuaMetMoi.Repositories;

namespace QuaMetMoi.Controllers
{
    public class EmployeesController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Login(string address)
        {
            Employee nv =  _unitOfWork.Employee.FindOne(x=>x.Address == address);
            ViewBag.Address = "Thành công";
            return View(nv);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //public EmployeesController(ManageEmployeesTestContext context)
        //{
        //    _context = context;
        //}

        // GET: Employees
        public IActionResult Index()
        {
            ViewBag.listEmploy = _unitOfWork.Employee.GetAll().ToList();
              return View();
        }

        // GET: Employees/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Employees == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(string tk, string mk)
        //{
        //    Employee e = _unitOfWork.Employee.Login(tk, mk);
        //    if(e == null)
        //    {
        //        Response.StatusCode = 404;
        //    }
        //    else
        //    {
        //        return RedirectToAction("Edit");
        //    }

        //    return View();
        //}

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                Response.StatusCode = 404;

            }
            else
            {
                Employee nv = _unitOfWork.Employee.GetById((int)id);
                return View(nv);

            }



            return View();
          
        }

        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            Employee check = _unitOfWork.Employee.GetById(e.Id);
            if(check == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                check.Email = e.Email;
                check.Address = e.Address;
                check.Phone = e.Phone;
                check.Name = e.Name;
                _unitOfWork.Complete();
            }
            return RedirectToAction("Index", "Employees");
                
                } 

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create( Employee employee)
        {
            
               _unitOfWork.Employee.Add(employee);
                //_context.Employees.Add(employee);
                // _context.SaveChangesAsync();
                _unitOfWork.Complete();
               

                return RedirectToAction("Index","Employees");
          
        }

        // GET: Employees/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Employees == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(employee);
        //}

        //// POST: Employees/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Address,Phone")] Employee employee)
        //{
        //    if (id != employee.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(employee);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EmployeeExists(employee.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(employee);
        //}

        //// GET: Employees/Delete/5
        //[HttpGet]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Employees == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index", "Employees");
        //}

        //// POST: Employees/Delete/5
        
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Employees == null)
        //    {
        //        return Problem("Entity set 'ManageEmployeesTestContext.Employees'  is null.");
        //    }
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee != null)
        //    {
        //        _context.Employees.Remove(employee);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EmployeeExists(int id)
        //{
        //  return _context.Employees.Any(e => e.Id == id);
        //}

       
    }
}
