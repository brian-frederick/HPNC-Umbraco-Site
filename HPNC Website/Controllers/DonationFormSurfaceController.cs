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
       
        public ActionResult RenderDonationForm()
        {
            return PartialView("~/Views/Partials/_DonationForm.cshtml", new DonationFormModel());
        }

        public ActionResult RenderCreditCardForm(DonationFormModel model)
        {
            TempData["DonationInProcess"] = true;
            TempData["DonationSuccessful"] = false;
            TempData.Add("model", model);

            return RedirectToCurrentUmbracoPage();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BeginDonation(DonationFormModel model)
        {



            return PartialView("~/Views/Partials/_personalInfoForm.cshtml", model); 
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
            //string authorization = "sq0atp-y3yfJ9z11FzNCI-0yXsT3A";
            string authorization = "sandbox-sq0atb-uIKrJ7mof7lHpc8tBOU1HA"; //sandbox
            //string locationId = "4TF4RMNFM5D9T";
            string locationId = "CBASEAF9JuhJ7vWfEWKTYiRX57QgAQ"; //sandbox
            string key = Guid.NewGuid().ToString();
            string fullName = model.Name;
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

                TempData["DonationError"] = true;

                //All done - lets redirect to the current page & show our thanks/success message
                return RedirectToCurrentUmbracoPage();
            }

            //Update success flag (in a TempData key)
            TempData["DonationSuccessful"] = true;

            //All done - lets redirect to the current page & show our thanks/success message
            return RedirectToCurrentUmbracoPage();
        }

        public void ChargeCard(DonationFormModel model)
        {

        }

    }
}