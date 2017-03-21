<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>註冊</title>
    <link href="css/register.css" rel="stylesheet" />
    <style type="text/css">
        #email
    {
       margin-top:20px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div id="wrappper">
		<header>
        <a href="index.aspx">
           <img src="images/goggle_06.png"   alt="GOGGLE" width="300" />
        </a>
           <h1>PROTECT YOUR EYES &middot; COLOR FILTER</h1>
			<h2>保護眼睛，過濾顏色!</h2>
			<div id="btnmenu" >
                <figure>選單</figure>
            </div>
		</header>
		<div id="main">
    <h3>會員註冊</h3>
        <div id="content">
        &lowast;<span style="letter-spacing:32px">帳號</span>：<asp:TextBox runat="server" ID="user"   MaxLength="10" placeholder="5~10個字英文跟數字混合" onkeyup="value=value.replace(/[^a-zA-Z0-9]/g,'')"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revAccount" runat="server" ControlToValidate="user"
                    Display="Dynamic"
                    ValidationExpression="^(?=([a-zA-Z]{1})+\d+[a-zA-Z0-9]{0,10}).{5,10}$">
                 <span style="margin-left:120px"><br />「帳號」格式有誤！</span>
                </asp:RegularExpressionValidator>
       
   <br />
             &lowast;<span style="letter-spacing:32px">密碼</span>：<asp:TextBox runat="server" ID="pwd" MaxLength="10" placeholder="5~10個字英文跟數字混合" TextMode="Password" onkeyup="value=value.replace(/[^a-zA-Z0-9]/g,'')"></asp:TextBox>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="pwd"
                    Display="Dynamic"
                     ValidationExpression="^(?=([a-zA-Z]{1})+\d+[a-zA-Z0-9]{0,10}).{5,10}$">
                 <span style="margin-left:120px"><br />「密碼」格式有誤！</span>
                </asp:RegularExpressionValidator>
                <br />
               &lowast;<span style="letter-spacing:8px">確認密碼</span>：<asp:TextBox runat="server" ID="pwd2" MaxLength="10" placeholder="5~10個字英文跟數字混合" TextMode="Password" onkeyup="value=value.replace(/[^a-zA-Z0-9]/g,'')"></asp:TextBox>
                <asp:CompareValidator ID="cvCheck" runat="server" ControlToValidate="pwd" ControlToCompare="pwd2" Display="Dynamic">
                  <span style="margin-left:120px"><br />密碼與確認密碼兩者不吻合！</span>
                </asp:CompareValidator>
            <br />
              &lowast;<span style="letter-spacing:8px">出年年份</span>：西元<asp:TextBox runat="server" ID="age" Text=""  Width="60" MaxLength="4" onkeyup="value=value.replace(/\D/g,'')" style="margin-left:10px"></asp:TextBox>
              <br /><asp:Label Text="Goggle擴充功能會依你設定年齡設定字型大小" ID="Lab" runat="server" ForeColor="Red"></asp:Label>
              <br />
             &lowast;使用時間限制：<input type="number" id="limittime" runat="server" min="30" max="720" step="1" onkeyup="value=value.replace(/\D/g,'')"/>分鐘
                <br />
                &lowast;<span style="letter-spacing:8px;">電子信箱</span>：<asp:TextBox runat="server" ID="email" MaxLength="30" Width="250" placeholder="最大30個字元"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="email"
                        Display="Dynamic"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        <span style="margin-left:120px" ><br />電子信箱格式有誤！</span>
                    </asp:RegularExpressionValidator>
                    <br />
                    <br />
                    <span style="padding-left:10px">眼部疾病：</span>
                      <input type=checkbox id="redblind" runat="server"  value="1" />紅綠色弱
                    <input type=checkbox id="blueblind" runat="server" value="1" />藍黃色弱<br /><br />
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                  <br />
                  <br />
              <asp:Button ID="submit" runat="server" Text="確定註冊" OnClick="submit_Click"  />
                <asp:Button ID="cal" runat="server" Text="清除" OnClick="cal_Click" style="margin-bottom:50px" />
            </div>
               <div id="pic">
            <asp:FileUpload runat="server" ID="FileUpload1" onchange="preview(this)" />
                <span style=""><div id="preview" style="width:250px;height:300px;float:right;margin-right:167px;margin-top:20px"></div> </span>
 <script type="text/javascript">
     function preview(file) {
         var prevDiv = document.getElementById('preview');
         if (file.files && file.files[0]) {
             var reader = new FileReader();
             reader.onload = function (evt) {
                 prevDiv.innerHTML = '<img src="' + evt.target.result + '"' + "style='max-width:100%;height:auto'" + '/>';
             }
             reader.readAsDataURL(file.files[0]);
         }
         else {
             prevDiv.innerHTML = '<div class="img" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale;,src=\'' + file.value + '\'"></div>';

         }
     }
 </script>  
              </div>
    </div>

		<footer> 

                    	<h3>關於GOGGLE</h3>
                    	<ul> 
                        	<li>
                            	<a href="https://www.facebook.com/goggle.tw?pnref=lhc" title="Goggle臉書粉絲團" target="_blank">Goggle臉書粉絲團</a>
                        	</li>
                        	<li>
                            	<a href="mailto:lhugoggle@gmail.com">聯絡我們</a>
                        	</li>
                        	<br/>
                        	<li class="liwl">版權所有&copy; 龍華資管 GOGGLES &right,all right reserved
                        	</li>
                        	<li class="liwr">本站建議Google瀏覽器解析度1280*1024
                        	</li>
                    	</ul>
        </footer>
    </div>
    </form>
</body>
</html>
