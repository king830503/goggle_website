using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dr_theme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["doctor_m"] = "check";
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
        string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString; SqlConnection conn = new SqlConnection(connstring);
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from [doctor] where name='" + usert.Text + "'", conn);
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
            sqlstr = sqlstr + "([name]like '%'+'" + usert.Text.Trim() + "'+'%')";
            SqlDataSource1.SelectCommand = "SELECT * FROM [doctor] where" + sqlstr;

            Label1.Text = "";
        }

    }
    protected void delete_click(object sender, EventArgs e)
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502");
        Conn.Open();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox checkbox = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Checkbox1");
            if (checkbox.Checked)
            {
                string deleteSQL = "DELETE FROM [doctor] WHERE [name]='" + GridView1.DataKeys[i].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(deleteSQL, Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();
                reader.Close();
            }
        }
        GridView1.DataBind();
        Conn.Close();

    }
    protected void cal_click(object sender, EventArgs e)
    {
        usert.Text = "";
        GridView1.DataBind();

    }
    protected void update_Click(object sender, EventArgs e)
    {

        errormsg.Text = "";

        if (name.Text.Trim().Length == 0)
        {
            errormsg.Text = "主題不可為空";
            name.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            string bgColor = bgcolor.Value;
            System.Drawing.Color bg = System.Drawing.ColorTranslator.FromHtml(bgColor);
            string fontColor = fontcolor.Value;
            System.Drawing.Color font = System.Drawing.ColorTranslator.FromHtml(fontColor);
            SqlConnection conn = new SqlConnection(@"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502");
            conn.Open();
            for (int g = 0; g < GridView1.Rows.Count; g++)
            {
                CheckBox checkbox2 = (CheckBox)GridView1.Rows[g].Cells[0].FindControl("CheckBox1");

                if (checkbox2.Checked)
                {
                    string updateSQL = "UPDATE [doctor] set bgcolor=@bg_r,bg_g=@bg_g,bg_b=@bg_b,font_r=@font_r,font_b=@font_b,font_g=@font_g,name=@name WHERE [color_id]='" + GridView1.DataKeys[g].Value + "'";
                    SqlCommand cmd2 = new SqlCommand(updateSQL, conn);
                    cmd2.Parameters.AddWithValue("@name", name.Text.Trim());
                    cmd2.Parameters.AddWithValue("@bgcolor", bg.R);
                    cmd2.Parameters.AddWithValue("@bg_b", bg.B);
                    cmd2.Parameters.AddWithValue("@bg_g", bg.G);
                    cmd2.Parameters.AddWithValue("@font_r", font.R);
                    cmd2.Parameters.AddWithValue("@font_g", font.G);
                    cmd2.Parameters.AddWithValue("@font_b", font.B);
                    cmd2.ExecuteNonQuery();
                    cmd2.Dispose();
                }
            }

            GridView1.DataBind();
            conn.Close();
            Response.Write("<script>alert('修改成功');location.href='index.aspx';</script>");
        }
    }
}