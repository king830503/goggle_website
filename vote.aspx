<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vote.aspx.cs" Inherits="content_vote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
    <div style="margin-top:-70px;width: 900px;font-family:'Microsoft JhengHei'">
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
    </form>
</body>
</html>
