using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for sellproduct
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.ScriptService]
public class sellproduct : System.Web.Services.WebService {

    public sellproduct()
    {        
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    
    //--------------------ProductSearch-----------------------------------
    [WebMethod]
    public string[] Partname(string prefixText, int count)
    {
        //if (Session["paid"] == "and Paid='Debit'")
        //{
            ClsConnection Cnn = new ClsConnection();
            count = 6;
            string[] str;
            string SearchWord = "";
            char[] C = { ' ' };
            str = prefixText.Split(C, StringSplitOptions.RemoveEmptyEntries);
            int i;
            for (i = 0; i < str.Length; i++)
            {
                SearchWord = SearchWord + str[i];
                if (i == str.Length - 1) break;
                SearchWord = SearchWord + " near ";
            }
            SearchWord = SearchWord.Replace(".", " ");
            SearchWord = SearchWord.Replace(",", " ");
            SearchWord = SearchWord.Replace(")", " ");
            SearchWord = SearchWord.Replace("(", " ");
            //string sql = "Select top 10 'keywords'= CategoryName,CategoryId from M_CategoryMaster where   ActiveStatus=1 and CategoryName like '" + SearchWord + "%'";
            string sql = "Select top 5 substring(Firmname,0,10) as KeyWords,UserId from Registration where   ActiveStatus=1 and  Firmname like '" + SearchWord + "%'";
            //Select * From V#ProductDetail Where ProductName like '%asus%' OR CategoryName like '%asu%' OR BrandName like '%asus%'


            DataTable dt = Cnn.FillTable(sql, "dt");
            string[] items = new string[dt.Rows.Count];
            i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["keywords"].ToString(), i);
                i++;
            }
            return items;
        //}
      
    }

    //
    [WebMethod]
    public string[] Partname1(string prefixText, int count)
    {
        //if (Session["paid"] == "and Paid='Debit'")
        //{
        ClsConnection Cnn = new ClsConnection();
        count = 6;
        string[] str;
        string SearchWord = "";
        char[] C = { ' ' };
        str = prefixText.Split(C, StringSplitOptions.RemoveEmptyEntries);
        int i;
        for (i = 0; i < str.Length; i++)
        {
            SearchWord = SearchWord + str[i];
            if (i == str.Length - 1) break;
            SearchWord = SearchWord + " near ";
        }
        SearchWord = SearchWord.Replace(".", " ");
        SearchWord = SearchWord.Replace(",", " ");
        SearchWord = SearchWord.Replace(")", " ");
        SearchWord = SearchWord.Replace("(", " ");
        //string sql = "Select top 10 'keywords'= CategoryName,CategoryId from M_CategoryMaster where   ActiveStatus=1 and CategoryName like '" + SearchWord + "%'";
        string sql = "Select top 5 substring(Firmname,0,20) as KeyWords,UserId from Registration where   ActiveStatus=1 and  Firmname like '" + SearchWord + "%'";
        //Select * From V#ProductDetail Where ProductName like '%asus%' OR CategoryName like '%asu%' OR BrandName like '%asus%'


        DataTable dt = Cnn.FillTable(sql, "dt");
        string[] items = new string[dt.Rows.Count];
        i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["keywords"].ToString(), i);
            i++;
        }
        return items;
        //}

    }


    //
      [WebMethod]
    public string[] Transportname(string prefixText, int count)
    {
        //if (Session["paid"] == "and Paid='Debit'")
        //{
        ClsConnection Cnn = new ClsConnection();
        count = 6;
        string[] str;
        string SearchWord = "";
        char[] C = { ' ' };
        str = prefixText.Split(C, StringSplitOptions.RemoveEmptyEntries);
        int i;
        for (i = 0; i < str.Length; i++)
        {
            SearchWord = SearchWord + str[i];
            if (i == str.Length - 1) break;
            SearchWord = SearchWord + " near ";
        }
        SearchWord = SearchWord.Replace(".", " ");
        SearchWord = SearchWord.Replace(",", " ");
        SearchWord = SearchWord.Replace(")", " ");
        SearchWord = SearchWord.Replace("(", " ");
        //string sql = "Select top 10 'keywords'= CategoryName,CategoryId from M_CategoryMaster where   ActiveStatus=1 and CategoryName like '" + SearchWord + "%'";
        string sql = "Select top 5 substring(TransPortName,0,20) as KeyWords,id from OrderDispatch where   ActiveStatus=1 and  TransPortName like '" + SearchWord + "%'";
        //Select * From V#ProductDetail Where ProductName like '%asus%' OR CategoryName like '%asu%' OR BrandName like '%asus%'


        DataTable dt = Cnn.FillTable(sql, "dt");
        string[] items = new string[dt.Rows.Count];
        i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["keywords"].ToString(), i);
            i++;
        }
        return items;
        //}

    }

    
    //--------------------BrandSearch-----------------------------------
    
     [WebMethod]
    public string[] OrderSearch(string prefixText, int count)
    {
        //if (Session["paid"] == "and Paid='Debit'")
        //{
            ClsConnection Cnn = new ClsConnection();
            count = 6;
            string[] str;
            string SearchWord = "";
            char[] C = { ' ' };
            str = prefixText.Split(C, StringSplitOptions.RemoveEmptyEntries);
            int i;
            for (i = 0; i < str.Length; i++)
            {
                SearchWord = SearchWord + str[i];
                if (i == str.Length - 1) break;
                SearchWord = SearchWord + " near ";
            }
            SearchWord = SearchWord.Replace(".", " ");
            SearchWord = SearchWord.Replace(",", " ");
            SearchWord = SearchWord.Replace(")", " ");
            SearchWord = SearchWord.Replace("(", " ");
            string sql = "Select top 5 substring(InvoiceNo,0,10) as KeyWords,OrderID from TrnOrderMain where  InvoiceNo like '" + SearchWord + "%'";

            //Select * From V#ProductDetail Where ProductName like '%asus%' OR CategoryName like '%asu%' OR BrandN"me like '%asus%'


            DataTable dt = Cnn.FillTable(sql, "dt");
            string[] items = new string[dt.Rows.Count];
            i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["KeyWords"].ToString(), i);
                i++;
            }
            return items;
        //}
      
    }

     [WebMethod]
     public string[] UNameSearch(string prefixText, int count)
     {
         //if (Session["paid"] == "and Paid='Debit'")
         //{
         ClsConnection Cnn = new ClsConnection();
         count = 6;
         string[] str;
         string SearchWord = "";
         char[] C = { ' ' };
         str = prefixText.Split(C, StringSplitOptions.RemoveEmptyEntries);
         int i;
         for (i = 0; i < str.Length; i++)
         {
             SearchWord = SearchWord + str[i];
             if (i == str.Length - 1) break;
             SearchWord = SearchWord + " near ";
         }
         SearchWord = SearchWord.Replace(".", " ");
         SearchWord = SearchWord.Replace(",", " ");
         SearchWord = SearchWord.Replace(")", " ");
         SearchWord = SearchWord.Replace("(", " ");
         //string sql = "Select top 10 'keywords'= CategoryName,CategoryId from M_CategoryMaster where   ActiveStatus=1 and CategoryName like '" + SearchWord + "%'";
         string sql = "Select top 5 ProductName from M_ProductMaster where  ProductName like '%" + SearchWord + "%'";
         //Select * From V#ProductDetail Where ProductName like '%asus%' OR CategoryName like '%asu%' OR BrandN"me like '%asus%'


         DataTable dt = Cnn.FillTable(sql, "dt");
         string[] items = new string[dt.Rows.Count];
         i = 0;
         foreach (DataRow dr in dt.Rows)
         {
             items.SetValue(dr["ProductName"].ToString(), i);
             i++;
         }
         return items;
         //}

     }
   }