using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class ProductsRESTService
    {

        readonly string baseUri = "http://localhost:3749/api/ProductsEF/";

        public List<DTO.Product> GetProducts()
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Product>>(response.Result);
            }
        }

        public bool PostProducts(Product p)
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(p);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PostAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool PutProducts(Product p)
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(p);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PutAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool DeleteProducts(int i)
        {
            string uri = baseUri + i;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<HttpResponseMessage> response = httpClient.DeleteAsync(uri);
                return response.Result.IsSuccessStatusCode;
            }
        }

    }
}
