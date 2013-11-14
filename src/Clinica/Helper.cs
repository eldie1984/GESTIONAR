using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;

namespace Clinica
{
    public static class Helper
    {
        public static DateTime GetFechaNow()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string strDate = appSettings["DateTimeNow"];
            DateTime date = Convert.ToDateTime(strDate);
            return date;
        }
    }
}
