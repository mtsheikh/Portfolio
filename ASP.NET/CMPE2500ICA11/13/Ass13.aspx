<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ass13.aspx.cs" Inherits="_13_Ass13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     Pick a Customer :

    <asp:DropDownList ID="DDL_Customers" runat="server" Width="300px" 
        OnSelectedIndexChanged="DDL_Customers_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList>
    
    <asp:TextBox ID="TXB_FilterCust" runat="server" Width="200px">
    </asp:TextBox>

    <asp:Button ID="BTN_FilterCust" runat="server" Text="Filter" OnClick="BTN_FilterCust_Click" />

    <br /><br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </asp:Content>

