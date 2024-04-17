using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Reflection;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string baseApiUrl = "https://localhost:7248/api/api/";
        public HomeController(ILogger<HomeController> logger)
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(baseApiUrl);  

            if (response.IsSuccessStatusCode)
            {
                var note = JsonConvert.DeserializeObject<List<Note>>(await response.Content.ReadAsStringAsync());
                return View(note);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddNote(Note note)
        {
            if (note.Title.IsNullOrEmpty())
            {
                return View(note);
            }
            if (note.Client.IsNullOrEmpty())
            {
                return View(note);
            }
            else
            {
                await _httpClient.PostAsJsonAsync(baseApiUrl, note);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var response = await _httpClient.DeleteAsync(baseApiUrl + id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddNote()
        {
            return View();
        }
    }
}