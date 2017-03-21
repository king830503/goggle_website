using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class new_mange_theme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            Response.Write("<script>alert('登入時效已過，請重新登入!');location.href='index.aspx';</script>");
        }
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

        string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstring);
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from votecolor where v_name='" + theme.Text.Trim() + "'", conn);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();


        if (!dr.Read())
        {
            dr.Close();
            conn.Close();
            cmd.Cancel();
            Label1.Text = "查無主題";
        }
        else if (theme.Text.Trim() != "")
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM [votecolor] where v_name='" + theme.Text.Trim() + "'";
            GridView1.DataBind();
            dr.Close();
            conn.Close();
            cmd.Cancel();
        }
        else
        {
            dr.Close();
            conn.Close();
            cmd.Cancel();
            Label1.Text = "沒有查詢的值";
            Label1.Font.Size = 12;
            Label1.Width = 100;
        }

    }
  
    protected void cal_click(object sender, EventArgs e)
    {
        theme.Text = "";
        GridView1.DataBind();
        vname.Text = "";
        bg.Value = "#000";
        fr.Value = "#000";
        linkcolor.Value = "#000";
       
    }

    
    protected void update_Click(object sender, EventArgs e)
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502");
        Conn.Open();
        if (vname.Text.Trim().Length == 0)
        {
            alert.ForeColor = System.Drawing.Color.Red;
            alert.Text = "你未輸入主題的名稱";
        }
        else {
                    string bgColor = bg.Value;
                    System.Drawing.Color b = System.Drawing.ColorTranslator.FromHtml(bgColor);
                    string frColor = fr.Value;
                    System.Drawing.Color f = System.Drawing.ColorTranslator.FromHtml(frColor);
                    string aColor = linkcolor.Value;
                    System.Drawing.Color a = System.Drawing.ColorTranslator.FromHtml(aColor);
                    for (int k = 0; k < GridView1.Rows.Count; k++)
                    {
                        CheckBox checkbox = (CheckBox)GridView1.Rows[k].Cells[0].FindControl("CheckBox1");
                        if (checkbox.Checked)
                        {
                            string updateSQL = "UPDATE [votecolor] set v_name=@vname,bg_r=@bgr,bg_g=@bgg,bg_b=@bgb,fc_r=@fr,fc_b=@fb,fc_g=@fg,ac_r=@ar,ac_b=@ab,ac_g=@ag WHERE [v_id]='" + GridView1.DataKeys[k].Value.ToString() + "'";
                            SqlCommand cmd = new SqlCommand(updateSQL, Conn);
                            cmd.Parameters.AddWithValue("@vname", vname.Text.Trim());
                            cmd.Parameters.AddWithValue("@bgr", b.R);
                            cmd.Parameters.AddWithValue("@bgb", b.B);
                            cmd.Parameters.AddWithValue("@bgg", b.G);
                            cmd.Parameters.AddWithValue("@fr", f.R);
                            cmd.Parameters.AddWithValue("@fb", f.B);
                            cmd.Parameters.AddWithValue("@fg", f.G);
                            cmd.Parameters.AddWithValue("@ar", a.R);
                            cmd.Parameters.AddWithValue("@ab", a.B);
                            cmd.Parameters.AddWithValue("@ag", a.G);
                            SqlDataReader reader = cmd.ExecuteReader();
                            cmd.Dispose();
                            reader.Close();
                        }
                    }
                    GridView1.DataBind();
                    Conn.Close();
                }
        vname.Text = "";
        bg.Value = "#000";
        fr.Value = "#000";
        linkcolor.Value = "#000";
  }
    
       
}