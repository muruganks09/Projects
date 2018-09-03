using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSD.API.Models;
using PSD.API.Models.Repository;
using PSD.API.Models.DataManager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PSD.API.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private IDataRepository<Company,long> _iRepo; 
        public CompanyController(IDataRepository<Company, long> repo)
        {
            _iRepo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _iRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return _iRepo.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Company company)
        {
            _iRepo.Add(company);
        }

        // POST api/values
        [HttpPut]
        public void Put([FromBody]Company company)
        {
            _iRepo.Update(company.Id, company);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}
