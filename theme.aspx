<%@ Page Language="C#" AutoEventWireup="true" CodeFile="theme.aspx.cs" Inherits="user_set" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href=css/theme.css rel="stylesheet"/>
    <script src="js/jquery-1.8.3.min.js"></script>
     <script>        $(document).ready(function () {

            var setTimeouId;

            $("#firstDiv li").each(function (index) {
                $(this).mouseover(function () {
                    var nodeTabin = $(this);
                    setTimeouId = setTimeout(function () {
                        $("#firstDiv .contentin").removeClass("contentin");
                        $("#firstDiv .tabin").removeClass("tabin");

                        $("#firstDiv div").eq(index).addClass("contentin");
                        //我在这里犯错了哦，不应该再用this  this如果用在这里的话那么是指的window
                        nodeTabin.addClass("tabin");
                    }, 300);
                }).mouseout(function () {
                    clearTimeout(setTimeouId);
                });
            });
        })
        </script>
         <script type="text/javascript">
             function ab(val) {
                 document.getElementById('light').value = val;
             }
             function abc(vala) {
                 document.getElementById('filtertxt').value = vala;
             }
             function filtertxta(fliter) {
                 document.getElementById('appfilter').value = fliter;
             }
             function lighter(lightval) {
                 document.getElementById('applight').value = lightval;

             }
             function apibgrang(bgrange) {
                 document.getElementById('bgtxt').value = bgrange;
             }
             function apibgtxt(bgtxt) {
                 document.getElementById('apibg').value = bgtxt;
             }
             function apifrangt(frange) {
                 document.getElementById('plugfilter').value = frange;
             }
             function apiftxt(ftxt) {
                 document.getElementById('apifr').value = ftxt;
             }

    </script>

</head>
<body>
    <form id="form1" runat="server">
     <div id="container">
            <h3>環境設定</h3>
            <div id="content">
                  <div id="firstDiv">
                        <ul>
                            <li class="tabin">APP</li>
                            <li>BROWSER</li>
                            
                        </ul>
                        <div class="contentin">

                  <span class="pen2" >&bull; 個人主題： 
                       <asp:DropDownList ID="appTheme" runat="server" 
                       AutoPostBack="True" OnSelectedIndexChanged="appTheme_SelectedIndexChanged">
            </asp:DropDownList><br /><br />
             <span >
            &bull; 提醒 : &nbsp;  <asp:RadioButtonList ID="remind" runat="server" 
                    OnSelectedIndexChanged="remind_SelectedIndexChanged" AutoPostBack="true"
                    RepeatDirection="Horizontal" RepeatLayout="Flow" >
                       <asp:ListItem Selected="True" Text="開啟提醒"  Value="true"  ></asp:ListItem>
                       <asp:ListItem  Text="關閉提醒"  Value="false"></asp:ListItem>
                       </asp:RadioButtonList></span>
            </span>
                <br />
                <br />
                
                &bull; 提醒間隔：<asp:RadioButtonList ID="remindtime"  runat="server" 
                    OnSelectedIndexChanged="remindtime_SelectedIndexChanged"
                    RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true">
                       <asp:ListItem Selected="True" Text="30分鐘"  Value="1" ></asp:ListItem>
                       <asp:ListItem Text="1小時"  Value="2"></asp:ListItem>
                       <asp:ListItem Text="2小時" Value="3"></asp:ListItem>
                       <asp:ListItem Text="自訂" Value="4"></asp:ListItem>
                       </asp:RadioButtonList>
                      <span class="pen" style="float:left;margin-left:50%;margin-top:-32px" > <asp:TextBox id="time" runat="server" size="3" style="text-align:center;height:30px"></asp:TextBox></span>       
           <span style="float:left;margin-top:-30px;margin-left:56%;font-weight:bold">分</span> 
             <br /> 
            <p style=" font-family: 'Microsoft JhengHei';width:450px;float:left;">
                  &bull; 亮度：
                   
                  <asp:RadioButtonList ID="appset" runat="server" RepeatDirection="Horizontal" 
                       RepeatLayout="Flow" OnSelectedIndexChanged="appset_SelectedIndexChanged" AutoPostBack=true>
                       <asp:ListItem Selected="True" Text="自動設定"  Value="auto" >自動設定</asp:ListItem>
                       <asp:ListItem  Text="手動設定"  Value="manually">手動設定</asp:ListItem>
                       <asp:ListItem Text="系統自動" Value="sys_auto"></asp:ListItem>
                   </asp:RadioButtonList>
                  <br /><br />
           <input type="range" id="applight" style="width:300px;margin-left:4em" min="0" max="255" onchange= "ab(this.value);" runat="server"/><br />
     
           <span class="pen" style="float:left;margin-left:8.2em;"><input type="text" runat="server" id="light" value="0" onchange="lighter(this.value);" style="width:50px;height:30px;text-align:center;margin-top:20px;"/></span> 
            
        </p>
        <p style=" font-family: 'Microsoft JhengHei';float:right;margin-right:1.5em;margin-top:-150px;">
                   <br />
            &bull; 濾鏡：    
             <asp:RadioButtonList ID="appfliterset" runat="server" 
                RepeatDirection="Horizontal" RepeatLayout="Flow" 
                OnSelectedIndexChanged="appfliterset_SelectedIndexChanged" AutoPostBack="True">
                       <asp:ListItem Selected="True" Text="開啟濾鏡"  Value="true"  ></asp:ListItem>
                       <asp:ListItem  Text="關閉濾鏡"  Value="false"></asp:ListItem>
                   </asp:RadioButtonList>
            <br />
            <br />
              <input type="color" id="filtercolor" runat="server" value="" style="margin-left:7em;"/>
              <br />
            <br />
            <input type="range" id="appfilter" style="width:300px;"  min="0" max="100" onchange= "abc(this.value);" runat="server" /><br />
               <span class="pen2" style="float:left;margin-left:4.5em;"><input type="text" name="f" id="filtertxt"  runat="server" onchange="filtertxta(this.value);" style="width:50px;height:30px;margin-top:20px;text-align:center;"/> </span>
               <span style="float:left;height:20px; font-size: 1em; font-family: 'Microsoft JhengHei';margin-left:1.3em;margin-top:20px">%</span>
               </p>
            <br /> <br /> <br /> <br /> 
            <p style=" font-family: 'Microsoft JhengHei'">
                   
             <br /> <br />
            <span style="float:right;margin-right:16em;">
            <asp:Button ID="appsubmit" runat="server" Text="確定" OnClick="appsubmit_Click"/>
              <asp:Button ID="appcancel" runat="server" Text="刪除" OnClick="apidelete_Click"/></span>
          </p> 
    
                        </div>
                        <div id="c1">
         <span style="float:left;margin-left:0.2em;">
            <p style=" font-family: 'Microsoft JhengHei'">
                
               &bull; 背景顏色：
                <input type="color" runat="server" id="bgcolor"  style="margin-top:-150px;margin-left:-5px"/>
               <br />
             <br />
         &bull; 背景濃度：  <br /> <input type="range" runat="server" id="apibg" onchange="apibgrang(this.value)" max=100 min=1  step=1 style="margin-top:30px;margin-left:1em;"/> 
         <input type="text" runat="server" size="3" id="bgtxt" onchange="apibgtxt(this.value)" style="margin-top:20px;width:50px;height:30px;background-image:none;margin-left:46%;text-align:center" /> 
                 <span style="margin-left:200px;float:left;width:20px;margin-top:-35px;font-size:1em">%</span> 
            <br />
        </p>

 

         </span>
        <span style="float:right;margin-top:20px;margin-right:40px;">
        
            &bull; 濾鏡顏色：
                      <input type=color runat="server" id="apifilter" style="margin-top:-150px" />
                    
             <br /><br />
             &bull; 濾鏡濃度：  <br />        <input type="range" runat="server" id="apifr" onchange="apifrangt(this.value);" min="1" step="1" max="100" style="margin-top:30px;margin-left:1em;" />
         <input type="text" ID="plugfilter" runat="server" size="3" onchange="apiftxt(this.value);" style="margin-top:20px;width:50px;height:30px;background-image:none;margin-left:46%;text-align:center;" />
         <span style="margin-left:200px;float:left;width:20px;margin-top:-35px;font-size:1em">%</span>
          <br />
           &bull; 字體大小：
            <span class="pen">
            <asp:DropDownList ID="fontsize" runat="server">
                  <asp:ListItem Selected="True" Value="12">12</asp:ListItem>
                  <asp:ListItem Value="13">13</asp:ListItem>
                  <asp:ListItem Value="14">14</asp:ListItem>
                  <asp:ListItem Value="15">15</asp:ListItem>
                  <asp:ListItem Value="16">16</asp:ListItem>
                 <asp:ListItem Value="17">17</asp:ListItem>
                 <asp:ListItem Value="18" >18</asp:ListItem>
                 <asp:ListItem Value="19" >19</asp:ListItem>
                 <asp:ListItem Value="20" >20</asp:ListItem>
            </asp:DropDownList>
            </span>         
        </span>
            <span style="float:right;margin-right:16em;margin-top:2em;">
            <asp:Button ID="apisubmit" runat="server" Text="確定" OnClick="apisubmit_Click"/>
              <asp:Button ID="apicancel" runat="server" Text="取消"/>

            </span>  
           
        </div>
                    </div>
            </div>
       </div>
    </form>
</body>
</html>
