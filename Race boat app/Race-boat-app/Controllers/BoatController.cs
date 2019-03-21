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
    public class BoatController : Controller
    {
        static HttpClient client = new HttpClient();
        static string holding = "";

        public IActionResult Register()
        {
            return View("BoatRegister");
        }

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
                            holding = boatIn.Id;
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
                    holding = HttpContext.Session.GetString("_BoatID");
                    return View("Boat", boatTemp);
                }
                return View("Boat", boat);
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

        [HttpPost]
        public async Task<ActionResult> UpdateBoat(Boat boat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    boat.CaptainID = HttpContext.Session.GetString("_ID");
                    await UpdateBoatAsync(boat);
                    var url = "https://localhost:44389/api/1.0/boat/" + boat.Id;
                    Boat boatTemp = await GetBoatAsync(url.ToString());
                    return View("Boat", boatTemp);
                }
                return View("Boat");
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

        static async Task<Uri> CreateBoatAsync(Boat boat)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/boat", boat);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            Console.WriteLine(tempURL);
            return response.Headers.Location;
        }

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

        static async Task<Boat> UpdateBoatAsync(Boat boat)
        {
            boat.Id = holding;
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/boat/{ boat.Id}", boat);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            boat = await response.Content.ReadAsAsync<Boat>();
            return boat;
        }

        static async Task<HttpStatusCode> DeleteBoatAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/boat/{id}");
            return response.StatusCode;
        }
    }
}
