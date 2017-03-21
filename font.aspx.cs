using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class font : System.Web.UI.Page
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
        Label1.Text = "";
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
        string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstring);
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from fontsize where hiage=@age", conn);
        cmd.Parameters.AddWithValue("@age", age.Text.Trim());

        SqlDataReader dr;
        dr = cmd.ExecuteReader();

        string sqlstr = "";
        if (age.Text.Trim().Length == 0)
        {

            Label1.ForeColor = System.Drawing.Color.Red;
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
            Label1.ForeColor = System.Drawing.Color.Red;

        }

        else if (age.Text.Trim().Length > 0)
        {
            dr.Close();
            conn.Close(); ;
            sqlstr = sqlstr + "([hiage]like '%'+'" + age.Text.Trim() + "'+'%')";

            SqlDataSource1.SelectCommand = "SELECT * FROM [fontsize] where" + sqlstr;

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

                string deleteSQL = "DELETE FROM [fontsize] WHERE [fid]='" + GridView1.DataKeys[i].Value.ToString() + "'";
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
        age.Text = "";
        GridView1.DataBind();


    }
    protected void add_Click(object sender, EventArgs e)
    {

        SqlDataSource db = new SqlDataSource();
        db.ConnectionString = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
        db.SelectCommand = "select * from [fontsize]";

        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);

        for (int i = 0; i < dv.Table.Rows.Count; i++)
        {
            if (Convert.ToInt16(hiage.Value) == Convert.ToInt16(dv.Table.Rows[i][0]))
            {
                errormsg.Text = "年齡層不能重覆";
                errormsg.ForeColor = System.Drawing.Color.Red;
                break;
            }
            else
            {
                string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string sql = "";

                sql = "INSERT INTO [fontsize] (hiage,fontsize) VALUES (@hiage,@fontsize)";
                SqlCommand cmd1 = new SqlCommand(sql, conn);
                cmd1.Parameters.AddWithValue("@hiage", hiage.Value);
                cmd1.Parameters.AddWithValue("@fontsize", fontsize.Value);

                cmd1.ExecuteNonQuery();
                conn.Close();
                cmd1.Dispose();
                Response.Write("<script>alert('新增成功!');location.href='font.aspx';</script>");
                GridView1.DataBind();
                break;
            }

        }

    }
    protected void update_Click(object sender, EventArgs e)
    {
        errormsg.Text = "";
        SqlConnection Conn = new SqlConnection(@"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502");
        Conn.Open();

        for (int g = 0; g < GridView1.Rows.Count; g++)
        {
            CheckBox checkbox2 = (CheckBox)GridView1.Rows[g].Cells[0].FindControl("Checkbox1");

            if (checkbox2.Checked)
            {

                string updateSQL = "UPDATE [fontsize] set hiage=@hiage,fontsize=@fontsize WHERE [fid]='" + GridView1.DataKeys[g].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(updateSQL, Conn);
                cmd.Parameters.AddWithValue("@hiage", hiage.Value);
                //cmd.Parameters.AddWithValue("@lowage", lowage.Value);
                cmd.Parameters.AddWithValue("@fontsize", fontsize.Value);
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();
                reader.Close();
                Response.Write("<script>alert('修改成功');location.href='font.aspx';</script>");
            }


        }

        GridView1.DataBind();
        Conn.Close();
    }

}