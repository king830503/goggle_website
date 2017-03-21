using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["name"] == null)
        {
            Response.Write("<script>alert('登入時效已過，請重新登入!');location.href='index.aspx';</script>");
        }
        else
        {
            Session["Login"] = "ok";
            user.Text = Session["name"].ToString();
            string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlDataReader dr1;
            SqlCommand cmd1 = new SqlCommand("select * from [member] where m_name='" + Session["name"] + "'", conn);
            dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                if (dr1[4].ToString() == null || dr1[4].ToString() == "")
                {
                    Image1.ImageUrl = "user-images/people.png";
                }
                else
                {
                    Image1.ImageUrl = "user-images/" + dr1[4].ToString();
                }
                user.Text = dr1[1].ToString();

                dr1.Close();
                conn.Close();
                cmd1.Cancel();

            }
        }

        SqlDataSource db = new SqlDataSource();
        db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
        db.SelectCommand = "select * from votecolor ";

        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);
        if (!IsPostBack)
        {
            voteitem.Text += "<ul style='font-size:2.8em; text-align: center; list-style: none;'>";
            voteitem.Text += "<li style='margin-bottom: 15px; padding-top:1em;'>";
            voteitem.Text += "<div style='float: left;'>";
            voteitem.Text += "<div id='vote1'>";
            voteitem.Text += "<div><a class='group1' href='content/1.aspx' >";
            voteitem.Text += "<div class='s3' style='width:310px;height:100px;color:rgb(" + dv.Table.Rows[0][8].ToString() + "," + dv.Table.Rows[0][9].ToString() + "," + dv.Table.Rows[0][10].ToString() + "); background-color: rgb(" + dv.Table.Rows[0][2].ToString() + "," + dv.Table.Rows[0][3].ToString() + "," + dv.Table.Rows[0][4].ToString() + ");'>";
            voteitem.Text += dv.Table.Rows[0][0].ToString() + "</div></a></div></div>";
            voteitem.Text += " <div class='votenum2'>" + dv.Table.Rows[0][1].ToString() + "票</div>";
            div1.Text = "</div>";
            voteitem2.Text += "<div style='float: right;'>" + "<div id='vote2'>";
            voteitem2.Text += "<div><a class='group1' href='content/2.aspx'>";
            voteitem2.Text += "<div class='s4' style='width:310px;height:100px;color:rgb(" + dv.Table.Rows[1][8].ToString() + "," + dv.Table.Rows[1][9].ToString() + "," + dv.Table.Rows[1][10].ToString() + "); background-color: rgb(" + dv.Table.Rows[1][2].ToString() + "," + dv.Table.Rows[1][3].ToString() + "," + dv.Table.Rows[1][4].ToString() + ");'>";
            voteitem2.Text += dv.Table.Rows[1][0] + "</div></a></div></div>";
            voteitem2.Text += "<div class='votenum2'>" + dv.Table.Rows[1][1].ToString() + "票</div>";
            div2.Text = "</div>  </li>";
            voteitem3.Text += " <li style='margin-bottom: 15px; margin-top: 5em;'>";
            voteitem3.Text += " <div style='float: left'>" + "<div id='vote3'>";
            voteitem3.Text += "<div><a class='group1' href='content/3.aspx'>";
            voteitem3.Text += "<div class='s5' style='width:310px;height:100px;color:rgb(" + dv.Table.Rows[2][8].ToString() + "," + dv.Table.Rows[2][9].ToString() + "," + dv.Table.Rows[2][10].ToString() + "); background-color: rgb(" + dv.Table.Rows[2][2].ToString() + "," + dv.Table.Rows[2][3].ToString() + "," + dv.Table.Rows[2][4].ToString() + ");'>";
            voteitem3.Text += dv.Table.Rows[2][0] + "</div></a></div></div>";
            voteitem3.Text += "<div class='votenum2'>" + dv.Table.Rows[2][1].ToString() + "票</div>";
            div3.Text = "</div>";
            voteitem4.Text += "<div style='float: right;'>" + "<div id='vote4'>";
            voteitem4.Text += "<div><a class='group1' href='content/4.aspx'>";
            voteitem4.Text += "<div class='s6' style='width:310px;height:100px;color:rgb(" + dv.Table.Rows[3][8].ToString() + "," + dv.Table.Rows[3][9].ToString() + "," + dv.Table.Rows[3][10].ToString() + "); background-color: rgb(" + dv.Table.Rows[3][2].ToString() + "," + dv.Table.Rows[3][3].ToString() + "," + dv.Table.Rows[3][4].ToString() + ");'>";
            voteitem4.Text += dv.Table.Rows[3][0] + "</div></a></div></div>";
            voteitem4.Text += "<div class='votenum2'>" + dv.Table.Rows[3][1].ToString() + "票</div>";
            div4.Text = "</div>  </li>";
            voteitem5.Text += " <li style='margin-bottom: 15px; margin-top: 5em;'>";
            voteitem5.Text += " <div style='float: left;'>" + "<div id='vote5'>";
            voteitem5.Text += "<div><a class='group1' href='content/5.aspx'>";
            voteitem5.Text += "<div class='s7' style='width:310px;height:100px;color:rgb(" + dv.Table.Rows[4][8].ToString() + "," + dv.Table.Rows[4][9].ToString() + "," + dv.Table.Rows[4][10].ToString() + "); background-color: rgb(" + dv.Table.Rows[4][2].ToString() + "," + dv.Table.Rows[4][3].ToString() + "," + dv.Table.Rows[4][4].ToString() + ");'>";
            voteitem5.Text += dv.Table.Rows[4][0] + "</div></a></div></div>";
            voteitem5.Text += "<div class='votenum2'>" + dv.Table.Rows[4][1].ToString() + "票</div>";
            div5.Text = "</div>";
            voteitem6.Text += "<div style='float: right;'>" + "<div id='vote6'>";
            voteitem6.Text += "<div><a class='group1' href='content/6.aspx'>";
            voteitem6.Text += "<div class='s8' style='width:310px;height:100px;color:rgb(" + dv.Table.Rows[5][8].ToString() + "," + dv.Table.Rows[5][9].ToString() + "," + dv.Table.Rows[5][10].ToString() + "); background-color: rgb(" + dv.Table.Rows[5][2].ToString() + "," + dv.Table.Rows[5][3].ToString() + "," + dv.Table.Rows[5][4].ToString() + ");'>";
            voteitem6.Text += dv.Table.Rows[5][0] + "</div></a></div></div>";
            voteitem6.Text += "<div class='votenum2'>" + dv.Table.Rows[5][1].ToString() + "票</div>";
            div6.Text = "</div></li></ul>";
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlDataSource db = new SqlDataSource();

        db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
        db.SelectCommand = "select m_vote from member where m_name='" + Session["name"].ToString() + "'";
        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);




        //資料庫注意修改!!
        if (dv.Table.Rows[0][0].ToString() == "0")
        {
            String sql = "";
            String sqldb = @"Data Source =king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
            SqlConnection conn = new SqlConnection(sqldb);
            conn.Open();
            sql = "update votecolor set v_num = v_num+1 where v_id=1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
            reader.Close();
            Response.AddHeader("Refresh", "0");
            Response.Write("<script>alert('投票完成');location.href='avote.aspx'  </script>");


            conn.Open();
            String voo = "";
            voo = "update member set m_vote = m_vote+1 where m_name = '" + Session["name"].ToString() + "'";
            SqlCommand cdm = new SqlCommand(voo, conn);
            SqlDataReader rder = cdm.ExecuteReader();
            conn.Close();
            rder.Close();


        }
        else
        {
            Response.Write("<script>alert('您已經投過票了!');  </script>");




        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlDataSource db = new SqlDataSource();

        db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
        db.SelectCommand = "select m_vote from member where m_name='" + Session["name"].ToString() + "'";
        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);

        String vot = Session["vo"].ToString();


        //資料庫注意修改!!
        if (dv.Table.Rows[0][0].ToString() == "0")
        {
            String sql = "";
            String sqldb = @"Data Source =king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
            SqlConnection conn = new SqlConnection(sqldb);
            conn.Open();
            sql = "update votecolor set v_num = v_num+1 where  v_id=2";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
            reader.Close();
            Response.AddHeader("Refresh", "0");
            Response.Write("<script>alert('投票完成');location.href='avote.aspx'  </script>");


            conn.Open();
            String voo = "";
            voo = "update member set m_vote = m_vote+1 where m_name = '" + Session["name"].ToString() + "'";
            SqlCommand cdm = new SqlCommand(voo, conn);
            SqlDataReader rder = cdm.ExecuteReader();
            conn.Close();
            rder.Close();


        }
        else
        {
            Response.Write("<script>alert('您已經投過票了!');  </script>");
        }


    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlDataSource db = new SqlDataSource();

        db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
        db.SelectCommand = "select m_vote from member where m_name='" + Session["name"].ToString() + "'";
        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);

        String vot = Session["vo"].ToString();


        //資料庫注意修改!!
        if (dv.Table.Rows[0][0].ToString() == "0")
        {
            String sql = "";
            String sqldb = @"Data Source =king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
            SqlConnection conn = new SqlConnection(sqldb);
            conn.Open();
            sql = "update votecolor set v_num = v_num+1 where  v_id=3";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
            reader.Close();
            Response.AddHeader("Refresh", "0");
            Response.Write("<script>alert('投票完成');location.href='avote.aspx'  </script>");


            conn.Open();
            String voo = "";
            voo = "update member set m_vote = m_vote+1 where m_name = '" + Session["name"].ToString() + "'";
            SqlCommand cdm = new SqlCommand(voo, conn);
            SqlDataReader rder = cdm.ExecuteReader();
            conn.Close();
            rder.Close();


        }
        else
        {
            Response.Write("<script>alert('您已經投過票了!');  </script>");
        }


    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlDataSource db = new SqlDataSource();

        db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
        db.SelectCommand = "select m_vote from member where m_name='" + Session["name"].ToString() + "'";
        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);

        String vot = Session["vo"].ToString();


        //資料庫注意修改!!
        if (dv.Table.Rows[0][0].ToString() == "0")
        {
            String sql = "";
            String sqldb = @"Data Source =king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
            SqlConnection conn = new SqlConnection(sqldb);
            conn.Open();
            sql = "update votecolor set v_num = v_num+1 where  v_id=4";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
            reader.Close();
            Response.AddHeader("Refresh", "0");
            Response.Write("<script>alert('投票完成');location.href='avote.aspx'  </script>");


            conn.Open();
            String voo = "";
            voo = "update member set m_vote = m_vote+1 where m_name = '" + Session["name"].ToString() + "'";
            SqlCommand cdm = new SqlCommand(voo, conn);
            SqlDataReader rder = cdm.ExecuteReader();
            conn.Close();
            rder.Close();


        }
        else
        {
            Response.Write("<script>alert('您已經投過票了!');  </script>");
        }


    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlDataSource db = new SqlDataSource();

        db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
        db.SelectCommand = "select m_vote from member where m_name='" + Session["name"].ToString() + "'";
        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);

        String vot = Session["vo"].ToString();


        //資料庫注意修改!!
        if (dv.Table.Rows[0][0].ToString() == "0")
        {
            String sql = "";
            String sqldb = @"Data Source =king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
            SqlConnection conn = new SqlConnection(sqldb);
            conn.Open();
            sql = "update votecolor set v_num = v_num+1 where  v_id=5";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
            reader.Close();
            Response.AddHeader("Refresh", "0");
            Response.Write("<script>alert('投票完成');location.href='avote.aspx'  </script>");


            conn.Open();
            String voo = "";
            voo = "update member set m_vote = m_vote+1 where m_name = '" + Session["name"].ToString() + "'";
            SqlCommand cdm = new SqlCommand(voo, conn);
            SqlDataReader rder = cdm.ExecuteReader();
            conn.Close();
            rder.Close();


        }
        else
        {
            Response.Write("<script>alert('您已經投過票了!');  </script>");
        }


    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        SqlDataSource db = new SqlDataSource();

        db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
        db.SelectCommand = "select m_vote from member where m_name='" + Session["name"].ToString() + "'";
        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);

        String vot = Session["vo"].ToString();


        //資料庫注意修改!!
        if (dv.Table.Rows[0][0].ToString() == "0")
        {
            String sql = "";
            String sqldb = @"Data Source =king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
            SqlConnection conn = new SqlConnection(sqldb);
            conn.Open();
            sql = "update votecolor set v_num = v_num+1 where  v_id=6";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
            reader.Close();
            Response.AddHeader("Refresh", "0");
            Response.Write("<script>alert('投票完成');location.href='avote.aspx'  </script>");


            conn.Open();
            String voo = "";
            voo = "update member set m_vote = m_vote+1 where m_name = '" + Session["name"].ToString() + "'";
            SqlCommand cdm = new SqlCommand(voo, conn);
            SqlDataReader rder = cdm.ExecuteReader();
            conn.Close();
            rder.Close();


        }
        else
        {
            Response.Write("<script>alert('您已經投過票了!');  </script>");
        }


    }
}