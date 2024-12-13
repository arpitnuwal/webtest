using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for BaseUrl
/// </summary>
public class BaseUrl
{
    public string Url()
    {
        string ApiURLLink = "http://api.rmrmobile.in/api";
        return ApiURLLink;
    }

     #region
    /*--------- start SMS -----------------------------------------------------------------------------------*/
    public static class Gateway
    {
        public static string High = "high";
        public static string Regular = "regular";
    }
    public static string CountryCode(string Mobile)
    {
        if (Mobile != "")
        {
            string MobileNo = "";
            char[] delimeter = new char[] { ',', ' ' };
            string[] mobileList = Mobile.Split(delimeter, StringSplitOptions.RemoveEmptyEntries);
            foreach (string mobile in mobileList)
            {                         
                MobileNo = MobileNo + mobile.Substring(mobile.Length - Math.Min(10, mobile.Length)) + ",";
            }
            MobileNo = MobileNo.Remove(MobileNo.LastIndexOf(','));
            return (MobileNo);
        }
        else
        {
            return ("");
        }
    }
   
    /*--------- end SMS--------------------------------------------------------------------------------------*/
    #endregion

   
}
