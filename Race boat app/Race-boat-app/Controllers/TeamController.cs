using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Race_boat_app.Models;
using Microsoft.AspNetCore.Http;

namespace Race_boat_app.Controllers
{
    public class TeamController : Controller
    {

        static HttpClient client = new HttpClient();
        private static readonly string passPhrase = "l%HJb5N^O@fl0K02H9PsxlR9algJTzK7ARBjJsd3fPG0&GwkrU";


        public async Task<IActionResult> All()
        {
            try
            {
                List<Team> teams = await GetTeamsAsync("https://localhost:44389/api/1.0/team");
                List<User> users = new List<User>();
                foreach (var user in teams)
                {
                    User usr = await GetUserAsync("https://localhost:44389/api/1.0/user/" + user.CaptainID);
                    usr = DecryptUser(usr);
                    users.Add(usr);
                }
                List<string> recruiting = new List<string>();
                foreach (var rec in teams)
                {
                    recruiting.Add(rec.Recruiting);
                }
                ViewData["recruiting"] = recruiting;
                ViewData["users"] = users;
                return View("Teams");
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

        public async Task<IActionResult> JoinTeam(Join join) {
            //var hold = Request.Form["Team"];
            //var id = Request.Form["ID"];
            try
            {
                var url = "https://localhost:44389/api/1.0/team/" + join.TeamID;
                Team team = await GetTeamAsync(url.ToString());
                team.PitID = HttpContext.Session.GetString("_ID");
                team.Recruiting = "false";
                await UpdateTeamAsync(team);
                HttpContext.Session.SetString("_Team", team.Id);
                User user1 = await UpdateUser();
                List<Team> teams = await GetTeamsAsync("https://localhost:44389/api/1.0/team");
                List<User> users = new List<User>();
                List<string> recruiting = new List<string>();
                foreach (var user in teams)
                {
                    User usr = await GetUserAsync("https://localhost:44389/api/1.0/user/" + user.CaptainID);
                    usr = DecryptUser(usr);
                    users.Add(usr);
                }
                foreach (var rec in teams)
                {
                    recruiting.Add(rec.Recruiting);
                }
                ViewData["recruiting"] = recruiting;
                ViewData["users"] = users;
                return View("Teams");
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

        public async Task<IActionResult> CreateTeam()
        {
            try
            {
                string captainID1 = HttpContext.Session.GetString("_ID");
                Team temp = new Team()
                {
                    CaptainID = captainID1,
                    PitID = "null",
                    Recruiting = "true"
                };
                var url = await CreateTeamAsync(temp);
                Team team = await GetTeamAsync(url.ToString());
                HttpContext.Session.SetString("_Team", team.Id);
                User user1 = await UpdateUser();
                List<Team> teams = await GetTeamsAsync("https://localhost:44389/api/1.0/team");
                List<User> users = new List<User>();
                foreach (var user in teams)
                {
                    User usr = await GetUserAsync("https://localhost:44389/api/1.0/user/" + user.CaptainID);
                    usr = DecryptUser(usr);
                    users.Add(usr);
                }
                List<string> recruiting = new List<string>();
                foreach (var rec in teams)
                {
                    recruiting.Add(rec.Recruiting);
                }
                ViewData["recruiting"] = recruiting;
                ViewData["users"] = users;
                return RedirectToAction("All");
                //return View("Teams");
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

        public async Task<IActionResult> DisplayTeam(Join join)
        {
            var url = "https://localhost:44389/api/1.0/team/" + join.TeamID;
            Team team = await GetTeamAsync(url.ToString());
            var url2 = "https://localhost:44389/api/1.0/user/" + team.CaptainID;
            User captain = await GetUserAsync(url2.ToString());
            captain = DecryptUser(captain);
            ViewData["Captain"] = captain;
            List<Boat> boats = await GetBoatsAsync("https://localhost:44389/api/1.0/boat");
            Boat boatSend = null;
            foreach (Boat boat in boats)
            {
                if (boat.CaptainID == team.CaptainID)
                {
                    boatSend = boat;
                    ViewData["Boat"] = boat;
                }
            }
            string hasBoat = "true";
            ViewData["hasBoat"] = hasBoat;
            if (boatSend == null)
            {
                hasBoat = "false";
                ViewData["hasBoat"] = hasBoat;
            }
            string hasPit = "false";
            ViewData["hasPit"] = hasPit;
            if (team.PitID != "null")
            {
                var url3 = "https://localhost:44389/api/1.0/user/" + team.PitID;
                User pit = await GetUserAsync(url3.ToString());
                pit = DecryptUser(pit);
                hasPit = "true";
                ViewData["hasPit"] = hasPit;
                ViewData["Pit"] = pit;
            }
            return View("TeamView");
        }

            async Task<User> UpdateUser() {
            User user = new User();
            user.FirstName = HttpContext.Session.GetString("_Name");

            user.Id = HttpContext.Session.GetString("_ID");
            user.Email = HttpContext.Session.GetString("_Email");

            user.LastName = HttpContext.Session.GetString("_LastName");
            user.Address = HttpContext.Session.GetString("_Address");
            user.PostCode = HttpContext.Session.GetString("_PostCode");
            user.City = HttpContext.Session.GetString("_City");
            user.DOB = HttpContext.Session.GetString("_DOB");
            user.Team = HttpContext.Session.GetString("_Team");
            user.Points = HttpContext.Session.GetString("_Points");
            user.PhoneNumber = HttpContext.Session.GetString("_PhoneNumber");
            user.MobilePhoneNumber = HttpContext.Session.GetString("_MobileNumber");
            user.Posistion = HttpContext.Session.GetString("_Posistion");
            user.Password = HttpContext.Session.GetString("_Password");

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

            return decUser;


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



        static async Task<Team> UpdateTeamAsync(Team team)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/team/{ team.Id}", team);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            team = await response.Content.ReadAsAsync<Team>();
            return team;
        }

        static User DecryptUser(User user)
        {
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

        static async Task<User> UpdateUserAsync(User user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/user/{ user.Id}", user);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            user = await response.Content.ReadAsAsync<User>();
            return user;
        }

        static async Task<Uri> CreateTeamAsync(Team team)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/team", team);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            Console.WriteLine(tempURL);
            return response.Headers.Location;
        }

        static async Task<List<Team>> GetTeamsAsync(string path)
        {
            List<Team> teams = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                teams = await response.Content.ReadAsAsync<List<Team>>();
            }
            return teams;
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

        static async Task<Team> GetTeamAsync(string path)
        {
            Team team = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                team = await response.Content.ReadAsAsync<Team>();
            }
            return team;
        }
    }
}