using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GlobalObject
{
    public class FixedAssets
    {
        public static string Context
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings["FAMR"].ToString();
                }
                catch (Exception) { throw new Exception("No database connection"); }
            }
        }
    }
    public class SystemConfig
    {
        public static string MicrosoftId
        {
            get
            {
                return ConfigurationManager.AppSettings["MicrosoftId"].ToString();
            }
        }
        public static string MicrosoftSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["MicrosoftSecret"].ToString();
            }
        }
        public static string ServiceUnavailable
        {
            get
            {
                return ConfigurationManager.AppSettings["ServiceUnavailable"].ToString();
            }
        }
        public static string RedirectURI
        {
            get
            {
                return HttpContext.Current.Request.Url.Scheme + System.Uri.SchemeDelimiter + HttpContext.Current.Request.Url.Authority + "/Account/OAuthLogin";
            }
        }
    }
    public class DefaultValue
    {
        public static DateTime datetime
        {
            get
            {
                return new DateTime(1753, 1, 1);
            }
        }
    }
}
