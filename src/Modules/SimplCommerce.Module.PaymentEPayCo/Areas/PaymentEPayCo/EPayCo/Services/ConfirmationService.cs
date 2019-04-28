using Newtonsoft.Json;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Entities;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Services
{
    public class ConfirmationService : GenericService<Confirmation, ConfirmationDTO>
    {
        public ConfirmationService(EPayCoConfigForm ePayCo)
        {
            EPayCo = ePayCo;
        }

        public override async Task<Confirmation> Create(ConfirmationDTO options)
        {
            return await base.Create(options);
        }

        public override async Task<Confirmation> Get(int id)
        {
           
            return await base.Get(id);
        }

        public async Task<Confirmation> Get(string id)
        {
            Url = $@"https://secure.epayco.co/validation/v1/reference/{id}";
            var response = await GetRequest();
            return JsonConvert.DeserializeObject<Confirmation>(response);
        }
    }
}
