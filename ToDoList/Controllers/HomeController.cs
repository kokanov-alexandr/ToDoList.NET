using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private const string baseApiUrl = "https://localhost:7248/api/api/";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(baseApiUrl);  

            if (response.IsSuccessStatusCode)
            {
                var note = JsonConvert.DeserializeObject<List<Note>>(
                   await response.Content.ReadAsStringAsync());
                return View(note);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Index(Note note)
        {
            await _httpClient.PostAsJsonAsync(baseApiUrl, note);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult AddNote()
        {
            return View();
        }
    }
}