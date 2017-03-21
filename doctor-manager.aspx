<%@ Page Language="C#" AutoEventWireup="true" CodeFile="doctor-manager.aspx.cs" Inherits="doctor_manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta name="google-site-verification" content="AMgOq2Q_Nm6z8VwrlxUgIFZfP8gTIMqGBy1bRzwB7nk" />
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.1.1/css/bootstrap.min.css"/>
    <link href="note.css" rel="stylesheet" />
  <link href="userface_manager.css" rel="stylesheet" />
    <link href="icon3.ico" rel="shortcut icon" />
    <link href="icon3.ico" rel="bookmark" />

   <style type="text/css">
        td {
            width: 150px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
   <header class="header2 header" style="height:100px; background-color:#333">
  <div class="container">
     
 <img src="images/goggle_06.png" style="width: 240px; height:100px;float:left;margin-left:20px"  alt="GOGGLES "/>
 <nav class="header__nav clearfix">
         <ul class="header__nav__links" style="padding-left:280px;padding-top:20px;height:50px">
                        <li><a href="doctor-manager.aspx" class="download js-download-extension" target="_self"
                 style="font-size: 20px;">手機管理</a></li>    
             <li><a href="font.aspx" class="download js-download-extension" target="_self"
                 style="font-size: 20px;">字體管理</a></li>        
             <li style="width:135px;padding-left:15px;"><a href="dr_theme.aspx" class="download js-download-extension" target="_self"
                 style="font-size: 20px;">瀏覽器管理</a></li>

             <li><a href="index.aspx" class="download js-download-extension" target="_self" style="font-size: 20px;">
                 登出</a></li>

         </ul>
    </nav>
   </div>
   </header>
     <div class="container" style="padding-bottom:50px">
    <h3 style="text-align:left;color:#83c2bc;font-size: 3em;margin-top:120px">手機管理</h3>
      <div class="user-comments__list clearfix" style="border-top: solid #83c2bc 0.3em; margin: 0 auto; text-align: center; padding-top: 1.2em; padding-bottom: 1em; /*height:600px;width:800px;*/">
          <div style="padding-left:100px;">
              <span class="pstyle-f" style="padding-top:5px;margin-left:120px;width:170px">病症名稱：</span>
          
          
          
          
          
          
          
              <span class="pstyle-i"><asp:TextBox runat="server" ID="usert"></asp:TextBox></span>    
              <span class="pstyle-b"><asp:Button runat="server" ID="lookup" Text="查詢" 
                  OnClick="lookup_Click"/>
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                  ConnectionString="<%$ ConnectionStrings:Goggle %>" 
                  SelectCommand="SELECT * FROM [dr_appset]" 
                  ProviderName="System.Data.SqlClient">
              </asp:SqlDataSource>
              </span>
                   <asp:Label runat="server" ID="Label1" style="position:absolute"></asp:Label>
          </div>
          
        
        <div style="margin-top:70px;"></div> 
          <div style=" font-size:1.5em; font-family:'Microsoft JhengHei'; height:auto;padding-left:100px;">
                  <asp:GridView ID="GridView1" runat="server" CellPadding="5" ForeColor="#333333" 
                  GridLines="None" AllowSorting="True" BorderStyle="Dashed" BorderWidth="1px" 
                  EnableTheming="True"  CssClass="gvStyle" Width="850px"
                      AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                      OnRowDeleted="delete_click" AutoGenerateColumns="False" 
                      DataSourceID="SqlDataSource1" AllowPaging="True"
                      DataKeyNames="color_id" >
                <AlternatingRowStyle HorizontalAlign="Left"  />
                      <Columns>
                          <asp:TemplateField HeaderText="勾選">
                              <ItemTemplate>
                                  <asp:CheckBox ID="CheckBox1" runat="server" />
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="color_id" HeaderText="病症編號" 
                              SortExpression="color_id" ReadOnly="True" />
                          <asp:BoundField DataField="t_name" HeaderText="名稱" 
                              SortExpression="name" />
                          <asp:BoundField DataField="r_color" HeaderText="r_color" 
                              SortExpression="r_color" />
                          <asp:BoundField DataField="g_color" HeaderText="g_color" 
                              SortExpression="g_color" />
                          <asp:BoundField DataField="b_color" HeaderText="b_color" 
                              SortExpression="b_color" />
                          <asp:BoundField DataField="a_color" HeaderText="a_color" 
                              SortExpression="a_color" />
                          <asp:BoundField DataField="brightness" HeaderText="brightness" 
                              SortExpression="brightness" />
                      </Columns>
                <EditRowStyle HorizontalAlign="Right" />
                <FooterStyle Font-Bold="True" />
                <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
                <PagerStyle HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Left" />
                <SelectedRowStyle HorizontalAlign="Left" />
              </asp:GridView>
          </div>

            <br />
                <br />
                <div style="font-size: 1.5em; font-family: 'Microsoft JhengHei'; margin-left:5%;clear:both;">
                   <div>
                   <span style="float:left;padding-left:50px">主題名稱：</span><asp:TextBox runat="server" 
                           ID="name" style="float:left;width:150px;height:40px"></asp:TextBox>
                   <span>背景顏色：<input type="color" runat="server" id="bgcolor" /></span>
                   <span style="float:right">字體顏色：<input type="color" id="fontcolor" runat="server" min=0 max=100/></span>
                       <br />
                   <br /> 
                       <asp:Label runat="server" ID="errormsg" style="position:absolute;clear:both;color:red"></asp:Label>
                    </div>
                   <br />

        <div style="font-size:1em; font-family:'Microsoft JhengHei';clear:both;margin-top:20px">
              <asp:Button ID="add" runat="server" Text="新增" OnClick="add_Click" /> 
              <asp:Button ID="update" runat="server" Text="修改" OnClick="update_Click" />
              <asp:Button ID="Button1" runat="server" Text="刪除"  OnClick="delete_click" OnClientClick="return confirm('你確定要刪除已選取的資料?');" />
              <asp:Button ID="Button2" runat="server" Text="取消" OnClick="cal_click" />
          </div>

      </div>
      
      <br /><br />
      <br />
  </div>
   </div>
     <div id="footer" style="height:50px;">
  <!-- 網站地圖 -->
  <div class="footer__sitemap"  >
    <div class="footer__sitemap__content container" >
      
          
             
              <ul class="footer__sitemap__sections__section__links" style= "list-style:none">
                    <li style="color:#fff;float:left;margin-left:-12%">版權所有&copy; 龍華資管 GOGGLES , all right reserved             olor:#fff;float:right;margin-right:-12%">本站建議Google瀏覽器解析度1280*1024</li>
              </ul>
    </div>
  </div>

  

  <!-- Mixpanel badge -->
  <div class="footer__mixpanel hidden-phone">
    <div class="container footer__mixpanel__container">
      
    </div>
  </div>

  <!-- Terms & Copyright -->
  <%--<div class="footer__last" >
    <div class="footer__last__content container">
      <a href="#" class="footer__last__elm footer__last__terms">隱私權與使用條款</a>
      <span class="footer__last__elm footer__last__copyright">Copyright 2014-2015&copy; 龍華資管 GOGGLES , all right reserved</span>
    </div>
  </div>--%>
</div>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
        <script src="goggle.js"></script>
    </form>
</body>
</html>
