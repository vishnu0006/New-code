using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Race_boat_app.Models;
using Microsoft.AspNetCore.Http;

namespace Race_boat_app.Controllers
{
    /// <summary>
    /// The BoatController class handels user interaction with boat data,
    /// either adding, getting, or putting the data.
    /// </summary>
    public class BoatController : Controller
    {
        static HttpClient client = new HttpClient();
        static string holding = "";

        /// <summary>
        /// When the user makes the request to add a boat this is called.
        /// </summary>
        /// <returns>
        /// If the user does not have a boattThis function 
        /// returns the regerstration page for a boat otherwise
        /// it will redirect them to the ViewBoat action.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public async Task<IActionResult> Register()

        {
            try
            {
                string CaptainID = HttpContext.Session.GetString("_ID");

                List<Boat> boats = await GetBoatsAsync("https://localhost:44389/api/1.0/boat");

                //Boat boatTemp = new Boat();

                foreach (Boat boating in boats)

                {
                    if (boating.CaptainID == CaptainID)

                    {
                        HttpContext.Session.SetString("_HasBoat", "True");
                    }

                }

                if (HttpContext.Session.GetString("_HasBoat") == "True")
                {
                    return RedirectToAction("ViewBoat");
                }
                else
                {
                    return View("BoatRegister");
                }

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
        /// When the user whishes to view the boat that is assoicated with their account they
        /// will make a request to this function.
        /// </summary>
        /// <returns>
        /// It will return one of there things, if their is a boat associated with the user
        /// then it will return the boat page which displays the users boat information.
        /// If there is no boat associated with the user the boat will redirect them to the 
        /// register page.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public async Task<IActionResult> ViewBoat()
        {
            try
            {
                if (holding == "")
                {
                    string captainID = HttpContext.Session.GetString("_ID");
                    List<Boat> boats = await GetBoatsAsync("https://localhost:44389/api/1.0/boat");
                    foreach (Boat boatIn in boats)
                    {
                        if (boatIn.CaptainID == captainID)
                        {
                            //holding = boatIn.Id;
                            return View("Boat", boatIn);
                        }
                    }
                }
                else
                {
                    var url = "https://localhost:44389/api/1.0/boat/" + holding;
                    Boat boat = await GetBoatAsync(url.ToString());
                    return View("Boat", boat);
                }
                return View("BoatRegister");
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
        /// This function handels the registration of the boat for the user.
        /// </summary>
        /// <param name="boat">
        /// Boat is the boat that is object containing the information about the boat
        /// the user is trying to add 
        /// </param>
        /// <returns>
        /// Redirects the user to the boat page which will display their boats information
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> RegisterBoat(Boat boat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    boat.CaptainID = HttpContext.Session.GetString("_ID");
                    var url = await CreateBoatAsync(boat);
                    Boat boatTemp = await GetBoatAsync(url.ToString());
                    HttpContext.Session.SetString("_BoatID", boatTemp.Id);
                    //holding = HttpContext.Session.GetString("_BoatID");
                    //redirecttoaction(viewboat)
                    //return View("Boat", boatTemp);
                    HttpContext.Session.SetString("_HasBoat", "True");
                    return RedirectToAction("ViewBoat");
                }
                //return View("Boat", boat);
                return RedirectToAction("ViewBoat");
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
        /// This function handels updating the user's boat's information. 
        /// </summary>
        /// <param name="boat">
        /// An object containg the updated information the user wants to replace
        /// their current boat with
        /// </param>
        /// <returns>
        /// Redirects to action view boat to display the updated boat information
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> UpdateBoat(Boat boat)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    boat.CaptainID = HttpContext.Session.GetString("_ID");
                    List<Boat> boats = await GetBoatsAsync("https://localhost:44389/api/1.0/boat");
                    //Boat boatTemp = new Boat();
                    foreach (Boat boating in boats)
                    {
                        if (boating.CaptainID == boat.CaptainID)
                        {
                            boat.Id = boating.Id;
                        }
                    }
                    //Boat boatTemp = await GetBoatAsync(url.ToString());
                    //HttpContext.Session.SetString("_BoatID", boatTemp.Id);
                    //holding = HttpContext.Session.GetString("_BoatID");
                    await UpdateBoatAsync(boat);
                    var url = "https://localhost:44389/api/1.0/boat/" + boat.Id;
                    Boat boatTemp = await GetBoatAsync(url.ToString());
                    //return View("Boat", boatTemp);
                    return RedirectToAction("ViewBoat");
                }
                //return View("Boat");
                return RedirectToAction("ViewBoat");
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
        /// Gets all boats the API has to be displayed. 
        /// </summary>
        /// <returns>
        /// Returns the view boats which displays all the boats in the API.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public async Task<IActionResult> All()
        {
            try
            {
                List<Boat> boats = await GetBoatsAsync("https://localhost:44389/api/1.0/boat");
                return View("Boats", boats);
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
        /// Handels communicating with the API to create a Boat.
        /// </summary>
        /// <param name="boat">
        /// An object containing the information to be passed to the API.
        /// </param>
        /// <returns>
        /// Returns the location in the API of the newly created boat. 
        /// </returns>
        static async Task<Uri> CreateBoatAsync(Boat boat)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/boat", boat);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            Console.WriteLine(tempURL);
            return response.Headers.Location;
        }

        /// <summary>
        /// Handels communicating with the API to get a specific Boat.
        /// </summary>
        /// <param name="path">
        /// The location of the boat that should be retrieved.
        /// </param>
        /// <returns>
        /// Returns the boat that was retrieved from the API.
        /// </returns>
        static async Task<Boat> GetBoatAsync(string path)
        {
            Boat boat = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                boat = await response.Content.ReadAsAsync<Boat>();
            }
            return boat;
        }

        /// <summary>
        /// Handels communicating with the API to retrieve all boats currently stored in the database
        /// </summary>
        /// <param name="path">
        /// The location of the boats that should be retrieved
        /// </param>
        /// <returns>
        /// Returns all the boat that was retrieved from the API
        /// </returns>
        static async Task<List<Boat>> GetBoatsAsync(string path)
        {
            List<Boat> boat = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                boat = await response.Content.ReadAsAsync<List<Boat>>();
            }
            return boat;
        }

        /// <summary>
        /// Handels communicating with the API to update the information of 
        /// a specific boat
        /// </summary>
        /// <param name="boat">
        /// An object containing the information to be passed to the API
        /// </param>
        /// <returns>
        /// Will return the status code of the APIs response, should be 420 No Content  
        /// </returns>
        static async Task<HttpStatusCode> UpdateBoatAsync(Boat boat)
        {
            //boat.Id = holding;
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/boat/{ boat.Id}", boat);
            response.EnsureSuccessStatusCode();
            holding = "";
            // Deserialize the updated product from the response body.
            //boat = await response.Content.ReadAsAsync<Boat>();
            return response.StatusCode;
        }

        /// <summary>
        /// Handels communicating with the API to delete a specific boat
        /// </summary>
        /// <param name="id">
        /// The ID of the boat that is to be deleted
        /// </param>
        /// <returns>
        /// Will return the status code of the APIs response, should be 420 No Content  
        /// </returns>
        static async Task<HttpStatusCode> DeleteBoatAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/boat/{id}");
            return response.StatusCode;
        }
    }
}
