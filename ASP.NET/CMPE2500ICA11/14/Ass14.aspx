<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ass14.aspx.cs" Inherits="_14_Ass14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>ICA14 - Modify Order Details</h1>
    <hr />
    <h1>Part I - Delete Order Details</h1>
    <hr />
    Enter OrderID:<asp:TextBox ID="tbOrderID" runat="server"></asp:TextBox>
    <asp:Button ID="btnGetOrderDetails" runat="server" Text="Get Order Details" OnClick="btnGetOrderDetails_Click" />
    <hr />
    <asp:GridView ID="gvOrders" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" >
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <br />
    <asp:Button ID="btnDelete" runat="server" Text="Delete Selected" OnClick="btnDelete_Click" />
    <br />
    <asp:Label ID="lblStatus" Text="Status:" runat="server" />
    <br />
    <br />
    <h1>Part II - Insert Order Details</h1>
    <hr />
    Enter OrderID: <asp:TextBox ID="tbInsOrderID" runat="server"></asp:TextBox><br />
    Select Product: <asp:DropDownList ID="ddlProducts" runat="server"></asp:DropDownList><br />
    Enter Quantity: <asp:TextBox ID="tbQuantity" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnInsert" runat="server" Text="Insert Record" OnClick="btnInsert_Click" /><br />
    Status:<asp:Label ID="lblInsStatus" runat="server" Text=""></asp:Label>
</asp:Content>

