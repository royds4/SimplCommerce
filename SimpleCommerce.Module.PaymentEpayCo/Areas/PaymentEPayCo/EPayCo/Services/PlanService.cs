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
    public class PlanService : GenericService<Plans, PlansDTO>
    {
        public PlanService(EPayCoConfigForm ePayCo)
        {
            EPayCo = ePayCo;
        }

        public override Task<Plans> Create(PlansDTO options)
        {
            Url =$@"/recurring/v1/plan/create";
            return base.Create(options);
        }

        public override Task<Plans> Get(int id)
        {
            Url = $@"/recurring/v1/plan/{EPayCo.PublicKey}/{id}/";
            return base.Get(id);
        }

        public async Task<IEnumerable<Plans>> List()
        {
            Url = $@"/payment/v1/customers/{EPayCo.PublicKey}/";
            var result = await GetRequest();
            return JsonConvert.DeserializeObject<IEnumerable<Plans>>(result);
        }

        public async Task Delete(int id)
        {
            Url = $@"/recurring/v1/plan/remove/{EPayCo.PublicKey}/{id}/";
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(Url,null);
                result = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
