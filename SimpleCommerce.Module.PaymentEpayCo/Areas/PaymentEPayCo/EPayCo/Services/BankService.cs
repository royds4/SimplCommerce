using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Services
{
    public class BankService : GenericService<Bank, BankDTO>
    {
        public BankService(EPayCoConfigForm ePayCo)
        {
            EPayCo = ePayCo;
        }

        public override async Task<Bank> Create(BankDTO options)
        {
            Url = $@"/restpagos/pagos/debitos.json";
            return await base.Create(options);
        }

        public override async Task<Bank> Get(int id)
        {
            Url = $@"/restpagos/pse/transactioninfomation.json?transactionID={id}&&public_key={EPayCo.PublicKey}";
            return await base.Get(id);
        }
    }
}
