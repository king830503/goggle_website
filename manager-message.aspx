<%@ Page Title="會員個人設定" Language="C#" MasterPageFile="~/MasterPage-mananger.master" AutoEventWireup="true" CodeFile="manager-message.aspx.cs" Inherits="new_manager_message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>會員個人設定</title>
<style type="text/css" >
    .fixwidth
    {
        word-break:break-all;
    }
</style>
<script>
    function ValidateNumber(e, pnumber) {
    if (!/^\d+$/.test(pnumber)) {
        var newValue = /^\d+/.exec(e.value);
        if (newValue != null) {
            e.value = newValue;
        }
        else {
            e.value = "";
        }
    }
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="container" style="padding-top: 100px; padding-bottom: 50px">
            <h3 style="text-align: left; color: #83c2bc; font-size: 3em;">留言管理</h3>
            <div class="user-comments__list clearfix" style="border-top: solid #83c2bc 0.3em; margin: 0 auto; text-align: center; padding-top: 1.2em; padding-bottom: 1em;  width:980px;">
                <div style="padding-left: 100px;margin-left:20%">
                    <span class="pstyle-f" style="padding-top: 5px;">編號：</span>
                    <span class="pstyle-i">
                        <asp:TextBox runat="server" ID="id" onkeyup="return ValidateNumber(this,value)"></asp:TextBox></span>


                    <span class="pstyle-b">
                        <asp:Button runat="server" ID="lookup" Text="查詢"
                            OnClick="lookup_Click" />
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="Data Source=KING0503-PC\SQLEXPRESS;Initial Catalog=test;User ID=sa;Password=f502" 
                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [msgboard]">
                    </asp:SqlDataSource>
                    </span>
                    <asp:Label runat="server" ID="Label1" style="position:absolute"></asp:Label>
                </div>


                <div style="margin-top: 70px;"></div>
                <div style="font-size: 1.5em; font-family: 'Microsoft JhengHei'; height:auto; padding-left: 100px;">
                    <asp:GridView DataKeyNames="c_id" ID="GridView1" runat="server" CellPadding="5" ForeColor="#333333"
                        GridLines="None" AllowSorting="True" BorderStyle="Dashed" BorderWidth="1px"
                        EnableTheming="True" CssClass="gvStyle" Width="850px" 
                        AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                        OnRowDeleted="delete_click" AutoGenerateColumns="False"
                        DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="5"
                        >
                        <AlternatingRowStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="勾選">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="c_id" HeaderText="c_id" InsertVisible="False"
                                ReadOnly="True" SortExpression="c_id" />
                            <asp:BoundField DataField="m_name" HeaderText="m_name"
                                SortExpression="m_name" />
                            <asp:BoundField DataField="m_mail" HeaderText="m_mail" 
                                SortExpression="m_mail" />
                            <asp:BoundField DataField="m_msg" HeaderText="m_msg"
                                SortExpression="m_msg" />
                            <asp:BoundField DataField="re_msg" HeaderText="re_msg" ItemStyle-CssClass="fixwidth"
                                SortExpression="re_msg" >
                            <ItemStyle CssClass="fixwidth" />
                            </asp:BoundField>
                            <asp:BoundField DataField="m_datetime" HeaderText="m_datetime" 
                                SortExpression="m_datetime" />
                            <asp:BoundField DataField="re_datetime" HeaderText="re_datetime" 
                                SortExpression="re_datetime" />
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
                <br />
                <br />
                <div style="font-size: 1.5em; font-family: 'Microsoft JhengHei'; margin-left:5%;clear:both;">
                <span style="float:left;margin-left:15%"> 回覆留言:</span>
                    <asp:TextBox ID="remessage" runat="server" Height="70px" Width="500px" TextMode="MultiLine" style="max-height:70px;max-width:500px"></asp:TextBox>
              
                 <span style="float:right; font-family: 'Microsoft JhengHei';margin-right:50px">  <asp:Button ID="Button3" runat="server" Text="回覆" OnClick="Button3_Click" OnClientClick="return confirm('確定回覆，回覆成功會寄信到留言者信箱');" /></span> 
                <p style="margin-top:10px;">
                    
                    <asp:Button ID="Button1" runat="server" Text="刪除" OnClick="delete_click" OnClientClick="return confirm('你確定要刪除已選取的資料?');" />
                    <asp:Button ID="Button2" runat="server" Text="取消" OnClick="cal_click" />
                </p>
                 </div>
            </div>

            <br />
            <br />

        </div>
</asp:Content>

