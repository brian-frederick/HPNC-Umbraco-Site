using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.Mappers;
using HPNC_Website.Models;
using Umbraco.Web.Mvc;
using Square.Connect.Api;
using Square.Connect.Client;
using Square.Connect.Model;

namespace HPNC_Website.Controllers
{
    public class DonationFormSurfaceController : SurfaceController
    {
        // GET: DonationFormSurface
        public ActionResult RenderDonationForm()
        {
            return PartialView("~/Views/Partials/_DonationForm.cshtml", new DonationFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleDonationForm(DonationFormModel model)
        {
            //Check if the dat posted is valid (All required's & email set in email field)
            if (!ModelState.IsValid)
            {
                //Not valid - so lets return the user back to the view with the data they entered still prepopulated
                return CurrentUmbracoPage();
            }

            //build API model
            string authorization = "sq0atp-y3yfJ9z11FzNCI-0yXsT3A";
            string locationId = "4TF4RMNFM5D9T";
            string key = Guid.NewGuid().ToString();
            string fullName = model.FirstName + " " + model.LastName;
            model.Amount = model.Amount * 100;
            Money money = new Money(model.Amount, Money.CurrencyEnum.USD);

            try
            {
                ChargeRequest body = new ChargeRequest(AmountMoney: money, IdempotencyKey: key, CardNonce: model.Nonce);
                TransactionApi transactionApi = new TransactionApi();
                var response2 = transactionApi.Charge(authorization, locationId, body);
                var confirm = response2;
            }
            catch (Exception ex)
            {
                //Throw an exception if there is a problem sending the email
                throw ex;
            }

            //Update success flag (in a TempData key)
            TempData["IsSuccessful"] = true;

            //All done - lets redirect to the current page & show our thanks/success message
            return RedirectToCurrentUmbracoPage();
        }

        public void ChargeCard(DonationFormModel model)
        {

        }

    }
}