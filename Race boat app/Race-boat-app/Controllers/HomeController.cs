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
    /// <summary>
    /// Controller for login and miscellaneous aspects of the website 
    /// </summary>
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        private static readonly string passPhrase = "l%HJb5N^O@fl0K02H9PsxlR9algJTzK7ARBjJsd3fPG0&GwkrU";
        //private static readonly string passPhrase2 = "yUVyb$shjp4*%S6G!fx5t%i!fTZ@b8KQ#ymQyfhgNQ$#mKB0vA";

        /// <summary>
        /// Landing page for the website.
        /// Initialises several session variables. 
        /// </summary>
        /// <returns>
        /// If successful returns the homepage.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public IActionResult Index()
        {
            try
            {
                HttpContext.Session.SetString("_BoatID", "Empty");
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

        /// <summary>
        /// Method handles user request for the About us page
        /// </summary>
        /// <returns>
        /// If successful returns the About Us Page.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public ActionResult About()
        {
            try
            { 
                ViewBag.Message = "Your application description page.";

                return View();
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

        /// <summary>
        /// Method handles user request for the Contact us page
        /// </summary>
        /// <returns>
        /// If successful returns the Contact Us Page.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public ActionResult Contact()
        {
            try
            { 
                ViewBag.Message = "Your contact page.";

                return View();
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

        /// <summary>
        /// Method handles user request for the Privacy Policy page
        /// </summary>
        /// <returns>
        /// If successful returns the Privacy Policy Page.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public ActionResult Privacy()
        {
            try
            {
                ViewBag.Message = "Your privacy page.";

                return View();
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

        /// <summary>
        /// Method handles user request for the Cookies page
        /// </summary>
        /// <returns>
        /// If successful returns the Cookies Page.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public ActionResult Cookies()
        {
            try
            { 
                ViewBag.Message = "Your cookie page.";

                return View();
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

        /// <summary>
        /// Method handles user request for the Terms and Conditions page
        /// </summary>
        /// <returns>
        /// If successful returns the Terms and Conidtions Page.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public ActionResult Terms()
        {
            try
            { 
                ViewBag.Message = "Your Terms page.";

                return View();
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

        /// <summary>
        /// Method handles user request to access the login page
        /// </summary>
        /// <returns>
        /// If the user is logged in it redirects them to the home page.
        /// Otherwise it returns the login page. 
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public IActionResult Login()
        {
            try
            {
                HttpContext.Session.SetString("_BoatID", "Empty");
                if (HttpContext.Session.GetString("_LoggedIn") == "true")
                {
                    return RedirectToAction("Index");
                }
                return View("UserLogin");
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

        /// <summary>
        /// Method handles admin request to access the admin login page
        /// </summary>
        /// <returns>
        /// If the admin is logged in it redirects them to the home page.
        /// Otherwise it returns the admin login page.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public IActionResult AdminLogin()
        {
            try
            {
                HttpContext.Session.SetString("_BoatID", "Empty");
                if (HttpContext.Session.GetString("_Admin") == "true")
                {
                    return RedirectToAction("Index");
                }
                return View("AdminLogin");
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

        /// <summary>
        /// Method handles users' request to log out by setting several,
        /// including loggedIn, to either false or empy.
        /// </summary>
        /// <returns>
        /// Once the action is completed it redirects the user
        /// to the home page. 
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.SetString("_HasBoat", "Empty");
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
                return RedirectToAction("Index");
                //return View("Index");
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

        /// <summary>
        /// Method handles admins' request to log out by setting several,
        /// including loggedIn, to either false or empy.
        /// </summary>
        /// <returns>
        /// Once the action is completed it redirects the user
        /// to the home page. 
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public IActionResult AdminLogout() {
            try
            { 
                HttpContext.Session.SetString("_Admin", "false");
                return RedirectToAction("Index");
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

        /// <summary>
        /// Method handles logging in a user.
        /// </summary>
        /// <param name="login">
        /// An object that contains the user's login information.
        /// </param>
        /// <returns>
        /// Once the action is completed it redirects the user
        /// to the home page. 
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
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
                return RedirectToAction("Index");
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

        /// <summary>
        /// Handels communicating with the API to get a specific User.
        /// </summary>
        /// <param name="path">
        /// The location of the user that should be retrieved.
        /// </param>
        /// <returns>
        /// Returns the user that was retrieved from the API.
        /// </returns>
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

        /// <summary>
        /// Method handles logging in a admin.
        /// </summary>
        /// <param name="login">
        /// An object that contains the admin's login information.
        /// </param>
        /// <returns>
        /// Once the action is completed it redirects the user
        /// to the home page. 
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
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
                return RedirectToAction("Index");
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

        /// <summary>
        /// Handels communicating with the API to get a specific Admin.
        /// </summary>
        /// <param name="path">
        /// The location of the Admin that should be retrieved.
        /// </param>
        /// <returns>
        /// Returns the Admin that was retrieved from the API.
        /// </returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

    }
}
