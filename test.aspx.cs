using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    int i = 0;
     Button[] btnDemo = new Button[6];
    protected void Page_Load(object sender, EventArgs e)
    {
            SqlDataSource db = new SqlDataSource();
            db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
            db.SelectCommand = "select * from colorblind";
            DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);
            btnDemo = new Button[dv.Table.Rows.Count];
            Label[] label = new Label[dv.Table.Rows.Count];
            Label[] btn = new Label[dv.Table.Rows.Count];
            for (i = 0; i <dv.Table.Rows.Count; i++)
            {   
                label[i]=new Label();
                label[i].ID="label"+i;
                label[i].Text+="<div class='theme' runat='server' id='item"+(i+1)+ "' style='background-color:rgb(" + dv.Table.Rows[i][1] + "," + dv.Table.Rows[i][2] + "," + dv.Table.Rows[i][3] + ");color:rgb(" + dv.Table.Rows[i][4] + "," + dv.Table.Rows[i][5] + "," + dv.Table.Rows[i][6] + ");'>" + dv.Table.Rows[i][0].ToString() + "</div>";
                    /*"<div class='theme' style='background-color:rgb(" + dv.Table.Rows[i][1] + "," + dv.Table.Rows[i][2] + "," + dv.Table.Rows[i][3] + ");color:rgb(" + dv.Table.Rows[i][4] + "," + dv.Table.Rows[i][5] + "," + dv.Table.Rows[i][6] + ");'>" + dv.Table.Rows[i][0].ToString() + "</div>");*/
                btnDemo[i] = new Button();
                btnDemo[i].ID = "btnDemo" + i;
                btnDemo[i].Text ="加入主題";
                btnDemo[i].Height = 20;
                btnDemo[i].Width = 100;
                string count = i.ToString();

                btnDemo[i].Click += new EventHandler(btnDemo_Click);
                btn[i] = new Label();
                btn[i].ID = "addbtn" + i;
                btn[i].Controls.Add(btnDemo[i]);
                votebutton.Controls.Add(label[i]);
                votebutton.Controls.Add(btn[i]);
            }
    }



    protected void btnDemo_Click(object sender, EventArgs e)
    {
        Button temp = (Button)sender;
        Response.Write("45d4f");
        
    }
    protected void btnDemo1_Click(object sender, EventArgs e) {
        Button temp = (Button)sender;
        SqlDataSource db = new SqlDataSource();
            db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
            db.SelectCommand = "select * from colorblind";
            DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);
         String sql = "";
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();
        sql = "select * from Theme where m_name=@name and t_name=@t_name";
        SqlCommand repeat = new SqlCommand(sql, conn);
        repeat.Parameters.AddWithValue("@name", Session["name"].ToString());
        repeat.Parameters.AddWithValue("@t_name","紅綠色盲");
        SqlDataReader dr;
        dr = repeat.ExecuteReader();
    }
    }
}