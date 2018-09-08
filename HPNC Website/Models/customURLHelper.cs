using System;
using System.Configuration;

namespace HPNC_Website.Models
{
    public class customURLHelper
    {
        
        public static string UmbracoFile(string partialURL)
        {
            if (partialURL != "")
            {
                //var BaseURL = ConfigurationManager.AppSettings["BaseURL"];

                var imageIndex = partialURL.IndexOf("/media", StringComparison.Ordinal);
                var clippedPartialURL = partialURL.Substring(imageIndex);

                //var completeURL = BaseURL + clippedPartialURL;
                var completeURL = clippedPartialURL;
                return completeURL;
            }
            else
            {
                return partialURL;
            }
        }
    }
}