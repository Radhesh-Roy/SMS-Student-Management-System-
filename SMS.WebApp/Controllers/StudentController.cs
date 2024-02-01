using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.WebApp.DatabaseContext;
using SMS.WebApp.Models;

namespace SMS.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _context.Set<Student>().AsNoTracking().ToListAsync();

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {

            if (id == 0)
            {
                return View(new Student());
            }
            else
            {
                var data = await _context.Set<Student>().FindAsync(id);

                return View(data);
            }

        }

        [HttpPost]

        public async Task<IActionResult> CreateOrEdit(int id, Student student)
        {
            if (id == 0)
            {
                if (ModelState.IsValid)
                {
                    await _context.Set<Student>().AddAsync(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }


            }
            else
            {
                _context.Set<Student>().Update(student);
                _context.SaveChanges(); 
                return RedirectToAction("Index");
                
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id !=0)
            {
                var data = await _context.Set<Student>().FindAsync(id);
                if (data is not null)
                {
                    _context.Set<Student>().Remove(data);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data =await _context.Set<Student>().FindAsync(id);
            return View(data);
        }
           
        
      
       
        
    }
}
