﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index2.aspx.cs" Inherits="index2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=0">
	<title>GOGGLE</title>
	<link rel="shortcut icon" type="text/css" href="icon3.ico">
	<link rel="bookmark" type="text/css" href="icon3.ico">
<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
	<script type="text/javascript" src="js/jquery.colorbox-min.js"></script>
	<script type="text/javascript" src="js/jquery.colorbox.js"></script>
	<link rel="stylesheet" type="text/css" href="css/home.css">
    <link rel="stylesheet" type="text/css" href="css/colorbox.css">
    <script>
        $(document).ready(function () {
            $("#btnmenu").click(function () {
                $('body').toggleClass('active');
            });
            $(".group1").colorbox();
        });
            $(window).load(function () {
                $(window).bind('scroll resize', function () {
                    var $this = $(this);
                    var $this_Top = $this.scrollTop();

                    //當高度小於100時，關閉區塊 
                    if ($this_Top < 50) {
                        $('nav').removeClass("sh");
                    }
                    if ($this_Top > 50) {
                        $('nav').addClass("sh");
                    }
                }).scroll();
            });

   </script>
    <style type="text/css">
      #vote1, #vote2, #vote3, #vote4, #vote5, #vote6 {
            float: left;
            /*border:solid #000 2px;*/
        }
     

        .hh3 {
         z-index:0;
        position:absolute;
       
        }

         .s3,.num {
             border:solid #000 2px;
            border-radius: 1.5em;
            font-size: 1.5em;
            font-weight: 900;
       
           margin-bottom:30px;

        }
          .s4,.num {
             border:solid #000 2px;
            border-radius: 1.5em;
            font-size: 1.5em;
            font-weight: 900;
            margin-bottom:30px;
          

        }     
          
         .s5,.num {
             border:solid #000 2px;
            border-radius: 1.5em;
            font-size: 1.5em;
            font-weight: 900;
        
           margin-bottom:30px;

        }
          .s6,.num {
             border:solid #000 2px;
            border-radius: 1.5em;
            font-size: 1.5em;
            font-weight: 900;
            margin-bottom:30px;
           

        }     
          
         .s7,.num {
             border:solid #000 2px;
            border-radius: 1.5em;
            font-size: 1.5em;
            font-weight: 900;
        
           margin-bottom:30px;

        }
          .s8,.num {
             border:solid #000 2px;
            border-radius: 1.5em;
            font-size: 1.5em;
            font-weight: 900;
            margin-bottom:30px;
         

        }     
          
     
            .votenum2
        {
            font-size: 1.2em;
            width:150px;
            margin-top:0px;
            }
        a {
        text-decoration:none;       
        }
            a:visited {
            
         
            border:0;
            
            }
   
         .ma
        {
          margin-right:10px
        }
        .bu1
        {
            float:left;
            margin-left:3.5em;
            margin-top:-85px;

        }
      
        .bu3
        {
            float:left;
            margin-left:3em;
           margin-top:-85px;
        }
        .bu5
        {
            float:left;
            margin-left:3em;
            margin-top:-85px;
        }
           .bu2
        {
            float:right;
            margin-right:0.5em;
            margin-top:-85px;
        }
          .bu4
        {
            float:right;
            margin-right:0.5em;
             position:relative;
            margin-top:-85px;
        }
             .bu6
        {
  
            float:right;
            position:relative;
            margin-right:0.5em;
            margin-top:-85px;
        }
       input[type="submit"]
        {
            width:130px;
            background-color:orange;
            line-height:50px;
            border-radius:5px;
            -moz-appearance: none;
		-webkit-appearance: none;
		-o-appearance: none;
		-ms-appearance: none;
		-appearance: none;
        text-align:center;
        		border: 0;
                color:#fff;
                font-size: 0.5em;
                font-family:'Microsoft JhengHei';
        }
        
   </style>
</head>
<body>
    <form id="form1" runat="server">
    <a name="Home"></a>
	<div id="wrappper">
		<header>
        <div id="ma">
			<img src="images/goggle_06.png"   alt="GOGGLE"  >
			<h1>PROTECT YOUR EYES &middot; COLOR FILTER</h1>
			<h2>保護眼睛，過濾顏色!</h2>
        </div>
			<div id="btnmenu" >
                <figure>選單</figure>
            </div>
			<nav>
				<ul>
					<li id="VOTE">
						<a href="#Vote" target="_self" onmouseout="this.innerText='VOTE';" onmouseover="this.innerText='主題票選'">VOTE</a>
					</li>
					<li id="MESSAGE">
						<a href="#Message" target="_self" onmouseout="this.innerText='MESSAGE'" onmouseover="this.innerText='留言'">MESSAGE</a>
					</li>
								
					<li id="DOWNLOAD">
						<a href="#Download" target="_self" onmouseout="this.innerText='DOWNLOAD'" onmouseover="this.innerText='下載'">DOWNLOAD</a>
					</li>
					<li id="ABOUT">
						<a href="#About" target="_self" onmouseout="this.innerText='ABOUT US'" onmouseover="this.innerText='關於我們'">ABOUT US</a>
					</li>
					<li id="SIGN" style="padding-left:10px">
						<a href="#" target="_self"><asp:Image runat="server" ID="Image1" Width="35" Height="35"/><asp:Label runat="server" ID="user" style="float:right;width:60px"></asp:Label></a>
                        <ul>
                            <li><a href="user.aspx">會員中心</a></li>
                            <li><a href="index.aspx">登出</a></li>
                        </ul>
					</li>
				</ul>
			</nav>
			<div class="tr-go"></div>
		</header>
		<div id="main">
			
			<div class="dmenu1">
                <div id="content1">
                    <p class="h1-a">
					功能介紹
                </p>
                <h2>Google擴充功能</h2>
				<div class="intro" >
					<img src="images/n1.png" alt="" width="120">
					<div class="itro">
						<h3>濾光</h3>
						<p>提供使用者選擇適合的顏色
                            、依照使用環境及個人狀況，
                            設定濾鏡的強度，降低藍光對
                            於眼睛的傷害。
					</div>
				</div>
				<div class="intro2">
					<img src="images/ad.png" alt="" width="120">
					<div class="itro">
                        <h3>擋Google廣告</h3>
						<p>如不想再瀏覽看到廣告，可以使用此功能擋Google瀏覽器所產生的廣告。
					</div>
				</div>
				<div class="intro">
					<img src="images/n2.png" alt="" width="120">
					<div class="itro">
						<h3>背景顏色</h3>
						<p>設計出能讓使用者選擇瀏覽器上網頁的配色，此功能根據色彩組合，讓畫面看起來舒適簡潔，背景可調整成偏好的顏色或改成柔和的顏色。</p>
					</div>
				</div>
                <div class="intro2">
					<img src="images/n3.png" alt="" width="120">
					<div class="itro">
					
                        <h3>同步</h3>
						<p>系統會偵測使用者的環境亮度，畫面會跟著環境亮度而改變，利用手機感光元件感測環境亮度進而改變螢幕亮度，讓使用者能舒適地瀏覽網頁。</p>

					</div>
				</div>
				<div class="intro-a">
					<img src="images/n4.png" alt="" width="120">
					<div class="itro">
						<h3>提醒</h3>
						<p>目的是提醒使用者使用電腦的時間，透過時間設定的方式來提醒做適度的休息；另外也會用記錄每天使用電腦的情況，能事後觀看自己的使用時間。</p>
					</div>
				</div>
				<div class="intro2-b">
					<img src="images/n5.png" alt="" width="120">
					<div class="itro">
						<h3>推薦</h3>
						<p>根據各年齡層的舒適度、喜好，建議出適合使用者的字體大小及色彩組合，分析出不同個年齡的顏色組合及字體大小、向用戶推薦較舒適的顏色組合，滿足使用者的需求。</p>
					</div>
				</div>
                <h2>App</h2>
				<div class="intro">
					<img src="images/n6.png" alt="" width="120">
					<div class="itro">
						<h3>濾光</h3>
						<p>濾掉多餘的光線使使用者在使用3c產品時能使眼睛更舒適。
					</div>
				</div>
				<div class="intro2">
					<img src="images/n7.png" alt="" width="120">
					<div class="itro">
						<h3>亮度</h3>
						<p>利用手機自動感光原件可讓使用者選擇是否開起自動改變亮度或手動調整亮度。</p>
					</div>
				</div>
				<div class="intro-a">
					<img src="images/n8.png" alt="" width="120">
					<div class="itro">
						<h3>手機與電腦同步亮度 / 主題</h3>
						<p>利用手機自動感測亮度後直接改變電腦端的螢幕亮度。</p>
						<p id="p2">使用者設定好濾光、亮度、提醒時間後可直接儲存設定到主題內。
						</p>
					</div>
				</div>
				<div class="intro2-b">
					<img src="images/n9.png" alt="" width="120">
					<div class="itro">
						<h3>提醒</h3>
						<p>為了避免長時間使用3c產品造成的眼部傷害，讓使用者可以選擇提醒休息的時間讓眼睛得到良好休息。</p>
					</div>
                  </div>
               </div>
                
			</div>

			<a name="Vote" class="am"></a>
			<div class="dmenu2">
                <div id="cotent2">
                    <p class="h1-a">主題</p>
				<div class="Vtheme">
                     <div style="width: 900px;font-family:'Microsoft JhengHei';margin-left:15%;">
            <asp:Literal runat="server" ID="voteitem"></asp:Literal>
                <span class="bu1">                            
                <asp:Button ID="Button1" runat="server" Text="我要投票" OnClick="Button1_Click"/></span>
                <asp:Literal runat="server" ID="div1"></asp:Literal>
                <asp:Literal runat="server" ID="voteitem2"></asp:Literal>
                  
                <span class="bu2">
                <asp:Button ID="Button2" runat="server" Text="我要投票" OnClick="Button2_Click" style="margin-left:1.5em; float: left;" /></span>

                <asp:Literal runat="server" ID="div2"></asp:Literal>
                <asp:Literal runat="server" ID="voteitem3"></asp:Literal>
         
                 <span class="bu3">   
                <asp:Button ID="Button3" runat="server" Text="我要投票" OnClick="Button3_Click" Style="margin-left: 1em; float: left;" /></span>
                            
                <asp:Literal runat="server" ID="div3"></asp:Literal>
                      
                 <asp:Literal runat="server" ID="voteitem4"></asp:Literal>
                   
               <span class="bu4">
                 <asp:Button ID="Button4" runat="server" Text="我要投票" OnClick="Button4_Click" Style="margin-left: 1em; float: left;" /></span>
                           
                            
                <asp:Literal runat="server" ID="div4"></asp:Literal>
               
                <asp:Literal runat="server" ID="voteitem5"></asp:Literal>
   
                 <span class="bu5">   
                <asp:Button ID="Button5" runat="server" Text="我要投票" OnClick="Button5_Click" Style="margin-left: 1em; float: left;" /></span>
               <asp:Literal runat="server" ID="div5"></asp:Literal>
               <asp:Literal runat="server" ID="voteitem6"></asp:Literal>
                 <span class="bu6">
              <asp:Button ID="Button6" runat="server" Text="我要投票" OnClick="Button6_Click" Style="margin-left: 1em; float: left;" /></span>
              <asp:Literal runat="server" ID="div6"></asp:Literal>
            </div>
            	</div>
              
               
                </div>
				
			</div>

			<a name="Message" class="am"></a>
			<div class="dmenu3">
                <div id="content3">
                    <p class="h1-a">
					留言
				    </p>
				    <div id="txt">
                    <p id="r">
                	    <input type="email" id="email" placeholder="Email" runat="server" maxlength="30" style="width:475px"/>
                    </p> 
                    <p>
                	    <textarea runat="server" id="msg" placeholder="輸入訊息" rows="6" ></textarea>
                    </p>
                    <asp:Button ID="submit"  runat="server" Text="送出" style="font-size:12pt" />
                    <asp:Label ID="Label1" runat="server" style="position:absolute"></asp:Label>
            	    </div>
                </div>
				
			</div>

			<a name="Download" class="am"></a>
			<div class="dmenu4">
                <div id="content4">
                    <p class="h1-a">
					下載
				</p>
				<div class="down">
                <p>Goggle Plug-in 下載</p>
                <img src="images/ppin.jpg" >
                <a href="#" class="bt" id="dw" > 
                	<p>DOWNLOAD</p>
                </a>
            	</div>
            	<div class="down">
                <p>Goggle APP 下載</p>
                <img src="images/app.jpg"  >
                <span>請使用手機掃描 QRCode</span>
                <img src="images/qr.jpg" id="qr">
            	</div>
                </div>
				
			</div>

			<a name="About" class="am"></a>
			<div class="dmenu5">
                <div id="content5">
                    	<p class="h1-a">
					關於我們
				</p>
				<div class="c1">
                <div class="box">
                    <h2>產品名稱</h2>
                    <p><img src="icon3.ico" width="30">GOGGLE 顧目啾</p>
                    <h2>簡短說明</h2>
                    <p>使用者接觸這套軟體時，提醒現代人更需要適時的使用螢幕、適度的休息來保護好自己的眼睛，更健康的使用3C產品。</p>
                    <h2>版本資訊</h2>
                    <p>第一版</p>
                    <h2>詳細說明</h2>
                    <p> 我們希望藉由Goggle這個軟體來讓手機及Chrome extension跨平台同步，主要透過手機的感光元件偵測周圍環境，透過Web service將手機上所得到的感光值與濾光量計算後傳至Chrome extension，讓電腦接收資訊後進行與手機環境同步，讓電腦螢幕更融入使用者的環境，以及探討文獻後，找出閱讀時的文字及背景色彩、亮度組合，讓人們在使用3C產品時如同帶了護目鏡，隔絕了對眼睛不好的因子，讓使用者更為便利。</p>
                </div>
                <div class="box1">
                    <h2>創作團隊</h2>
                        <h3>擴充功能組</h3>
                        <img src="images/20.gif" >
                        <span class="myname">劉繼元</span>
                        <img src="images/40.gif" >
                        <span class="myname">廖偉宏</span>
                    
                       <h3>手機組</h3>
                        <img src="images/34.gif" >
                        <span class="myname">許翰傑</span>
                        <img src="images/56.gif" >
                        <span class="myname">陳虹吟</span>
                        <img src="images/21.gif" >
                        <span class="myname">王立宇</span>
           		       	 <h3>網站組</h3>
                       	<img src="images/53.gif" >
                        <span class="myname">林韻庭</span>
                        <img src="images/31.gif" >
                        <span class="myname">陳宛婷</span>
                        <img src="images/39.gif" >
                        <span class="myname">吳昌翰</span>
                    <div class="box">
                        <h2>與我們聯繫</h2>
                        <p>電子郵件 :
                            <a href="mailto:lhugoggle@gmail.com"> lhugoggle@gmail.com</a>
                        </p>
                        <p>facebook : 
                        	<a href="https://www.facebook.com/goggle.tw?pnref=lhc" title="Goggle臉書粉絲團">Goggle臉書粉絲團</a>
                        </p>
                    </div>
                </div>
            	</div>
                </div>
			
            </div>
            <div id="LoginBox">
        <div class="row1">
            會員登入<a href="#" title="關閉" class="close_btn" id="closeBtn">×</a>
        </div>
        <div class="row">
            帳號: <span class="inputBox">
                <input type="text" id="txtName" />
            </span><a title="提示" class="warning" id="warn">請輸入帳號</a>
        </div>
        <div class="row">
               密碼: <span class="inputBox">
                <input type="password" id="txtPwd" />
            </span><a title="提示" class="warning" id="warn2">請輸入密碼</a>
        </div>
        <div class="row">
            <input type="submit" id="loginbtn" value="登入" runat="server"/>
            <div id="forget">
                <p>忘記密碼?</p>
            </div>
            <span id="font">|尚未<a href="#">註冊</a></span>
            <div id="panel">    
               信箱:<span class="inputBox">
                <input type="email" id="mail" placeholder="例:adb123@yahoo.com.tw" />
                <input type="submit" id="emailbtn" value="送出"/>
              </span><div class="warning2" id="warn3"></div> 
              <p>請輸入註冊的信箱</p>           
            </div>
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