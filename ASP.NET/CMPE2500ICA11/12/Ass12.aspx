<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="Ass12.aspx.cs" Inherits="_12_Ass12" Theme="ADO"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1>ICA12 - ADO Part I - Basic Queries</h1><br />

    Pick a Supplier :

    <asp:DropDownList ID="DDL_Supliers" runat="server" Width="300px" 
        OnSelectedIndexChanged="DDL_Supliers_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList>
    
    <asp:TextBox ID="TXB_Filter" runat="server" Width="200px">
    </asp:TextBox>

    <asp:Button ID="BTN_Filter" runat="server" Text="Filter" OnClick="BTN_Filter_Click" />

    <br /><br />

    <center>
        <asp:Table ID="TBL_Products" runat="server" Width="500px" >
        </asp:Table>
    </center>
</asp:Content>