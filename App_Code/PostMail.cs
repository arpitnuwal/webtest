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

/// <summary>
/// Summary description for PostMail
/// </summary>
public class PostMail
{
     string UserName = "";
    string AddId = "";
    string AddTitle = "";
    string Amount = "";
    string Day = "";
   public  string Mail = "";
	public   PostMail(string UserName,string AddId,string AddTitle,string Amount,string Day)
	{
        Mail = "<html>" +
    "<head>" +
    "<Style type='text/css' >" +
    "body{" +
    "font-family:verdana; font-size:12px;  background-color:#1fa0b6;" +
    "}" +
    ".main_nav_right_nav" +
    "{" +
    "width:100%;height:25px;float:left;margin:0;padding:0;font-size:11px;color:#515151;" +
    "}" +
    ".main_nav_right_nav ul" +
    "{" +
    "height:20px;float:left;padding-top:5px;" +
    "}" +
    ".main_nav_right_nav ul li" +
    "{" +
    "display:inline;" +
    "padding:0;" +
    "margin:0;" +
    "}" +
    ".main_nav_right_nav ul li a" +
    "{" +
    "font-family:Verdana;" +
    "font-size:11px;" +
    "color:#515151;" +
    "padding:0 3px;" +
    "text-decoration:none;" +
    "}" +
    ".main_nav_right_nav ul li a:hover" +
    "{" +
    "font-family:Verdana;" +
    "font-size:11px;" +
    "padding:1px 3px 3px 3px;" +
    "color:#ffffff;" +
    "background-color:#819a1d;" +
    "}" +
     ".emailpost" +
    "{" +
    "width:600px;" +
    "height:auto;" +
    "margin:0 auto;" +
    "padding:0;" +
    "border:solid 1px #767676;" +
    "background-color:#d0d0d0;" +
    "overflow:hidden;" +
    "}" +
    ".logo" +
    "{" +

    "}" +
    ".tr0" +
    "{" +
      "background-color:yellow;" +
        
    "}" +
    ".tr0" +
    "{" +
      "background-color:white;" +
    "}" +
    ".dear" +
    "{" +
    "width:600px;float:left;font-size:11px;" +
            "}" +
   ".color" +
    "{" +
    "color: white;" +
            "}" +
    ".addetail" +
    "{" +
    "width:570px;float:left;font-size:11px;padding:5px 10px;" +
    "}" +
    ".addetail a" +
    "{" +
    "color:#be0404;" +
    "text-decoration:underline;" +
    "}" +
    ".addetail a:hover" +
    "{" +
    "color:#000000;" +
    "text-decoration:none;" +
    "}" +
    ".addetail_A" +
    "{" +
    "width:570px;float:left;font-size:11px;height:150px;background-color:#ffffe8;" +
    "}" +
    ".addetail span" +
    "{" +
    "font-size:13px;" +
    "color:#c70303;" +
    "font-weight:bold;" +
    "}" +
    ".addetail kbd" +
    "{" +
    "font-size:13px;" +
    "color:#014686;" +
    "font-weight:bold;" +
    "font-family:Verdana;" +
    "}" +
    ".addetail_D" +
    "{" +
    "width:570px;" +
    "float:left;" +
    "font-size:12px;" +
    "background-color:#cc3232;" +
    "text-align:left;" +
    "}" +
    ".addetail_D b" +
    "{" +
    "font-size:12px;" +
    "color:#000000;" +
    "}" +
    ".addetail_D kbd" +
    "{" +
    "font-size:12px;" +
    "color:#ffffff;" +
    "font-weight:bold;" +
    "font-family:Verdana;" +
    "}" +
    ".addetail_P" +
    "{" +
    "width:570px;float:left;height:90px;font-size:12px;background-color:#ffffff;" +
    "}" +
    ".tr1" +
    "{" +
    "font-size:12px;" +
    "color:#;" +
    "}" +
    "</Style>" +
    "</head>" +
    "<body>" + "<Table style='width:100%'><tr><td style='background-color:#1fa0b6;'>" +
              "  <div style='width:570px; '>" +"<table><tr>"+"<td>"+
                    "<a href='#' target='_blank'>" +
                          "<img src='http://loveheda.Chittorgarhonline.in/images/textilemarket_logo_223x229.png' border='0' />" +
                     "</a>"
              +"</td>"+"<td>"+
                         "<span style='color:white;font-weight:bold;font-size:18px;'><center>Welcome to Textilemarket.in </center><span></font></b><span>" +

               "</td>"+"</tr></table>"+
                
            "</div>" +
            "<div>"+  "<b>Dear : " + UserName  + "</b>" +
                "<br />" +
              
           "<div style='width:570px;float:left;font-size:11px;padding:5px 10px;'>" +
             "<div style='width:570px;float:left;font-size:11px;height:150px;background-color:#ffffe8;'>" +
                 "<span>&nbsp;Your Ad Information</span><br />" +
                 "<br />" +
                 "<b>&nbsp;Your Ad Id:</b>"  + AddId   + "<br />" +
                 "<br />" +
                 "<b>&nbsp;Ad Title:</b>" + AddTitle    +
                 "<br />" +
                 "<br />" +
                "&nbsp;<b>Ad Duration:</b>"  + Day  +" <b>Days</b>" +
                "<br />" +
                "<br />" +
                "&nbsp;<b>Amount:</b>"  + Amount   +
            "</div>" +


       "</div>"+
        "<div style='width:570px;float:left;font-size:11px;padding:5px 10px;'>" +
            "<div style='width:570px;float:left;height:90px;font-size:12px;background-color:#ffffff;'>" +
                " <table width='100%' style='background-color:#dfedf0;color:#1d1d1d; font-size:13px;'>" +
                    "<tr>" +
                        "<td>" +

                       "You can deposit Ad Charges  at our any Branch office within" +
               "<asp:Label ID='LblDay' runat='server' Text='2'></asp:Label>" +
                            "days, otherwise your post will be deleted from server.<br />" +
                           "Thank you for posting.<br><kbd>&nbsp;Only Cash</kbd>" +
                        "</td>" +
                    "</tr>" +
               "</table>" +
               //###############  Remove bol counter code from here  ######################################
               "</div>"+
       "</div>"+

       "<table width='100%'>" +
       "<tr><td style='font-size:14px'>" + "Warm Regards<br />" +
                 "<b>Textile Trade Portal</b>" +
      "</td></tr>" +
       
       
      "<tr><td>" +
           "<table align='center'><tr align='center'><center>" + "<td>" + "<a style='color:white' style='color:white' href='http://www.textilemarket.in/TextileHome.aspx'>Home</a>" + "</td>" +
           "<td>"+"|"+"</td>"+
           "<td>" + "<a style='color:white' href='http://www.textilemarket.in/TexTileViewBuyGrayFab.aspx'>Textile Buy</a>" + "</td>" +
           "<td>" + "|" + "</td>" +
           "<td style='color:white'>" + "<a style='color:white' href='http://www.textilemarket.in/TexTileViewsellGrayFab.aspx'>Textile Sell</a>" + "</td>" +
           "<td>" + "|" + "</td>" +
           "<td style='color:white'>" + "<a style='color:white' href='http://www.textilemarket.in/TextileViewNews.aspx'>Textile News</a>" + "</td>" +
           "<td>" + "|" + "</td>" +
           "<td>" + "<a style='color:white' href='http://www.textilemarket.in/TextileViewEvent.aspx'>Textile Event</a>" + "</td>" +
           "<td>" + "|" + "</td>" +
           "<td>" + "<a style='color:white' href='http://www.textilemarket.in/TextileViewRates.aspx'>Textile Rate</a>" + "</td>" +
           "<td>" + "|" + "</td>" +
           "<td>" + "<a style='color:white' href='http://www.textilemarket.in/TextileForumView.aspx'>Textile Forum</a>" + "</td>" +
             "<td>" + "|" + "</td>" +
           "<td>" + "<a style='color:white' href='http://www.textilemarket.in/Machinery.aspx'>Textile Machinery</a>" + "</td>" +
            "<td>" + "|" + "</td>" +
           "<td>" + "<a style='color:white' href='http://www.textilemarket.in/JobHome.aspx'>Textile Jobs</a>" + "</td>" +
           "</center></tr></table>"  
      +"</td></tr>"+
       "<tr><td align='center'>" +
             "You can Email us at <a href='mailto:support@textilemarket.in'>support@textilemarket.in</a>" +
      "</td></tr>" +
       "<tr><td align='center'>" +
             "©2011-2012 Copyright <a href='http://www.textilemarket.in' target='_blank'>Textilemarket.in</a>.All Rights Reserved." +
      "</td></tr>" +
        "</table>"+"</div>" +
          
      
            "</td></tr></table>"+
        "</div></body></html>";

	}

	}


