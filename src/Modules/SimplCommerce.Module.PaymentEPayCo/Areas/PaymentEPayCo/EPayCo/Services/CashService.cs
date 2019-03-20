using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Resources.Constants;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Services
{
    public class CashService : GenericService<Cash, CashDTO>
    {
        public CashType Type { get; private set; }
        public CashService(EPayCoConfigForm ePayCo, CashType type)
        {
            EPayCo = ePayCo;
            Type = type;
        }

        public void ChangeType(CashType type)
        {
            Type = type;
        }

        public override async Task<Cash> Create(CashDTO options)
        {
            var response = string.Empty;
            switch (Type)
            {
                case CashType.Efecty:
                    Url = @"/restpagos/pagos/efecties.json";
                    break;
                case CashType.Baloto:
                    Url = @"/restpagos/pagos/balotos.json";
                    break;
                case CashType.Gana:
                    Url = @"/restpagos/pagos/ganas.json";
                    break;
            }
            return await base.Create(options);
        }

        public override async Task<Cash> Get(int id)
        {
            Url = $@"/restpagos/pse/transactioninfomation.json?transactionID={id}&&public_key={EPayCo.PublicKey}";
            return await base.Get(id);
        }
    }
}
