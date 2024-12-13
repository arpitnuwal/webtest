using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    ClsConnection cnn = new ClsConnection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        if (txtemail.Text == "")
        {
            lblerror.Text = "Enter Email..."; return;
        }
        if (txtphone.Text == "")
        {
            lblerror.Text = "Enter MObile Number..."; return;
        }
        if (txtsubject.Text == "")
        {
            lblerror.Text = "Enter Subject..."; return;
        }
        if (txtmsg.Text == "")
        {
            lblerror.Text = "Enter Message..."; return;
        }
        cnn.Open();
        int ID = Convert.ToInt32(cnn.ExecuteScalar("Select  IsNull(Max(id)+1,1) From [contact]"));
        cnn.ExecuteNonQuery("INSERT INTO contact (id,name,mobile,subject,message,rts,email) values ('" + ID + "','" + txtname.Text + "','" + txtphone.Text + "','" + txtsubject.Text + "','" + txtmsg.Text + "',getdate(),'"+txtemail.Text+"')");
        cnn.Close();

        txtmsg.Text = "";
        txtname.Text = "";
        txtphone.Text = "";
        txtsubject.Text = "";
        txtemail.Text = "";
        lblerror.Text = "Thanks for Enquiry.. Admin Contact Soon...";
    }
}