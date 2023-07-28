using coreAPIClientProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace coreAPIClientProject.Controllers
{
    public class CustomerClientController : Controller
    {
        public IActionResult Index()
        {
            List<Customer> customers = getCustomersList("");
            return View(customers);
        }

        public IActionResult Search() 
        {
            List<Customer> customers = getCustomersList("");
            return View(customers);
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            List<Customer> customers = getCustomersList(name);
            return View(customers);
        }

        public static List<Customer> getCustomersList(string name) 
        {
            List<Customer> customers = new List<Customer>();
            string apiUrl = "http://localhost:5092/api/Customers";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl + string.Format("/{0}", name)).Result;
            if (response.IsSuccessStatusCode)
            {
                customers = JsonConvert.DeserializeObject<List<Customer>>(response.Content.ReadAsStringAsync().Result);
            }
            return customers;
        }
    }
}
