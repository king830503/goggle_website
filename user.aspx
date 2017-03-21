<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/user.css" rel="stylesheet" />
       <script src="js/jquery-1.8.3.min.js"></script>
     <script>        $(document).ready(function () {

            var setTimeouId;

            $("#firstDiv li").each(function (index) {
                $(this).click(function () {
                    var nodeTabin = $(this);
                    setTimeouId = setTimeout(function () {
                        $("#firstDiv .contentin").removeClass("contentin");
                        $("#firstDiv .tabin").removeClass("tabin");

                        $("#firstDiv div").eq(index).addClass("contentin");
                        //我在这里犯错了哦，不应该再用this  this如果用在这里的话那么是指的window
                        nodeTabin.addClass("tabin");
                    }, 100);
                }).mouseout(function () {
                    clearTimeout(setTimeouId);
                });
            });
        })
        </script>
        <style type="text/css">


             #firstDiv .contentin {
            display: block;
             width:900px;
             height:60%;
            float:right;
            font-size: 24px;
            margin-top:-260px;
            margin-right:80px;
        }
            .theme
            {
                display:block;
                background-color:rgb(255,240,132);
                color:rgb(63, 72, 204);
                margin: 0 auto;
                width:400px;
                height:300px; 
                position:absolute;
                top:350px;
                left:200px;

            }
        </style>
         
</head>
<body>
    <form id="form1" runat="server">
  	<div id="wrappper">
		<header>
        
        <a href="index2.aspx">
           <img src="images/goggle_06.png"   alt="GOGGLE" />

        </a>
           <h1>PROTECT YOUR EYES &middot; COLOR FILTER</h1>
			<h2>保護眼睛，過濾顏色!</h2>
			<div id="btnmenu" >
                <figure>選單</figure>
            </div>
		</header>
		<div id="main">

         <div id="firstDiv">
         <asp:Label ID="name" runat="server" style="margin-left:-80%;padding-top:20px;font-size:14pt;font-weight:bold;color:#000"></asp:Label>
                <ul style="margin-top:20px;margin-right:50px;">
					<li class="tabin">
                        會員修改
                    </li>
					<li>
						主題環境設定
					</li>
					<li>
						使用時間
					</li>
								
					<li>
						主題票選
					</li>
                    <li>色盲推薦色系</li>
				</ul>

                <div class="contentin">
                    <iframe src="user-set.aspx" width="830" height="600" style="overflow-x:hidden"></iframe> 
			    </div>
                 <div id="a">
                    <iframe src="theme.aspx" width="1000" height="610"></iframe>
                </div>
                <div id="c">
                     <asp:Chart ID="Chart1" runat="server" Width="894px" Height="610px" style="margin-left:30px">
                <Series>
                    <asp:Series Name="Series1" XValueMember="datetimestart" YValueMembers="duration"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
                </div>
                <div id="g">                
                    <iframe src="vote.aspx"  width="900" height="700"></iframe>
                </div>
                <div id="ga">
                       <iframe src="color.aspx"  width="900" height="650"></iframe>
                </div>
               
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
