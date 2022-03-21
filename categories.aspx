<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="categories.aspx.cs" Inherits="Default2" enableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="page-wrapper">
<div id="page-inner">
<div class="mb-3">
    <label class="form-label">Category Name</label>
    <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
</div>
<div class="mb-3">
    <label class="form-label">Category Status</label>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Active</asp:ListItem>
        <asp:ListItem Value="0">Inactive</asp:ListItem>
    </asp:RadioButtonList>
</div>
<asp:Button ID="Button1" runat="server" Text="Insert" class="btn btn-primary my-5" 
        onclick="Button1_Click" />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Horizontal">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
                <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("c_id") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("c_name") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
                <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("c_status") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Edit">
            <ItemTemplate>
                <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("c_id") %>' 
                    Text="EDIT" onclick="Button2_Click" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
                <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("c_id") %>' 
                    Text="DELETE" onclick="Button3_Click" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    <SortedAscendingCellStyle BackColor="#F4F4FD" />
    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
    <SortedDescendingCellStyle BackColor="#D8D8F0" />
    <SortedDescendingHeaderStyle BackColor="#3E3277" />

</asp:GridView>
     </div>
 </div>
</asp:Content>

