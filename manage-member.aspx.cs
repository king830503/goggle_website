using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class new_manage_member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        
        Session["manager"] = "check";
        if (Session["name"] == null)
        {
            Response.Write("<script>alert('登入時效已過，請重新登入!');location.href='index.aspx';</script>");
        }
      
        
        SqlDataSource db = new SqlDataSource();
        db.ConnectionString = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
        db.SelectCommand = "select * from [member]";
     
        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);
    
  

    }
    protected void lookup_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(GridView1.PageIndex) != 0)
        {
            //資料庫轉換
            GridView1.PageIndex = 0;
        }
        DBInit();
    }
    protected void DBInit()
    {

        //SqlDataSource d2 = new SqlDataSource();
        //d2.ConnectionString = WebConfigurationManager.ConnectionStrings["gogglestring"].ConnectionString;
        //d2.SelectCommand = "select * from [member2]";
        string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString; SqlConnection conn = new SqlConnection(connstring); 
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from member where m_name='"+usert.Text+"'", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
      
        string sqlstr = "";
        if (usert.Text.Trim().Length == 0)
        {
            Label1.Text = "沒有查詢的值";
            Label1.Font.Size = 12;
            Label1.Width = 100;
        }

        else if (!dr.Read())
        {
            dr.Close();
            conn.Close();
            cmd.Cancel();
            Label1.Text = "查無此人";
        }

        else if (usert.Text.Trim().Length > 0)
        {
            dr.Close();
            conn.Close();
            sqlstr = sqlstr + "([m_name]like '%'+'" + usert.Text.Trim() + "'+'%')";
            SqlDataSource1.SelectCommand = "SELECT * FROM [member] where" + sqlstr;
            Label1.Text = "";
        }
     
    }
    protected void delete_click(object sender, EventArgs e)
    {
        //SqlDataSource d3 = new SqlDataSource();
        //d3.ConnectionString = WebConfigurationManager.ConnectionStrings["gogglestring"].ConnectionString;
        //d3.SelectCommand = "select * from [member]";
        //DataTable dt = (DataTable)d3.Select(DataSourceSelectArguments.Empty);

        SqlConnection Conn = new SqlConnection(@"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502");
        Conn.Open();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            //string a = GridView1.Rows[i].Cells[2].Text; 

            CheckBox checkbox = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
            if (checkbox.Checked)
            {
                string deleteSQL = "DELETE FROM [member] WHERE [m_id]='" + GridView1.DataKeys[i].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(deleteSQL, Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();
                reader.Close();   
            }
        }
        GridView1.DataBind();
        Conn.Close();
        
    }
    protected void cal_click(object sender, EventArgs e) {
        usert.Text = "";
        GridView1.DataBind();
    }
   
}