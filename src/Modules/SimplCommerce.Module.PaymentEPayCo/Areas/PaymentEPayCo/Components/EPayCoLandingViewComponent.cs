using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using SimplCommerce.Module.PaymentEPayCo.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.Components
{
    public class EPayCoLandingViewComponent:ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public EPayCoLandingViewComponent(ICartService cartService, IWorkContext workContext, IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _cartService = cartService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var epaycoProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.EPayCoProviderId);
            var epaycoSetting = JsonConvert.DeserializeObject<EPayCoConfigForm>(epaycoProvider.AdditionalSettings);
            var curentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(curentUser.Id);
            var zeroDecimalAmount = cart.OrderTotal;
            var zeroDecimalTax= cart.TaxAmount;
            var zeroDecimalSubtotal = cart.SubTotalWithDiscountWithoutTax;
            if (!CurrencyHelper.IsZeroDecimalCurrencies())
            {
                zeroDecimalAmount = zeroDecimalAmount * 100;
                zeroDecimalTax = zeroDecimalTax * 100;
                zeroDecimalSubtotal = zeroDecimalSubtotal * 100;
            }

            var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.LCID);
            var model = new EPayCoCheckoutForm();
            model.Key = epaycoSetting.PublicKey;
            model.Name = string.Join(',',cart.Items);
            model.Description = cart.OrderNote;
            model.Amount = (long)zeroDecimalAmount;
            model.Currency = regionInfo.ISOCurrencySymbol;
            model.Country = regionInfo.Name;
            model.Tax = (long)zeroDecimalTax;
            model.TaxBase = (long)zeroDecimalSubtotal;
            model.Test = epaycoSetting.Test;
            model.ResponseUrl = Request.GetFullHostingUrlRoot() + Url.Action("Charge", "EPayCo", new { Area = "PaymentEPayCo" });

            return View(this.GetViewPath(), model);
        }
    }
}
