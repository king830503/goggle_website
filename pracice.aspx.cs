using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pracice : System.Web.UI.Page
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (Session["IsAddBtn"] != null && (bool)Session["IsAddBtn"])
        {
            bt = new Button();
            bt.Click += new System.EventHandler(this.Button_Click);
            abb.Controls.Add(bt);
        }

    }

    private void Button1_Click(object sender, System.EventArgs e)
    {
        bt = new Button();
        bt.Click += new System.EventHandler(this.Button_Click);
        abb.Controls.Add(bt);
        Session["IsAddBtn"] = true;
        Response.Write("adf");

       

    private void Button_Click(object sender, System.EventArgs e)
    {
        Response.Write("ClickBtn");
    }
}