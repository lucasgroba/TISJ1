using Newtonsoft.Json;
using Shared.DTO;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:60698/API/Employee");
            List<DTOEmployee> employees = JsonConvert.DeserializeObject<List<DTOEmployee>>(json);
            return View(employees);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id) {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:60698/API/Employee/"+id);
            DTOEmployee employee = JsonConvert.DeserializeObject<DTOEmployee>(json);

            return View(employee);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(DTOEmployee emp)
        {
            var httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(emp);
            var response = await httpClient.PutAsync("http://localhost:60698/API/Employee/Put", new StringContent(json, Encoding.UTF8, "application/json"));


            return View();

        }
        [HttpGet]
        public async Task<ActionResult> Add()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Add(DTOEmployee emp)
        {
            var httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(emp);
            var response = await httpClient.PostAsync("http://localhost:60698/API/Employee/Post", new StringContent(json, Encoding.UTF8, "application/json"));

            return View();
        }
    }
}