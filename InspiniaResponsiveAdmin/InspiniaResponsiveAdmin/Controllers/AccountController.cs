using System.Web.Mvc;
using System.Web.Security;
using InspiniaResponsiveAdmin.Models;

namespace InspiniaResponsiveAdmin.Controllers {

    public class AccountController : Controller {
        public ActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl) {
            if (ModelState.IsValid) {
                if (model != null) {
                    Session["CurrentUser"] = model;
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToLocal(returnUrl);
                }
                else {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }


        public ActionResult LogOff() {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}