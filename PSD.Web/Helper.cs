using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PSD.Web.Helper
{
 
    public class PSDAPI
    {
        private string _apiBaseURI = "http://localhost:60883";
        public HttpClient InitializeClient()
        {
            var client = new HttpClient();
            //Passing service base url  
            client.BaseAddress = new Uri(_apiBaseURI);

            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;

        }
    }

    public class CompanyDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Pincode { get; set; }

        public string Clients { get; set; }

        public string Comments { get; set; }
    }
}
