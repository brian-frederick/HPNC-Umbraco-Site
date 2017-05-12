using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using HPNC_Website.Models;
using System.Web.Security;

namespace HPNC_Website.Controllers
{
    public class MemberController: SurfaceController
    {
        public ActionResult RenderLogin()
        {
            return PartialView("_LoginForm", new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitLogin(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    UrlHelper myHelper = new UrlHelper(HttpContext.Request.RequestContext);
                    if (myHelper.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        var url = HttpContext.Request.RawUrl;
                        return Redirect(url);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The username or password provided is incorrect.");
                }
            }
            return CurrentUmbracoPage();
        }

        public ActionResult RenderLogout()
        {
            return PartialView("_LogoutForm", null);
        }

        public ActionResult SubmitLogout()
        {
            TempData.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToCurrentUmbracoPage();
        }

    }
}