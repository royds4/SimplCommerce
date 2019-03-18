using Newtonsoft.Json;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Services
{
    public class SuscriptionService : GenericService<Suscriptions, SuscriptionDTO>
    {
        public SuscriptionService(EPayCoConfigForm ePayCo)
        {
            EPayCo = ePayCo;
        }

        public override async Task<Suscriptions> Create(SuscriptionDTO options)
        {
            Url = $@"/recurring/v1/subscription/create";
            return await base.Create(options);
        }

        public override async Task<Suscriptions> Get(int id)
        {
            Url = $@"/recurring/v1/subscription/{id}/{EPayCo.PublicKey}/";
            return await base.Get(id);
        }

        public async Task<IEnumerable<Suscriptions>> List()
        {
            Url = $@"/recurring/v1/subscriptions/{EPayCo.PublicKey}/";
            var result = await GetRequest();
            return JsonConvert.DeserializeObject<IEnumerable<Suscriptions>>(result);
        }

        public async Task Cancel(int id)
        {
            Url = $@"/recurring/v1/subscription/cancel";
            var nameValueCollection = new List<KeyValuePair<string, string>>();
            nameValueCollection.Add(new KeyValuePair<string, string>("id", id.ToString()));
            nameValueCollection.Add(new KeyValuePair<string, string>("public_key", EPayCo.PublicKey));
            var content = new FormUrlEncodedContent(nameValueCollection.ToArray());
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(Url, content);
            }
        }

        public async Task Charge(SuscriptionDTO options)
        {
            Url = $@"/payment/v1/charge/subscription/create";
            var result = await PostRequest(options);
        }
    }
}
