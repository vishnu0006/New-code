using System;
using System.Web;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Race_boat_app.Models;

namespace Race_boat_app.Controllers
{
    /// <summary>
    /// Controller manages user requests in regards to users
    /// and gathers information from the API regarding users.
    /// </summary>
    public class UserController : Controller
    {
        static HttpClient client = new HttpClient();
        private static readonly string passPhrase = "l%HJb5N^O@fl0K02H9PsxlR9algJTzK7ARBjJsd3fPG0&GwkrU";
        //private static readonly string passPhrase2 = "yUVyb$shjp4*%S6G!fx5t%i!fTZ@b8KQ#ymQyfhgNQ$#mKB0vA";

        /// <summary>
        /// Gathers all users from the API and sends them to the users
        /// view page to display a list of all users registered with
        /// the API.
        /// </summary>
        /// <returns>
        /// Attempts to return the users view displaying all users
        /// registered with the API.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public async Task<IActionResult> All()
        {
            try
            {
                List<User> users = await GetUsersAsync("https://localhost:44389/api/1.0/user");
                List<User> usrs = new List<User>();
                foreach (User user in users) {
                    User usr = DecryptUser(user);
                    usrs.Add(usr);
                }
                return View("Users", usrs);
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
            //return View("User");
        }

        /// <summary>
        /// When the user makes a reuest to register 
        /// this method will be triggered and
        /// display the registration form.
        /// </summary>
        /// <returns>
        /// Returns the user registration form.
        /// If the user is logged in it will
        /// redirect them to the index page.
        /// Should anything go wrong it will send 
        /// the user to the Error page.
        /// </returns>
        public IActionResult Register()
        {
            try
            {
                if (HttpContext.Session.GetString("_LoggedIn") == "false")
                {
                    return View("Register");
                }
                return RedirectToAction("Index", "Home");
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
        /// When the user makes a reuest to view their 
        /// profile this method will be triggered and
        /// display the users profile page if they are logged
        /// in.
        /// </summary>
        /// <returns>
        /// Returns the user profile page.
        /// If not logged in it will redirect to
        /// the home page.
        /// Should anything go wrong it will send the 
        /// user to the Error page.
        /// </returns>
        public IActionResult Profile()
        {
            try
            {
                if (HttpContext.Session.GetString("_LoggedIn") == "true")
                { 
                    return View("profile");
                }
                return RedirectToAction("Index", "Home");
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
        /// When the user requests an update to their profile
        /// this action is triggered which will pass the
        /// data onto the API.
        /// </summary>
        /// <param name="user">
        /// The object contains the updated information to
        /// be passed onto the API.
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> UpdateUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Password = HttpContext.Session.GetString("_Password");
                    user.Email = HttpContext.Session.GetString("_Email");
                    user.Points = HttpContext.Session.GetString("_Points");
                    user.Team = HttpContext.Session.GetString("_Team");
                    user.Posistion = HttpContext.Session.GetString("_Posistion");
                    User crypto = new User();
                    crypto.FirstName = Crypto.Encrypt(user.FirstName, passPhrase);
                    crypto.Posistion = Crypto.Encrypt(user.Posistion, passPhrase);
                    crypto.Address = Crypto.Encrypt(user.Address, passPhrase);
                    crypto.City = Crypto.Encrypt(user.City, passPhrase);
                    crypto.DOB = Crypto.Encrypt(user.DOB, passPhrase);
                    crypto.Email = Crypto.Encrypt(user.Email, passPhrase);
                    crypto.LastName = Crypto.Encrypt(user.LastName, passPhrase);
                    crypto.PostCode = Crypto.Encrypt(user.PostCode, passPhrase);
                    crypto.Password = Crypto.Encrypt(user.Password, passPhrase);
                    crypto.Team = Crypto.Encrypt(user.Team, passPhrase);
                    crypto.Points = Crypto.Encrypt(user.Points, passPhrase);
                    crypto.PhoneNumber = Crypto.Encrypt(user.PhoneNumber, passPhrase);
                    crypto.MobilePhoneNumber = Crypto.Encrypt(user.MobilePhoneNumber, passPhrase);
                    crypto.Id = HttpContext.Session.GetString("_ID");
                    await UpdateUserAsync(crypto);
                    var url = "https://localhost:44389/api/1.0/user/" + HttpContext.Session.GetString("_ID");
                    User encUser = await GetUserAsync(url.ToString());
                    User decUser = DecryptUser(encUser);


                    //HttpContext.Session.Set("User", Encoding.UTF8.GetBytes(decUser.FirstName));
                    HttpContext.Session.SetString("_LoggedIn", "true");
                    HttpContext.Session.SetString("_Name", decUser.FirstName);

                    HttpContext.Session.SetString("_ID", decUser.Id);
                    HttpContext.Session.SetString("_Email", decUser.Email);

                    HttpContext.Session.SetString("_LastName", decUser.LastName);
                    HttpContext.Session.SetString("_Address", decUser.Address);
                    HttpContext.Session.SetString("_PostCode", decUser.PostCode);
                    HttpContext.Session.SetString("_City", decUser.City);
                    HttpContext.Session.SetString("_DOB", decUser.DOB);
                    HttpContext.Session.SetString("_Team", decUser.Team);
                    HttpContext.Session.SetString("_Points", decUser.Points);
                    HttpContext.Session.SetString("_PhoneNumber", decUser.PhoneNumber);
                    HttpContext.Session.SetString("_MobileNumber", decUser.MobilePhoneNumber);
                    HttpContext.Session.SetString("_Posistion", decUser.Posistion);

                    //return View("profile", decUser);
                    return RedirectToAction("Profile");
                }
                return RedirectToAction("Profile");
                //return View("profile");
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
        /// This action handels the users request to register
        /// it will pass the given information onto the
        /// API for storage.
        /// </summary>
        /// <param name="user">
        /// The object containing the information to be passed to the
        /// API.
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> RegisterUser(User user)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    User crypto = new User();
                    crypto.FirstName = Crypto.Encrypt(user.FirstName, passPhrase);
                    crypto.Posistion = Crypto.Encrypt(user.Posistion, passPhrase);
                    crypto.Address = Crypto.Encrypt(user.Address, passPhrase);
                    crypto.City = Crypto.Encrypt(user.City, passPhrase);
                    crypto.DOB = Crypto.Encrypt(user.DOB, passPhrase);
                    crypto.Email = Crypto.Encrypt(user.Email, passPhrase);
                    crypto.LastName = Crypto.Encrypt(user.LastName, passPhrase);
                    crypto.PostCode = Crypto.Encrypt(user.PostCode, passPhrase);
                    crypto.Password = Crypto.Encrypt(user.Password, passPhrase);
                    crypto.Team = Crypto.Encrypt(user.Team, passPhrase);
                    crypto.Points = Crypto.Encrypt(user.Points, passPhrase);
                    crypto.PhoneNumber = Crypto.Encrypt(user.PhoneNumber, passPhrase);
                    crypto.MobilePhoneNumber = Crypto.Encrypt(user.MobilePhoneNumber, passPhrase);
                    var url = await CreateUserAsync(crypto);
                    User encUser = await GetUserAsync(url.ToString());
                    //string points = DecryptPoints(encUser);
                    User decUser = DecryptUser(encUser);
                    //decUser.Points = DecryptPoints(decUser.Points);


                    //HttpContext.Session.Set("User", Encoding.UTF8.GetBytes(decUser.FirstName));
                    HttpContext.Session.SetString("_LoggedIn", "true");
                    HttpContext.Session.SetString("_Name", decUser.FirstName);

                    HttpContext.Session.SetString("_ID", decUser.Id);
                    HttpContext.Session.SetString("_Email", decUser.Email);

                    HttpContext.Session.SetString("_LastName", decUser.LastName);
                    HttpContext.Session.SetString("_Address", decUser.Address);
                    HttpContext.Session.SetString("_PostCode", decUser.PostCode);
                    HttpContext.Session.SetString("_City", decUser.City);
                    HttpContext.Session.SetString("_DOB", decUser.DOB);
                    HttpContext.Session.SetString("_Team", decUser.Team);
                    HttpContext.Session.SetString("_Points", decUser.Points);
                    HttpContext.Session.SetString("_PhoneNumber", decUser.PhoneNumber);
                    HttpContext.Session.SetString("_MobileNumber", decUser.MobilePhoneNumber);
                    HttpContext.Session.SetString("_Posistion", decUser.Posistion);
                    HttpContext.Session.SetString("_Password", decUser.Password);

                    return RedirectToAction("Profile");
                }

                return RedirectToAction("Profile");
            }
            catch(Exception e)
            {
                string message = e.Message;
                string stackTrace = e.StackTrace;
                HttpContext.Session.SetString("_Error", "true");
                HttpContext.Session.SetString("_ErrorMessage", message);
                HttpContext.Session.SetString("_ErrorTrace", stackTrace);
                return View("RegisterFail");
            }
        }

        /*static string DecryptPoints(string points) {
            string point2 = Crypto.Decrypt(points, passPhrase2);
            return point2;
        }*/

        /// <summary>
        /// This method handels decrypting a user so the required information
        /// can be displayed. 
        /// </summary>
        /// <param name="user">
        /// The user information that needs to be decrypted.
        /// </param>
        /// <returns>
        /// A decrypted user.
        /// </returns>
        static User DecryptUser(User user) {
            user.Address = Crypto.Decrypt(user.Address, passPhrase);
            user.City = Crypto.Decrypt(user.City, passPhrase);
            user.DOB = Crypto.Decrypt(user.DOB, passPhrase);
            user.Email = Crypto.Decrypt(user.Email, passPhrase);
            user.FirstName = Crypto.Decrypt(user.FirstName, passPhrase);
            user.LastName = Crypto.Decrypt(user.LastName, passPhrase);
            user.PostCode = Crypto.Decrypt(user.PostCode, passPhrase);
            user.Password = Crypto.Decrypt(user.Password, passPhrase);
            user.Team = Crypto.Decrypt(user.Team, passPhrase);
            user.Posistion = Crypto.Decrypt(user.Posistion, passPhrase);
            user.PhoneNumber = Crypto.Decrypt(user.PhoneNumber, passPhrase);
            user.MobilePhoneNumber = Crypto.Decrypt(user.MobilePhoneNumber, passPhrase);
            user.Points = Crypto.Decrypt(user.Points, passPhrase);
            return user;
        }

        /// <summary>
        /// Handels communicating with the API to update the information of 
        /// a specific user
        /// </summary>
        /// <param name="user">
        /// An object containing the information to be passed to the API
        /// </param>
        /// <returns>
        /// Will return the status code of the APIs response, should be 420 No Content  
        /// </returns>
        static async Task<User> UpdateUserAsync(User user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/user/{ user.Id}", user);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            user = await response.Content.ReadAsAsync<User>();
            return user;
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
        /// Handels communicating with the API to create a User.
        /// </summary>
        /// <param name="crypto">
        /// An object containing the encrypted information to be passed to the API.
        /// </param>
        /// <returns>
        /// Returns the location in the API of the newly created User. 
        /// </returns>
        static async Task<Uri> CreateUserAsync(User crypto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/user", crypto);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.

            return response.Headers.Location;
        }



        //public async Task<IActionResult> UserAll()
        //{

        //}

        /// <summary>
        /// Handels communicating with the API to retrieve all users currently stored in the database
        /// </summary>
        /// <param name="path">
        /// The location of the users that should be retrieved
        /// </param>
        /// <returns>
        /// Returns all the users that were retrieved from the API
        /// </returns>
        static async Task<List<User>> GetUsersAsync(string path)
        {
            List<User> users = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<List<User>>();
            }
            //List<User> publicEncUsers = new List<User>();

            //foreach (User user in users)
            //{
            //    User crypto = new User();
            //    user.Address = Crypto.Decrypt(user.Address, passPhrase2);
            //    user.City = Crypto.Decrypt(user.City, passPhrase2);
            //    user.DOB = Crypto.Decrypt(user.DOB, passPhrase2);
            //    user.Email = Crypto.Decrypt(user.Email, passPhrase2);
            //    user.FirstName = Crypto.Decrypt(user.FirstName, passPhrase2);
            //    user.LastName = Crypto.Decrypt(user.LastName, passPhrase2);
            //    user.PostCode = Crypto.Decrypt(user.PostCode, passPhrase2);
            //    user.Password = Crypto.Decrypt(user.Password, passPhrase2);
            //    user.Team = Crypto.Decrypt(user.Team, passPhrase2);
            //    user.Posistion = Crypto.Decrypt(user.Posistion, passPhrase2);
            //    user.PhoneNumber = Crypto.Decrypt(user.PhoneNumber, passPhrase2);
            //    user.MobilePhoneNumber = Crypto.Decrypt(user.MobilePhoneNumber, passPhrase2);
            //    publicEncUsers.Add(crypto);
            //}
             return users;
        }

        /// <summary>
        /// Handels communicating with the API to delete a specific user
        /// </summary>
        /// <param name="id">
        /// The ID of the user that is to be deleted
        /// </param>
        /// <returns>
        /// Will return the status code of the APIs response, should be 420 No Content  
        /// </returns>
        static async Task<HttpStatusCode> DeleteUserAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/user/{id}");
            return response.StatusCode;
        }
    }
}
