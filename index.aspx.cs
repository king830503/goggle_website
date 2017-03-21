using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataSource db = new SqlDataSource();
        db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
        db.SelectCommand = "select * from votecolor";
        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);
        for (int i = 0; i < dv.Table.Rows.Count; i += 2)
        {
            if (dv.Table.Rows.Count % 2 == 0)
            {
                if (!IsPostBack) {

                    voteitem.Text += "<ul style='font-size:2.8em; text-align: center; list-style: none;'>";
                    voteitem.Text += "<li style='margin-bottom: 15px; padding-top:1em;'>";
                    voteitem.Text += "<div style='float: left;margin-left:2em'>";
                    voteitem.Text += "<div id='t" + (i + 1) + "'>";
                    voteitem.Text += "<div><a class='group1' href='content/" + (i + 1) + ".aspx' >";
                    voteitem.Text += "<div class='s1' style='color:rgb(" + dv.Table.Rows[i][8].ToString() + "," + dv.Table.Rows[i][9].ToString() + "," + dv.Table.Rows[i][10].ToString() + "); background-color: rgb(" + dv.Table.Rows[i][2].ToString() + "," + dv.Table.Rows[i][3].ToString() + "," + dv.Table.Rows[i][4].ToString() + ");'>";
                    voteitem.Text += dv.Table.Rows[i][0].ToString() + "</div></a></div></div>";
                    voteitem.Text += " <div class='votenum'>" + dv.Table.Rows[i][1].ToString() + "票</div>";
                    voteitem.Text += "</div>";
                    voteitem.Text += "<div style='float: right;margin-right: 2em;'>" + "<div id='t" + (i + 2) + "'>";
                    voteitem.Text += "<div><a class='group1' href='content/" + (i + 2) + ".aspx'>";
                    voteitem.Text += "<div class='s2' style='width:310px;height:100px;;color:rgb(" + dv.Table.Rows[i + 1][8].ToString() + "," + dv.Table.Rows[i + 1][9].ToString() + "," + dv.Table.Rows[i + 1][10].ToString() + "); background-color: rgb(" + dv.Table.Rows[i + 1][2].ToString() + "," + dv.Table.Rows[i + 1][3].ToString() + "," + dv.Table.Rows[i + 1][4].ToString() + ");'>";
                    voteitem.Text += dv.Table.Rows[i + 1][0] + "</div></a></div></div>";
                    voteitem.Text += "<div class='votenum'>" + dv.Table.Rows[i + 1][1].ToString() + "票</div>";
                    voteitem.Text += "</div></li></ul>";
                
                }
               

            }
            else
            {
                if (!IsPostBack)
                {
                    voteitem.Text += "<ul style='font-size:2.8em; text-align: center; list-style: none;'>";
                    voteitem.Text += "<li style='margin-bottom: 15px; padding-top:1em;'>";
                    voteitem.Text += "<div style='float: left;margin-left:2em'>";
                    voteitem.Text += "<div id='t" + (i + 1) + "'>";
                    voteitem.Text += "<div><a class='group1' href='content/" + (i + 1) + ".aspx' >";
                    voteitem.Text += "<div class='s1' style='width:300px;height:100px;color:rgb(" + dv.Table.Rows[i][8].ToString() + "," + dv.Table.Rows[i][9].ToString() + "," + dv.Table.Rows[i][10].ToString() + "); background-color: rgb(" + dv.Table.Rows[i][2].ToString() + "," + dv.Table.Rows[i][3].ToString() + "," + dv.Table.Rows[i][4].ToString() + ");'>";
                    voteitem.Text += dv.Table.Rows[i][0].ToString() + "</div></a></div></div>";
                    voteitem.Text += " <div class='votenum'>" + dv.Table.Rows[i][1].ToString() + "票</div>";
                    voteitem.Text += "</div>";
                    voteitem.Text += "<div style='float: right;margin-right: 2em;'>" + "<div id='t" + (i + 1) + "'>";
                    voteitem.Text += "<div><a class='group1' href='content/" + (i + 1) + ".aspx'>";
                    voteitem.Text += "<div class='s2' style='width:300px;height:100px;color:rgb(" + dv.Table.Rows[i][8].ToString() + "," + dv.Table.Rows[i][9].ToString() + "," + dv.Table.Rows[i][10].ToString() + "); background-color: rgb(" + dv.Table.Rows[i][2].ToString() + "," + dv.Table.Rows[i][3].ToString() + "," + dv.Table.Rows[i][4].ToString() + ");'>";
                    voteitem.Text += dv.Table.Rows[i][0] + "</div></a></div></div>";
                    voteitem.Text += "<div class='votenum'>" + dv.Table.Rows[i][1].ToString() + "票</div>";
                    voteitem.Text += "</div></li></ul>";
                }
            }
        }
 
    }
    protected void loginbtn_click(object sender, EventArgs e)
    {
        string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstring);
        conn.Open();
        SqlDataReader dr;
        SqlCommand cmd = new SqlCommand("select * from member where m_name=@m_name and m_pwd=@m_pwd", conn);
        cmd.Parameters.AddWithValue("@m_name", txtName.Value.Trim());
        cmd.Parameters.AddWithValue("@m_pwd", txtPwd.Value.Trim());
        dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                dr.Close();
                conn.Close();
                cmd.Cancel();
                Response.Write("<script>alert('查無此帳戶');setTimeout(location.href='index.aspx', 500);</script>");
               
            }
            else
            {
                if (dr["manger"].ToString() == "1")
                {
                    Session["manager"] = "check";
                    Session["name"] = dr["m_name"];
                    Response.Write("<script>alert('歡迎管理員');setTimeout(location.href='manage-member.aspx', 500); </script>");
                }
                else if (dr["manger"].ToString()=="2")
                {
                    Session["doctor_m"] = "check";
                    Session["name"] = dr["m_name"];
                    Response.Write("<script>alert('歡迎醫師登入');setTimeout(location.href='doctor-manager.aspx', 500); </script>");
                }
                else
                {

                    Session["Login"] = "ok";
                    Session["name"] = dr["m_name"];
                    Session["password"] = dr["m_pwd"];
                    Session["pic"] = dr["m_photo"];
                    Session["email"] = dr["m_mail"];
                    Session["vo"] = dr["m_vote"];
                    Response.Write("<script>alert('登入成功!');setTimeout(location.href='index2.aspx', 500); </script>");
                }

                cmd.Cancel();
                dr.Close();
                conn.Close();


            }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (name.Value.Trim().Length == 0)
        {
            name.Style["border"] = "solid #FF0000 1px";
            Response.Write("<script>alert('姓名未填!');location.href='http://140.131.7.23/Goggle/index.aspx#Message'; </script>");
        }
        else if (email.Value.Trim().Length == 0)
        {
            email.Style["border"] = "solid #FF0000 1px";
            Response.Write("<script>alert('信箱未填!');location.href='http://140.131.7.23/Goggle/index.aspx#Message'; </script>");
        }
        else if (msg.Value.Trim().Length == 0)
        {
            msg.Style["border"] = "solid #FF0000 1px";
            Response.Write("<script>alert('訊息未填!');location.href='http://140.131.7.23/Goggle/index.aspx#Message'; </script>");
        }
        else
        {
            String sql = "";
            String sqldb = @"Data Source=KING0503-PC\SQLEXPRESS;Initial Catalog=test;User ID=sa;Password=f502";
            SqlConnection conn = new SqlConnection(sqldb);
            conn.Open();
            sql = "insert into [msgboard] (m_name,m_mail,m_msg,m_datetime) values(@name,@mail,@msg,@datetime)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name.Value.Trim());
            cmd.Parameters.AddWithValue("@mail", email.Value.Trim());
            cmd.Parameters.AddWithValue("@msg", msg.Value);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes);

            cmd.ExecuteNonQuery();

            cmd.Cancel();
            conn.Close();
            Response.Write("<script>alert('留言成功!'); location.href='index.aspx'; </script>");
        }
    }
    protected void forgetbtn_Click(object sender, EventArgs e) {
        string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstring);
        conn.Open();
        SqlDataReader dr;
        SqlCommand cmd = new SqlCommand("select * from member where m_mail=@mail", conn);
        cmd.Parameters.AddWithValue("@mail", mail.Value.Trim());
        dr = cmd.ExecuteReader();
        if (!dr.Read())
        {
            dr.Close();
            conn.Close();
            cmd.Cancel();
            Literal1.Text = "查無此信箱";
            Response.Write("<script>alert('請輸入當時的註冊信箱!');setTimeout(location.href='index.aspx', 500);</script>");
        }
        else
        {
            Session["name"] = dr["m_name"];
            Session["password"] = dr["m_pwd"];
            Session["email"] = dr["m_mail"];
            cmd.Cancel();
            dr.Close();
            conn.Close();
            MailMessage em = new MailMessage();
            NetworkCredential cred = new System.Net.NetworkCredential("yk814016@gmail.com", "elma801208.");
            em.To.Add(Session["email"].ToString());
            em.Subject = "subject";
            em.From = new System.Net.Mail.MailAddress("yk814016@gmail.com", "Goggle", System.Text.Encoding.UTF8);
            em.SubjectEncoding = System.Text.Encoding.UTF8;
            em.BodyEncoding = Encoding.UTF8;
            //信件主題 
            em.Subject = "您好" + Session["name"].ToString() + "，Goggle的忘記密碼信已送達";
            //內容 
            em.Body = "您好" + Session["name"].ToString() + "<br/>" + "你的密碼是：" + Session["password"].ToString() + "<br/>" + "請妥善保管";
            em.IsBodyHtml = true;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //登入帳號認證  
            client.UseDefaultCredentials = false;
            //使用587 Port 
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            //啟動SSL 
            client.EnableSsl = true;
            client.Credentials = cred;
            //寄出 
            client.Send(em);
            Response.Write("<script>alert('寄信成功，可前往信箱收信!');setTimeout(location.href='index.aspx', 500); </script>");
        }
    }
    
}