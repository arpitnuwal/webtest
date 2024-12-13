using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contactus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LogIn_Click(object sender, EventArgs e)
    {


        LblErr.Text = "";
        if (txtname.Text == "")
        {
            LblErr.Text = "Input Name..";
            return;
        }
        if (txtemail.Text == "")
        {
            LblErr.Text = "Input Email..";
            return;
        }
        if (txtmobile.Text == "")
        {
            LblErr.Text = "Input Phone No..";
            return;
        }

        if (txtmsg.Text == "")
        {
            LblErr.Text = "Input Subject ...";
            return;
        }
        try
        {
            MailMessage newmail = new MailMessage();
            MailAddress toadd = new MailAddress("info@profitbusiness.in");
            MailAddress fromadd = new MailAddress("info@profitbusiness.in");
            newmail.Subject = "New Enquiry from Website";
            string msg = "<div>";
            msg = msg + "<br/>Name:" + txtname.Text;
            msg = msg + "<br/>Email :<a href='mailto:" + txtemail.Text + "' target='_blank'>" + txtemail.Text + "</a><br />Company Name= " + txtaddress.Text + "";
            msg = msg + "<br/>Mobile No:" + txtmobile.Text + "<br/>Subject : " + txtmsg.Text + " <br/>Message :" + txtmsg.Text + "</div>";
            newmail.Body = msg;
            newmail.To.Add(toadd);
            newmail.From = fromadd;
            newmail.IsBodyHtml = true;
            SmtpClient sserver = new SmtpClient();
            sserver.Host = "mail.aemailsrv.com";
            sserver.Credentials = new NetworkCredential("info@profitbusiness.in", "7M5L(S5dlNqv3.");
            sserver.DeliveryMethod = SmtpDeliveryMethod.Network;
            sserver.Port = 25;
            sserver.Send(newmail);
            LblErr.Text = "Message sent successfully ...";
            txtmsg.Text = "";
            txtemail.Text = "";
            txtmobile.Text = "";
            txtmsg.Text = "";
            txtname.Text = "";
            txtaddress.Text = "";

        }
        catch (Exception ex)
        {
            LblErr.Text = ex.Message;
        }
    }
}