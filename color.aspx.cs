using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class color : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataSource db = new SqlDataSource();
        db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
        db.SelectCommand = "select * from colorblind";
        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);

        Literal1.Text = "<div class='theme' style='background-color:rgb(" + dv.Table.Rows[0][2].ToString() + "," + dv.Table.Rows[0][3].ToString() + "," + dv.Table.Rows[0][4].ToString() + ");color:rgb(" + dv.Table.Rows[0][5].ToString() + "," + dv.Table.Rows[0][6].ToString() + "," + dv.Table.Rows[0][7].ToString() + ");'>" + dv.Table.Rows[0][1].ToString() + "</div>";
        Literal2.Text = "<div class='theme' style='background-color:rgb(" + dv.Table.Rows[1][2].ToString() + "," + dv.Table.Rows[1][3].ToString() + "," + dv.Table.Rows[1][4].ToString() + ");color:rgb(" + dv.Table.Rows[1][5].ToString() + "," + dv.Table.Rows[1][6].ToString() + "," + dv.Table.Rows[1][7].ToString() + ");'>" + dv.Table.Rows[1][1].ToString() + "</div>";
        Literal3.Text = "<div class='theme' style='background-color:rgb(" + dv.Table.Rows[2][2].ToString() + "," + dv.Table.Rows[2][3].ToString() + "," + dv.Table.Rows[2][4].ToString() + ");color:rgb(" + dv.Table.Rows[2][5].ToString() + "," + dv.Table.Rows[2][6].ToString() + "," + dv.Table.Rows[2][7].ToString() + ");'>" + dv.Table.Rows[2][1].ToString() + "</div>";
        Literal4.Text = "<div class='theme' style='background-color:rgb(" + dv.Table.Rows[3][2].ToString() + "," + dv.Table.Rows[3][3].ToString() + "," + dv.Table.Rows[3][4].ToString() + ");color:rgb(" + dv.Table.Rows[3][5].ToString() + "," + dv.Table.Rows[3][6].ToString() + "," + dv.Table.Rows[3][7].ToString() + ");'>" + dv.Table.Rows[3][1].ToString() + "</div>";
        Literal5.Text = "<div class='theme' style='background-color:rgb(" + dv.Table.Rows[4][2].ToString() + "," + dv.Table.Rows[4][3].ToString() + "," + dv.Table.Rows[4][4].ToString() + ");color:rgb(" + dv.Table.Rows[4][5].ToString() + "," + dv.Table.Rows[4][6].ToString() + "," + dv.Table.Rows[4][7].ToString() + ");'>" + dv.Table.Rows[4][1].ToString() + "</div>";
        Literal6.Text = "<div class='theme' style='background-color:rgb(" + dv.Table.Rows[5][2].ToString() + "," + dv.Table.Rows[5][3].ToString() + "," + dv.Table.Rows[5][4].ToString() + ");color:rgb(" + dv.Table.Rows[5][5].ToString() + "," + dv.Table.Rows[5][6].ToString() + "," + dv.Table.Rows[5][7].ToString() + ");'>" + dv.Table.Rows[5][1].ToString() + "</div>";
        Literal7.Text = "<div class='theme' style='background-color:rgb(" + dv.Table.Rows[6][2].ToString() + "," + dv.Table.Rows[6][3].ToString() + "," + dv.Table.Rows[6][4].ToString() + ");color:rgb(" + dv.Table.Rows[6][5].ToString() + "," + dv.Table.Rows[6][6].ToString() + "," + dv.Table.Rows[6][7].ToString() + ");'>" + dv.Table.Rows[6][1].ToString() + "</div>";
        Literal8.Text = "<div class='theme' style='background-color:rgb(" + dv.Table.Rows[7][2].ToString() + "," + dv.Table.Rows[7][3].ToString() + "," + dv.Table.Rows[7][4].ToString() + ");color:rgb(" + dv.Table.Rows[7][5].ToString() + "," + dv.Table.Rows[7][6].ToString() + "," + dv.Table.Rows[7][7].ToString() + ");'>" + dv.Table.Rows[7][1].ToString() + "</div>";
        
    }
      
      

   
    protected void add1_Click(object sender, EventArgs e)
    {
        String sql = "";
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();
        sql = "select * from Theme where m_name=@name and t_name=@t_name";
        SqlCommand repeat = new SqlCommand(sql, conn);
        repeat.Parameters.AddWithValue("@name",Session["name"].ToString());
        repeat.Parameters.AddWithValue("@t_name","紅綠色弱1");
        SqlDataReader dr;
        dr=repeat.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('您已經新增過這個主題了!'); </script>");
            repeat.Cancel();
            dr.Close();
            conn.Close();
           
        }
        else
        {
            conn.Close();
            dr.Close();
            repeat.Cancel();
            conn.Open();

            sql = "UPDATE Theme SET default_set=0 where m_name=@name";
            SqlCommand update = new SqlCommand(sql, conn);
            update.Parameters.AddWithValue("@name", Session["name"].ToString());
           
            update.ExecuteNonQuery();
            update.Cancel();
            conn.Close();
            conn.Open();
            sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd.Parameters.AddWithValue("@pwd", Session["password"].ToString());
            cmd.Parameters.AddWithValue("@tname", "紅綠色弱1");//255,240,132
            cmd.Parameters.AddWithValue("@r", Convert.ToInt32(255 / 2.55));//color:rgb(63, 72, 204);
            cmd.Parameters.AddWithValue("@g", Convert.ToInt32(240 / 2.55));
            cmd.Parameters.AddWithValue("@b", Convert.ToInt32(132 / 2.55));
            cmd.Parameters.AddWithValue("@a", 40);
            cmd.Parameters.AddWithValue("@retime",0);
            cmd.Parameters.AddWithValue("@restatus","0");
            cmd.Parameters.AddWithValue("@setmode","1");
            cmd.Parameters.AddWithValue("@bright","0");
            cmd.Parameters.AddWithValue("@str_isremind","false");
            cmd.Parameters.AddWithValue("@str_light","manually");
            cmd.Parameters.AddWithValue("@str_isadd", "true");
            cmd.Parameters.AddWithValue("@default_set","1");
            cmd.ExecuteNonQuery();

            cmd.Cancel();
            conn.Close();
            conn.Open();
            sql = "UPDATE apiset SET m_name=@name,filltercolor=@filter,bgcolor=@bgcolor,bgcoloropacity=@bgopacity,filltercoloropacity=@fillteropacity WHERE  m_name=@name";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd1.Parameters.AddWithValue("@bgcolor", "255,240,132");
            cmd1.Parameters.AddWithValue("@filter", "#FFF084");
            cmd1.Parameters.AddWithValue("@bgopacity", 0.2);
            cmd1.Parameters.AddWithValue("@fillteropacity", 0.2);
            cmd1.ExecuteNonQuery();
            cmd1.Cancel();
            conn.Close();
            Response.Write("<script>alert('新增環境成功!');top.location.href='user.aspx'; </script>");   
        }
    }
   
    protected void add2_Click(object sender, EventArgs e)
    {
        String sql = "";
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();
        sql = "select * from Theme where m_name=@name and t_name=@t_name";
        SqlCommand repeat = new SqlCommand(sql, conn);
        repeat.Parameters.AddWithValue("@name", Session["name"].ToString());
        repeat.Parameters.AddWithValue("@t_name", "紅綠色弱2");
        SqlDataReader dr;
        dr = repeat.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('您已經新增過這個主題了!'); </script>");
            repeat.Cancel();
            dr.Close();
            conn.Close();

        }
        else
        {
            conn.Close();
            dr.Close();
            repeat.Cancel();
            conn.Open();

            sql = "UPDATE Theme SET default_set=0 where m_name=@name";
            SqlCommand update = new SqlCommand(sql, conn);
            update.Parameters.AddWithValue("@name", Session["name"].ToString());

            update.ExecuteNonQuery();
            update.Cancel();
            conn.Close();
            conn.Open();
            sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)"; 
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd.Parameters.AddWithValue("@pwd", Session["password"].ToString());
            cmd.Parameters.AddWithValue("@tname", "紅綠色弱2");// background-color:rgb(63,72,204);color: rgb(185, 122, 87);
            cmd.Parameters.AddWithValue("@r", Convert.ToInt32(63 / 2.55));
            cmd.Parameters.AddWithValue("@g", Convert.ToInt32(72 / 2.55));
            cmd.Parameters.AddWithValue("@b", Convert.ToInt32(204 / 2.55));
            cmd.Parameters.AddWithValue("@a", 40);
            cmd.Parameters.AddWithValue("@retime", 0);
            cmd.Parameters.AddWithValue("@restatus", "0");
            cmd.Parameters.AddWithValue("@setmode", "1");
            cmd.Parameters.AddWithValue("@bright", "0");
            cmd.Parameters.AddWithValue("@str_isremind", "false");
            cmd.Parameters.AddWithValue("@str_light", "manually");
            cmd.Parameters.AddWithValue("@str_isadd", "true");
            cmd.Parameters.AddWithValue("@default_set", "1");
            cmd.ExecuteNonQuery();

            cmd.Cancel();
            conn.Close();
            conn.Open();
            sql = "UPDATE apiset SET m_name=@name,filltercolor=@filter,bgcolor=@bgcolor,bgcoloropacity=@bgopacity,filltercoloropacity=@fillteropacity WHERE  m_name=@name";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd1.Parameters.AddWithValue("@bgcolor", "63,72,204");
            cmd1.Parameters.AddWithValue("@filter", "#3F48CC");
            cmd1.Parameters.AddWithValue("@bgopacity", 0.2);
            cmd1.Parameters.AddWithValue("@fillteropacity", 0.2);
            cmd1.ExecuteNonQuery();
            cmd1.Cancel();
            conn.Close();
            Response.Write("<script>alert('新增環境成功!');top.location.href='user.aspx'; </script>");
          
        }
    }
    protected void add3_Click(object sender, EventArgs e)
    {
        String sql = "";
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();
        sql = "select * from Theme where m_name=@name and t_name=@t_name";
        SqlCommand repeat = new SqlCommand(sql, conn);
        repeat.Parameters.AddWithValue("@name", Session["name"].ToString());
        repeat.Parameters.AddWithValue("@t_name", "紅綠色弱3");
        SqlDataReader dr;
        dr = repeat.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('您已經新增過這個主題了!'); </script>");
            repeat.Cancel();
            dr.Close();
            conn.Close();

        }
        else
        {
            conn.Close();
            dr.Close();
            repeat.Cancel();
            conn.Open();

            sql = "UPDATE Theme SET default_set=0 where m_name=@name";
            SqlCommand update = new SqlCommand(sql, conn);
            update.Parameters.AddWithValue("@name", Session["name"].ToString());

            update.ExecuteNonQuery();
            update.Cancel();
            conn.Close();
            conn.Open();
            sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)"; 
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd.Parameters.AddWithValue("@pwd", Session["password"].ToString());
            cmd.Parameters.AddWithValue("@tname", "紅綠色弱3");
            cmd.Parameters.AddWithValue("@r", Convert.ToInt32(153 / 2.55));
            cmd.Parameters.AddWithValue("@g", Convert.ToInt32(217 / 2.55));
            cmd.Parameters.AddWithValue("@b", Convert.ToInt32(234 / 2.55));
            cmd.Parameters.AddWithValue("@a", 40);
            cmd.Parameters.AddWithValue("@retime", 0);
            cmd.Parameters.AddWithValue("@restatus", "0");
            cmd.Parameters.AddWithValue("@setmode", "1");
            cmd.Parameters.AddWithValue("@bright", "0");
            cmd.Parameters.AddWithValue("@str_isremind", "false");
            cmd.Parameters.AddWithValue("@str_light", "manually");
            cmd.Parameters.AddWithValue("@str_isadd", "true");
            cmd.Parameters.AddWithValue("@default_set", "1");
            cmd.ExecuteNonQuery();

            cmd.Cancel();
            conn.Close();
            conn.Open();
            sql = "UPDATE apiset SET m_name=@name,filltercolor=@filter,bgcolor=@bgcolor,bgcoloropacity=@bgopacity,filltercoloropacity=@fillteropacity WHERE  m_name=@name";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd1.Parameters.AddWithValue("@bgcolor", "153,217,234");
            cmd1.Parameters.AddWithValue("@filter", "#99D6EA");
            cmd1.Parameters.AddWithValue("@bgopacity", 0.2);
            cmd1.Parameters.AddWithValue("@fillteropacity", 0.2);
            cmd1.ExecuteNonQuery();
            cmd1.Cancel();
            conn.Close();
            Response.Write("<script>alert('新增環境成功!');top.location.href='user.aspx'; </script>");
        }
    }
    protected void add4_Click(object sender, EventArgs e)
    {
        String sql = "";
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();
        sql = "select * from Theme where m_name=@name and t_name=@t_name";
        SqlCommand repeat = new SqlCommand(sql, conn);
        repeat.Parameters.AddWithValue("@name", Session["name"].ToString());
        repeat.Parameters.AddWithValue("@t_name", "紅綠色弱4");
        SqlDataReader dr;
        dr = repeat.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('您已經新增過這個主題了!'); </script>");
            repeat.Cancel();
            dr.Close();
            conn.Close();

        }
        else
        {
            conn.Close();
            dr.Close();
            repeat.Cancel();
            conn.Open();

            sql = "UPDATE Theme SET default_set=0 where m_name=@name";
            SqlCommand update = new SqlCommand(sql, conn);
            update.Parameters.AddWithValue("@name", Session["name"].ToString());

            update.ExecuteNonQuery();
            update.Cancel();
            conn.Close();
            conn.Open();
            sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)"; 
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd.Parameters.AddWithValue("@pwd", Session["password"].ToString());
            cmd.Parameters.AddWithValue("@tname", "紅綠色弱4"); 
            cmd.Parameters.AddWithValue("@r", Convert.ToInt32(185 / 2.55));
            cmd.Parameters.AddWithValue("@g", Convert.ToInt32(122 / 2.55));
            cmd.Parameters.AddWithValue("@b", Convert.ToInt32(87 / 2.55));
            cmd.Parameters.AddWithValue("@a", 40);
            cmd.Parameters.AddWithValue("@retime", 0);
            cmd.Parameters.AddWithValue("@restatus", "0");
            cmd.Parameters.AddWithValue("@setmode", "1");
            cmd.Parameters.AddWithValue("@bright", "0");
            cmd.Parameters.AddWithValue("@str_isremind", "false");
            cmd.Parameters.AddWithValue("@str_light", "manually");
            cmd.Parameters.AddWithValue("@str_isadd", "true");
            cmd.Parameters.AddWithValue("@default_set", "1");
            cmd.ExecuteNonQuery();

            cmd.Cancel();
            conn.Close();
            conn.Open();
            sql = "UPDATE apiset SET m_name=@name,filltercolor=@filter,bgcolor=@bgcolor,bgcoloropacity=@bgopacity,filltercoloropacity=@fillteropacity WHERE  m_name=@name";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd1.Parameters.AddWithValue("@bgcolor", "185,122,87");
            cmd1.Parameters.AddWithValue("@filter", "#B97A57");
            cmd1.Parameters.AddWithValue("@bgopacity", 0.2);
            cmd1.Parameters.AddWithValue("@fillteropacity", 0.2);
            cmd1.ExecuteNonQuery();
            cmd1.Cancel();
            conn.Close();
            Response.Write("<script>alert('新增環境成功!'top.location.href='user.aspx';); </script>");
        }
    }
    protected void add5_Click(object sender, EventArgs e)
    {
        String sql = "";
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();
        sql = "select * from Theme where m_name=@name and t_name=@t_name";
        SqlCommand repeat = new SqlCommand(sql, conn);
        repeat.Parameters.AddWithValue("@name", Session["name"].ToString());
        repeat.Parameters.AddWithValue("@t_name", "藍綠(黃)色弱1");
        SqlDataReader dr;
        dr = repeat.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('您已經新增過這個主題了!'); </script>");
            repeat.Cancel();
            dr.Close();
            conn.Close();

        }
        else
        {
            conn.Close();
            dr.Close();
            repeat.Cancel();
            conn.Open();
            sql = "UPDATE Theme SET default_set=0 where m_name=@name";
            SqlCommand update = new SqlCommand(sql, conn);
            update.Parameters.AddWithValue("@name", Session["name"].ToString());

            update.ExecuteNonQuery();
            update.Cancel();
            conn.Close();
            conn.Open();
            sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)"; 
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd.Parameters.AddWithValue("@pwd", Session["password"].ToString());
            cmd.Parameters.AddWithValue("@tname", "藍綠(黃)色弱1");
            cmd.Parameters.AddWithValue("@r", Convert.ToInt32(136 / 2.55));
            cmd.Parameters.AddWithValue("@g", 0);
            cmd.Parameters.AddWithValue("@b", Convert.ToInt32(21 / 2.55));
            cmd.Parameters.AddWithValue("@a", 40);
            cmd.Parameters.AddWithValue("@retime", 0);
            cmd.Parameters.AddWithValue("@restatus", "0");
            cmd.Parameters.AddWithValue("@setmode", "1");
            cmd.Parameters.AddWithValue("@bright", "0");
            cmd.Parameters.AddWithValue("@str_isremind", "false");
            cmd.Parameters.AddWithValue("@str_light", "manually");
            cmd.Parameters.AddWithValue("@str_isadd", "true");
            cmd.Parameters.AddWithValue("@default_set", "1");
            cmd.ExecuteNonQuery();

            cmd.Cancel();
            conn.Close();
            conn.Open();
            sql = "UPDATE apiset SET m_name=@name,filltercolor=@filter,bgcolor=@bgcolor,bgcoloropacity=@bgopacity,filltercoloropacity=@fillteropacity WHERE  m_name=@name";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd1.Parameters.AddWithValue("@bgcolor", "136,0,21");
            cmd1.Parameters.AddWithValue("@filter", "#880015");
            cmd1.Parameters.AddWithValue("@bgopacity", 0.2);
            cmd1.Parameters.AddWithValue("@fillteropacity", 0.2);
            cmd1.ExecuteNonQuery();
            cmd1.Cancel();
            conn.Close();
            Response.Write("<script>alert('新增環境成功!');top.location.href='user.aspx'; </script>");
        }
    }
    protected void add6_Click(object sender, EventArgs e)
    {
        String sql = "";
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();
        sql = "select * from Theme where m_name=@name and t_name=@t_name";
        SqlCommand repeat = new SqlCommand(sql, conn);
        repeat.Parameters.AddWithValue("@name", Session["name"].ToString());
        repeat.Parameters.AddWithValue("@t_name", "藍綠(黃)色弱2");
        SqlDataReader dr;
        dr = repeat.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('您已經新增過這個主題了!'); </script>");
            repeat.Cancel();
            dr.Close();
            conn.Close();

        }
        else
        {
            conn.Close();
            dr.Close();
            repeat.Cancel();
            conn.Open();
            sql = "UPDATE Theme SET default_set=0 where m_name=@name";
            SqlCommand update = new SqlCommand(sql, conn);
            update.Parameters.AddWithValue("@name", Session["name"].ToString());

            update.ExecuteNonQuery();
            update.Cancel();
            conn.Close();
            conn.Open();
            sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)"; 
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd.Parameters.AddWithValue("@pwd", Session["password"].ToString());
            cmd.Parameters.AddWithValue("@tname", "藍綠(黃)色弱2"); 
            cmd.Parameters.AddWithValue("@r", Convert.ToInt32(163 / 2.55));
            cmd.Parameters.AddWithValue("@g", Convert.ToInt32(73 / 2.55));
            cmd.Parameters.AddWithValue("@b", Convert.ToInt32(164 / 2.55));
            cmd.Parameters.AddWithValue("@a", 40);
            cmd.Parameters.AddWithValue("@retime", 0);
            cmd.Parameters.AddWithValue("@restatus", "0");
            cmd.Parameters.AddWithValue("@setmode", "1");
            cmd.Parameters.AddWithValue("@bright", "0");
            cmd.Parameters.AddWithValue("@str_isremind", "false");
            cmd.Parameters.AddWithValue("@str_light", "manually");
            cmd.Parameters.AddWithValue("@str_isadd", "true");
            cmd.Parameters.AddWithValue("@default_set", "1");
            cmd.ExecuteNonQuery();

            cmd.Cancel();
            conn.Close();
            conn.Open();
            sql = "UPDATE apiset SET m_name=@name,filltercolor=@filter,bgcolor=@bgcolor,bgcoloropacity=@bgopacity,filltercoloropacity=@fillteropacity WHERE  m_name=@name";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd1.Parameters.AddWithValue("@bgcolor", "163,73,164");
            cmd1.Parameters.AddWithValue("@filter", "#A349A4");
            cmd1.Parameters.AddWithValue("@bgopacity", 0.2);
            cmd1.Parameters.AddWithValue("@fillteropacity", 0.2);
            cmd1.ExecuteNonQuery();
            cmd1.Cancel();
            conn.Close();
            Response.Write("<script>alert('新增環境成功!');top.location.href='user.aspx'; </script>");
        }
    }
    protected void add7_Click(object sender, EventArgs e)
    {
        String sql = "";
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();
        sql = "select * from Theme where m_name=@name and t_name=@t_name";
        SqlCommand repeat = new SqlCommand(sql, conn);
        repeat.Parameters.AddWithValue("@name", Session["name"].ToString());
        repeat.Parameters.AddWithValue("@t_name", "藍綠(黃)色弱3");
        SqlDataReader dr;
        dr = repeat.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('您已經新增過這個主題了!'); </script>");
            repeat.Cancel();
            dr.Close();
            conn.Close();

        }
        else
        {
            conn.Close();
            dr.Close();
            repeat.Cancel();
            conn.Open();
            sql = "UPDATE Theme SET default_set=0 where m_name=@name";
            SqlCommand update = new SqlCommand(sql, conn);
            update.Parameters.AddWithValue("@name", Session["name"].ToString());

            update.ExecuteNonQuery();
            update.Cancel();
            conn.Close();
            conn.Open();
            sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)"; 
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd.Parameters.AddWithValue("@pwd", Session["password"].ToString());
            cmd.Parameters.AddWithValue("@tname", "藍綠(黃)色弱3");  
            cmd.Parameters.AddWithValue("@r", Convert.ToInt32(195 / 2.55));
            cmd.Parameters.AddWithValue("@g", Convert.ToInt32(195 / 2.55));
            cmd.Parameters.AddWithValue("@b", Convert.ToInt32(195 / 2.55));
            cmd.Parameters.AddWithValue("@a", 40);
            cmd.Parameters.AddWithValue("@retime", 0);
            cmd.Parameters.AddWithValue("@restatus", "0");
            cmd.Parameters.AddWithValue("@setmode", "1");
            cmd.Parameters.AddWithValue("@bright", "0");
            cmd.Parameters.AddWithValue("@str_isremind", "false");
            cmd.Parameters.AddWithValue("@str_light", "manually");
            cmd.Parameters.AddWithValue("@str_isadd", "true");
            cmd.Parameters.AddWithValue("@default_set", "1");
            cmd.ExecuteNonQuery();

            cmd.Cancel();
            conn.Close();
            conn.Open();
            sql = "UPDATE apiset SET m_name=@name,filltercolor=@filter,bgcolor=@bgcolor,bgcoloropacity=@bgopacity,filltercoloropacity=@fillteropacity WHERE  m_name=@name";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd1.Parameters.AddWithValue("@bgcolor", "195,195,195");
            cmd1.Parameters.AddWithValue("@filter", "#C3C3C3");
            cmd1.Parameters.AddWithValue("@bgopacity", 0.2);
            cmd1.Parameters.AddWithValue("@fillteropacity", 0.2);
            cmd1.ExecuteNonQuery();
            cmd1.Cancel();
            conn.Close();
            Response.Write("<script>alert('新增環境成功!'); top.location.href='user.aspx';</script>");
        }
    }
    protected void add8_Click(object sender, EventArgs e)
    {
        String sql = "";
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();
        sql = "select * from Theme where m_name=@name and t_name=@t_name";
        SqlCommand repeat = new SqlCommand(sql, conn);
        repeat.Parameters.AddWithValue("@name", Session["name"].ToString());
        repeat.Parameters.AddWithValue("@t_name", "藍綠(黃)色弱4");
        SqlDataReader dr;
        dr = repeat.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('您已經新增過這個主題了!'); </script>");
            repeat.Cancel();
            dr.Close();
            conn.Close();

        }
        else
        {
            conn.Close();
            dr.Close();
            repeat.Cancel();
            conn.Open();
            sql = "UPDATE Theme SET default_set=0 where m_name=@name";
            SqlCommand update = new SqlCommand(sql, conn);
            update.Parameters.AddWithValue("@name", Session["name"].ToString());

            update.ExecuteNonQuery();
            update.Cancel();
            conn.Close();
            conn.Open();
            sql = "insert into [Theme] (m_name,m_pwd,t_name,r_color,g_color,b_color,a_color,re_time,re_status,setmode,brightness,str_isadd,str_isremind,str_light,default_set) values (@name,@pwd,@tname,@r,@g,@b,@a,@retime,@restatus,@setmode,@bright,@str_isadd,@str_isremind,@str_light,@default_set)"; 
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd.Parameters.AddWithValue("@pwd", Session["password"].ToString());
            cmd.Parameters.AddWithValue("@tname", "藍綠(黃)色弱4");  // background-color:rgb(153,217,234);color:rgb(150,150,150);
            cmd.Parameters.AddWithValue("@r", Convert.ToInt32(239 / 2.55));
            cmd.Parameters.AddWithValue("@g", Convert.ToInt32(228 / 2.55));
            cmd.Parameters.AddWithValue("@b", Convert.ToInt32(176 / 2.55));
            cmd.Parameters.AddWithValue("@a", 40);
            cmd.Parameters.AddWithValue("@retime", 0);
            cmd.Parameters.AddWithValue("@restatus", "0");
            cmd.Parameters.AddWithValue("@setmode", "1");
            cmd.Parameters.AddWithValue("@bright", "0");
            cmd.Parameters.AddWithValue("@str_isremind", "false");
            cmd.Parameters.AddWithValue("@str_light", "manually");
            cmd.Parameters.AddWithValue("@str_isadd", "true");
            cmd.Parameters.AddWithValue("@default_set", "1");
            cmd.ExecuteNonQuery();

            cmd.Cancel();
            conn.Close();
            conn.Open();
            sql = "UPDATE apiset SET m_name=@name,filltercolor=@filter,bgcolor=@bgcolor,bgcoloropacity=@bgopacity,filltercoloropacity=@fillteropacity WHERE  m_name=@name";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.Parameters.AddWithValue("@name", Session["name"].ToString());
            cmd1.Parameters.AddWithValue("@bgcolor", "239,228,176");
            cmd1.Parameters.AddWithValue("@filter", "#EFE4B0");
            cmd1.Parameters.AddWithValue("@bgopacity", 0.2);
            cmd1.Parameters.AddWithValue("@fillteropacity", 0.2);
            cmd1.ExecuteNonQuery();
            cmd1.Cancel();
            conn.Close();
            Response.Write("<script>alert('新增環境成功!');top.location.href='user.aspx'; </script>");
        }
    }
}