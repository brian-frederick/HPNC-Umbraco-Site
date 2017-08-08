using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace HPNC_Website.Models
{
    public class customURLHelper
    {
        
        public static string UmbracoFile(string partialURL)
        {
            if (partialURL != "")
            {
                var BaseURL = ConfigurationManager.AppSettings["BaseURL"];

                var imageIndex = partialURL.IndexOf("/media");
                var clippedPartialURL = partialURL.Substring(imageIndex);

                var completeURL = BaseURL + clippedPartialURL;
                return completeURL;
            }
            else
            {
                return partialURL;
            }
        }
    }
}