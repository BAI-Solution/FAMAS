using FA_MR.Models;
using GlobalObject;
using Library.BLO.Interface;
using SingleSignIn;
using SingleSignIn.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA_MR.Controllers
{
    public class AccountController : BaseController
    {
        #region BLO
        IEmployees lIEmployees;
        IAuthenticate lIAuthenticate;
        #endregion
        #region Construct
        public AccountController(IEmployees pIEmployees)
        {
            lIEmployees = pIEmployees;
            lIAuthenticate = new Authenticate();
        }
        #endregion
        #region Method
        public ActionResult Index()
        {
            if (bool.Parse(SystemConfig.ServiceUnavailable))
                return RedirectToAction("Index", "ServiceUnavailable");
            else return View();
        }
        public ActionResult OAuthLogin(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                    throw new Exception("Your authorization code is already expired");

                MUsers _user = new MUsers();
                #region User Information
                var _mailInfo = lIAuthenticate.UserInformation(code, SystemConfig.RedirectURI, SystemConfig.MicrosoftId, SystemConfig.MicrosoftSecret, "Microsoft", "rafi.ph");
                _user.UMID = _mailInfo.id;
                _user.FNAM = _mailInfo.firstname;
                _user.LNAM = _mailInfo.lastname;
                _user.MAIL = _mailInfo.mail;
                _user.PICT = _mailInfo.picture;
                _user.FULL = _mailInfo.firstname + " " + _mailInfo.lastname;
                #endregion
                var _emp = lIEmployees.Get(_user.MAIL);
                _user.EMID = _emp.EmployeeId;
                Session["Users"] = (_user as MUsers);
                if (!_emp.Equals(0))
                    return RedirectToAction("Index", "Page");
                else return RedirectToAction("Index", "Account");
            }
            catch (Exception ex)
            {
                Session.RemoveAll();
                TempData["msg"] = ex.Message;
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult Logout()
        {

            Session.Remove("Users");
            return RedirectToAction("Index", "Account");
        }
        #endregion
    }
}