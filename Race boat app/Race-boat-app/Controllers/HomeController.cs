using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Race_boat_app.Models;
using Microsoft.AspNetCore.Http;

namespace Race_boat_app.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        private static readonly string passPhrase = "l%HJb5N^O@fl0K02H9PsxlR9algJTzK7ARBjJsd3fPG0&GwkrU";
        //private static readonly string passPhrase2 = "yUVyb$shjp4*%S6G!fx5t%i!fTZ@b8KQ#ymQyfhgNQ$#mKB0vA";

        public IActionResult Index()
        {
            try
            {

                if (HttpContext.Session.GetString("_LoggedIn") == "true")
                {
                    if (HttpContext.Session.GetString("_Admin") == "true")
                    {
                        HttpContext.Session.SetString("_Error", "false");
                        return View();
                    }
                    HttpContext.Session.SetString("_Admin", "false");
                    HttpContext.Session.SetString("_Error", "false");
                    return View();
                }
                else
                {
                    if (HttpContext.Session.GetString("_Admin") == "true")
                    {
                        HttpContext.Session.SetString("_Error", "false");
                        HttpContext.Session.SetString("_LoggedIn", "false");
                        return View();
                    }
                    HttpContext.Session.SetString("_Admin", "false");
                    HttpContext.Session.SetString("_Error", "false");
                    HttpContext.Session.SetString("_LoggedIn", "false");
                    return View();
                }
            }
            catch (Exception e)
            {
                string message = e.Message;
                string stackTrace = e.StackTrace;
                HttpContext.Session.SetString("_Error", "false");
                HttpContext.Session.SetString("_ErrorMessage", message);
                HttpContext.Session.SetString("_ErrorTrace", stackTrace);
                HttpContext.Session.SetString("_LoggedIn", "false");
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Privacy()
        {
            ViewBag.Message = "Your privacy page.";

            return View();
        }

        public ActionResult Cookies()
        {
            ViewBag.Message = "Your cookie page.";

            return View();
        }

        public ActionResult Terms()
        {
            ViewBag.Message = "Your Terms page.";

            return View();
        }

        public IActionResult Login()
        {
            return View("UserLogin");
        }

        public IActionResult AdminLogin()
        {
            return View("AdminLogin");
        }

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.SetString("_BoatID", "Empty");
                HttpContext.Session.SetString("_LoggedIn", "false");
                HttpContext.Session.SetString("_Name", "Empty");

                HttpContext.Session.SetString("_ID", "Empty");
                HttpContext.Session.SetString("_Email", "Empty");

                HttpContext.Session.SetString("_LastName", "Empty");
                HttpContext.Session.SetString("_Address", "Empty");
                HttpContext.Session.SetString("_PostCode", "Empty");
                HttpContext.Session.SetString("_City", "Empty");
                HttpContext.Session.SetString("_DOB", "Empty");
                HttpContext.Session.SetString("_Team", "Empty");
                HttpContext.Session.SetString("_Points", "Empty");
                HttpContext.Session.SetString("_PhoneNumber", "Empty");
                HttpContext.Session.SetString("_MobileNumber", "Empty");
                HttpContext.Session.SetString("_Posistion", "Empty");
                return View("Index");
            }
            catch (Exception e)
            {
                string message = e.Message;
                string stackTrace = e.StackTrace;
                HttpContext.Session.SetString("_Error", "true");
                HttpContext.Session.SetString("_ErrorMessage", message);
                HttpContext.Session.SetString("_ErrorTrace", stackTrace);
                return View("Error");
            }
        }

        public IActionResult AdminLogout() {
            HttpContext.Session.SetString("_Admin", "false");
            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> LoginUser(Login login)
        {
            try
            {
                string sendEmail = Crypto.Encrypt(login.Email, passPhrase);
                string sendPassword = Crypto.Encrypt(login.Password, passPhrase);
                Login logSend = new Login()
                {
                    Email = sendEmail,
                    Password = sendPassword
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "https://localhost:44389/api/1.0/login", logSend);
                response.EnsureSuccessStatusCode();
                var tempURL = response.Headers.Location;
                Console.WriteLine(tempURL);
                User tempUser = await GetUserAsync(tempURL.ToString());
                string id = tempUser.Id;
                string email = Crypto.Decrypt(tempUser.Email, passPhrase);
                string firstname = Crypto.Decrypt(tempUser.FirstName, passPhrase);
                string lastname = Crypto.Decrypt(tempUser.LastName, passPhrase);
                string address = Crypto.Decrypt(tempUser.Address, passPhrase);
                string city = Crypto.Decrypt(tempUser.City, passPhrase);
                string dob = Crypto.Decrypt(tempUser.DOB, passPhrase);
                string postCode = Crypto.Decrypt(tempUser.PostCode, passPhrase);
                string team = Crypto.Decrypt(tempUser.Team, passPhrase);
                string points = Crypto.Decrypt(tempUser.Points, passPhrase);
                string phoneNumber = Crypto.Decrypt(tempUser.PhoneNumber, passPhrase);
                string mobileNumber = Crypto.Decrypt(tempUser.MobilePhoneNumber, passPhrase);
                string posistion = Crypto.Decrypt(tempUser.Posistion, passPhrase);
                string password = Crypto.Decrypt(tempUser.Password, passPhrase);
                OutLogin final = new OutLogin()
                {
                    Email = email,
                    Id = id
                };
                HttpContext.Session.SetString("_Name", firstname);
                HttpContext.Session.SetString("_ID", id);
                HttpContext.Session.SetString("_Email", email);
                HttpContext.Session.SetString("_LoggedIn", "true");
                HttpContext.Session.SetString("_LastName", lastname);
                HttpContext.Session.SetString("_Address", address);
                HttpContext.Session.SetString("_PostCode", postCode);
                HttpContext.Session.SetString("_City", city);
                HttpContext.Session.SetString("_DOB", dob);
                HttpContext.Session.SetString("_Team", team);
                HttpContext.Session.SetString("_Points", points);
                HttpContext.Session.SetString("_PhoneNumber", phoneNumber);
                HttpContext.Session.SetString("_MobileNumber", mobileNumber);
                HttpContext.Session.SetString("_Posistion", posistion);
                HttpContext.Session.SetString("_Password", password);
                return View("Index");
                //OutLogin temp = response.Content.ReadAsAsync<OutLogin>();
            }
            catch (Exception e)
            {
                string message = e.Message;
                string stackTrace = e.StackTrace;
                HttpContext.Session.SetString("_Error", "true");
                HttpContext.Session.SetString("_ErrorMessage", message);
                HttpContext.Session.SetString("_ErrorTrace", stackTrace);
                return View("UserLoginFail");
            }

        }

        
        static async Task<User> GetUserAsync(string path)
        {
            User user = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }


        [HttpPost]
        public async Task<ActionResult> AdminLogin(Login login)
        {
            try
            {
                string sendEmail = Crypto.Encrypt(login.Email, passPhrase);
                string sendPassword = Crypto.Encrypt(login.Password, passPhrase);
                Login logSend = new Login()
                {
                    Email = sendEmail,
                    Password = sendPassword
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "https://localhost:44389/api/1.0/adminlogin", logSend);
                Console.Write(response.IsSuccessStatusCode);
                response.EnsureSuccessStatusCode();
                var tempURL = response.Headers.Location;

                Console.WriteLine(tempURL);
                Admin tempAdmin = await GetAdminAsync(tempURL.ToString());
                string id = tempAdmin.Id;
                string email = Crypto.Decrypt(tempAdmin.Email, passPhrase);
                OutLogin final = new OutLogin()
                {
                    Email = email,
                    Id = id
                };
                HttpContext.Session.SetString("_Admin", "true");
                return View("Index");
            }
            catch (Exception e)
            {
                string message = e.Message;
                string stackTrace = e.StackTrace;
                HttpContext.Session.SetString("_Error", "true");
                HttpContext.Session.SetString("_ErrorMessage", message);
                HttpContext.Session.SetString("_ErrorTrace", stackTrace);
                return View("AdminLoginError");
            }
            //OutLogin temp = response.Content.ReadAsAsync<OutLogin>();

        }


        static async Task<Admin> GetAdminAsync(string path)
        {
            Admin admin = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                admin = await response.Content.ReadAsAsync<Admin>();
            }
            return admin;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

    }
}
