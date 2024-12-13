using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for SendSMS
/// </summary>
public static class Msg
{
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
    public static string SendSMS(string Mobile, string Message)
    {
//        
        try
        {
          
            Mobile = Msg.CountryCode(Mobile);
            Message = Message.Replace("&", "%26");
            Message = Message.Replace("+", "%2B");


            string baseurl = "https://www.fast2sms.com/dev/bulkV2?authorization=kj2qAUCnDwsFmlouMLh4K19f7BtvJYr8zZgVeWH5OGNQIb3yRSneBLwa8T4gZx0vAjWNOmohfl35XI1q&route=otp&variables_values="+Message+"&flash=0&numbers="+Mobile+"";
            WebClient client = new WebClient();
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return (s);
        }
        catch (Exception Ex)
        {
            return ("");
        }
    }
    /*--------- end SMS--------------------------------------------------------------------------------------*/
    #endregion
    

}
