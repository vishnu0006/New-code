using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Race_boat_app.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Race_boat_app.Controllers
{
    public class EventController : Controller
    {
        static HttpClient client = new HttpClient();

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

        public IActionResult RegisterEvent()
        {
            return View("EventRegister");
        }

        [HttpPost]
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
        }

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

                        return View("Events");
                    }
                }
                EventReg tempReg = new EventReg()
                {
                    EventID = download.Id,
                    TeamID = download.TeamId
                };
                var url = await CreateEventRegAsync(tempReg);
                RedirectToAction("All");
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

        /*public async Task<IActionResult> GetDownload(Download download) {
            string hold = download.Id;
            //await Download(hold);
            return View("Events");
        }*/

        public async Task<ActionResult> EventRegister(EventIn events)
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

        


        [HttpPost]
        public async Task<ActionResult> Upload()
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
                        EventFile = array
                    };
                    await CreateEventAsync(temp);
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
        }

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


        public async Task<List<EventIn>> AllEvents()
        {

            List<EventIn> events = await GetEventsAsync("https://localhost:44389/api/1.0/event");
            return events;
        }

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

        static async Task<EventIn> UpdateEventAsync(EventIn eventIn)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/event/{ eventIn.Id}", eventIn);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            eventIn = await response.Content.ReadAsAsync<EventIn>();
            return eventIn;
        }

        static async Task<Uri> CreateEventRegAsync(EventReg eventReg)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/eventReg", eventReg);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            Console.WriteLine(tempURL);
            return response.Headers.Location;
        }

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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
