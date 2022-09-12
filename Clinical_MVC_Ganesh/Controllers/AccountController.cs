using Clinical_MVC_Ganesh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Clinical_MVC_Ganesh.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(TblLogin model, string returnUrl)
        {
            ClinicMVCDbEntities db = new ClinicMVCDbEntities();
            try
            {
                var dataItem = db.TblLogins.Where(x => x.MailID == model.MailID && x.Password == model.Password).First();
                Url.IsLocalUrl(returnUrl);


                if (dataItem != null)
                {
                    FormsAuthentication.SetAuthCookie(dataItem.MailID, false);
                    if (dataItem.Role is "Admin")

                    {
                        return RedirectToAction("Index","Home");
                    }

                    else  if (dataItem.Role is "Doctor")

                    { 
                        return RedirectToAction("Doctor", "Home");
                    }
                    else if (dataItem.Role is "Receptionist")          //Completed 
                    {
                        return RedirectToAction("Receptionist", "Home");

                    }
                    else if (dataItem.Role is "Laboratorian")       //Completed
                    {
                        return RedirectToAction("Laboratorian", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid user/pass");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user/pass");
                    return View();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Invalid User");
                return View();
            }
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}




