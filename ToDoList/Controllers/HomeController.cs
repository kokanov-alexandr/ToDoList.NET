using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost]
        public async Task<IActionResult> IndexDelete(int id)
        {
            var response = await _httpClient.DeleteAsync(baseApiUrl + id);
            Console.WriteLine(baseApiUrl + id);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Успешно!");
            }
            else
            {
                Console.WriteLine("Ошибка!!");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddNote()
        {
            return View();
        }
    }
}