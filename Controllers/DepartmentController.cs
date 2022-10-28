using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tugas4MCC71.Context;
using Tugas4MCC71.Models;

namespace Tugas4MCC71.Controllers
{
    public class DepartmentController : Controller
    {
        MyContext myContext;
        public DepartmentController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        // GET ALL
        public IActionResult Index()
        {
            var data = myContext.Departments.ToList();
            return View(data);
        }

        // GET BY ID
        public IActionResult Details(int id)
        {
            var data = myContext.Departments.Find(id);
            return View(data);
        }

        // INSERT - GET POST
        public IActionResult Create()
        {
            // get data disini
            // ex: dropdown data didapat dari database
            var data = new ViewModelDivision();
            data.Divisions = myContext.Divisions.Select(a => new SelectListItem()
            {
                Value = a.Division_Id.ToString(),
                Text = a.Name
            }).ToList();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            myContext.Departments.Add(department);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Department");
            return View();
        }

        // UPDATE - GET POST
        public IActionResult Edit(int id)
        {
            var data = myContext.Departments.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            var data = myContext.Departments.Find(id);
            if (data != null)
            {
                data.Name = department.Name;
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "Department");
            }
            return View();
        }

        // DELETE - GET POST
        public IActionResult Delete(int id)
        {
            var data = myContext.Departments.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department)
        {
            myContext.Departments.Remove(department);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Department");
            return View();
        }
    }
}
