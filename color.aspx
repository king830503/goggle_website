<%@ Page Language="C#" AutoEventWireup="true" CodeFile="color.aspx.cs" Inherits="color" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        html {
    font-family: sans-serif;
    /* 1 */
    -ms-text-size-adjust: 100%;
    /* 2 */
    -webkit-text-size-adjust: 100%;
    /* 2 */
}

body {
    margin: 0;
    padding: 0;
}

header {
    margin: 0;
    padding: 0;
}

article, aside, details, figcaption, figure, footer, header, hgroup, main, menu, nav, section, summary {
    display: block;
}

audio, canvas, progress, video {
    display: inline-block;
    /* 1 */
    vertical-align: baseline;
    /* 2 */
}

    audio:not([controls]) {
        display: none;
        height: 0;
    }

[hidden], template {
    display: none;
}

a {
    background-color: transparent;
}

    a:active, a:hover {
        outline: 0;
    }

abbr[title] {
    border-bottom: 1px dotted;
}

b, strong {
    font-weight: bold;
}

dfn {
    font-style: italic;
}

h1 {
    font-size: 2em;
    margin: 0.67em 0;
}

mark {
    background: #ff0;
    color: #000;
}

small {
    font-size: 80%;
}

sub {
    font-size: 75%;
    line-height: 0;
    position: relative;
    vertical-align: baseline;
}

sup {
    font-size: 75%;
    line-height: 0;
    position: relative;
    vertical-align: baseline;
    top: -0.5em;
}

sub {
    bottom: -0.25em;
}

img {
    border: 0;
}

svg:not(:root) {
    overflow: hidden;
}

figure {
    margin: 1em 40px;
}

hr {
    -moz-box-sizing: content-box;
    box-sizing: content-box;
    height: 0;
}

pre {
    overflow: auto;
}

code, kbd, pre, samp {
    font-family: monospace, monospace;
    font-size: 1em;
}

button, input, optgroup, select, textarea {
    color: inherit;
    /* 1 */
    font: inherit;
    /* 2 */
    margin: 0;
    /* 3 */
}

button {
    overflow: visible;
    text-transform: none;
}

select {
    text-transform: none;
}

button, html input[type="button"] {
    -webkit-appearance: button;
    /* 2 */
    cursor: pointer;
    /* 3 */
}

input[type="reset"], input[type="submit"] {
    -webkit-appearance: button;
    /* 2 */
    cursor: pointer;
    /* 3 */
}

button[disabled], html input[disabled] {
    cursor: default;
}

button::-moz-focus-inner {
    border: 0;
    padding: 0;
}

input {
    line-height: normal;
}

    input::-moz-focus-inner {
        border: 0;
        padding: 0;
    }

    input[type="checkbox"], input[type="radio"] {
        box-sizing: border-box;
        /* 1 */
        padding: 0;
        /* 2 */
    }

    input[type="number"]::-webkit-inner-spin-button, input[type="number"]::-webkit-outer-spin-button {
        height: auto;
    }

    input[type="search"] {
        -webkit-appearance: textfield;
        /* 1 */
        -moz-box-sizing: content-box;
        -webkit-box-sizing: content-box;
        /* 2 */
        box-sizing: content-box;
    }

        input[type="search"]::-webkit-search-cancel-button, input[type="search"]::-webkit-search-decoration {
            -webkit-appearance: none;
        }

fieldset {
    border: 1px solid #c0c0c0;
    margin: 0 2px;
    padding: 0.35em 0.625em 0.75em;
}

legend {
    border: 0;
    /* 1 */
    padding: 0;
    /* 2 */
}

textarea {
    overflow: auto;
}

optgroup {
    font-weight: bold;
}

table {
    border-collapse: collapse;
    border-spacing: 0;
}

td, th {
    padding: 0;
}

ol, ul {
    list-style: none;
}
        body
        {
            font-family: Microsoft JhengHei;
        }
        #wrap
        {
            width:650px;
            margin:0 auto;
        }
        #theme1
        {
            background-color:rgb(255,240,132);
            color:rgb(63, 72, 204);

        }
         #theme2
        {
            background-color:rgb(63,72,204);
            color:rgb(185,122,87);

        }
          #theme3
        {
            background-color:rgb(153,217,234);
            color:rgb(150,150,150);

        }
        #theme4
        {
            background-color:rgb(185,122,87);
            color:rgb(255,201,14);

        }
        #theme5
        {
            background-color:rgb(136,0,21);
            color:rgb(0,126,232);

        }
        #theme6
        {
            background-color:rgb(163,73,164);
            color:rgb(255,255,255);

        }
        #theme7
        {
          
            background-color:rgb(195,195,195);
            color:rgb(255,127,39);

        }
        #theme8
        {

            background-color:rgb(239,228,176);
            color:rgb(237, 28,36);

        }
        .theme
        {
            width:250px;
            line-height:80px;
            border-radius:50px;
            text-align:center;
             margin-top:20px;
             font-size:22px;
             font-family:'Microsoft JhengHei';
             font-weight:bold;

        }
        input[type="submit"]
        {
            width:130px;
            background-color:rgb(109, 200, 167);
            line-height:30px;
            border-radius:10px;
            -moz-appearance: none;
		-webkit-appearance: none;
		-o-appearance: none;
		-ms-appearance: none;
		-appearance: none;
        text-align:center;
        		border: 0;
                color:#fff;
                font-size: 1em;
                font-weight:bold;
                font-family:'Microsoft JhengHei';
                margin-left:60px;
                margin-top:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrap">
        <div style="float:left;">
        <h3>紅綠色弱</h3>
        <asp:Literal runat="server" ID="Literal1"></asp:Literal>
       
        <asp:Button ID="add1" runat="server" Text="加入環境" OnClick="add1_Click" />
         <asp:Literal runat="server" ID="Literal2"></asp:Literal>
        
         <asp:Button ID="add2" runat="server" Text="加入環境" OnClick="add2_Click" />
          <asp:Literal runat="server" ID="Literal3"></asp:Literal>
        
         <asp:Button ID="add3" runat="server" Text="加入環境" OnClick="add3_Click" />
          <asp:Literal runat="server" ID="Literal4"></asp:Literal>
    
         <asp:Button ID="add4" runat="server" Text="加入環境" OnClick="add4_Click" />
        </div>
        <div style="float:right;">
        <h3>藍綠(黃)色弱</h3>
         <asp:Literal runat="server" ID="Literal5"></asp:Literal>
        
         <asp:Button ID="add5" runat="server" Text="加入環境" OnClick="add5_Click" />
          <asp:Literal runat="server" ID="Literal6"></asp:Literal>
        
         <asp:Button ID="add6" runat="server" Text="加入環境" OnClick="add6_Click" />
          <asp:Literal runat="server" ID="Literal7"></asp:Literal>
        
         <asp:Button ID="add7" runat="server" Text="加入環境" OnClick="add7_Click" />
          <asp:Literal runat="server" ID="Literal8"></asp:Literal>
        
         <asp:Button ID="add8" runat="server" Text="加入環境" OnClick="add8_Click" />
       </div>
    </div>
    </form>
</body>
</html>
