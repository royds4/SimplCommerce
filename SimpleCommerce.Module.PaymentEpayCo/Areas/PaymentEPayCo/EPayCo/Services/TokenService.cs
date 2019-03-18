using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Services
{
    public class TokenService : GenericService<Token, TokenDTO>
    {
        public TokenService(EPayCoConfigForm epayco)
        {
            EPayCo = epayco;
        }

        public override Task<Token> Create(TokenDTO options)
        {
            Url =$@"/v1/tokens";
            return base.Create(options);
        }

        public override Task<Token> Get(int id)
        {
            return base.Get(id);
        }
    }
}
