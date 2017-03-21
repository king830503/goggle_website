<%@ Page Title="管理票選主題" Language="C#" MasterPageFile="~/MasterPage-mananger.master" AutoEventWireup="true" CodeFile="mange-theme.aspx.cs" Inherits="new_mange_theme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>管理票選主題</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="container" style="padding-top:100px;padding-bottom:50px">
    <h3 style="text-align:left;color:#83c2bc;font-size: 3em;">票選主題管理</h3>
      <div class="user-comments__list clearfix" style="border-top: solid #83c2bc 0.3em; margin: 0 auto; text-align: center; padding-top: 1.2em; padding-bottom: 1em;height:auto; /*width:800px;*/">
          <div style="padding-left:100px;">
              <span class="pstyle-f" style="padding-top:5px;margin-left:150px;width:150px">主題名稱：</span>
              <span class="pstyle-i"><asp:TextBox runat="server" ID="theme"></asp:TextBox></span>    
              <span class="pstyle-b"><asp:Button runat="server" ID="lookup" Text="查詢" 
                  OnClick="lookup_Click"/>
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                  ConnectionString="<%$ ConnectionStrings:Goggle %>" 
                  SelectCommand="SELECT * FROM [votecolor]" 
                  ProviderName="System.Data.SqlClient">
              </asp:SqlDataSource>
              </span>
                   <asp:Label runat="server" ID="Label1" style="position:absolute"></asp:Label>
          </div>

        <div style="margin-top:70px;"></div> 
          <div style=" font-size:1.5em; font-family:'Microsoft JhengHei'; height:auto;padding-left:50px;">
                  <asp:GridView ID="GridView1" DataKeyNames="v_id" runat="server" CellPadding="5" ForeColor="#333333" 
                  GridLines="None" BorderStyle="Dashed" BorderWidth="1px" 
                  EnableTheming="True"  CssClass="gvStyle" Width="850px"
                      AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                      AutoGenerateColumns="False" 
                      DataSourceID="SqlDataSource1" AllowPaging="True" >
                <AlternatingRowStyle HorizontalAlign="Left"  />
                      <Columns>
                          <asp:TemplateField HeaderText="勾選">
                              <ItemTemplate>
                                  <asp:CheckBox ID="CheckBox1" runat="server" />
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="v_id" HeaderText="v_id" SortExpression="v_id" />
                          <asp:BoundField DataField="v_name" HeaderText="v_name" 
                              SortExpression="v_name" />
                          <asp:BoundField DataField="v_num" HeaderText="v_num" SortExpression="v_num" />
                          <asp:BoundField DataField="bg_r" HeaderText="bg_r" SortExpression="bg_r" />
                          <asp:BoundField DataField="bg_g" HeaderText="bg_g" SortExpression="bg_g" />
                          <asp:BoundField DataField="bg_b" HeaderText="bg_b" SortExpression="bg_b" />
                          <asp:BoundField DataField="fc_r" HeaderText="fc_r" SortExpression="fc_r" />
                          <asp:BoundField DataField="fc_g" HeaderText="fc_g" SortExpression="fc_g" />
                          <asp:BoundField DataField="fc_b" HeaderText="fc_b" SortExpression="fc_b" />
                          <asp:BoundField DataField="ac_r" HeaderText="ac_r" SortExpression="ac_r" />
                          <asp:BoundField DataField="ac_g" HeaderText="ac_g" SortExpression="ac_g" />
                          <asp:BoundField DataField="ac_b" HeaderText="ac_b" SortExpression="ac_b" />
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


           <div style="margin: 0 auto;margin-top:2em;font-family:'Microsoft JhengHei';font-size:1.5em; width:800px;margin-bottom:10%">
              <p style="float:left;margin-right:3em;">v_name<asp:TextBox ID="vname" runat="server" Width="230" Height="40" MaxLength="20"></asp:TextBox></p>

              <asp:Label runat="server" ID="alert" style="position:absolute;float:left;padding-top:90px;margin-left:-500px"></asp:Label>
              <p style="float:left;margin-right:3em;">背景顏色<br /><input type="color" runat="server" id="bg" /></p>
              <p style="float:left;margin-right:3em">字體顏色<br /><input type="color" runat="server" id="fr" /></p>
               <p style="float:left">連結顏色<br /><input type="color" runat="server" id="linkcolor" /></p>
              
          </div>
          <br />
          <br />
        <br />
        <br />
        <div style="font-size:1.5em; font-family:'Microsoft JhengHei';clear:both;">
             
              <asp:Button ID="update" runat="server" Text="修改" OnClick="update_Click" OnClientClick="return confirm('你確定要修改已選取的資料?');" />
              <asp:Button ID="Button2" runat="server" Text="取消" OnClick="cal_click" />
          </div>

         


      </div>
     <div>

     </div>
 </div>
</asp:Content>

