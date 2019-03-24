using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Race_boat_app.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Race_boat_app.Controllers
{
    /// <summary>
    /// This controller handels communicating user requests with API responses
    /// in regards to the Events and Registering intrests in competing in an
    /// Event.
    /// </summary>
    public class EventController : Controller
    {
        static HttpClient client = new HttpClient();

        /// <summary>
        /// Gets all events the API has to be displayed on the websites calander. 
        /// </summary>
        /// <returns>
        /// Returns the view events which displays all the events currently taking place.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public async Task<IActionResult> All()
        {
            try
            {
                List<EventReg> eventRegs = await GetEventRegsAsync("https://localhost:44389/api/1.0/eventReg");
                ViewData["eventRegs"] = eventRegs;
                return View("Events");
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
        /// Handels the Admins request to register an event with the API. 
        /// </summary>
        /// <returns>
        /// Returns the view where the admin can register the event with the API.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public IActionResult RegisterEvent()
        {
            return View("EventRegister");
        }


        /*[HttpPost]
        public async Task<IActionResult> ViewEvent(String id)
        {
            try
            {
                EventIn event1 = await GetEventAsync("https://localhost:44389/api/1.0/event/" + id);
                return RedirectToAction("EventRegister", event1);
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
        }*/

        /// <summary>
        /// Handels registering a teams intrest in competing in an Event. 
        /// </summary>
        /// <param name="download">
        /// Contains the TeamID and EventID that is required to register for the event.
        /// </param>
        /// <returns>
        /// If successful it will redirect the user to the All action 
        /// which returns the event calendar
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> RegisterTeam(Download download)
        {
            try
            {
                List<EventReg> eventRegs = await GetEventRegsAsync("https://localhost:44389/api/1.0/eventReg");
                ViewData["eventRegs"] = eventRegs;
                foreach (var reg in eventRegs)
                {
                    if (reg.EventID == download.Id && reg.TeamID == download.TeamId)
                    {
                        return RedirectToAction("All");
                        //return View("Events");
                    }
                }
                EventReg tempReg = new EventReg()
                {
                    EventID = download.Id,
                    TeamID = download.TeamId
                };
                var url = await CreateEventRegAsync(tempReg);
                //RedirectToAction("All");
                return RedirectToAction("All");
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

        /*public async Task<IActionResult> GetDownload(Download download) {
            string hold = download.Id;
            //await Download(hold);
            return View("Events");
        }*/

        /// <summary>
        /// This function is the first part of two that allows for the creation
        /// of an Event by the Admin
        /// </summary>
        /// <param name="events"></param>
        /// <returns>
        /// Returns the view update which will handle file uploading.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public ActionResult EventRegister(EventIn events)
        {//This must be an async task 
            try
            {
                HttpContext.Session.SetString("_VideoURL", events.VideoURL);
                HttpContext.Session.SetString("_EventName", events.Name);
                HttpContext.Session.SetString("_Date", events.Date);
                HttpContext.Session.SetString("_Location", events.Location);
                HttpContext.Session.SetString("_TimeStart", events.TimeStart);
                HttpContext.Session.SetString("_TimeEnd", events.TimeEnd);
                HttpContext.Session.SetString("_Description", events.Description);
                return View("upload");
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
        /// This function will handle gathering the information 
        /// needed to display an events information to an administrator 
        /// so that the event can be updated
        /// </summary>
        /// <param name="download">
        /// This object will contain the ID of the event that needs
        /// to be updated.
        /// </param>
        /// <returns>
        /// If successful it will return the event update view where an Admin 
        /// can edit an events information.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> EditEvent(Download download)
        {
            try
            { 
                var url = "https://localhost:44389/api/1.0/event/" + download.Id;
                EventIn event1 = await GetEventAsync(url.ToString());
                HttpContext.Session.SetString("_VideoURL", "Null");
                HttpContext.Session.SetString("_EventName", event1.Name);
                HttpContext.Session.SetString("_Date", event1.Date);
                HttpContext.Session.SetString("_Location", event1.Location);
                HttpContext.Session.SetString("_TimeStart", event1.TimeStart);
                HttpContext.Session.SetString("_TimeEnd", event1.TimeEnd);
                HttpContext.Session.SetString("_Description", "Null");
                HttpContext.Session.SetString("_EventID", event1.Id);
                return View("EventUpdate");
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
        /// Handels updating an Event
        /// </summary>
        /// <param name="events">
        /// An object containing an events updated information.
        /// </param>
        /// <returns>
        /// If successful it will redirect the user to the All action 
        /// which returns the event calendar
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public async Task<ActionResult> EventUpdater(EventIn events)
        {//This must be an async task 
            try
            { 
                List<EventReg> eventRegs = await GetEventRegsAsync("https://localhost:44389/api/1.0/eventReg");
                ViewData["eventRegs"] = eventRegs;
                EventIn event1 = await GetEventAsync("https://localhost:44389/api/1.0/event/" + HttpContext.Session.GetString("_EventID"));
                EventIn temp = new EventIn()
                {
                    Name = events.Name,
                    Location = events.Location,
                    Date = events.Date,
                    TimeStart = events.TimeStart,
                    TimeEnd = events.TimeEnd,
                    Description = events.Description,
                    VideoURL = events.VideoURL,
                    EventFile = event1.EventFile,
                    Id = event1.Id
                };
                var url = await UpdateEventAsync(temp);
                HttpContext.Session.SetString("_VideoURL", "Empty");
                HttpContext.Session.SetString("_EventName", "Empty");
                HttpContext.Session.SetString("_Date", "Empty");
                HttpContext.Session.SetString("_Location", "Empty");
                HttpContext.Session.SetString("_TimeStart", "Empty");
                HttpContext.Session.SetString("_TimeEnd", "Empty");
                HttpContext.Session.SetString("_Description", "Empty");
                HttpContext.Session.SetString("_EventID", "Empty");
                return RedirectToAction("All");
                //return View("Events");
                //return Redirect("https://localhost:44374/Event/All");
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

        /*[HttpPost]
        public async Task<ActionResult> UploadNewFile()
        {
            try
            {
                List<EventReg> eventRegs = await GetEventRegsAsync("https://localhost:44389/api/1.0/eventReg");
                ViewData["eventRegs"] = eventRegs;
                //var test = Request.Form.Files;
                foreach (var upload in Request.Form.Files)
                {
                    //if (test[0].FileName != "")
                    //{

                    // read file to stream
                    Stream hold = upload.OpenReadStream();
                    byte[] array = new byte[hold.Length];
                    hold.Seek(0, SeekOrigin.Begin);
                    hold.Read(array, 0, array.Length);
                    EventIn temp = new EventIn()
                    {
                        VideoURL = HttpContext.Session.GetString("_VideoURL"),
                        Name = HttpContext.Session.GetString("_EventName"),
                        Location = HttpContext.Session.GetString("_Location"),
                        Date = HttpContext.Session.GetString("_Date"),
                        TimeStart = HttpContext.Session.GetString("_TimeStart"),
                        TimeEnd = HttpContext.Session.GetString("_TimeEnd"),
                        Description = HttpContext.Session.GetString("_Description"),
                        Id = HttpContext.Session.GetString("_EventID"),
                        EventFile = array
                    };
                    await UpdateEventAsync(temp);
                    hold.Close();
                    return View("Events");

                    //}
                }
                return View("Events");
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
        }*/

        /// <summary>
        /// Handels uploading a file to the API for storage and 
        /// creating an event to be sent to the API
        /// </summary>
        /// <returns>
        /// If successful it will redirect the user to the All action 
        /// which returns the event calendar
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            try
            {
                List<EventReg> eventRegs = await GetEventRegsAsync("https://localhost:44389/api/1.0/eventReg");
                ViewData["eventRegs"] = eventRegs;
                var test = Request.Form["FileUpload1"];
                foreach (var upload in Request.Form.Files)
                {
                    //if (test[0].FileName != "")
                    //{

                    // read file to stream
                    Stream hold = upload.OpenReadStream();
                    byte[] array = new byte[hold.Length];
                    hold.Seek(0, SeekOrigin.Begin);
                    hold.Read(array, 0, array.Length);
                    EventIn temp = new EventIn()
                    {
                        VideoURL = HttpContext.Session.GetString("_VideoURL"),
                        Name = HttpContext.Session.GetString("_EventName"),
                        Location = HttpContext.Session.GetString("_Location"),
                        Date = HttpContext.Session.GetString("_Date"),
                        TimeStart = HttpContext.Session.GetString("_TimeStart"),
                        TimeEnd = HttpContext.Session.GetString("_TimeEnd"),
                        Description = HttpContext.Session.GetString("_Description"),
                        EventFile = array
                    };
                    await CreateEventAsync(temp);
                    hold.Close();
                    HttpContext.Session.SetString("_VideoURL", "Empty");
                    HttpContext.Session.SetString("_EventName", "Empty");
                    HttpContext.Session.SetString("_Date", "Empty");
                    HttpContext.Session.SetString("_Location", "Empty");
                    HttpContext.Session.SetString("_TimeStart", "Empty");
                    HttpContext.Session.SetString("_TimeEnd", "Empty");
                    HttpContext.Session.SetString("_Description", "Empty");
                    HttpContext.Session.SetString("_EventID", "Empty");
                    //return RedirectToAction("All");
                    //return View("Events");
                    

                    //}
                }
                HttpContext.Session.SetString("_VideoURL", "Empty");
                HttpContext.Session.SetString("_EventName", "Empty");
                HttpContext.Session.SetString("_Date", "Empty");
                HttpContext.Session.SetString("_Location", "Empty");
                HttpContext.Session.SetString("_TimeStart", "Empty");
                HttpContext.Session.SetString("_TimeEnd", "Empty");
                HttpContext.Session.SetString("_Description", "Empty");
                HttpContext.Session.SetString("_EventID", "Empty");
                //return stopRed();
                return RedirectToAction("All");
                //return View("Events");
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

        /*public IActionResult stopRed() {
            return RedirectToAction("All");
        }*/

        /// <summary>
        /// Gets all event regs the API has to be displayed. 
        /// </summary>
        /// <returns>
        /// Returns the view event regs which displays all the event regs.
        /// Should anything go wrong it will send the user to the Error page.
        /// </returns>
        public async Task<IActionResult> EventRegAll()
        {
            try
            {
                List<EventReg> eventRegs = await GetEventRegsAsync("https://localhost:44389/api/1.0/eventReg");
                return View("EventRegs", eventRegs);
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
        /// Handels communicating with the API to create an Event.
        /// </summary>
        /// <param name="eventIn">
        /// An object containing the information to be passed to the API.
        /// </param>
        /// <returns>
        /// Returns the location in the API of the newly created Event. 
        /// </returns>
        static async Task<Uri> CreateEventAsync(EventIn eventIn)
        {
        
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "https://localhost:44389/api/1.0/event", eventIn);
                response.EnsureSuccessStatusCode();
                var tempURL = response.Headers.Location;
                Console.WriteLine(tempURL);
                return response.Headers.Location;
      
        }

        //[HttpGet("{id:length(24)}")]
        //public async Task<ActionResult> ViewEvent(string id)
        //{
        //    EventIn event1 = await GetEventAsync("https://localhost:44389/api/1.0/event/" + id);
        //    return View("EventView",event1);
        //}

        /// <summary>
        /// Handels communicating with the API to retrieve all events currently stored in the database
        /// </summary>
        /// <returns>
        /// Returns all the events that was retrieved from the API
        /// </returns>
        public async Task<List<EventIn>> AllEvents()
        {

            List<EventIn> events = await GetEventsAsync("https://localhost:44389/api/1.0/event");
            return events;
        }

        /// <summary>
        /// Handels communicating with the API to retrieve all events currently stored in the database
        /// </summary>
        /// <param name="path">
        /// The location of the boats that should be retrieved
        /// </param>
        /// <returns>
        /// Returns all the events that was retrieved from the API
        /// </returns>
        static async Task<List<EventIn>> GetEventsAsync(string path)
        {
            List<EventIn> events = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                events = await response.Content.ReadAsAsync<List<EventIn>>();
            }
            return events;
        }

        /// <summary>
        /// Handels communicating with the API to get a specific Event
        /// </summary>
        /// <param name="path">
        /// The location of the boat that should be retrieved.
        /// </param>
        /// <returns>
        /// Returns the Event that was retrieved from the API.
        /// </returns>
        static async Task<EventIn> GetEventAsync(string path)
    {
        EventIn eventIn = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            eventIn = await response.Content.ReadAsAsync<EventIn>();
        }
        return eventIn;
    }

        /// <summary>
        /// This handels the user equest to download a flyer containing 
        /// information about an event
        /// </summary>
        /// <param name="download">
        /// An object that contains the event id that will be used to 
        /// locate the correct flyer on the API
        /// </param>
        /// <returns>
        /// Returns the file to the user as a download.
        /// </returns>
        public async Task<FileResult> Download(Download download)
        {
            EventIn tempEvent = await GetEventAsync("https://localhost:44389/api/1.0/event/" + download.Id);

            using (var stream = new MemoryStream())
            {
                stream.Write(tempEvent.EventFile, 0, tempEvent.EventFile.Length);
                stream.Seek(0, SeekOrigin.Begin);
                string filename = tempEvent.Name + tempEvent.Date + ".pdf";
                return File(stream.GetBuffer(), "application/pdf", filename);
            }

        }

        /// <summary>
        /// Handels communicating with the API to update the information of 
        /// a specific event
        /// </summary>
        /// <param name="eventIn">
        /// An object containing the information to be passed to the API
        /// </param>
        /// <returns>
        /// Will return the status code of the APIs response, should be 420 No Content  
        /// </returns>
        static async Task<HttpStatusCode> UpdateEventAsync(EventIn eventIn)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/event/{ eventIn.Id}", eventIn);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            //eventIn = await response.Content.ReadAsAsync<EventIn>();
            //return eventIn;
            return response.StatusCode;
        }

        /// <summary>
        /// Handels communicating with the API to create an EventReg.
        /// </summary>
        /// <param name="eventReg">
        /// An object containing the information to be passed to the API.
        /// </param>
        /// <returns>
        /// Returns the location in the API of the newly created EventReg. 
        /// </returns>
        static async Task<Uri> CreateEventRegAsync(EventReg eventReg)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/eventReg", eventReg);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            Console.WriteLine(tempURL);
            return response.Headers.Location;
        }

        /// <summary>
        /// Handels communicating with the API to get a specific EventReg.
        /// </summary>
        /// <param name="path">
        /// The location of the boat that should be retrieved.
        /// </param>
        /// <returns>
        /// Returns the EventReg that was retrieved from the API.
        /// </returns>
        static async Task<EventReg> GetEventRegAsync(string path)
        {
            EventReg eventReg = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                eventReg = await response.Content.ReadAsAsync<EventReg>();
            }
            return eventReg;
        }

        /// <summary>
        /// Handels communicating with the API to retrieve all EventRegs currently stored in the database
        /// </summary>
        /// <param name="path">
        /// The location of the boats that should be retrieved
        /// </param>
        /// <returns>
        /// Returns all the EventRegs that was retrieved from the API
        /// </returns>
        static async Task<List<EventReg>> GetEventRegsAsync(string path)
        {
            List<EventReg> eventReg = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                eventReg = await response.Content.ReadAsAsync<List<EventReg>>();
            }
            return eventReg;
        }

        /// <summary>
        /// Handels communicating with the API to delete a specific event
        /// </summary>
        /// <param name="id">
        /// The ID of the event that is to be deleted
        /// </param>
        /// <returns>
        /// Will return the status code of the APIs response, should be 420 No Content  
        /// </returns>
        static async Task<HttpStatusCode> DeleteEventAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/event/{id}");
            return response.StatusCode;
        }

        /// <summary>
        /// Handels communicating with the API to delete a specific event reg
        /// </summary>
        /// <param name="id">
        /// The ID of the event reg that is to be deleted
        /// </param>
        /// <returns>
        /// Will return the status code of the APIs response, should be 420 No Content  
        /// </returns>
        static async Task<HttpStatusCode> DeleteEventRegAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/eventReg/{id}");
            return response.StatusCode;
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
