using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for API
/// </summary>
public class API
{
    string BaseURL = "http://api.rmrmobile.in/api";
   

    public string Url()
    {
        string ApiURLLink = "http://api.rmrmobile.in/api/";
      return ApiURLLink;
    }

    public string GetSingleData(string Url="")
    {
        WebClient client = new WebClient();
        client.Headers["Content-type"] = "application/json";
        client.Encoding = Encoding.UTF8;
        string json = client.DownloadString(BaseURL + Url);
        return (new JavaScriptSerializer()).Deserialize<string>(json);
    }

    public void PostData(string Url,Object Obj)
    {
        string apiUrl = "http://api.rmrmobile.in/api";
        WebClient client = new WebClient();
        client.Headers["Content-type"] = "application/json";
        client.Encoding = Encoding.UTF8;
        var dataString = JsonConvert.SerializeObject(Obj);
        string pagesource = client.UploadString(apiUrl + Url, "POST", dataString).ToString();
    }
    public void PostData1(string Url, Object Obj)
    {
        string apiUrl = "http://api.rmrmobile.in/api";
        WebClient client = new WebClient();
        client.Headers["Content-type"] = "application/json";
        client.Encoding = Encoding.UTF8;
        var dataString = JsonConvert.SerializeObject(Obj);
        string pagesource = client.UploadString(apiUrl + Url, "POST", dataString).ToString();
    }
    public void SendEmail(string Receiver_Email, string Subject, string Message)
    {
        try
        {
            //************************************* E-mail system *********************************************************//
         //   System.Configuration.Configuration configurationFile = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("web.config");
           // System.Net.Configuration.MailSettingsSectionGroup mailSettings = configurationFile.GetSectionGroup("system.net/mailSettings") as System.Net.Configuration.MailSettingsSectionGroup;
            //if (mailSettings != null)
            //{
            int port = 25;
            string host = "mail.aemailsrv.com";
            string password = "7M5L(S5dlNqv3.";
                string username = "info@rmrmobile.in";

                System.Net.Mail.MailMessage Msg = new System.Net.Mail.MailMessage();
                Msg.From = new System.Net.Mail.MailAddress(username);
                Msg.To.Add(Receiver_Email);
                Msg.Subject = "RMR Mobile";
                Msg.Subject = Subject;
                Msg.Body = Message;
     
                Msg.IsBodyHtml = true;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = host;
                smtp.Port = port;
                smtp.Credentials = new System.Net.NetworkCredential(username, password);
                smtp.Send(Msg);
                Msg = null;
          //  }
            //*************************************************************************************************************//
        }
        catch (Exception Ex)
        {

        }
    }    

}