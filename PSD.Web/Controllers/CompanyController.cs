using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using PSD.Web.Helper;

namespace PSD.Web.Controllers
{

    public class CompanyController : Controller
    {
        PSDAPI _psdAPI = new PSDAPI();

        public async Task<IActionResult> Index()
        {
            List<CompanyDTO> dto = new List<CompanyDTO>();

            HttpClient client = _psdAPI.InitializeClient();

            HttpResponseMessage res = await client.GetAsync("api/company");

            //Checking the response is successful or not which is sent using HttpClient  
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var result = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                dto = JsonConvert.DeserializeObject<List<CompanyDTO>>(result);

            }

            //returning the employee list to view  
            return View(dto);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Website,Address1,Address2,City,Country,Pincode,Comments")] CompanyDTO student)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _psdAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8,"application/json");
                HttpResponseMessage res = client.PostAsync("api/company", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        // GET: Students/Edit/1
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<CompanyDTO> dto = new List<CompanyDTO>();
            HttpClient client = _psdAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("api/company");
 
            if (res.IsSuccessStatusCode)
            { 
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<CompanyDTO>>(result);
            }

            var student = dto.SingleOrDefault(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("StudentId,FirstName,LastName,Gender,DateOfBirth,DateOfRegistration,PhoneNumber,Email,Address1,Address2,City,State,Zip")] CompanyDTO student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _psdAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("api/student", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        // GET: Students/Delete/1
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = _psdAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync($"api/company/{id}").Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();

            //if (res.IsSuccessStatusCode)
            //{  
            //    var result = res.Content.ReadAsStringAsync().Result; 
            //    dto = JsonConvert.DeserializeObject<List<CompanyDTO>>(result);
            //}

            //var student = dto.SingleOrDefault(m => m.Id == id);
            //if (student == null)
            //{
            //    return NotFound();
            //}

            //return RedirectToAction("Index");
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(long id) 
        {
            HttpClient client = _psdAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync($"api/company/{id}").Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Add()  
        {

            return View();

        }

    }

   
}