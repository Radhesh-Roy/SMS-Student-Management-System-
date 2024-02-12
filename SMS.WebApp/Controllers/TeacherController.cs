using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.WebApp.DatabaseContext;
using SMS.WebApp.Models;

namespace SMS.WebApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _TContext;
        public TeacherController(ApplicationDbContext Tcontext)
        {
            this._TContext = Tcontext;
        }
        [HttpGet]
        public async Task<IActionResult> DataShow()
        {
            var data=await _TContext.Set<Teacher>().AsNoTracking().ToArrayAsync();  
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAndEdit(int id)
        {
            if (id==0)
            {
                return View(new Teacher());
            }
            else
            {
                var data=await _TContext.Set<Teacher>().FindAsync(id);
                return View(data);
            }
          
        }
        [HttpPost]

        public async Task<IActionResult> CreateAndEdit(int id,Teacher teacher)
        {
            if (id == 0)
            {
                if (ModelState.IsValid)
                {
                    await _TContext.Set<Teacher>().AddAsync(teacher);
                    await _TContext.SaveChangesAsync();
                    return RedirectToAction("DataShow");
                }


            }
            else
            {
                _TContext.Set<Teacher>().Update(teacher);
                _TContext.SaveChanges();
                return RedirectToAction("DataShow");

            }
            return View(teacher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var teacher = await _TContext.Set<Teacher>().FindAsync(id);

                if (teacher != null)
                {
                    _TContext.Set<Teacher>().Remove(teacher);
                    await _TContext.SaveChangesAsync();
                }
            }

            return RedirectToAction("DataShow");
        }
        [HttpGet]
      public async Task<IActionResult> Details(int id)
        {
            var data = await _TContext.Set<Teacher>().FindAsync(id);
            return View(data);
        }



    }
}
