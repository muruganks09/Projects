using PSD.API.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PSD.API.Models.DataManager
{
    public class CompanyManager : IDataRepository<Company, long>
    {
        PSDContext ctx;
        public CompanyManager(PSDContext c)
        {
            ctx = c;
        }

        public Company Get(long id)
        {
            var company = ctx.Companys.FirstOrDefault(b => b.Id == id);
            return company;
        }

        public IEnumerable<Company> GetAll()
        {
            var company = ctx.Companys.ToList();
            return company;
        }

        public long Add(Company company)
        {
            ctx.Companys.Add(company);
            long studentID = ctx.SaveChanges();
            return studentID;
        }

        public long Delete(long id)
        {
            int Id = 0;
            var company = ctx.Companys.FirstOrDefault(b => b.Id == id);
            if (company != null)
            {
                ctx.Companys.Remove(company);
                Id = ctx.SaveChanges();
            }
            return Id;
        }

        public long Update(long id, Company item)
        {
            long Id  = 0;
            var company = ctx.Companys.Find(id);
            if (company != null)
            {
                //student.FirstName = item.FirstName;
                //student.LastName = item.LastName;
                //student.Gender = item.Gender;
                //student.PhoneNumber = item.PhoneNumber;
                //student.Email = item.Email;
                //student.DateOfBirth = item.DateOfBirth;
                //student.DateOfRegistration = item.DateOfRegistration;
                //student.Address1 = item.Address1;
                //student.Address2 = item.Address2;
                //student.City = item.City;
                //student.State = item.State;
                //student.Zip = item.Zip;

                Id = ctx.SaveChanges();
            }
            return Id;
        }
    }
}
