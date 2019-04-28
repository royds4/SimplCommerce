using Newtonsoft.Json;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Services
{
    public abstract class GenericService<T, D>
    {
        public EPayCoConfigForm EPayCo { get; protected set; }
        public string Url { get; protected set; }

        protected async Task<string> PostRequest(D options)
        {
            try
            {


                var nameValueCollection = new List<KeyValuePair<string, string>>();
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(options))
                {
                    string value = propertyDescriptor.GetValue(options)?.ToString() ?? string.Empty;
                    nameValueCollection.Add(new KeyValuePair<string, string>(propertyDescriptor.Name, value));
                }
                var content = new FormUrlEncodedContent(nameValueCollection.ToArray());
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(Url, content);
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected async Task<string> GetRequest()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(Url);
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual async Task<T> Create(D options)
        {
            string result = string.Empty;
            result = await PostRequest(options);
            return JsonConvert.DeserializeObject<T>(result);
        }
        public virtual async Task<T> Get(int id)
        {
            var result = await GetRequest();
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
