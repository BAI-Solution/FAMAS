using FA_MR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA_MR.Controllers
{
    public class BaseController : Controller
    {
        public MUsers UserLog
        {

            get { return Session["Users"] as MUsers; }
        }
        protected override void OnActionExecuting(ActionExecutingContext pFilterContext)
        {
            string actFilter = pFilterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string _actName = pFilterContext.ActionDescriptor.ActionName;
            var _user = (Session["Users"] != null ? Session["Users"] : null) as MUsers;

            if (actFilter == "Account" && _actName != "Logout" && _actName != "OAuthLogin" && _user != null)
            {
                pFilterContext.Result = new RedirectResult("~/Page");
                return;
            }
            else if (actFilter != "Account" && _user == null)
            {

                pFilterContext.Result = new RedirectResult("~/Account/Index");
                return;
            }
            base.OnActionExecuting(pFilterContext);
        }
    }
}