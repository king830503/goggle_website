<%@ Page Language="C#" AutoEventWireup="true" CodeFile="3.aspx.cs" Inherits="content_1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <style>
            a:visited {
            
         
            border:0;
            
            }

        #menu1 {
            width: 500px;
            overflow: hidden;
            position: relative;
            padding:10px;
        }

            #menu1 ul {
                float: left;
                list-style: none;
                margin: 0;
                padding: 0;
                position: relative;
                left: 50%;
            }

                #menu1 ul li {
                    float: left;
                    position: relative;
                    right: 50%;
                    height:50px;
                    
                }

                    #menu1 ul li a {
                        padding: 3px 10px;
                        text-decoration: none;
                        
                        line-height: 1.3em;
                    }

                        #menu1 ul li a:hover {
                            font-style:oblique;
                        }

        a {    
        text-decoration: none;
        }
          .gol
        {
            color:#fff;
            float:left;
            margin-left:-12%;
        }
        .gor
        {
            color:#fff;
            float:right;
            margin-right:-12%;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>  
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>


    </div>
    </form>
</body>
</html>
