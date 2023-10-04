using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineVaccineMVC.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineVaccineMVC.Controllers
{
    public class AdminController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5130/api");
        private readonly HttpClient _client;

        public AdminController()
        {
             _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Admin> adminList = new List<Admin>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Admin/Get").Result;
            if (response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;
                adminList = JsonConvert.DeserializeObject<List<Admin>>(data);
            }
            return View(adminList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            string data = JsonConvert.SerializeObject(admin);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = _client.PostAsync(_client.BaseAddress + "/Admin", content).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Admin admin = new Admin();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Admin/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                admin = JsonConvert.DeserializeObject<Admin>(data);
            }
            return View(admin);
        }
        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            try
            {
                string data = JsonConvert.SerializeObject(admin);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Admin/" + admin.AdminId, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error updating admin.");
                    return View(admin);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
                return View(admin);
            }

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Admin admin = new Admin();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Admin/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                admin = JsonConvert.DeserializeObject<Admin>(data);
            }
            return View(admin);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Admin admin = new Admin();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Admin/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                admin = JsonConvert.DeserializeObject<Admin>(data);
            }
            return View(admin);
        }
        [HttpPost]
        public ActionResult Delete(Admin admin)
        {
            string data = JsonConvert.SerializeObject(admin);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Admin/" + admin.AdminId).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
