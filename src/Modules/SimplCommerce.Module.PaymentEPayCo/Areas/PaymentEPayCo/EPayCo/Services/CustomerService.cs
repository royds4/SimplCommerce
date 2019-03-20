using Newtonsoft.Json;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Services
{
    public class CustomerService : GenericService<Customers, CustomerDTO>
    {
        public CustomerService(EPayCoConfigForm ePayCo)
        {
            EPayCo = ePayCo;
        }

        public override async Task<Customers> Create(CustomerDTO options)
        {
            Url = $@"/payment/v1/customer/create";
            return await base.Create(options);
        }

        public override async Task<Customers> Get(int id)
        {
            Url = $@"/payment/v1/customer/{EPayCo.PublicKey}/{id}/";
            return await base.Get(id);
        }

        public async Task<IEnumerable<Customers>> List()
        {
            Url = $@"/payment/v1/customers/{EPayCo.PublicKey}/";
            var result = await GetRequest();
            return JsonConvert.DeserializeObject<IEnumerable<Customers>>(result);
        }

        public async Task Edit(int id, CustomerDTO options)
        {
            Url = $@"/payment/v1/customer/edit/{EPayCo.PublicKey}/{id}/";
            string result = await PostRequest(options);
        }
    }
}
