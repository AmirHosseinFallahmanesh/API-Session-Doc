using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Endpoint.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Endpoint.Controllers
{
    public class HomeController : Controller
    {
        string baseAddress = @"https://localhost:44332/api/";
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var url = $"{baseAddress}product";
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            JToken token = JToken.Parse(result).SelectToken("data");
            string data = token.ToString();
            List<Product> model = JsonConvert.DeserializeObject<List<Product>>(data);

            return View(model);
        }


        public IActionResult Create()
        {
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(Product product)
        {
            var model = product;

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"{baseAddress}product";
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            var model = product;

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"{baseAddress}product";
            var client = new HttpClient();

            var response = await client.PutAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var url = $"{baseAddress}product/{id}";
            var client = new HttpClient();

            var response = await client.DeleteAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View();
        }


    }
}
