using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DTO;

namespace BLL
{
    public class ContactRESTService
    {

        readonly string baseUri = "http://localhost:56130/api/contacts/";

        public List<Contact> GetContacts()
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Contact>>(response.Result);
            }
        }

        public Contact GetContactById(int id)
        {
            string uri = baseUri + id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Contact>(response.Result);
            }
        }

        public bool PostContact(Contact c)
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(c);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PostAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool PutContact(Contact c)
        {
            string uri = baseUri + c.ContactId;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(c);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PutAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool DeleteContact(int i)
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
