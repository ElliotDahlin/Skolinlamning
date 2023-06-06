using Microsoft.AspNetCore.Mvc;
using Skolinlämning.Models;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Skolinlämning.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ApiService _apiService;

        public ApiController(HttpClient httpClient)
        {
            _apiService = new ApiService(httpClient);
        }

        public async Task<IActionResult> DriverDetails()
        {
            var drivers = await _apiService.GetDriversAsync();
            Debug.WriteLine(drivers);
            return View(drivers);
        }
        


    }




}

