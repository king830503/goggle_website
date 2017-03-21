using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_set : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
   
        Session["Login"] = "ok";
        Label2.Text = "修改資料時需要輸入目前密碼";
        Label1.ForeColor = System.Drawing.Color.Red;
        Label2.ForeColor = System.Drawing.Color.Red;
        pwd.Text.Trim();
        newpwd.Text.Trim();
        newpwd2.Text.Trim();
        if (!Page.IsPostBack)
        {
            if (Session["name"] == null || Session["Login"] == null || Session["password"] == null || Session["pic"] == null || Session["email"] == null)
            {
                Response.Write("<script>alert('登入時效已過，請重新登入!');top.location.href='index.aspx';</script>");
            }
            else {
                String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
                SqlConnection conn = new SqlConnection(sqldb);
                conn.Open();

                SqlCommand cmd1 = new SqlCommand("select * from member where m_name='" + Session["name"] + "'", conn);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    if (reader1[8].ToString() == "0")
                    {

                        limittime.Value = "0";
                    }
                    else
                    {
                        limittime.Value = reader1[8].ToString();
                    }
                    if (reader1[7].ToString() == null)
                    {
                        born.Text = "";
                    }
                    else
                    {
                        born.Text = reader1[7].ToString();
                    }
                    email.Text = reader1["m_mail"].ToString();
                }
            }
        }
        //people.png

    }


    protected void sumit_Click(object sender, EventArgs e)
    {

        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();

        SqlCommand cmd1 = new SqlCommand("select * from member where m_name=@name and m_pwd=@pwd", conn);
   
        cmd1.Parameters.AddWithValue("@name",Session["name"]);
        cmd1.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
        SqlDataReader reader1 = cmd1.ExecuteReader();
        if (!reader1.Read())
        {
            Label1.Text = "密碼錯誤!!";
            pwd.BorderColor = System.Drawing.Color.Red;
            reader1.Close();
            conn.Close();
        }
        else if (email.Text.Trim().Length == 0)
        {
            Label1.Text = "電子信箱不得為空";
            email.BorderColor = System.Drawing.Color.Red;
        }
        else if (pwd.Text.Trim().Length == 0)
        {

            Label1.Text = "密碼不得為空";
            pwd.BorderColor = System.Drawing.Color.Red;

        }
        else if(limittime.Value==""){
            Label1.Text = "使用時間未設定時間";
           
        }
        else if (born.Text.Trim().Length == 0) {

            Label1.Text = "出生年份未設定";
            born.BorderColor = System.Drawing.Color.Red;
        }
        else if (Convert.ToInt16(born.Text.Trim()) <= 1890 || Convert.ToInt16(born.Text.Trim()) >= 2015)
        {
            Label1.Text = "西元年份1890~2015";
            born.BorderColor = System.Drawing.Color.Red;
        }


        else if (!reader1.Read() && newpwd.Text.Trim() == Session["password"].ToString().Trim())
        {
            //密碼無重複
            pwd.BorderColor = System.Drawing.Color.Red;
            newpwd.BorderColor = System.Drawing.Color.Red;
            newpwd2.BorderColor = System.Drawing.Color.Red;
            Label1.Text = "新密碼不可跟舊密碼重覆";
        }
        else
        {
            reader1.Close();
            cmd1.Cancel();
            conn.Close();


            if (newpwd.Text.Trim().Length == 0 && newpwd2.Text.Trim().Length == 0)
            {
                string ExtName = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
                string mimi = "";
                if (FileUpload1.HasFile)
                {

                    switch (ExtName)
                    {
                        case ".gif":
                            mimi = Session["name"].ToString() + ExtName;
                            break;
                        case ".jpg":
                            mimi = Session["name"].ToString() + ExtName;
                            break;
                        case ".png":
                            mimi = Session["name"].ToString() + ExtName;
                            break;
                        default:
                            Label1.Text = "只允許jpg.gif.png的圖片檔上傳";
                            break;
                    }

                    int filesize = FileUpload1.PostedFile.ContentLength;
                    if (filesize > 2100000)
                    {
                        Label1.Text = "檔案大小上限為 2MB，該檔案無法上傳";
                        return;
                    }
                    if (mimi != "")
                    {

                        string savepath = @"C:\inetpub\wwwroot\Goggle\new\user-images\";
                        FileUpload1.SaveAs(savepath + mimi);
                        conn.Open();
                        String strSQL = "UPDATE member SET m_mail=@mail,m_pwd=@pwd,m_photo=@photo,age=@age,limittime=@limittime WHERE  m_name=@name and m_pwd =@pwd";
                        SqlCommand cmd = new SqlCommand(strSQL, conn);
                        cmd.Parameters.AddWithValue("mail", email.Text.Trim());
                        cmd.Parameters.AddWithValue("pwd", pwd.Text.Trim());
                        cmd.Parameters.AddWithValue("name", Session["name"]);
                        cmd.Parameters.AddWithValue("photo", mimi);
                        cmd.Parameters.AddWithValue("age", born.Text.Trim());
                        cmd.Parameters.AddWithValue("limittime", limittime.Value);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        cmd.Cancel();
                        Session.Abandon();
                        Response.Write("<script>alert('修改成功，請重新登入一次!');top.location.href='index.aspx';  </script>");

                    }
                }
                else
                {
                    string pwdstr = Session["password"].ToString();
                    conn.Open();
                    String strSQL = "UPDATE member SET m_mail=@mail,m_pwd=@pwd,age=@age,limittime=@limittime WHERE  m_name=@name and m_pwd =@pwd";
                    SqlCommand cmd = new SqlCommand(strSQL, conn);
                    cmd.Parameters.AddWithValue("mail", email.Text.Trim());
                    cmd.Parameters.AddWithValue("pwd", pwd.Text.Trim());
                    cmd.Parameters.AddWithValue("name", Session["name"]);
                    cmd.Parameters.AddWithValue("age", born.Text.Trim());
                    cmd.Parameters.AddWithValue("limittime", limittime.Value);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    cmd.Cancel();
                    Session.Abandon();
                    Response.Write("<script>alert('修改成功，請重新登入一次!'); top.location.href='index.aspx'; </script>");

                }
            }

            else if (newpwd.Text.Trim().Length != 0 && newpwd2.Text.Trim().Length != 0)
            {
                string ExtName = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
                string mimi = "";
                conn.Open();
                if (FileUpload1.HasFile)
                {
                    switch (ExtName)
                    {

                        case ".gif":
                            mimi = Session["name"].ToString() + ExtName;
                            break;
                        case ".jpg":
                            mimi = Session["name"].ToString() + ExtName;
                            break;
                        case ".png":
                            mimi = Session["name"].ToString() + ExtName;
                            break;
                        default:
                            Label1.Text = "只允許jpg.gif.png的圖片檔上傳";
                            break;
                    }

                    int filesize = FileUpload1.PostedFile.ContentLength;
                    if (filesize > 2100000)
                    {
                        Label1.Text = "檔案大小上限為 2MB，該檔案無法上傳";
                        return;
                    }
                    if (mimi != "")
                    {
                        string savepath = @"C:\inetpub\wwwroot\Goggle\user-images\";
                        FileUpload1.SaveAs(savepath + mimi);
                        String strSQL = "UPDATE member SET m_mail=@mail,m_pwd=@newpwd,m_photo=@photo,age=@age,limittime=@limittime WHERE  m_name=@name and m_pwd =@pwd";
                        SqlCommand cmd = new SqlCommand(strSQL, conn);
                        cmd.Parameters.AddWithValue("mail", email.Text.Trim());
                        cmd.Parameters.AddWithValue("pwd", pwd.Text.Trim());
                        cmd.Parameters.AddWithValue("newpwd", newpwd.Text.Trim());
                        cmd.Parameters.AddWithValue("name", Session["name"]);
                        cmd.Parameters.AddWithValue("photo", mimi);
                        cmd.Parameters.AddWithValue("age", born.Text.Trim());
                        cmd.Parameters.AddWithValue("limittime", limittime.Value);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        cmd.Cancel();
                        Session.Abandon();
                        Response.Write("<script>alert('修改成功，請重新登入一次!');top.location.href='index.aspx'; </script>");


                    }
                }
                else
                {
                    String strSQL = "UPDATE member SET m_mail=@mail,m_pwd=@newpwd,age=@age,limittime=@limittime WHERE  m_name=@name and m_pwd =@pwd";
                    SqlCommand cmd = new SqlCommand(strSQL, conn);

                    cmd.Parameters.AddWithValue("mail", email.Text.Trim());
                    cmd.Parameters.AddWithValue("pwd", pwd.Text.Trim());
                    cmd.Parameters.AddWithValue("name", Session["name"]);
                    cmd.Parameters.AddWithValue("@newpwd", newpwd.Text.Trim());
                    cmd.Parameters.AddWithValue("age", born.Text.Trim());
                    cmd.Parameters.AddWithValue("limittime", limittime.Value);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    cmd.Cancel();
                    Session.Abandon();
                    Response.Write("<script>alert('修改成功，請重新登入一次!'); top.location.href='index.aspx';  </script>");
                }
            }
        }
        }
    protected void cancel_Click(object sender, EventArgs e) {
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();

        SqlCommand cmd1 = new SqlCommand("select * from member where m_name='" + Session["name"] + "'", conn);
        SqlDataReader reader1 = cmd1.ExecuteReader();

        if (reader1.Read())
        {
            if (reader1[8].ToString() == "0")
            {

                limittime.Value = "0";
            }
            else
            {
                limittime.Value = reader1[8].ToString();
            }

            if (reader1[7].ToString() == null)
            {
                born.Text = "";
            }
            else
            {
                born.Text = reader1[7].ToString();
            }
            email.Text = reader1["m_mail"].ToString();
        }
    }
}