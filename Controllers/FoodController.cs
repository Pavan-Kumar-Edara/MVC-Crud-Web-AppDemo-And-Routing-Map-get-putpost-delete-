using Microsoft.AspNetCore.Mvc;
using MVCFoodDelivery.Models;
using MVCFoodDelivery.Repository;
using System.Xml.Linq;

namespace MVCFoodDelivery.Controllers
{
    public class FoodController : Controller
    {

        private readonly IToLoginRepository _loginRepository;

        public FoodController(IToLoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        //[ViewData]
        //public string Title { get; set; }

        [HttpGet]
        public IActionResult LoginForm() { 
            
            return View();
        }

        [HttpPost]
        public IActionResult LoginForm(ToLogin toLogin)
        {
            ToLogin newtoLogin=_loginRepository.Add(toLogin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditLoginDetails(int Id)
        {
            ToLogin toLogin=_loginRepository.GetLoginById(Id);
            return View(toLogin);
        }

        [HttpPost]
        public IActionResult EditLoginDetails(ToLogin modifyDetails)
        {
            ToLogin toLogin = _loginRepository.GetLoginById(modifyDetails.Id);
            toLogin.Email = modifyDetails.Email;
            toLogin.Password=modifyDetails.Password;
            ToLogin updateDetails = _loginRepository.update(toLogin);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDetails(int Id)
        {
            ToLogin toLogin=_loginRepository.delete(Id);
            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            var toLogin=_loginRepository.GetAll();

            //var toLogin = new List<ToLogin>
            //{
            //    new ToLogin {Email="pavan@gmail.com",Password="12345678"},
            //    new ToLogin {Email="rohit@gmail.com",Password="87654321"},
            //};
            //ViewData["toLogin"] = toLogin;
            //ViewData["title"] = "Login Details";
            //Title = "Login Info";

            //ViewBag.ToLogin = toLogin;

            //var newLogin = new ToLogin
            //{
            //    Email = "shivu@gmail.com",
            //    Password = "123789"
            //};

            //TempData["Email"] = "david@gmail.com";

            return View(toLogin);
        }
        public IActionResult Login()
        {
            //string email;
            //if (TempData.ContainsKey("Email"))
            //    email = TempData["Email"].ToString();
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }
    }
}
