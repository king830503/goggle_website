<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
         .theme
        {
            width:250px;
            line-height:80px;
            border-radius:50px;
            text-align:center;
             margin-top:20px;
             font-size:26px;
        }
           input[type="submit"]
        {
            width:130px;
            background-color:rgb(109, 200, 167);
            height:50px;
            line-height:25px;
            border-radius:10px;
            -moz-appearance: none;
		-webkit-appearance: none;
		-o-appearance: none;
		-ms-appearance: none;
		-appearance: none;
        text-align:center;
        		border: 0;
                color:#fff;
                font-size:1.5em;
                font-weight:bold;
                font-family:'Microsoft JhengHei';
                margin-left:60px;
                margin-top:30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="votebutton" runat="server"></div>
    <asp:Literal runat="server" ID="panel"></asp:Literal>
    <asp:Label runat="server" ID="abc"></asp:Label>
    
    </form>
</body>
</html>
