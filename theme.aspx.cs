using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_set : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstring);

        if (!Page.IsPostBack)
        {

            SqlDataSource db = new SqlDataSource();
            db.ConnectionString = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
            db.SelectCommand = "select * from [Theme] where m_name='" + Session["name"] + "'";
            DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);
            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                appTheme.Items.Add(dv.ToTable().Rows[i][2].ToString());
            }
            conn.Close();
            conn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select * from [Theme] where t_name=@tname and m_name=@name", conn);
            cmd.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd.Parameters.AddWithValue("@name",Session["name"].ToString());
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                appTheme.SelectedValue = dr[2].ToString();
                    ArrayList colorArr = new ArrayList();
                    int R = Convert.ToInt32(Convert.ToInt16(dr[3].ToString()) * 2.55);
                    int G = Convert.ToInt32(Convert.ToInt16(dr[4].ToString()) * 2.55);
                    int B = Convert.ToInt32(Convert.ToInt16(dr[5].ToString()) * 2.55);
                    colorArr.Add(R);
                    colorArr.Add(G);
                    colorArr.Add(B);
                    colorArr.Sort();
                    float max = Convert.ToInt32(colorArr[colorArr.Count - 1]);
                    float mix = Convert.ToInt32(colorArr[0]);
                    filtercolor.Value = string.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);

                if (dr[11].ToString().Trim() == "true")
                {
                    appfliterset.SelectedValue = "true";
                    filtercolor.Visible = true;
                    filtertxt.Value = dr[6].ToString();
                    appfilter.Value = dr[6].ToString();
                }
                else
                {
                    appfliterset.SelectedValue = "false";
                    filtertxt.Value = "";
                    filtercolor.Visible = false;
                    appfilter.Disabled = true;
                    filtertxt.Disabled = true;

                }

                if (dr[13].ToString().Trim() == "auto")
                {
                    appset.SelectedValue = "auto";
                    applight.Disabled = true;
                    light.Value = "";
                    light.Disabled = true;
                }
                else if (dr[13].ToString().Trim() == "sys_auto")
                {
                    appset.SelectedValue = "sys_auto";
                    applight.Disabled = true;
                    light.Value = "";
                    light.Disabled = true;
                }
                else
                {
                    appset.SelectedValue = "manually";
                    applight.Value = dr[10].ToString();
                    light.Value = dr[10].ToString();
                    applight.Disabled = false;
                    light.Disabled = false;
                }

                if (dr[12].ToString().Trim() == "true")
                {
                    remind.SelectedValue = "true";
                    time.Text = "";
                    remindtime.Enabled = true;
                    if (dr[8].ToString() == "1")
                    {
                        //30min
                        remindtime.SelectedValue = "1";
                        time.Enabled = false;
                        time.Text = "";
                    }
                    else if (dr[8].ToString() == "2")
                    {
                        //60min
                        remindtime.SelectedValue = "2";
                        time.Enabled = false;
                        time.Text = "";
                    }
                    else if (dr[8].ToString() == "3")
                    {
                        //120min
                        remindtime.SelectedValue = "3";
                        time.Enabled = false;
                        time.Text = "";
                    }
                    else
                    {
                        //自訂
                        remindtime.SelectedValue = "4";
                        time.Enabled = true;
                        time.Text = (Convert.ToDouble(dr[7].ToString()) / 60000).ToString();

                    }
                }
                else
                {
                    remind.SelectedValue = "false";
                    remindtime.Enabled = false;
                    time.Text = "";
                }
                //提醒時間
            }
            cmd.Dispose();
            dr.Close();
            conn.Close();
            
                conn.Open();
                SqlDataReader drapi;
                SqlCommand apicmd = new SqlCommand("select * from [apiset] where m_name='" + Session["name"] + "'", conn);
                drapi = apicmd.ExecuteReader();


                if (drapi.Read())
                {

                    string rgbstr = drapi[2].ToString();
                    string[] rgb = rgbstr.Split(',');
                    ArrayList colorArr = new ArrayList();
                    int red = Convert.ToInt16(rgbstr.Split(',')[0]);
                    int green = Convert.ToInt16(rgbstr.Split(',')[1]);
                    int blue = Convert.ToInt16(rgbstr.Split(',')[2]);
                    colorArr.Add(red);
                    colorArr.Add(green);
                    colorArr.Add(blue);
                    colorArr.Sort();
                    float max = Convert.ToInt16(colorArr[colorArr.Count - 1]);
                    float mix = Convert.ToInt16(colorArr[0]);
                    bgcolor.Value = string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);
                    double alpha = (Convert.ToDouble(drapi[3].ToString()) * 100);
                    bgtxt.Value = alpha.ToString();//bgtxt背景濃度
                    apibg.Value = alpha.ToString();//apibg range背景濃度
                    apifilter.Value = drapi[1].ToString();
                    plugfilter.Value = (Convert.ToDouble(drapi[4].ToString()) * 100).ToString();  //range濾鏡濃度
                    apifr.Value = (Convert.ToDouble(drapi[4].ToString()) * 100).ToString();
                    fontsize.SelectedValue = drapi[5].ToString();
                    drapi.Close();
                    conn.Close();
                    conn.Dispose();
                    apicmd.Cancel();
                }
            }
            



        //199



    }
    protected void appsubmit_Click(object sender, EventArgs e)
    {
        String sqldb = @"Data Source=king0503-pc\sqlexpress;Initial Catalog=test;User ID=sa;Password=f502";
        SqlConnection conn = new SqlConnection(sqldb);
        conn.Open();

        string myColor = filtercolor.Value;

        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(myColor);
        //亮度手動，濾鏡開，提醒開，時間30分鐘或60分鐘或2小時
        if (appset.SelectedValue == "manually" && appfliterset.SelectedValue == "true" && remind.SelectedValue == "true" && remindtime.SelectedValue == "1" || remindtime.SelectedValue == "2" || remindtime.SelectedValue == "3")
        {
            String strSQL = "UPDATE Theme SET t_name=@tname,r_color=@r,g_color=@g,b_color=@b,a_color=@a,brightness=@bright,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE m_name=@name and t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@name", Session["name"]);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@r", Convert.ToInt16(c.R / 2.55));
            cmd1.Parameters.AddWithValue("@b",Convert.ToInt16(c.B /2.55));
            cmd1.Parameters.AddWithValue("@g", Convert.ToInt16(c.G / 2.55));
            cmd1.Parameters.AddWithValue("@a", filtertxt.Value.Trim());
            cmd1.Parameters.AddWithValue("@bright", light.Value.Trim());
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "2");
            cmd1.ExecuteNonQuery();
            conn.Close();
            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }


        //亮度手動，濾鏡開，提醒開，時間自訂
        else if (appset.SelectedValue == "manually" && appfliterset.SelectedValue == "true" && remind.SelectedValue == "true" && remindtime.SelectedValue == "4")
        {//亮度自動1手動2系統自動3

            String strSQL = "UPDATE Theme SET t_name=@tname,r_color=@r,g_color=@g,b_color=@b,a_color=@a,brightness=@bright,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,re_time=@time,setmode=@brightset WHERE t_name=@tname";


            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@r", Convert.ToInt16(c.R / 2.55));
            cmd1.Parameters.AddWithValue("@b", Convert.ToInt16(c.B /2.55));
            cmd1.Parameters.AddWithValue("@g", Convert.ToInt16(c.G /2.55));
            cmd1.Parameters.AddWithValue("@a", filtertxt.Value.Trim());
            cmd1.Parameters.AddWithValue("@bright", light.Value.Trim());
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "2");
            cmd1.Parameters.AddWithValue("@time", Convert.ToString(Convert.ToDouble(time.Text.Trim()) * 60000));
            cmd1.ExecuteNonQuery();
            conn.Close();
            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }
        //亮度手動，濾鏡關，提醒開，時間30分鐘或60分鐘或2小時
        else if (appset.SelectedValue == "manually" && appfliterset.SelectedValue == "false" && remind.SelectedValue == "true" && remindtime.SelectedValue == "1" || remindtime.SelectedValue == "2" || remindtime.SelectedValue == "3")
        {

            String strSQL = "UPDATE Theme SET t_name=@tname,brightness=@bright,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@bright", light.Value.Trim());
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "2");

            cmd1.ExecuteNonQuery();
            conn.Close();
            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');location.href='Theme.aspx';</script>");
        }
        //亮度手動，濾鏡關，提醒開，時間自訂
        else if (appset.SelectedValue == "manually" && appfliterset.SelectedValue == "false" && remind.SelectedValue == "true" && remindtime.SelectedValue == "4")
        {//自動1手動2系統自動3

            String strSQL = "UPDATE Theme SET t_name=@tname,brightness=@bright,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,re_time=@time,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);

            cmd1.Parameters.AddWithValue("@bright", light.Value);
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "2");
            cmd1.Parameters.AddWithValue("@time", Convert.ToString(Convert.ToDouble(time.Text.Trim()) * 60000));
            cmd1.ExecuteNonQuery();

            conn.Close();

            cmd1.Cancel();
            Response.Write("<script>alert('主題修改成功!');location.href='Theme.aspx';</script>");
        }
        //亮度手動，濾鏡關，提醒關，時間空值
        else if (appset.SelectedValue == "manually" && appfliterset.SelectedValue == "false" && remind.SelectedValue == "false")
        {//自動1手動2系統自動3

            String strSQL = "UPDATE Theme SET t_name=@tname,r_color=@r,g_color=@g,b_color=@b,a_color=@a,brightness=@bright,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);

            cmd1.Parameters.AddWithValue("@bright", light.Value.Trim());
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "2");

            cmd1.ExecuteNonQuery();
            conn.Close();

            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }

        //亮度手動，濾鏡開，提醒關，時間空值
        else if (appset.SelectedValue == "manually" && appfliterset.SelectedValue == "true" && remind.SelectedValue == "false")
        {//自動1手動2系統自動3

            String strSQL = "UPDATE Theme SET t_name=@tname,r_color=@r,g_color=@g,b_color=@b,a_color=@a,brightness=@bright,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@r", Convert.ToInt16(c.R / 2.55));
            cmd1.Parameters.AddWithValue("@b", Convert.ToInt16(c.B / 2.55));
            cmd1.Parameters.AddWithValue("@g", Convert.ToInt16(c.G / 2.55));
            cmd1.Parameters.AddWithValue("@a", filtertxt.Value.Trim());
            cmd1.Parameters.AddWithValue("@bright", light.Value.Trim());
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "2");
            cmd1.ExecuteNonQuery();

            conn.Close();

            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }
        //亮度自動,濾鏡開，提醒開，時間30分鐘或60分鐘或2小時
        else if (appset.SelectedValue == "auto" && appfliterset.SelectedValue == "true" && remind.SelectedValue == "true" && remindtime.SelectedValue == "1" || remindtime.SelectedValue == "2" || remindtime.SelectedValue == "3")
        {

            String strSQL = "UPDATE Theme SET t_name=@tname,r_color=@r,g_color=@g,b_color=@b,a_color=@a,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@r", Convert.ToInt16(c.R /2.55));
            cmd1.Parameters.AddWithValue("@b", Convert.ToInt16(c.B / 2.55));
            cmd1.Parameters.AddWithValue("@g", Convert.ToInt16(c.G / 2.55));
            cmd1.Parameters.AddWithValue("@a", filtertxt.Value.Trim());

            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "1");


            cmd1.ExecuteNonQuery();
            conn.Close();

            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }
        //亮度自動,濾鏡開，提醒開，時間自訂
        else if (appset.SelectedValue == "auto" && appfliterset.SelectedValue == "true" && remind.SelectedValue == "true" && remindtime.SelectedValue == "4")
        {
            String strSQL = "UPDATE Theme SET t_name=@tname,r_color=@r,g_color=@g,b_color=@b,a_color=@a,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,re_time=@time,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@r", Convert.ToInt16(c.R / 2.55));
            cmd1.Parameters.AddWithValue("@b", Convert.ToInt16(c.B / 2.55));
            cmd1.Parameters.AddWithValue("@g", Convert.ToInt16(c.G / 2.55));
            cmd1.Parameters.AddWithValue("@a", filtertxt.Value.Trim());
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "1");
            cmd1.Parameters.AddWithValue("@time", Convert.ToString(Convert.ToDouble(time.Text.Trim()) * 60000));

            cmd1.ExecuteNonQuery();

            conn.Close();
            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');location.href='Theme.aspx';</script>");
        }
        //亮度自動，濾鏡關，提醒開，時間30分鐘或60分鐘或2小時
        else if (appset.SelectedValue == "auto" && appfliterset.SelectedValue == "false" && remind.SelectedValue == "true" && remindtime.SelectedValue == "1" || remindtime.SelectedValue == "2" || remindtime.SelectedValue == "3")
        {

            String strSQL = "UPDATE Theme SET t_name=@tname,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "1");
            cmd1.ExecuteNonQuery();

            conn.Close();
            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }
        //亮度自動，濾鏡關，提醒開，時間自訂
        else if (appset.SelectedValue == "auto" && appfliterset.SelectedValue == "false" && remind.SelectedValue == "false" && remindtime.SelectedValue == "4")
        {//自動1手動2系統自動3

            String strSQL = "UPDATE Theme SET t_name=@tname,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,re_time=@time,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "1");
            cmd1.Parameters.AddWithValue("@time", Convert.ToString(Convert.ToDouble(time.Text.Trim()) * 60000));
            cmd1.ExecuteNonQuery();

            conn.Close();
            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }
        //亮度自動，濾鏡關，提醒關，時間空值
        else if (appset.SelectedValue == "auto" && appfliterset.SelectedValue == "false" && remind.SelectedValue == "false")
        {//自動1手動2系統自動3

            String strSQL = "UPDATE Theme SET t_name=@tname,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,re_time=@time,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);

            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "1");
            cmd1.Parameters.AddWithValue("@time", Convert.ToString(Convert.ToDouble(time.Text.Trim()) * 60000));
            cmd1.ExecuteNonQuery();

            conn.Close();
            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }

        //亮度自動，濾鏡開，提醒關，時間空值
        else if (appset.SelectedValue == "auto" && appfliterset.SelectedValue == "true" && remind.SelectedValue == "false")
        {//自動1手動2系統自動3

            String strSQL = "UPDATE Theme SET t_name=@tname,r_color=@r,g_color=@g,b_color=@b,a_color=@a,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@r", Convert.ToInt16(c.R / 2.55));
            cmd1.Parameters.AddWithValue("@b", Convert.ToInt16(c.B / 2.55));
            cmd1.Parameters.AddWithValue("@g", Convert.ToInt16(c.G / 2.55));
            cmd1.Parameters.AddWithValue("@a", filtertxt.Value.Trim());
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "1");
            cmd1.ExecuteNonQuery();


            conn.Close();
            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }
        //亮度系統自動，濾鏡開，提醒開，時間30分鐘或60分鐘或2小時
        else if (appset.SelectedValue == "sys_auto" && appfliterset.SelectedValue == "true" && remind.SelectedValue == "true" && remindtime.SelectedValue == "1" || remindtime.SelectedValue == "2" || remindtime.SelectedValue == "3")
        {

            String strSQL = "UPDATE Theme SET t_name=@tname,r_color=@r,g_color=@g,b_color=@b,a_color=@a,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);

            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@r", Convert.ToInt16(c.R / 2.55));
            cmd1.Parameters.AddWithValue("@b", Convert.ToInt16(c.B / 2.55));
            cmd1.Parameters.AddWithValue("@g", Convert.ToInt16(c.G / 2.55));
            cmd1.Parameters.AddWithValue("@a", filtertxt.Value.Trim());
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "3");
            cmd1.ExecuteNonQuery();
            conn.Close();

            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }
        //亮度系統自動,濾鏡開，提醒開，時間自訂
        else if (appset.SelectedValue == "sys_auto" && appfliterset.SelectedValue == "true" && remind.SelectedValue == "true" && remindtime.SelectedValue == "4")
        {
            String strSQL = "UPDATE Theme SET t_name=@tname,r_color=@r,g_color=@g,b_color=@b,a_color=@a,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,re_time=@time,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@r", Convert.ToInt16(c.R / 2.55));
            cmd1.Parameters.AddWithValue("@b", Convert.ToInt16(c.B / 2.55));
            cmd1.Parameters.AddWithValue("@g", Convert.ToInt16(c.G / 2.55));
            cmd1.Parameters.AddWithValue("@a", filtertxt.Value.Trim());
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "3");
            cmd1.Parameters.AddWithValue("@time", Convert.ToString(Convert.ToDouble(time.Text.Trim()) * 60000));
            cmd1.ExecuteNonQuery();

            conn.Close();

            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }
        //亮度系統自動，濾鏡關，提醒開，時間30分鐘或60分鐘或2小時
        else if (appset.SelectedValue == "sys_auto" && appfliterset.SelectedValue == "false" && remind.SelectedValue == "true" && remindtime.SelectedValue == "1" || remindtime.SelectedValue == "2" || remindtime.SelectedValue == "3")
        {
            String strSQL = "UPDATE Theme SET t_name=@tname,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("tname", appTheme.SelectedValue);

            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "3");
            cmd1.ExecuteNonQuery();

            conn.Close();

            cmd1.Cancel();

            Response.Write("<script>alert('手機主題修改成功!');location.href='Theme.aspx';</script>");
        }
        //亮度系統自動，濾鏡關，提醒開，時間自訂
        else if (appset.SelectedValue == "sys_auto" && appfliterset.SelectedValue == "false" && remind.SelectedValue == "false" && remindtime.SelectedValue == "4")
        {//自動1手動2系統自動3
            String strSQL = "UPDATE Theme SET t_name=@tname,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,re_time=@time,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "3");
            cmd1.Parameters.AddWithValue("@time", Convert.ToString(Convert.ToDouble(time.Text.Trim()) * 60000));
            cmd1.ExecuteNonQuery();

            conn.Close();

            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }
        //亮度系統自動，濾鏡關，提醒關，時間空值
        else if (appset.SelectedValue == "sys_auto" && appfliterset.SelectedValue == "false" && remind.SelectedValue == "false")
        {//自動1手動2系統自動3
            String strSQL = "UPDATE Theme SET t_name=@tnamet,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "3");
            cmd1.ExecuteNonQuery();

            conn.Close();

            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }

        //亮度系統自動，濾鏡開，提醒關，時間空值
        else if (appset.SelectedValue == "sys_auto" && appfliterset.SelectedValue == "true" && remind.SelectedValue == "false")
        {//自動1手動2系統自動3

            String strSQL = "UPDATE Theme SET t_name=@tname,r_color=@r,g_color=@g,b_color=@b,a_color=@a,str_isadd=@fliterset, str_isremind=@remindset,str_light=@lightset,re_status=@remindtime,setmode=@brightset WHERE t_name=@tname";
            SqlCommand cmd1 = new SqlCommand(strSQL, conn);
            cmd1.Parameters.AddWithValue("@tname", appTheme.SelectedValue);
            cmd1.Parameters.AddWithValue("@r", Convert.ToInt16(c.R / 2.55));
            cmd1.Parameters.AddWithValue("@b", Convert.ToInt16(c.B / 2.55));
            cmd1.Parameters.AddWithValue("@g", Convert.ToInt16(c.G / 2.55));
            cmd1.Parameters.AddWithValue("@a", filtertxt.Value.Trim());
            cmd1.Parameters.AddWithValue("@fliterset", appfliterset.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindset", remind.SelectedValue);
            cmd1.Parameters.AddWithValue("@remindtime", remindtime.SelectedValue);
            cmd1.Parameters.AddWithValue("@lightset", appset.SelectedValue);
            cmd1.Parameters.AddWithValue("@brightset", "3");
            cmd1.ExecuteNonQuery();

            conn.Close();

            cmd1.Cancel();
            Response.Write("<script>alert('手機主題修改成功!');</script>");
        }


    }
    protected void appset_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (appset.SelectedValue == "auto")
        {
            appset.SelectedValue = "auto";
            applight.Disabled = true;
            light.Disabled = true;
        }
        else if (appset.SelectedValue == "manually")
        {
            appset.SelectedValue = "manually";
            applight.Disabled = false;
            light.Disabled = false;
        }
        else
        {
            appset.SelectedValue = "sys_auto";
            applight.Disabled = true;
            light.Disabled = true;
        }


    }
    protected void appfliterset_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (appfliterset.SelectedValue == "true")
        {
            appfliterset.SelectedValue = "true";
            filtercolor.Visible = true;
            appfilter.Disabled = false;
            filtertxt.Disabled = false;
        }
        else
        {
            appfliterset.SelectedValue = "false";
            filtercolor.Visible = false;
            appfilter.Disabled = true;
            filtertxt.Disabled = true;

        }


    }
    protected void remind_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (remind.SelectedValue == "true")
        {
            remind.SelectedValue = "true";
            remindtime.Enabled = true;
        }
        else
        {
            remind.SelectedValue = "false";
            remindtime.Enabled = false;
        }
    }

    protected void remindtime_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (remindtime.SelectedValue == "1")
        {
            remindtime.SelectedValue = "1";
            time.Enabled = false;
        }
        else if (remindtime.SelectedValue == "2")
        {
            remindtime.SelectedValue = "2";
            time.Enabled = false;
        }
        else if (remindtime.SelectedValue == "3")
        {
            remindtime.SelectedValue = "3";
            time.Enabled = false;
        }
        else
        {
            remindtime.SelectedValue = "4";
            time.Enabled = true;
        }
    }

    protected void appTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstring);
        conn.Open();
        SqlDataReader dr;
        SqlCommand cmd1 = new SqlCommand("select * from [Theme] where m_name='" + Session["name"] + "'and t_name='" + appTheme.SelectedValue + "'", conn);
        dr = cmd1.ExecuteReader();

        if (dr.Read())
        {
            if (dr[2].ToString() == null)
            {
                appTheme.Enabled = false;
            }
            //appfilter.Value ="20";
            //提醒時間三十分鐘，一小時，二小時，自訂：
            if (dr[3].ToString() == "" || dr[4].ToString() == "" || dr[5].ToString() == "")
            {
                filtercolor.Value = "#000";

            }
            else
            {
                ArrayList colorArr = new ArrayList();
                int R = Convert.ToInt32(Convert.ToInt32(dr[3].ToString()) * 2.55);
                int G = Convert.ToInt32(Convert.ToInt32(dr[4].ToString()) * 2.55);
                int B = Convert.ToInt32(Convert.ToInt32(dr[5].ToString()) * 2.55);
                colorArr.Add(R);
                colorArr.Add(G);
                colorArr.Add(B);
                colorArr.Sort();
                float max = Convert.ToInt32(colorArr[colorArr.Count - 1]);
                float mix = Convert.ToInt32(colorArr[0]);
                filtercolor.Value = string.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);

            }

            if (dr[11].ToString().Trim() == "true")
            {
                appfliterset.SelectedValue = "true";
                filtertxt.Value = dr[6].ToString();
                appfilter.Value = dr[6].ToString();

            }
            else
            {
                appfliterset.SelectedValue = "false";
                filtertxt.Value = "";

            }

            if (dr[13].ToString().Trim() == "auto")
            {
                appset.SelectedValue = "auto";
                light.Value = "";
            }
            else if (dr[13].ToString().Trim() == "sys_auto")
            {
                appset.SelectedValue = "sys_auto";
                light.Value = "";
            }
            else
            {
                appset.SelectedValue = "manually";
                applight.Value = dr[10].ToString();
                light.Value = dr[10].ToString();
            }

            if (dr[12].ToString().Trim() == "true")
            {
                remind.SelectedValue = "true";
                time.Text = "";
                if (dr[8].ToString() == "1")
                {
                    //30min
                    remindtime.SelectedValue = "1";
                    time.Text = "";
                }
                else if (dr[8].ToString() == "2")
                {
                    //60min
                    remindtime.SelectedValue = "2";
                    time.Text = "";
                }
                else if (dr[8].ToString() == "3")
                {
                    //120min
                    remindtime.SelectedValue = "3";
                    time.Text = "";
                }
                else
                {
                    //自訂
                    remindtime.SelectedValue = "4";
                    time.Text = (Convert.ToDouble(dr[7].ToString()) / 60000).ToString();

                }
            }
            else
            {
                remind.SelectedValue = "false";
                time.Text = "";
            }
            //提醒時間
        }
    }
    protected void apisubmit_Click(object sender, EventArgs e)
    {
        string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstring);
        conn.Open();
        String strSQL = "UPDATE apiset SET filltercolor=@filltercolor,bgcolor=@bgcolor,bgcoloropacity=@bgcoloropacity,filltercoloropacity=@filltercoloropacity,fontsize=@fontsize WHERE m_name=@name";
        SqlCommand cmd1 = new SqlCommand(strSQL, conn);
        string bgColor = bgcolor.Value;

        System.Drawing.Color bg = System.Drawing.ColorTranslator.FromHtml(bgColor);
        cmd1.Parameters.AddWithValue("@name", Session["name"]);
        cmd1.Parameters.AddWithValue("@filltercolor", apifilter.Value);
        cmd1.Parameters.AddWithValue("@bgcolor", bg.R + "," + bg.G + "," + bg.B);
        cmd1.Parameters.AddWithValue("@bgcoloropacity", Convert.ToDouble(bgtxt.Value) / 100);
        cmd1.Parameters.AddWithValue("@filltercoloropacity", Convert.ToDouble(plugfilter.Value) / 100);
        cmd1.Parameters.AddWithValue("@fontsize", fontsize.SelectedValue);
        cmd1.ExecuteNonQuery();
        Response.Write("<script>alert('擴充功能主題修改成功!');</script>");
        cmd1.Dispose();
        conn.Close();


    }
    protected void apidelete_Click(object sender, EventArgs e)
    {
        string connstring = WebConfigurationManager.ConnectionStrings["Goggle"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstring);
        conn.Open();
        SqlCommand apicmd = new SqlCommand("DELETE from [Theme] where [t_name]=@tname and [m_name]=@name", conn);
        apicmd.Parameters.AddWithValue("@tname",appTheme.SelectedValue);
        apicmd.Parameters.AddWithValue("@name", Session["name"].ToString());
        SqlDataReader reader = apicmd.ExecuteReader();
        Response.Write("<script>alert('刪除成功!');top.location.href='user.aspx';</script>");
        apicmd.Cancel();
        reader.Close();
        conn.Close();

          
    }
}