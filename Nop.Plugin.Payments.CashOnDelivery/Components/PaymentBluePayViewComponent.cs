using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Payments.CashOnDelivery.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.CashOnDelivery.Components
{
    [ViewComponent(Name = "PaymentCashOnDelivery")]
    public class PaymentCashOnDeliveryViewComponent : NopViewComponent
    {
        private readonly IWorkContext _workContext;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public PaymentCashOnDeliveryViewComponent(IWorkContext workContext,
            ISettingService settingService,
            IStoreContext storeContext)
        {
            this._workContext = workContext;
            this._settingService = settingService;
            this._storeContext = storeContext;
        }

        public IViewComponentResult Invoke()
        {
            var cashOnDeliveryPaymentSettings = _settingService.LoadSetting<CashOnDeliveryPaymentSettings>(_storeContext.CurrentStore.Id);

            var model = new PaymentInfoModel
            {
                DescriptionText = cashOnDeliveryPaymentSettings.GetLocalizedSetting(x => x.DescriptionText, _workContext.WorkingLanguage.Id, 0)
            };

            return View("~/Plugins/Payments.CashOnDelivery/Views/PaymentInfo.cshtml", model);
        }
    }
}
