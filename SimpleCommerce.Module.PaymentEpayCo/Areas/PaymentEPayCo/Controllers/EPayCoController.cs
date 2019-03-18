using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels;
using SimplCommerce.Module.PaymentEPayCo.Models;
using SimplCommerce.Module.ShoppingCart.Services;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Services;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto;
using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.Controllers
{
    [Area("PaymentEPayCo")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class EPayCoController:Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IRepository<Payment> _paymentRepository;

        public EPayCoController(
            ICartService cartService,
            IOrderService orderService,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IRepository<Payment> paymentRepository)
        {
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<IActionResult> Charge(string epaycoEmail, string epaycoToken)
        {
            var epaycoProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.EPayCoProviderId);
            var epaycoSetting = JsonConvert.DeserializeObject<EPayCoConfigForm>(epaycoProvider.AdditionalSettings);
            var epaycoChargeService = new ChargeService(epaycoSetting);
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCart(currentUser.Id);
            if (cart == null)
            {
                return NotFound();
            }

            var orderCreationResult = await _orderService.CreateOrder(cart.Id, "EPayCo", 0, OrderStatus.PendingPayment);
            if (!orderCreationResult.Success)
            {
                TempData["Error"] = orderCreationResult.Error;
                return Redirect("~/checkout/payment");
            }

            var order = orderCreationResult.Value;
            var zeroDecimalOrderAmount = order.OrderTotal;
            if (!CurrencyHelper.IsZeroDecimalCurrencies())
            {
                zeroDecimalOrderAmount = zeroDecimalOrderAmount * 100;
            }

            var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.LCID);
            var payment = new Payment()
            {
                OrderId = order.Id,
                Amount = order.OrderTotal,
                PaymentMethod = "EPayCo",
                CreatedOn = DateTimeOffset.UtcNow
            };
            try
            {
                var charge = await epaycoChargeService.Create(new ChargeDTO
                {
                    Value = (int)zeroDecimalOrderAmount,
                    Description = cart.OrderNote,
                    Currency = regionInfo.ISOCurrencySymbol,
                    Token_Card = epaycoToken
                });

                payment.GatewayTransactionId = charge.Id;
                payment.Status = PaymentStatus.Succeeded;
                order.OrderStatus = OrderStatus.PaymentReceived;
                _paymentRepository.Add(payment);
                await _paymentRepository.SaveChangesAsync();
                return Redirect($"~/checkout/success?orderId={order.Id}");
            }
            catch (EPayCoException ex)
            {
                payment.Status = PaymentStatus.Failed;
                payment.FailureMessage = ex.Message;
                order.OrderStatus = OrderStatus.PaymentFailed;

                _paymentRepository.Add(payment);
                await _paymentRepository.SaveChangesAsync();
                TempData["Error"] = ex.Message;
                return Redirect($"~/checkout/error?orderId={order.Id}");
            }
        }

    }
}
