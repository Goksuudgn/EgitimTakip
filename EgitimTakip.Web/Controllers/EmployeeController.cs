using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EgitimTakip.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Bütün employeelerı listelediğimiz bir sayfa olması çok anlamsız sonuçta firmadaki müşteriler benim için önemli 
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult GetAll(int companyId) //companyıd ye göre tüm employeelerı çekiyor 
        {
            var result = _context.Employees.Where(e => e.CompanyId == companyId && !e.IsDeleted).ToList();
            return Json(new { data = result });
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);

        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {

            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok(employee);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //SOFT DELETE
            Employee employee = _context.Employees.Find(id);
            employee.IsDeleted = true;
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult HardDelete (int id)
        {
            Employee employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
       

    }
}
