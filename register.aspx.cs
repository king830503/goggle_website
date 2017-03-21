using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Collections;

public partial class register : System.Web.UI.Page
{
    public SqlDataSource db;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.ForeColor = System.Drawing.Color.Red;
        Label1.Text = "&lowast;部分一定要填，圖片選填";
    }

    protected void submit_Click(object sender, EventArgs e)
    {

        String sql = "";
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();

        SqlCommand cmd1 = new SqlCommand("select * from member where m_name=@m_name", conn);
        cmd1.Parameters.AddWithValue("@m_name", user.Text.Trim());
        SqlDataReader reader1 = cmd1.ExecuteReader();
        if (reader1.Read())
        {
            Label1.Text = "帳號重複!!";
            user.BorderColor = System.Drawing.Color.Red;
            reader1.Close();
            conn.Close();

        }
        else
        {
            //帳號無重複
            reader1.Close();
            conn.Close();



            //判斷textbox格式
            if (email.Text.Trim().Length == 0 || pwd.Text.Trim().Length == 0 || pwd2.Text.Trim().Length == 0 || user.Text.Trim().Length == 0 || age.Text.Trim().Length == 0 || limittime.Value == "")
            {//有空白
                Label1.Text = "請輸入相關資料!!";
                user.BorderColor = pwd.BorderColor = System.Drawing.Color.Red;
                pwd.BorderColor = System.Drawing.Color.Red;
                pwd2.BorderColor = System.Drawing.Color.Red;
                email.BorderColor = System.Drawing.Color.Red;
            }
            else if (pwd.Text.Trim().Length < 5 || pwd2.Text.Trim().Length < 5 || user.Text.Trim().Length < 5)
            {
                Label1.Text = "帳號跟密碼至少5字元";
                user.BorderColor = pwd.BorderColor = System.Drawing.Color.Red;
                pwd.BorderColor = System.Drawing.Color.Red;
                pwd2.BorderColor = System.Drawing.Color.Red;
            }
            else if (Convert.ToInt16(age.Text.Trim()) <= 1890 || Convert.ToInt16(age.Text.Trim()) >= 2015)
            {
                Label1.Text = "西元介於1890~2015年";
                age.BorderColor = System.Drawing.Color.Red;
            }
            else if(redblind.Checked==true){
                if (FileUpload1.HasFile)
                {
                    string ExtName = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
                    string MIME = "";

                    switch (ExtName)
                    {
                        case ".gif":
                            MIME = "image/gif";
                            break;
                        case ".jpg":
                            MIME = "image/jpg";
                            break;
                        case ".png":
                            MIME = "image/png";
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

                    string savepath = @"C:\inetpub\wwwroot\Goggle\user-images\";

                    FileUpload1.SaveAs(savepath + user.Text.Trim() + ExtName);
                    conn.Open();
                    sql = "insert into [member] (m_name,m_pwd,m_mail,m_photo,m_vote,age,limittime,redcolor_blind) values(@name,@pwd,@mail,@photo,@vote,@age,@limit,@redcolor_blind)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@photo", user.Text.Trim() + ExtName);
                    cmd.Parameters.AddWithValue("@age", age.Text.Trim());
                    cmd.Parameters.AddWithValue("@limit", limittime.Value);
                    cmd.Parameters.AddWithValue("@vote", "0");
                    cmd.Parameters.AddWithValue("@redcolor_blind", redblind.Value);



                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                    conn.Close();
                    conn.Open();
                    sql = "insert into [apiset] (m_name,filltercolor,bgcolor,bgcoloropacity,filltercoloropacity,fontsize) values(@name,@fillter,@bgcolor,@bgcoloropacity,@filltercoloropacity,@fontsize)";
                    SqlCommand cmd3 = new SqlCommand(sql, conn);

                    cmd3.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd3.Parameters.AddWithValue("@fillter", "#A349A4");
                    cmd3.Parameters.AddWithValue("@bgcolor", "255,255,255 ");
                    cmd3.Parameters.AddWithValue("@bgcoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@filltercoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@fontsize", 12);
                    cmd3.ExecuteNonQuery();
                    cmd3.Cancel();
                    conn.Close();
                    conn.Open();
                    sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)";
                    SqlCommand cmd4 = new SqlCommand(sql, conn);
                    cmd4.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd4.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd4.Parameters.AddWithValue("@tname", "紅綠色弱");
                    cmd4.Parameters.AddWithValue("@r", 163);
                    cmd4.Parameters.AddWithValue("@g", 73);
                    cmd4.Parameters.AddWithValue("@b", 164);
                    cmd4.Parameters.AddWithValue("@a", 23);
                    cmd4.Parameters.AddWithValue("@retime", 20);
                    cmd4.Parameters.AddWithValue("@restatus", 1);
                    cmd4.Parameters.AddWithValue("@setmode", 2);
                    cmd4.Parameters.AddWithValue("@bright", 197);
                    cmd4.Parameters.AddWithValue("@str_isadd", "true");
                    cmd4.Parameters.AddWithValue("@str_isremind", "true");
                    cmd4.Parameters.AddWithValue("@str_light", "manually");
                    cmd4.Parameters.AddWithValue("@default_set", 1);
                    cmd4.ExecuteNonQuery();
                    cmd4.Cancel();
                    conn.Close();
                    Response.Write("<script>alert('註冊成功!'); location.href='index.aspx'; </script>");

                }
                else {
                 conn.Open();
                 sql = "insert into [member] (m_name,m_pwd,m_mail,m_photo,m_vote,age,limittime,redcolor_blind) values(@name,@pwd,@mail,@photo,@vote,@age,@limit,@redcolor_blind)";
                 SqlCommand cmd = new SqlCommand(sql, conn);
                   

                    cmd.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@age", age.Text.Trim());
                    cmd.Parameters.AddWithValue("@limit", limittime.Value);
                    cmd.Parameters.AddWithValue("@redcolor_blind", redblind.Value);
                    cmd.Parameters.AddWithValue("@vote", "0");
                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    cmd.Cancel();
                    reader.Close();
                    conn.Open();
                    sql = "insert into [apiset] (m_name,filltercolor,bgcolor,bgcoloropacity,filltercoloropacity,fontsize) values(@name,@fillter,@bgcolor,@bgcoloropacity,@filltercoloropacity,@fontsize)";
                    SqlCommand cmd3 = new SqlCommand(sql, conn);

                    cmd3.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd3.Parameters.AddWithValue("@fillter", "#A349A4");
                    cmd3.Parameters.AddWithValue("@bgcolor", "255,255,255");
                    cmd3.Parameters.AddWithValue("@bgcoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@filltercoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@fontsize", 12);
                    cmd3.ExecuteNonQuery();
                    cmd3.Cancel();
                    conn.Close();
                    conn.Open();
                    sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)";
                    SqlCommand cmd4 = new SqlCommand(sql, conn);
                    cmd4.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd4.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd4.Parameters.AddWithValue("@tname", "主題");
                    cmd4.Parameters.AddWithValue("@r", 163);
                    cmd4.Parameters.AddWithValue("@g", 73);
                    cmd4.Parameters.AddWithValue("@b", 164);
                    cmd4.Parameters.AddWithValue("@a", 23);
                    cmd4.Parameters.AddWithValue("@retime", 20);
                    cmd4.Parameters.AddWithValue("@restatus", 1);
                    cmd4.Parameters.AddWithValue("@setmode", 2);
                    cmd4.Parameters.AddWithValue("@bright", 197);
                    cmd4.Parameters.AddWithValue("@str_isadd", "true");
                    cmd4.Parameters.AddWithValue("@str_isremind", "true");
                    cmd4.Parameters.AddWithValue("@str_light", "manually");
                    cmd4.Parameters.AddWithValue("@default_set", 1);
                    cmd4.ExecuteNonQuery();
                    cmd4.Cancel();
                    conn.Close();
                    Response.Write("<script>alert('註冊成功!'); location.href='index.aspx'; </script>");       
                }
            }
            else if (blueblind.Checked == true)
            {

                if (FileUpload1.HasFile)
                {
                    string ExtName = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
                    string MIME = "";

                    switch (ExtName)
                    {
                        case ".gif":
                            MIME = "image/gif";
                            break;
                        case ".jpg":
                            MIME = "image/jpg";
                            break;
                        case ".png":
                            MIME = "image/png";
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

                    string savepath = @"C:\inetpub\wwwroot\Goggle\user-images\";

                    FileUpload1.SaveAs(savepath + user.Text.Trim() + ExtName);
                    conn.Open();
                    sql = "insert into [member] (m_name,m_pwd,m_mail,m_photo,m_vote,age,limittime,bluecolor_blind) values(@name,@pwd,@mail,@photo,@vote,@age,@limit,@bluecolor_blind)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@photo", user.Text.Trim() + ExtName);
                    cmd.Parameters.AddWithValue("@age", age.Text.Trim());
                    cmd.Parameters.AddWithValue("@limit", limittime.Value);
                    cmd.Parameters.AddWithValue("@vote", "0");
                    cmd.Parameters.AddWithValue("@bluecolor_blind", blueblind.Value);


                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                    conn.Close();
                    conn.Open();
                    sql = "insert into [apiset] (m_name,filltercolor,bgcolor,bgcoloropacity,filltercoloropacity,fontsize) values(@name,@fillter,@bgcolor,@bgcoloropacity,@filltercoloropacity,@fontsize)";
                    SqlCommand cmd3 = new SqlCommand(sql, conn);

                    cmd3.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd3.Parameters.AddWithValue("@fillter", "#880015");
                    cmd3.Parameters.AddWithValue("@bgcolor", "255,255,255 ");
                    cmd3.Parameters.AddWithValue("@bgcoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@filltercoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@fontsize", 12);
                    cmd3.ExecuteNonQuery();
                    cmd3.Cancel();
                    conn.Close();
                    conn.Open();
                    sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)";
                    SqlCommand cmd4 = new SqlCommand(sql, conn);
                    cmd4.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd4.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd4.Parameters.AddWithValue("@tname", "藍綠色弱");
                    cmd4.Parameters.AddWithValue("@r", 136);
                    cmd4.Parameters.AddWithValue("@g", 0);
                    cmd4.Parameters.AddWithValue("@b", 21);
                    cmd4.Parameters.AddWithValue("@a", 51);
                    cmd4.Parameters.AddWithValue("@retime", 20);
                    cmd4.Parameters.AddWithValue("@restatus", 1);
                    cmd4.Parameters.AddWithValue("@setmode", 2);
                    cmd4.Parameters.AddWithValue("@bright", 197);
                    cmd4.Parameters.AddWithValue("@str_isadd", "true");
                    cmd4.Parameters.AddWithValue("@str_isremind", "true");
                    cmd4.Parameters.AddWithValue("@str_light", "manually");
                    cmd4.Parameters.AddWithValue("@default_set", 1);
                    cmd4.ExecuteNonQuery();
                    cmd4.Cancel();
                    conn.Close();
                    Response.Write("<script>alert('註冊成功!'); location.href='index.aspx'; </script>");
                }
                else {
                    conn.Open();
                    sql = "insert into [member] (m_name,m_pwd,m_mail,m_photo,m_vote,age,limittime,bluecolor_blind) values(@name,@pwd,@mail,@photo,@vote,@age,@limit,@bluecolor_blind)";
                    SqlCommand cmd = new SqlCommand(sql, conn);


                    cmd.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@age", age.Text.Trim());
                    cmd.Parameters.AddWithValue("@limit", limittime.Value);
                    cmd.Parameters.AddWithValue("@bluecolor_blind", redblind.Value);
                    cmd.Parameters.AddWithValue("@vote", "0");
                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    cmd.Cancel();
                    reader.Close();
                    conn.Open();
                    sql = "insert into [apiset] (m_name,filltercolor,bgcolor,bgcoloropacity,filltercoloropacity,fontsize) values(@name,@fillter,@bgcolor,@bgcoloropacity,@filltercoloropacity,@fontsize)";
                    SqlCommand cmd3 = new SqlCommand(sql, conn);

                    cmd3.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd3.Parameters.AddWithValue("@fillter", "#880015");
                    cmd3.Parameters.AddWithValue("@bgcolor", "255,255,255");
                    cmd3.Parameters.AddWithValue("@bgcoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@filltercoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@fontsize", 12);
                    cmd3.ExecuteNonQuery();
                    cmd3.Cancel();
                    conn.Close();
                    conn.Open();
                    sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)";
                    SqlCommand cmd4 = new SqlCommand(sql, conn);
                    cmd4.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd4.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd4.Parameters.AddWithValue("@tname", "主題");
                    cmd4.Parameters.AddWithValue("@r", 136);
                    cmd4.Parameters.AddWithValue("@g", 0);
                    cmd4.Parameters.AddWithValue("@b", 21);
                    cmd4.Parameters.AddWithValue("@a", 51);
                    cmd4.Parameters.AddWithValue("@retime", 20);
                    cmd4.Parameters.AddWithValue("@restatus", 1);
                    cmd4.Parameters.AddWithValue("@setmode", 2);
                    cmd4.Parameters.AddWithValue("@bright", 197);
                    cmd4.Parameters.AddWithValue("@str_isadd", "true");
                    cmd4.Parameters.AddWithValue("@str_isremind", "true");
                    cmd4.Parameters.AddWithValue("@str_light", "manually");
                    cmd4.Parameters.AddWithValue("@default_set", 1);
                    cmd4.ExecuteNonQuery();
                    cmd4.Cancel();
                    conn.Close();
                    Response.Write("<script>alert('註冊成功!'); location.href='index.aspx'; </script>"); 
                }
            }
            else
            {

                if (FileUpload1.HasFile)
                {
                    string ExtName = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
                    string MIME = "";

                    switch (ExtName)
                    {
                        case ".gif":
                            MIME = "image/gif";
                            break;
                        case ".jpg":
                            MIME = "image/jpg";
                            break;
                        case ".png":
                            MIME = "image/png";
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

                    string savepath = @"C:\inetpub\wwwroot\Goggle\user-images\";

                    FileUpload1.SaveAs(savepath + user.Text.Trim() + ExtName);
                    conn.Open();
                    sql = "insert into [member] (m_name,m_pwd,m_mail,m_photo,m_vote,age,limittime) values(@name,@pwd,@mail,@photo,@vote,@age,@limit)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@photo", user.Text.Trim() + ExtName);
                    cmd.Parameters.AddWithValue("@age", age.Text.Trim());
                    cmd.Parameters.AddWithValue("@limit", limittime.Value);
                    cmd.Parameters.AddWithValue("@vote", "0");


                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                    conn.Close();
                    conn.Open();
                    sql = "insert into [apiset] (m_name,filltercolor,bgcolor,bgcoloropacity,filltercoloropacity,fontsize) values(@name,@fillter,@bgcolor,@bgcoloropacity,@filltercoloropacity,@fontsize)";
                    SqlCommand cmd3 = new SqlCommand(sql, conn);

                    cmd3.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd3.Parameters.AddWithValue("@fillter", "#666");
                    cmd3.Parameters.AddWithValue("@bgcolor", "245,222,179");
                    cmd3.Parameters.AddWithValue("@bgcoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@filltercoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@fontsize", 12);
                    cmd3.ExecuteNonQuery();
                    cmd3.Cancel();
                    conn.Close();
                    conn.Open();
                    sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)";
                    SqlCommand cmd4 = new SqlCommand(sql, conn);
                    cmd4.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd4.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd4.Parameters.AddWithValue("@tname", "主題");
                    cmd4.Parameters.AddWithValue("@r", 245);
                    cmd4.Parameters.AddWithValue("@g", 222);
                    cmd4.Parameters.AddWithValue("@b", 179);
                    cmd4.Parameters.AddWithValue("@a", 40);
                    cmd4.Parameters.AddWithValue("@retime", 0);
                    cmd4.Parameters.AddWithValue("@restatus", 1);
                    cmd4.Parameters.AddWithValue("@setmode", 2);
                    cmd4.Parameters.AddWithValue("@bright", 0);
                    cmd4.Parameters.AddWithValue("@str_isadd", "false");
                    cmd4.Parameters.AddWithValue("@str_isremind", "false");
                    cmd4.Parameters.AddWithValue("@str_light", "manually");
                    cmd4.Parameters.AddWithValue("@default_set", 1);
                    cmd4.ExecuteNonQuery();
                    cmd4.Cancel();
                    conn.Close();
                    Response.Write("<script>alert('註冊成功!'); location.href='index.aspx'; </script>");

                }

                else
                {
                    conn.Open();
                    sql = "insert into [member] (m_name,m_pwd,m_mail,m_vote,age,limittime) values(@name,@pwd,@mail,@vote,@age,@limit)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (redblind.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@redblind", redblind.Value);
                    }
                    else if (blueblind.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@blueblind", blueblind.Value);
                    }

                    cmd.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@age", age.Text.Trim());
                    cmd.Parameters.AddWithValue("@limit", limittime.Value);

                    cmd.Parameters.AddWithValue("@vote", "0");
                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    cmd.Cancel();
                    reader.Close();
                    conn.Open();
                    sql = "insert into [apiset] (m_name,filltercolor,bgcolor,bgcoloropacity,filltercoloropacity,fontsize) values(@name,@fillter,@bgcolor,@bgcoloropacity,@filltercoloropacity,@fontsize)";
                    SqlCommand cmd3 = new SqlCommand(sql, conn);

                    cmd3.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd3.Parameters.AddWithValue("@fillter", "#666");
                    cmd3.Parameters.AddWithValue("@bgcolor", "245,222,179");
                    cmd3.Parameters.AddWithValue("@bgcoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@filltercoloropacity", 0.2);
                    cmd3.Parameters.AddWithValue("@fontsize", 12);
                    cmd3.ExecuteNonQuery();
                    cmd3.Cancel();
                    conn.Close();
                    conn.Open();
                    sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)";
                    SqlCommand cmd4 = new SqlCommand(sql, conn);
                    cmd4.Parameters.AddWithValue("@name", user.Text.Trim());
                    cmd4.Parameters.AddWithValue("@pwd", pwd.Text.Trim());
                    cmd4.Parameters.AddWithValue("@tname", "主題");
                    cmd4.Parameters.AddWithValue("@r", 245);
                    cmd4.Parameters.AddWithValue("@g", 222);
                    cmd4.Parameters.AddWithValue("@b", 179);
                    cmd4.Parameters.AddWithValue("@a", 40);
                    cmd4.Parameters.AddWithValue("@retime", 0);
                    cmd4.Parameters.AddWithValue("@restatus", 1);
                    cmd4.Parameters.AddWithValue("@setmode", 2);
                    cmd4.Parameters.AddWithValue("@bright", 0);
                    cmd4.Parameters.AddWithValue("@str_isadd", "false");
                    cmd4.Parameters.AddWithValue("@str_isremind", "false");
                    cmd4.Parameters.AddWithValue("@str_light", "manually");
                    cmd4.Parameters.AddWithValue("@default_set", 1);
                    cmd4.ExecuteNonQuery();
                    cmd4.Cancel();
                    conn.Close();
                    Response.Write("<script>alert('註冊成功!'); location.href='index.aspx'; </script>");
                }
            }
        }

    }
    protected void cal_Click(object sender, EventArgs e)
    {
        user.Text = "";
        pwd.Text = "";
        pwd2.Text = "";
        email.Text = "";
        age.Text = "";
        limittime.Value = "";
    }
}
