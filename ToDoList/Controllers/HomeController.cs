using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public IActionResult AddNote()
        {
            return View();
        }
    }
}