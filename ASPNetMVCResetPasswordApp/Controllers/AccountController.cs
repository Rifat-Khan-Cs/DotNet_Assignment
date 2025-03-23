
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class AccountController : Controller
    {
        private static List<UserModel> users = new List<UserModel>
        {
            new UserModel { UserName = "john", Password = "123456" },
            new UserModel { UserName = "jane", Password = "abcdef" }
        };

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var user = users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            if (user != null)
            {
                ViewBag.Message = "Login successful!";
                return RedirectToAction("Success");
            }

            ViewBag.Message = "Invalid username or password!";
            return View();
        }

        public ActionResult Success()
        {
            return Content("Welcome! You have successfully logged in.");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string userName, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                ViewBag.Message = "Passwords do not match!";
                return View();
            }

            var user = users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
            {
                ViewBag.Message = "User not found!";
                return View();
            }

            user.Password = newPassword;
            ViewBag.Message = "Password updated successfully!";
            return RedirectToAction("Login");
        }
    }
}
