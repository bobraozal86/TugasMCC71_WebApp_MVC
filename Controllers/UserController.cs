using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tugas4MCC71.Context;
using Tugas4MCC71.Models;

namespace Tugas4MCC71.Controllers
{
    public class UserController : Controller
    {
        MyContext myContext;
        public UserController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        // GET ALL
        public IActionResult Index()
        {
            var data = myContext.Users.ToList();
            return View(data);
        }

        // GET BY ID
        public IActionResult Details(int id)
        {
            var data = myContext.Users.Find(id);
            return View(data);
        }

        // INSERT - GET POST
        public IActionResult Create()
        {
            // get data disini
            // ex: dropdown data didapat dari database
            var data = new ViewModelUser();
            data.Employees = myContext.Employees.Select(a => new SelectListItem()
            {
                Value = a.Employee_Id.ToString(),
                Text = a.Name
            }).ToList();
            data.Roles = myContext.Roles.Select(b => new SelectListItem()
            {
                Value = b.Role_Id.ToString(),
                Text = b.Name
            }).ToList();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            myContext.Users.Add(user);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "User");
            return View();
        }

        // UPDATE - GET POST
        public IActionResult Edit(int id)
        {
            var data = myContext.Users.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            var data = myContext.Users.Find(id);
            if (data != null)
            {
                data.Employee_Id = user.Employee_Id;
                data.Role_Id = user.Role_Id;
                data.Password = user.Password;
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "User");
            }
            return View();
        }

        // DELETE - GET POST
        public IActionResult Delete(int id)
        {
            var data = myContext.Users.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(User user)
        {
            myContext.Users.Remove(user);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "User");
            return View();
        }

    }
}
