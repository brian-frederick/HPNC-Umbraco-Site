using System;
using System.Web.Mvc;
using HPNC_Website.Models;
using Umbraco.Web.Mvc;
using Square.Connect.Api;
using Square.Connect.Model;
using System.Configuration;

namespace HPNC_Website.Controllers
{
    public class DonationFormSurfaceController : SurfaceController
    {

        string squareAuthorization = ConfigurationManager.AppSettings["SquareAuth"];
        string squareLocationId = ConfigurationManager.AppSettings["SquareLocationID"];
        //string squareAuthorization = "sq0atp-y3yfJ9z11FzNCI-0yXsT3A";
        //string squareLocationId = "4TF4RMNFM5D9T";

        //string squareLocationId = "CBASEAF9JuhJ7vWfEWKTYiRX57QgAQ"; //sandbox
        //string squareAuthorization = "sandbox-sq0atb-uIKrJ7mof7lHpc8tBOU1HA"; //sandbox

        public ActionResult RenderDonationForm()
        {
            return PartialView("~/Views/Partials/_DonationForm.cshtml", new DonationFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleDonationForm(DonationFormModel model)
        {
            if (!ModelState.IsValid)
            {

                return CurrentUmbracoPage();
            }


            string key = Guid.NewGuid().ToString();
            model.Amount = model.Amount * 100;
            Money money = new Money(model.Amount, Money.CurrencyEnum.USD);

            try
            {
                var customerId = CreateCustomer(model);
                ChargeRequest body = new ChargeRequest(key, money, model.Nonce, null, null, null, null, customerId);
                TransactionApi transactionApi = new TransactionApi();
                var response = transactionApi.Charge(squareAuthorization, squareLocationId, body);
                var confirm = response;
            }
            catch (Exception)
            {

                TempData["DonationError"] = true;
                return RedirectToCurrentUmbracoPage();
            }

            TempData["DonationSuccessful"] = true;
            return RedirectToCurrentUmbracoPage();
        }

        public string CreateCustomer(DonationFormModel model)
        {
            Address address = new Address(model.StreetAddress1, model.StreetAddress2, null, model.City, null, null, null, model.State, null, null, model.ZipCode, null, model.FirstName, model.LastName, null);
            CreateCustomerRequest body = new CreateCustomerRequest(model.FirstName, model.LastName, null, null, model.Email, address, model.Phone, null, null);
            CustomerApi customerAPI = new CustomerApi();
            var response = customerAPI.CreateCustomer(squareAuthorization, body);
            return response.Customer.Id;
        }
    }
}