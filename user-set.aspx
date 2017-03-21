<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user-set.aspx.cs" Inherits="user_set" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/user-set.css" rel="stylesheet" />
    <script type="text/javascript">
        function preview(file) {
            var prevDiv = document.getElementById('preview');
            if (file.files && file.files[0]) {
                var reader = new FileReader();
                reader.onload = function (evt) {
                    prevDiv.innerHTML = '<img src="' + evt.target.result + '"' + "style='max-width:100%;max-height:300px'" + '/>';
                }
                reader.readAsDataURL(file.files[0]);
            }
            else {
                prevDiv.innerHTML = '<div class="img" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale;,src=\'' + file.value + '\'"></div>';

            }

        }
         </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <h3>會員修改</h3>
            <div id="content">
                <p>目前密碼:</p>
                <span><asp:TextBox runat="server" ID="pwd" placeholder="輸入目前密碼" TextMode="Password"></asp:TextBox></span>
                <p>新密碼：</p>
                <span><asp:TextBox runat="server" ID="newpwd" placeholder="輸入5到10個字元" MaxLength="10" TextMode="Password"></asp:TextBox></span>
                
                <p>確認密碼：</p>
                <span><asp:TextBox runat="server" ID="newpwd2" placeholder="輸入5到10個字元" MaxLength="10" TextMode="Password"></asp:TextBox></span>
                <p>電子信箱：</p>
                <span><asp:TextBox runat="server" ID="email" placeholder="ex:abc12@gmail.com" MaxLength="30"></asp:TextBox></span>             
                <p>限制時間：</p>
                <span class="a"><input type="number" runat="server" id="limittime" min="30" max="720" style="width:70px"/></span>               
                <span id="min">分鐘</span>
                <p>出生年份：</p><span id="s">西元</span>
                <span class="a"><asp:Textbox runat="server" ID="born" MaxLength="4"></asp:Textbox></span>
                
                <span id="year">年</span>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </div>
                 <div id="pic">
                
                
                    <h4>請選擇一張大頭貼更改照片</h4>
             
                   <asp:FileUpload ID="FileUpload1" runat="server"  onchange="preview(this)" />
                    <br/>
                    <div id="preview" runat="server"></div>
                
            
            </div>
            <span style="left:250px;position:absolute;top:500px">
            <asp:Button Text="送出" ID="send" runat="server" OnClick="sumit_Click"  />
            <asp:Button Text="清除" ID="clear" runat="server" OnClick="cancel_Click" />

            </span>
       </div>
       
    </form>
</body>
</html>
