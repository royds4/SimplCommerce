using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Services
{
    public class ChargeService : GenericService<Charge, ChargeDTO>
    {
        public ChargeService(EPayCoConfigForm ePayCo)
        {
            EPayCo = ePayCo;
        }
        public override async Task<Charge> Create(ChargeDTO options)
        {
            Url = $@"/payment/v1/charge/create";
            return await base.Create(options);
        }

        public override async Task<Charge> Get(int id)
        {
            Url = $@"/restpagos/transaction/response.json?ref_payco={id}&&public_key={EPayCo.PublicKey}";
            return await base.Get(id);
        }

    }
}
