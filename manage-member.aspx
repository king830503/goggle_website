<%@ Page Title="管理會員" Language="C#" MasterPageFile="~/MasterPage-mananger.master" AutoEventWireup="true" CodeFile="manage-member.aspx.cs" Inherits="new_manage_member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>管理會員</title>
    <link href="userface_manager.css" rel="stylesheet" />
    <style type="text/css">
        td {
            width: 150px;
        }

        #firstDiv li {
            background-color: #83c2bc;
            float: left;
            color: White;
            padding: 5px;
            margin-right: 3px;
            border: 1px solid white;
            list-style-type: none;
            width: 270px;
        }

        #firstDiv .tabin {
            border: 1px solid #6E6E6E;
        }

        #firstDiv div {
            clear: left;
            margin: 0 auto;
            background-color: White;
            /*border: solid #83c2bc 1em;*/
            width: 900px;
            height:800px;
            /*height: 320px;*/
            display: none;
            padding: 5px;
        }

        #firstDiv .contentin {
            display: block;
        }


        .contentin {
            color: #333;
            text-align: left;
            font-size: 24px;
        }


        #c1 {
            text-align: left;
        }
        .fo
        {
           float:left;
           width:420px;
          

        }
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="container" style="padding-top:100px;padding-bottom:50px">
    <h3 style="text-align:left;color:#83c2bc;font-size: 3em;">會員管理</h3>
      <div class="user-comments__list clearfix" style="border-top: solid #83c2bc 0.3em; margin: 0 auto; text-align: center; padding-top: 1.2em; padding-bottom: 1em; /*height:600px;width:800px;*/">
          <div style="padding-left:100px;">
              <span class="pstyle-f" style="padding-top:5px;margin-left:200px">帳號：</span>
              <span class="pstyle-i"><asp:TextBox runat="server" ID="usert"></asp:TextBox></span>    
              <span class="pstyle-b"><asp:Button runat="server" ID="lookup" Text="查詢" 
                  OnClick="lookup_Click"/>
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                  ConnectionString="<%$ ConnectionStrings:Goggle %>" 
                  SelectCommand="SELECT * FROM [member]">
              </asp:SqlDataSource>
              </span>
                   <asp:Label runat="server" ID="Label1" style="position:absolute"></asp:Label>
          </div>
          
        
        <div style="margin-top:70px;"></div> 
          <div style=" font-size:1.5em; font-family:'Microsoft JhengHei'; height:auto;padding-left:100px;">
                  <asp:GridView DataKeyNames="m_id" ID="GridView1" runat="server" CellPadding="5" ForeColor="#333333" 
                  GridLines="None" AllowSorting="True" BorderStyle="Dashed" BorderWidth="1px" 
                  EnableTheming="True"  CssClass="gvStyle" Width="850px"
                      AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                      OnRowDeleted="delete_click" AutoGenerateColumns="False" 
                      DataSourceID="SqlDataSource1" AllowPaging="True" >
                <AlternatingRowStyle HorizontalAlign="Left"  />
                      <Columns>
                          <asp:TemplateField HeaderText="勾選">
                              <ItemTemplate>
                                  <asp:CheckBox ID="CheckBox1" runat="server" />
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="m_id" HeaderText="m_id" InsertVisible="False" 
                              ReadOnly="True" SortExpression="m_id" />
                          <asp:BoundField DataField="m_name" HeaderText="m_name" 
                              SortExpression="m_name" />
                          <asp:BoundField DataField="m_mail" HeaderText="m_mail" 
                              SortExpression="m_mail" />
                          <asp:BoundField DataField="m_photo" HeaderText="m_photo" 
                              SortExpression="m_photo" />
                      </Columns>
                <EditRowStyle HorizontalAlign="Right" />
                <EmptyDataTemplate>
                    <asp:CheckBox ID="checkboxdelete" runat="server" />
                </EmptyDataTemplate>
                <FooterStyle Font-Bold="True" />
                <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
                <PagerStyle HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Left" />
                <SelectedRowStyle HorizontalAlign="Left" />
              </asp:GridView>
          </div>



        <div style="font-size:1.5em; font-family:'Microsoft JhengHei';clear:both;margin-top:20px">
              <asp:Button ID="Button1" runat="server" Text="刪除"  OnClick="delete_click" OnClientClick="return confirm('你確定要刪除已選取的資料?');" />
              <asp:Button ID="Button2" runat="server" Text="取消" OnClick="cal_click" />
          </div>

      </div>
      
      <br /><br />

  </div>
</asp:Content>


