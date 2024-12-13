﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BlogDetail : System.Web.UI.Page
{
    ClsConnection Cnn = new ClsConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            LoadData();

        }
    }

    private void LoadData()
    {
        Cnn.Open();
        DataTable dtable = Cnn.FillTable("SELECT a.*, SUBSTRING(description, 1, 300) AS short_description, convert(varchar, entrydate, 106) as ndate FROM blog_detail AS a where ID='"+Request.QueryString["ID"]+"' ORDER BY id DESC; ", "Order");
        lstblog.DataSource = dtable;
        lstblog.DataBind();

        //pnlOrderInfo.Visible = false;
        Cnn.Close();

        //  Page.Title = dtable.Rows[0]["title"].ToString() + " - Formula Chai";

    }
}