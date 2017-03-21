using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    public SqlConnection conn;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["name"] == null)
        {
            Response.Write("<script>alert('登入時效已過，請重新登入!');location.href='index.aspx';</script>");
        }
        else
        {
          
            name.Text = "歡迎登入，" + Session["name"].ToString() + "<a href='index.aspx' style='text-decoration:none;border-bottom:dotted 1px red;color:#000'>登出</a>";
             string[] titleArr = { "手機", "瀏覽器", "總時數", "警告" };

        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["votestr"].ConnectionString);

        string query = "select top 7 m.m_name,c.datetimestart,c.duration,c.duration2,c.sumtime,m.limittime from member m  join charttime c ON (m.m_name=c.m_name)  where c.m_name='" + Session["name"] + "' ORDER BY datetimestart desc";

        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();

        Chart1.DataSource = cmd.ExecuteReader();
        Series Series1 = new Series();
        Series1.XValueMember = "datetimestart";
        Series1.YValueMembers = "duration";
        Series Series2 = new Series();
        Series2.XValueMember = "datetimestart";
        Series2.YValueMembers = "duration2";
        Series Series3 = new Series();
        Series3.XValueMember = "datetimestart";
        Series3.YValueMembers = "sumtime";
        Series Series4 = new Series();
        Series4.XValueMember = "datetimestart";
        Series4.YValueMembers = "limittime";

        Chart1.Legends.Add("Legends1");
        Chart1.Legends["Legends1"].DockedToChartArea = "ChartArea1"; //顯示在圖表內

        //Chart1.Legends["Legends1"].Docking = Docking.Bottom; //自訂顯示位置

        Chart1.Legends["Legends1"].BackColor = Color.FromArgb(235, 235, 235); //背景色

        //斜線背景

        Chart1.Legends["Legends1"].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;

        Chart1.Legends["Legends1"].BorderWidth = 2;

        Chart1.Legends["Legends1"].BorderColor = Color.FromArgb(200, 200, 200);

        Chart1.Legends["Legends1"].Docking = Docking.Right;

        Chart1.Legends["Legends1"].LegendStyle = LegendStyle.Row;


        Title title = new Title();
        title.Text = "使用時間統計圖表";
        title.Alignment = ContentAlignment.MiddleCenter;
        title.Font = new System.Drawing.Font("Microsoft JhengHei", 25F);
        title.ForeColor = Color.SeaGreen;
        Chart1.Titles.Add(title);
        //Chart1.Width = 894;
        //Chart1.Height= 510;


        Chart1.Series.Add(Series2);
        Chart1.Series.Add(Series3);
        Chart1.Series.Add(Series4);

        Chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;

        Chart1.ChartAreas[0].AxisX2.Enabled = AxisEnabled.False;



        Chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

        Chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.False;

        Chart1.Style["overflow"] = "scroll";


        Chart1.Series[0].Legend = "Legends1";
        Chart1.Series[0].LegendText = titleArr[0];
        Chart1.Series[0].ChartType = SeriesChartType.Column;
        Chart1.Series[0].PostBackValue = "#XVAL";
        Chart1.Series[0].ChartType = SeriesChartType.Column;
        Chart1.Series[0].Color = Color.SteelBlue;
        Chart1.Series[0].BorderWidth = 3;
        Chart1.Series[0].Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);


        Chart1.Series["Series2"].Legend = "Legends1";
        Chart1.Series["Series2"].LegendText = titleArr[1];
        Chart1.Series["Series2"].PostBackValue = "#XVAL";
        Chart1.Series["Series2"].ChartType = SeriesChartType.Column;
        Chart1.Series["Series2"].Color = Color.Orange;
        Chart1.Series["Series2"].BorderWidth = 3;
        Chart1.Series["Series2"].Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);

        Chart1.Series["Series3"].Legend = "Legends1";
        Chart1.Series["Series3"].LegendText = titleArr[2];
        Chart1.Series["Series3"].PostBackValue = "#XVAL";
        Chart1.Series["Series3"].ChartType = SeriesChartType.Spline;
        Chart1.Series["Series3"].Color = Color.Gold;
        Chart1.Series["Series3"].BorderWidth = 5;
        Chart1.Series["Series3"].Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);

        Chart1.Series["Series4"].Legend = "Legends1";
        Chart1.Series["Series4"].LegendText = titleArr[3];
        Chart1.Series["Series4"].PostBackValue = "#XVAL";
        Chart1.Series["Series4"].ChartType = SeriesChartType.Spline;
        Chart1.Series["Series4"].BorderDashStyle = ChartDashStyle.Dash;
        Chart1.Series["Series4"].Color = Color.Red;
        Chart1.Series["Series4"].BorderWidth = 1;
        Chart1.Series["Series4"].Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);

        //XY 標題
        Chart1.ChartAreas[0].AxisX.Title = "日期";
        Chart1.ChartAreas[0].AxisY.Title = "分鐘";
        Chart1.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft JhengHei", 18);
        Chart1.ChartAreas[0].AxisX.TitleFont = new Font("Microsoft JhengHei", 18);
        Chart1.ChartAreas[0].AxisY.TitleForeColor = Color.SeaGreen;
        Chart1.ChartAreas[0].AxisX.TitleForeColor = Color.SeaGreen;
        Chart1.ChartAreas[0].AxisY.Interval = 50;
        Chart1.ChartAreas[0].AxisY.Minimum = 0;
        Chart1.ChartAreas[0].AxisY.Maximum = 750;
        Chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;
        Chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
        Chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;

        Chart1.DataBind();

    }
    }
}
