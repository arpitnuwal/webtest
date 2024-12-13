using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for orderfunction
/// </summary>
public class orderfunction
{
    ClsConnection Cnn = new ClsConnection();
    SqlConnection sqlCon = new SqlConnection(@"Data Source=mssql2017.adnshost.com,1533; Database=aerosportsind; User id=aerosportsind; password=aerosportsind@2575;Max Pool Size=50000");


	public orderfunction()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void GenerateOrder(Order obj)
    {

        try
        {
            Cnn.Open();
            string conuntcart = Cnn.ExecuteScalar("select count(*) from trncart where UserId=" + obj.Usercode + " ").ToString();
            Cnn.Close();
            if (conuntcart != "0")
            {
                int Amount = 0, PaidAmount = 0, DeliveryCharges = 0, OrderAmount = 0, Quantity = 0, AdditionalCharges = 0;
            string strMsg_Admin = "", strMsg_User = "", strMsgCart = "", strEmailCart = "", Res_Email = "", FranchiseMobileNo = "", FranchiseEmailId = "";
            string Admin_Mobile = "7300113153";
            string Admin_Mail = " info@aerosportsind.com";
            string Cashback1 = "";
            decimal TotalDiscount = 0;
            int sid = 0, neworderid = 0;
            string colorname = "", varianame = "";
            if (obj.OrderThrough == "") { obj.OrderThrough = "App"; }
            Cnn.Open();
            sid = Convert.ToInt32(Cnn.ExecuteScalar("select sid from sessiontest where active=1"));
            neworderid = Convert.ToInt32(Cnn.ExecuteScalar("Select isnull( max(OrderId),0)+1 from trnordermain where sid=" + sid + ""));
            Cnn.Close();
            SqlConnection sqlCon = new SqlConnection(@"Data Source=mssql2017.adnshost.com,1533; Database=aerosportsind; User id=aerosportsind; password=aerosportsind@2575;Max Pool Size=50000");
            sqlCon.Open();
            obj.OrderId = neworderid;
            SqlDataAdapter sqlDa = new SqlDataAdapter("select b.sku,a.name,a.number,a.id,a.productid,a.color,a.Size,b.productname,a.Quantity,b.image,a.id as rate,a.id as discount  from trncart as a inner join  product as b on a.productid=b.productid Where a.UserId=" + obj.Usercode + "", sqlCon);
            DataTable Dt = new DataTable();
            sqlDa.Fill(Dt);
            FranchiseMobileNo = "7300113153";
            FranchiseEmailId = " info@aerosportsind.com";
            int calamt = 0;
            int calamount = 0, caldiscount = 0;
            // FranchiseMobileNo = "9214472437";
            Cnn.Open();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {

                DataRow dr = Cnn.FillRow("select price as  rate , Discount from  Product where    ProductId=" + Dt.Rows[i]["ProductId"] + " ");
                int Discount = Convert.ToInt32(dr["Discount"]);
                int Rate = Convert.ToInt32(dr["Rate"]);
                Dt.Rows[i]["rate"] = Rate;
                Dt.Rows[i]["Discount"] = Discount;
                calamount = Convert.ToInt32(Dt.Rows[i]["rate"]) * Convert.ToInt32(Dt.Rows[i]["Quantity"]);
                caldiscount = Convert.ToInt32(Dt.Rows[i]["Discount"]) * Convert.ToInt32(Dt.Rows[i]["Quantity"]);
                calamt = calamount - caldiscount;
                var DisInvoiceNo = "PI/0" + sid + "/" + obj.OrderId;
                Amount += calamt;
                AdditionalCharges = 0;

                Quantity += Convert.ToInt32(Dt.Rows[i]["Quantity"]);
                TotalDiscount += caldiscount;
                Cashback1 = "0";
                SqlCommand Sql = new SqlCommand("insert into TrnOrderDetail(InvoiceNo,DisInvoiceNo,OrderId,StoreId,ProductId,Unit,Weight,Quantity,Rate,Size,Color,Cashback,Amount,Discount,NetAmount,Cancelled,Delivered,Returned,Dispatched,RTS,DeliveryDate,DeliveryCharges,AdditionalCharges,RequestReason,remark,sid,name,number,sku) values (" + obj.OrderId + ",'" + DisInvoiceNo + "'," + obj.OrderId + ",'0'," + Dt.Rows[i]["ProductId"] + ",'','10'," + Dt.Rows[i]["Quantity"] + "," + Dt.Rows[i]["Rate"] + ",'" + Dt.Rows[i]["Size"] + "','" + Dt.Rows[i]["Color"] + "'," + Cashback1 + "," + calamount + "," + caldiscount + "," + calamt + ",0,0,0,0,GetDate(),GetDate(),'" + obj.DeliveryFees + "','0','',''," + sid + ",'" + Dt.Rows[i]["name"] + "','" + Dt.Rows[i]["number"] + "','"+ Dt.Rows[i]["sku"] + "')", sqlCon);
                string balanceObj = Sql.ExecuteNonQuery().ToString();
                var ProductImage = Dt.Rows[i]["Image"].ToString();
                var ProductName = Dt.Rows[i]["ProductName"].ToString()+"<br/>Print Name : "+ Dt.Rows[i]["name"] + "&nbsp;&nbsp;&nbsp;Size: " + Dt.Rows[i]["size"] + "";
               
                strMsgCart = strMsgCart + ProductName + "  Qty(" + Dt.Rows[i]["Quantity"].ToString() + ")  ,Amt. " + calamt + "   ";
                strEmailCart = strEmailCart + "<tr><td align='center'><img src='https://www.Aerosportsind.com/img/product/" + ProductImage + "' width='70' height='100' padding-top='10' padding-bottom='10'/></td><td padding='10' align='center'>" + ProductName + colorname + varianame + " <br/> </td><td padding='10' align='center'> " + Dt.Rows[i]["Quantity"] + "</td><td padding='10' align='center'>" + Dt.Rows[i]["rate"] + "</td><td padding='10' align='center'>" + Dt.Rows[i]["Quantity"] + "</td><td padding='10' align='center'>" + calamount + "</td><td padding='10' align='center'>" + caldiscount + "</td><td padding='10' align='center'>" + calamt + "</td></tr>";

            }
            Cnn.Close();
            DeliveryCharges = Convert.ToInt32(obj.DeliveryFees);


            OrderAmount = DeliveryCharges + Amount;
            PaidAmount = Convert.ToInt32(OrderAmount) - Convert.ToInt32(obj.WalletAmount);
            SqlCommand MainSql = new SqlCommand("insert into TrnOrderMain(OrderId,Usercode,OrderAmount,WalletAmount,PaidAmount,TotalQuantity,DeliveryFees,Amount,Paymode,TrnId,TrnStatus,OrderThrough,ShippingName,ShippingAddress,ShippingMobileNo,ShippingEmailId,ShippingCity,ShippingZipcode,ShippingStats,Delivered,Cancelled,Returned,Dispatched,Settlement,RTS,DeliveryDate,PromoCodeId,PromoCodeAmount,DeliveryboyId,FranchiseMessage,remark,sid,lessamount,preamount,remainingamount,domesticinternational,couponuse) values (" + obj.OrderId + "," + obj.Usercode + "," + OrderAmount + "," + obj.WalletAmount + "," + PaidAmount + "," + Quantity + "," + DeliveryCharges + "," + Amount + ",'" + obj.Paymode + "','" + obj.TrnId + "','" + obj.TrnStatus + "','" + obj.OrderThrough + "','" + obj.ShippingName + "','" + obj.ShippingAddress + "','" + obj.ShippingMobileNo + "','" + obj.ShippingEmailId + "','" + obj.ShippingCity + "','" + obj.ShippingZipcode + "','" + obj.ShippingStats + "',0,0,0,0,0,GetDate(),GetDate()," + obj.PromoCodeId + "," + obj.PromoCodeAmount + ",0,'',''," + sid + ",'"+obj.lessamount + "','"+obj.preamount+"','"+obj.remainingamount+"','"+obj.domesticinternational+"','"+obj.couponuse + "')", sqlCon);
            string balanceObj1 = MainSql.ExecuteNonQuery().ToString();

           
            //
            //  mAil & Message  Code Start
            if (obj.DeliveryFees != null && obj.DeliveryFees != 0)
            {
                strMsgCart = strMsgCart + "Discount " + TotalDiscount + ", Delivery Charges Rs." + DeliveryCharges + " , Wallet Amount Rs.:" + Convert.ToInt32(obj.WalletAmount) + "";
            }
            string Wallamt = "", wallietmsg = "",counpon="",prepaidbox="";
            if (Convert.ToInt32(obj.WalletAmount) > 0)
            {
                Cnn.Open();
                string remark = "  Order no. " + neworderid + " has been Complete  .. " + obj.WalletAmount + " point Debited in your Wallet";
                int nID = Convert.ToInt32(Cnn.ExecuteScalar("Select  IsNull(Max(id)+1,1) From [referlist]"));
                Cnn.ExecuteNonQuery("insert into referlist values ('" + nID + "','" + obj.Usercode + "','" + remark + "','" + obj.WalletAmount + "',1,getdate())");
                Cnn.ExecuteNonQuery("update register set Wallet=Wallet-" + obj.WalletAmount + " where UserId=" + obj.Usercode + "");
                Cnn.Close();
                Wallamt = "<tr><td align='right' style='padding-right:10'><b>Wallet Deduct &nbsp;&nbsp;&nbsp;: Rs." + obj.WalletAmount + " </b></td></tr>";
            }
            if (Convert.ToInt32(obj.lessamount) > 0)
            {
                counpon = "<tr><td align='right' style='padding-right:10'><b>Coupon Code Less (Code: "+obj.couponuse + ") &nbsp;&nbsp;&nbsp;: Rs." + obj.lessamount + " </b></td></tr>";



            }
            prepaidbox = "<tr><td align='right' style='padding-right:10'><b>PrePaid Amount &nbsp;&nbsp;&nbsp;: Rs." + obj.preamount + " </b></td></tr>";


            strMsg_Admin = "You Have Received New Order No." + obj.OrderId + " Amt Rs." + PaidAmount + "  Delivery Address: " + obj.ShippingName + ", " + obj.ShippingMobileNo;
            strMsg_User = "Thanks for your Order No." + obj.OrderId + " Amt Rs." + PaidAmount + " Order Details: " + strMsgCart + " Del Address: " + obj.ShippingName + ", " + obj.ShippingAddress + ", " + obj.ShippingCity + ". Will be delivered soon Visit: www.Aerosportsind.com";
            //strMsg_Restaurant = "Order No." + obj.Order_ID + " Amount Rs." + obj.Order_TotalAmount + " Order Details: " + strMsgCart + " Delivery Address: " + obj.Shipper_Name + ", " + obj.Shipper_Address + ", " + obj.Shipper_City + ". Order by: " + obj.User_Name + " " + obj.User_Mobile + " Visit: www.CityStore.in";
            ////Send Email
            string strEmail_Admin = "<html>" + DateTime.Now + "<br/><br/><br />Hello, &nbsp;Admin";
            strEmail_Admin += "<html><head><body><div style='border-style: double; border-width: 10px; border-color:#cccccc; padding:20px; Font-size:11px; color:black;width:590px'><img src='https://aerosportsind.com/img/logo.png' style='height:88px;width:200px'  alt='logo'    border='0'/><br /><br />";
            strEmail_Admin += "Order No. : <b>" + obj.OrderId + "</b>&nbsp;Order Date : <b>" + DateTime.Now + "</b>&nbsp;&nbsp;Order Through : " + obj.OrderThrough + " &nbsp; Payment Mode : " + obj.Paymode + "<br><br/>";
            strEmail_Admin += "<strong></strong><br/><br/><body><table width='590' height='auto' border='1' cellpadding='0' cellspacing='0'><tr bgcolor='#cbc7c7'  align='center'><td height='30'>Image</td><td color='#ffffff'>Particulars</td><td>Unit</td><td>Rate</td><td>Qty.</td><td>Amount</td><td>Discount</td><td>NetAmount</td></tr>" + strEmailCart + "</table></body>";
            strEmail_Admin += "<table width='590' Font-size:'11'><tr><td align='right' style='padding-right:10'>Amount &nbsp;&nbsp;&nbsp;<b>Rs." + Amount + "</b></td></tr><td><hr/></td></tr><tr><td align='right' style='padding-right:10'><b>Delivery Charges &nbsp;&nbsp;&nbsp;: Rs." + DeliveryCharges + " </b></td></tr>" + Wallamt + ""+ counpon + ""+ prepaidbox + "<tr><td align='right' style='padding-right:10'><b>Remaining Amount Collect in Delivery Time  &nbsp;&nbsp;&nbsp;: Rs." + obj.remainingamount + " </b></td></tr><tr><td><hr/></td></tr></table><br/>";
            strEmail_Admin += "Subject to T&C on <a href='https://www.Aerosportsind.com'>www.Aerosportsind.com</a><br/><br/>";
            strEmail_Admin += "<b>Delivery Address: </b><br/>";
            strEmail_Admin += obj.ShippingName + "<br/>";
            strEmail_Admin += obj.ShippingMobileNo + "<br/>";
            strEmail_Admin += obj.ShippingEmailId + "<br/>";
            strEmail_Admin += obj.ShippingAddress + "<br/>";
            strEmail_Admin += obj.ShippingCity + "<br/>";
            strEmail_Admin += "</div></body></head></html>";
            string strEmail_User = "<html>" + DateTime.Now + "<br/><br/><br />Hello, &nbsp;&nbsp;<b>" + obj.ShippingName + "</b><br/><br/>";
            strEmail_User += "<html><head><body><div style='border-style: double; border-width: 10px; border-color:#cccccc; padding:20px; Font-size:11px; color:black;width:590px'><img src='https://aerosportsind.com/img/logo.png'  alt='logo'  style='height:88px;width:200px'   border='0'/><br /><br />";
            strEmail_User += "Order No.: <b>" + obj.OrderId + "</b>;&nbsp;&nbsp;Order Date : <b>" + DateTime.Now + "</b>&nbsp;&nbsp;Order Through : " + obj.OrderThrough + " &nbsp;&nbsp;&nbsp;&nbsp; Payment Mode : " + obj.Paymode + "<br><br/>";
            strEmail_User += "<strong></strong><br/><br/><body><table width='590' height='auto' border='1' cellpadding='0' cellspacing='0'><tr bgcolor='#cbc7c7'  align='center'><td height='30'>Image</td><td color='#ffffff'>Particulars</td><td>Unit</td><td>Rate</td><td>Qty.</td><td>Amount</td><td>Discount</td><td>NetAmount</td></tr>" + strEmailCart + "</table></body>";
            strEmail_User += "<table width='590' Font-size:'11'><tr><td align='right' style='padding-right:10'>Amount &nbsp;&nbsp;&nbsp;<b>Rs." + Amount + "</b></td></tr><td><hr/></td></tr><tr><td align='right' style='padding-right:10'><b>Delivery Charges &nbsp;&nbsp;&nbsp;: Rs." + DeliveryCharges + " </b></td></tr>" + Wallamt + "" + counpon + ""+ prepaidbox + "<tr><td align='right' style='padding-right:10'><b>Remaining Amount Collect in Delivery Time &nbsp;&nbsp;&nbsp;: Rs." + obj.remainingamount + " </b></td></tr><tr><td><hr/></td></tr></table><br/>";
            strEmail_User += "Subject to T&C on <a href='https://www.Aerosportsind.com'>www.Aerosportsind.com</a><br/><br/>";
            strEmail_User += "<b>Delivery Address: </b><br/>";
            strEmail_User += obj.ShippingName + "<br/>";
            strEmail_User += obj.ShippingMobileNo + "<br/>";
            strEmail_User += obj.ShippingEmailId + "<br/>";
            strEmail_User += obj.ShippingAddress + "<br/>";
            strEmail_User += obj.ShippingCity + "<br/>";
            strEmail_User += "For any query or assistance, feel free to contact<br/>Thanks & Regards <br/><b>Aerosportsind.com</b><br/>Mobile No.  7300113153 ,&nbsp;<br/>Aerosportsind.com";
            strEmail_User += "</div></body></head></html>";
            //************ Send Email **************************************************************/             




          Send_Mail(obj.ShippingEmailId, "New Order: Aerosportsind.com", strEmail_User);//send email to user             
            
          Send_Mail("info@Aerosportsind.com", "New Order: Aerosportsind.com", strEmail_Admin);//send email to Admin

           Send_Mail("aerosportsind@gmail.com", "New Order: Aerosportsind.com", strEmail_Admin);//send email to Admin

            SqlCommand Sql5 = new SqlCommand("delete  from  trncart  where userId='" + obj.Usercode + "'", sqlCon);
            string Del = Sql5.ExecuteNonQuery().ToString();
            sqlCon.Close();

            refersystem(obj.Usercode, obj.ShippingName, obj.OrderId, PaidAmount);

            }
        }
        catch (Exception ex)
        {

           
        }
        //   finally { db.Dispose(); }

    }

    public void refersystem(int userid,string name,int oid,int orderamount)
    {
        Cnn.Open();
        string olduserid = Cnn.ExecuteScalar("select referbyid from register where UserId=" + userid + "").ToString();
        if (olduserid == "0")
        {           
        }
        else
        {

            int nID = Convert.ToInt32(Cnn.ExecuteScalar("Select  IsNull(Max(id)+1,1) From [ordercount]"));
            Cnn.ExecuteNonQuery("insert into ordercount (id,orderid,olduserid,newuserid,username,orderamount,active,rts) values ('" + nID + "'," + oid + ",'" + olduserid + "','" + userid + "','" + name + "','" + orderamount + "',1,getdate())");
            
        }
        Cnn.Close();


    }



    public void Send_Mail(string tomail,string subject, string mmessage)
    {
      
          
            try
            {

                MailMessage newmail = new MailMessage();
                MailAddress toadd = new MailAddress(tomail);
                MailAddress fromadd = new MailAddress("aerosportsind@gmail.com");
                newmail.Subject = subject;

                string msg = mmessage;
              

              
                newmail.Body = msg;
                newmail.To.Add(toadd);
                newmail.From = fromadd;
                newmail.IsBodyHtml = true;
                SmtpClient sserver = new SmtpClient();
                sserver.Host = "smtp.gmail.com";
                sserver.Credentials = new NetworkCredential("aerosportsind@gmail.com", "mljjiuguamxiigzt");
            //Future@2575#          info@aerosportsind.com
            //https://business.phonepe.com/login  AEROSPORTSIND@GMAIL.COM

            sserver.DeliveryMethod = SmtpDeliveryMethod.Network;
                sserver.Port = 587;
                sserver.EnableSsl = true;
                sserver.Send(newmail);
               
            }
            catch (Exception ex)
            {
              
            }
        }


    public string GetCourier(int id, string Exid)
    {
        Cnn.Open();
        int Couriergm = 0, Courierkg = 0;
        SqlDataAdapter sqlDa = new SqlDataAdapter("select a.id,a.productid,a.color,a.Size,b.productname,a.Quantity,b.image from trncart as a inner join  product as b on a.productid=b.productid Where a.UserId=" + id + "", sqlCon);
        DataTable Dt = new DataTable();
        sqlDa.Fill(Dt);
        String CourierState = Convert.ToString(Cnn.ExecuteScalar("Select State_Name from Loc_State where State_Name='" + Exid + "'"));
        String CourierW;
        for (int i = 0; i < Dt.Rows.Count; i++)
        {
            int ProductId = Convert.ToInt32(Dt.Rows[i]["ProductId"]);
            CourierW = Convert.ToString(Cnn.ExecuteScalar("Select Unit from Product where ProductId='" + ProductId + "'"));
            if (CourierW == "gm")
            {
                String Courier = Convert.ToString(Cnn.ExecuteScalar("Select ((cast(Weight as varchar(50)))) as CourierWeight from Product where ProductId='" + ProductId + "'"));
                Couriergm += (Convert.ToInt32(Courier) * Convert.ToInt32(Dt.Rows[i]["Quantity"]));
            }
            else
            {
                String Courier = Convert.ToString(Cnn.ExecuteScalar("Select ((cast(Weight as varchar(50)))) as CourierWeight from Product where ProductId='" + ProductId + "'"));
                Courierkg += (Convert.ToInt32(Courier) * Convert.ToInt32(Dt.Rows[i]["Quantity"]));
            }
        }
        string TotalWeight = (Convert.ToString(Courierkg + Couriergm)).ToString();
        double CW = (Convert.ToDouble(TotalWeight) / Convert.ToDouble(1000));
        string RajCourier_Fees;
        if (CourierState == "Rajasthan")
        {
            RajCourier_Fees = Convert.ToString(Cnn.ExecuteScalar("select RajCourier_Fees,id from Courier_Detailn where RajCourier_Name='" + CourierState + "' and '" + CW + "' between FromWeight and ToWeight"));
        }
        else if (CourierState == "North India")
        {
            RajCourier_Fees = Convert.ToString(Cnn.ExecuteScalar("select NICourier_fees,id from Courier_Detailn where NICourier_Name='" + CourierState + "' and '" + CW + "' between FromWeight and ToWeight"));
        }
        else if (CourierState == "Rest of India")
        {
            RajCourier_Fees = Convert.ToString(Cnn.ExecuteScalar("select ROICourier_fees,id from Courier_Detailn where ROICourier_Name='" + CourierState + "' and '" + CW + "' between FromWeight and ToWeight"));
        }
        else
        {
            RajCourier_Fees = Convert.ToString(Cnn.ExecuteScalar("select NECourier_fees,id from Courier_Detailn where NECourier_Name='" + CourierState + "' and '" + CW + "' between FromWeight and ToWeight"));
        }

        Cnn.Close();
        return RajCourier_Fees.ToString();
    }

}