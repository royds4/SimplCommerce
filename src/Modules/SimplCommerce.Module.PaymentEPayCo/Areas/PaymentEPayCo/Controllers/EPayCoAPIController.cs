using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using SimplCommerce.Module.PaymentEPayCo.Models;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.Controllers
{
    [Area("PaymentEPayCo")]
    [Authorize(Roles = "admin")]
    [Route("api/epayco")]
    public class EPayCoApiController:Controller
    {

        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public EPayCoApiController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var epaycoProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.EPayCoProviderId);
            var model = JsonConvert.DeserializeObject<EPayCoConfigForm>(epaycoProvider.AdditionalSettings);
            return Ok(model);
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] EPayCoConfigForm model)
        {
            if (ModelState.IsValid)
            {
                var epaycoProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.EPayCoProviderId);
                epaycoProvider.AdditionalSettings = JsonConvert.SerializeObject(model);
                await _paymentProviderRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }

    }
}
