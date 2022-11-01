using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tugas4MCC71.Context;
using Tugas4MCC71.Models;

namespace Tugas4MCC71.Controllers
{
    public class AccountController : Controller
    {
        MyContext myContext;
        public AccountController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        //Login

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email) && x.Password.Equals(password));
            if (data != null)
            {
                ViewModelLogin viewModelLogin = new ViewModelLogin()
                {
                    Name = data.Employee.Name,
                    Email = data.Employee.Email,
                    Role = data.Role.Name
                };
                return RedirectToAction("Index", "Home", viewModelLogin);
            }
            return View();
        }

        //register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string name, string email, string birthDate, string password)
        {
            Employee employee = new Employee()
            {
                Name = name,
                Email = email,
                Birth_Date = birthDate
            };
            myContext.Employees.Add(employee);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                var id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(email)).Employee_Id;
                User user = new User()
                {       
                    Password = password,
                    Role_Id = 1,
                    Employee_Id = id
                };
                myContext.Users.Add(user);
                var resultUser = myContext.SaveChanges();
                if (resultUser > 0)
                {
                    return RedirectToAction("Login", "Account");
                }

            }
            return View();
        }
        //change password
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string email, string password, string confirm)
        {
            var data = myContext.Users
               .Include(x => x.Employee)
               //.Include(x => x.Role)
               //AsNoTracking digunain untuk ngebaca data dan tidak melacak entitas yang ada tujuannya untuk
               //insert, update, atau delete data
             //  .AsNoTracking()
               .SingleOrDefault(x => x.Employee.Email.Equals(email) && x.Password.Equals(password));
           // myContext.SaveChanges();
            if (data != null)
            {
                //var id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(email)).Employee_Id;
                //User user = new User()
                //{
                //    Id = data.Id,
                //    Password = confirm,
                //    Role_Id = data.Role_Id,
                //    Employee_Id = data.Employee_Id
                //};
                data.Password = confirm;
                myContext.Entry(data).State = EntityState.Modified;
                var resultUser = myContext.SaveChanges();
                if (resultUser > 0)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();

        }
        //forget password
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(string email, string confirm)
        {
            var data = myContext.Users
               .Include(x => x.Employee)
               //.Include(x => x.Role)
               .AsNoTracking()
               .SingleOrDefault(x => x.Employee.Email.Equals(email));
            myContext.SaveChanges();
            if (data != null)
            {
                //var id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(email)).Employee_Id;
                //User user = new User()
                //{
                //    Id = data.Id,
                //    Password = confirm,
                //    Role_Id = data.Role_Id,
                //    Employee_Id = data.Employee_Id
                //};
                data.Password = confirm;
                myContext.Entry(data).State = EntityState.Modified;
                var resultUser = myContext.SaveChanges();
                if (resultUser > 0)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();

        }

    }
}
