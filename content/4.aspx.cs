using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        SqlDataSource db = new SqlDataSource();
        db.ConnectionString = WebConfigurationManager.ConnectionStrings["votestr"].ConnectionString;
        db.SelectCommand = "select * from votecolor";

        DataView dv = (DataView)db.Select(DataSourceSelectArguments.Empty);
        
        {
            Literal1.Text += "<div id='menu1' style='background-color: rgb(" + dv.Table.Rows[3][2].ToString() + "," + dv.Table.Rows[3][3].ToString() + "," + dv.Table.Rows[3][4].ToString() + "); width:700px; height: 450px; margin: 0 auto;'>";
            Literal1.Text += "<div> <ul> <li>";
            Literal1.Text += "<img src='images/goggle_06.png' style='width: 100px; height: 50px; float:left;margin-left:-40px;margin-right:30px;' alt='GOGGLES ' /></li>";
            Literal1.Text += "<li style='padding-top: 20px;'><a href='ck.aspx' style='color: rgb(" + dv.Table.Rows[3][8].ToString() + "," + dv.Table.Rows[3][9].ToString() + "," + dv.Table.Rows[3][10].ToString() + ");' >HOME</a></li> ";
            Literal1.Text += "<li style='padding-top: 20px;'><a href='vote.aspx' style='color: rgb(" + dv.Table.Rows[3][8].ToString() + "," + dv.Table.Rows[3][9].ToString() + "," + dv.Table.Rows[3][10].ToString() + ");'>VOTE</a></li>";
            Literal1.Text += "<li style='padding-top: 20px;'><a href='new/contact_us.aspx' style='color: rgb(" + dv.Table.Rows[3][8].ToString() + "," + dv.Table.Rows[3][9].ToString() + "," + dv.Table.Rows[3][10].ToString() + ");'>MESSAGE</a></li>";
            Literal1.Text += "<li style='padding-top: 20px;'><a href='new/download.aspx' style='color: rgb(" + dv.Table.Rows[3][8].ToString() + "," + dv.Table.Rows[3][9].ToString() + "," + dv.Table.Rows[3][10].ToString() + ");'>DOWNLOAD</a></li>";
            Literal1.Text += "<li style='padding-top: 20px;'><a href='new/about.aspx' style='color: rgb(" + dv.Table.Rows[3][8].ToString() + "," + dv.Table.Rows[3][9].ToString() + "," + dv.Table.Rows[3][10].ToString() + ");'>ABOUT US</a></li>";
            Literal1.Text += "<li style='padding-top: 20px;'><a href='new/login.aspx' style='color: rgb(" + dv.Table.Rows[3][8].ToString() + "," + dv.Table.Rows[3][9].ToString() + "," + dv.Table.Rows[3][10].ToString() + ");'>SIGN IN/UP</a></li>";
            Literal1.Text += "</ul></div><br />";
            Literal1.Text += "<div style='padding-top:20px;padding-left:20px;padding-right:20px;color: rgb(" + dv.Table.Rows[3][5].ToString() + "," + dv.Table.Rows[3][6].ToString() + "," + dv.Table.Rows[3][7].ToString() + ");line-height:1.3em;'><br />";
            Literal1.Text += "<h3 style='text-align: left; color: rgb(" + dv.Table.Rows[3][5].ToString() + "," + dv.Table.Rows[3][6].ToString() + "," + dv.Table.Rows[3][7].ToString() + "); border-bottom:solid 1px;padding-bottom:0.5em;letter-spacing:0.5em;'>關於我們</h3>";
            Literal1.Text += "<div style='width:350px;float:left;padding-top:-3em; letter-spacing:0.2em;'>";
            Literal1.Text += "<h4>  名稱 : GOGGLE 顧目啾<br /><br /><br />";
            Literal1.Text += "";
            Literal1.Text += " 版本資訊: 第一版<br /><br /><br />";

            Literal1.Text += " Email : lhugoggle@gmail.com<br /><br /><br />  facebook : <a href='https://www.facebook.com/goggle.tw?pnref=lhc' title='Goggle臉書粉絲團' style=' color: rgb(" + dv.Table.Rows[3][8].ToString() + "," + dv.Table.Rows[3][9].ToString() + "," + dv.Table.Rows[3][10].ToString() + ");'>Goggle臉書粉絲團</a></h4></div> <div style='float:right;width:300px;letter-spacing:0.5em;'><h4>  創作團隊人員</h4> <!-- Facebook Badge START --><a href='https://www.facebook.com/people/&#x5289;&#x7e7c;&#x5143;/100004384927175' title='&#x5289;&#x7e7c;&#x5143;' target='_TOP'><img class='img' src='https://badge.facebook.com/badge/100004384927175.383.49109667.png' style='border: 0px;height:100px;width:60px;'  /></a><!-- Facebook Badge END -->  <!-- Facebook Badge START --><a href='https://www.facebook.com/edelweisszeero' title='&#x5433;&#x660c;&#x7ff0;' target='_TOP'><img class='img' src='https://badge.facebook.com/badge/100003051139496.1318.145582059.png' style='border: 0px;height:100px;width:60px;'  /></a><!-- Facebook Badge END --> <!-- Facebook Badge START --><a href='https://www.facebook.com/people/Anya-Chen/100004747742810' title='Anya Chen' target='_TOP'><img class='img' src='https://badge.facebook.com/badge/100004747742810.440.1328204703.png' style='border: 0px;height:100px;width:60px;' /></a><!-- Facebook Badge END --> <!-- Facebook Badge START --><a href='https://www.facebook.com/wang.victor.16' title='Victor Wang' target='_TOP'><img class='img' src='https://badge.facebook.com/badge/100000282578385.3042.953813016.png' style='border: 0px;height:100px;width:60px;' /></a><!-- Facebook Badge END --><br/><br/> <!-- Facebook Badge START --><a href='https://www.facebook.com/people/&#x8a31;&#x7ff0;&#x5091;/100004236330034' title='&#x8a31;&#x7ff0;&#x5091;' target='_TOP'><img class='img' src='https://badge.facebook.com/badge/100004236330034.69.965107819.png' style='border: 0px;height:100px;width:60px;'  /></a><!-- Facebook Badge END --> <!-- Facebook Badge START --><a href='https://www.facebook.com/egoistroyo' title='&#x5ed6;&#x5049;&#x5b8f;' target='_TOP'><img class='img' src='https://badge.facebook.com/badge/100000291766165.3009.1122034026.png' style='border: 0px;height:100px;width:60px;' /></a><!-- Facebook Badge END --> <!-- Facebook Badge START --><a href='https://www.facebook.com/people/&#x6797;&#x5ead;/100000690131241' title='&#x6797;&#x5ead;' target='_TOP'><img class='img' src='https://badge.facebook.com/badge/100000690131241.1749.284765846.png' style='border: 0px;height:100px;width:60px;'  /></a><!-- Facebook Badge END --> <!-- Facebook Badge START --><a href='https://www.facebook.com/people/&#x9673;&#x8679;&#x541f;/1684819463' title='&#x9673;&#x8679;&#x541f;' target='_TOP'><img class='img' src='https://badge.facebook.com/badge/1684819463.2624.2008192943.png' style='border: 0px;height:100px;width:60px;' /></a><!-- Facebook Badge END --> </div> </div> </div>";
            Literal1.Text += "";
        }



    }
}