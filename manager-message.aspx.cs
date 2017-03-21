using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class new_manager_message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//Get Method
        {
            Session["txtA_value"] = null;//初始化
        }
        if (Session["name"] == null)
        {
            Response.Write("<script>alert('登入時效已過，請重新登入!');location.href='index.aspx';</script>");
        }
        string strConn = @"Server=KING0503-PC\SQLEXPRESS;database=test;User ID=sa;Password=f502;";
        SqlConnection myConn = new SqlConnection(strConn);
        myConn.Open();
        String strSQL = "select * from msgboard ";
        SqlCommand myCommand = new SqlCommand(strSQL, myConn);
        SqlDataReader myDataReader = myCommand.ExecuteReader();

        myDataReader.Close();
        myConn.Close();
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
        SqlCommand cmd = new SqlCommand("select * from msgboard where c_id='" + id.Text.Trim() + "'", conn);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();


        if (!dr.Read())
        {

            dr.Close();
            conn.Close();
            cmd.Cancel();
            Label1.Text = "查無此人";
        }
        else if (id.Text.Trim() != "")
        {


            SqlDataSource1.SelectCommand = "SELECT * FROM [msgboard] where c_id='" + id.Text.Trim() + "'";
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
    protected void delete_click(object sender, EventArgs e)
    {

        SqlConnection Conn = new SqlConnection(@"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502");
        Conn.Open();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            CheckBox checkbox = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Checkbox1");

            if (checkbox.Checked)
            {

                string deleteSQL = "DELETE FROM [msgboard] WHERE [c_id]='" + GridView1.DataKeys[i].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(deleteSQL, Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();
                reader.Close();


            }
        }
        GridView1.DataBind();
        Conn.Close();

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502");
        Conn.Open();
        
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox checkbox = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
            if (checkbox.Checked)
            {
            string updateSQL = "UPDATE [msgboard] set re_msg=@remsg,re_datetime=@datetime WHERE [c_id]='" + GridView1.DataKeys[i].Value.ToString() + "'";   
            SqlCommand cmd = new SqlCommand(updateSQL, Conn);
            cmd.Parameters.AddWithValue("@remsg", remessage.Text);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes);

            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Dispose();
            reader.Close();   
                    string SQL = "select * from [msgboard] where c_id='" + GridView1.DataKeys[i].Value.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(SQL, Conn);
                    SqlDataReader reader1 = cmd2.ExecuteReader();
                    if (reader1.Read())
                    {
                        MailMessage em = new MailMessage();
                        NetworkCredential cred = new System.Net.NetworkCredential("yk814016@gmail.com", "elma801208.");
                        em.To.Add(reader1["m_mail"].ToString());
                        em.Subject = "subject";
                        em.From = new System.Net.Mail.MailAddress("yk814016@gmail.com", "Goggle", System.Text.Encoding.UTF8);
                        em.SubjectEncoding = System.Text.Encoding.UTF8;
                        em.BodyEncoding = Encoding.UTF8;
                        //信件主題 
                        em.Subject = "您好" + reader1["m_name"].ToString() + "，Goggle已回覆您的留言";
                        //內容 
                        em.Body = "您好" + reader1["m_name"].ToString() + "<br/>" + "您的留言內容是：" + reader1["m_msg"].ToString() + "<br/>" + "Goggle回覆內容是:" + reader1["re_msg"].ToString();
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
                        cmd2.Dispose();
                        reader1.Close();
                       
                }
                 
            } 
        }    
    
         GridView1.DataBind();
         Conn.Close();
   
        
    }
    protected void cal_click(object sender, EventArgs e)
    {
        GridView1.DataBind();
        id.Text = "";
    
    }
    
}