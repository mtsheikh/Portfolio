<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Ass11.aspx.cs" Inherits="_11_Ass11" Theme="ADO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="SQLDS_ProdNames" runat="server"
        ConnectionString="<%$ ConnectionStrings:msheikh11_AdventureWorksLTConnectionString %>"
        SelectCommand="SELECT [ProductCategoryID], [Name] FROM [SalesLT].[ProductCategory] WHERE ([ParentProductCategoryID] IS NOT NULL) ORDER BY [Name]"></asp:SqlDataSource>

    <asp:DropDownList runat="server" ID="DDL_ProdNames" DataSourceID="SQLDS_ProdNames" DataTextField="Name"
        DataValueField="ProductCategoryID" AppendDataBoundItems="True" AutoPostBack="True">
    </asp:DropDownList>

    <asp:SqlDataSource ID="SQLDS_Products" runat="server"
        ConnectionString="<%$ ConnectionStrings:msheikh11_AdventureWorksLTConnectionString %>"
        DeleteCommand="
DELETE FROM
    SalesLT.Product
WHERE
    [ProductID] = @ProductID"
        InsertCommand="
INSERT INTO SalesLT.Product ([Name], [ProductNumber], [StandardCost], [ListPrice], [ProductCategoryID], [SellStartDate]) VALUES (@Name, @ProductNumber, @StandardCost, @ListPrice, @ProductCategoryID, @SellStartDate)"
        SelectCommand="SELECT [ProductID], [Name], [ProductNumber], [StandardCost], [ListPrice], [ProductCategoryID], [SellStartDate] FROM SalesLT.[Product] WHERE ([ProductCategoryID] = @ProductCategoryID) ORDER BY [Name]"
        UpdateCommand="UPDATE  SalesLT.Product SET [Name] = @Name, [ProductNumber] = @ProductNumber, [StandardCost] = @StandardCost, [ListPrice] = @ListPrice, [ProductCategoryID] = @ProductCategoryID, [SellStartDate] = @SellStartDate WHERE [ProductID] = @ProductID">
        <DeleteParameters>
            <asp:Parameter Name="ProductID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="ProductNumber" Type="String" />
            <asp:Parameter Name="StandardCost" Type="Decimal" />
            <asp:Parameter Name="ListPrice" Type="Decimal" />
            <asp:Parameter Name="ProductCategoryID" Type="Int32" />
            <asp:Parameter Name="SellStartDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DDL_ProdNames" DefaultValue="0" Name="ProductCategoryID"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="ProductNumber" Type="String" />
            <asp:Parameter Name="StandardCost" Type="Decimal" />
            <asp:Parameter Name="ListPrice" Type="Decimal" />
            <asp:Parameter Name="ProductCategoryID" Type="Int32" />
            <asp:Parameter Name="SellStartDate" Type="DateTime" />
            <asp:Parameter Name="ProductID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:ListView ID="LSV_Products" runat="server" DataSourceID="SQLDS_Products" DataKeyNames="ProductID"
        InsertItemPosition="LastItem">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFF8DC;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="SelectButton" runat="server" CommandName="Select" Text="Select" />
                </td>
                <td>
                    <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="ProductNumberLabel" runat="server" Text='<%# Eval("ProductNumber") %>' />
                </td>
                <td>
                    <%--<asp:Label ID="StandardCostLabel" runat="server" Text='<%# Eval("StandardCost") %>' />--%>
                     <asp:Label ID="StandardCostLabel" runat="server" Text='<%# string.Format("{0:c}", Eval("StandardCost")) %>' />
                </td>
                <td>
                    <%--<asp:Label ID="ListPriceLabel" runat="server" Text='<%# Eval("ListPrice") %>' />--%>
                <asp:Label ID="ListPriceLabel" runat="server" Text='<%# string.Format("{0:c}", Eval("ListPrice")) %>' />
                </td>
                <td>
                    <asp:Label ID="ProductCategoryIDLabel" runat="server" Text='<%# Eval("ProductCategoryID") %>' />
                </td>
                <td>
                    <asp:Label ID="SellStartDateLabel" runat="server" Text='<%# Eval("SellStartDate") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="background-color: #008A8C; color: #FFFFFF;">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:Label ID="ProductIDLabel1" runat="server" Text='<%# Eval("ProductID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ProductNumberTextBox" runat="server" Text='<%# Bind("ProductNumber") %>' />
                </td>
                <td>
                    <asp:TextBox ID="StandardCostTextBox" runat="server" Text='<%# Bind("StandardCost") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ListPriceTextBox" runat="server" Text='<%# Bind("ListPrice") %>' />
                </td>
                <td>
                    <%--<asp:TextBox ID="ProductCategoryIDTextBox" runat="server" Text='<%# Bind("ProductCategoryID") %>' />--%>
                    <asp:DropDownList runat="server" ID="DDL_EditProductCatID" DataSourceID="SQLDS_ProdNames"
                        DataTextField="Name" DataValueField="ProductCategoryID"
                        SelectedValue='<%# Bind("ProductCategoryID") %>' />
                    </asp:DropDownList>
                </td>
                <td>
                    <%--<asp:TextBox ID="SellStartDateTextBox" runat="server" Text='<%# Bind("SellStartDate") %>' />--%>
                    <asp:Calendar runat="server" ID="CAL_EditDate" 
                        SelectedDate='<%# Bind("SellStartDate") %>' 
                        VisibleDate='<%# Bind("SellStartDate") %>'>

                    </asp:Calendar>

                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ProductNumberTextBox" runat="server" Text='<%# Bind("ProductNumber") %>' />
                </td>
                <td>
                    <asp:TextBox ID="StandardCostTextBox" runat="server" Text='<%# Bind("StandardCost") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ListPriceTextBox" runat="server" Text='<%# Bind("ListPrice") %>' />
                </td>
                <td>
                    <%--<asp:TextBox ID="ProductCategoryIDTextBox" runat="server" Text='<%# Bind("ProductCategoryID") %>' />--%>
 <asp:DropDownList runat="server" ID="DDL_InsertProductCatID" DataSourceID="SQLDS_ProdNames" 
                        DataTextField="Name" DataValueField="ProductCategoryID" 
                        SelectedValue='<%# Bind("ProductCategoryID") %>' />
                    </asp:DropDownList>
                </td>
                <td>
                    <%--<asp:TextBox ID="SellStartDateTextBox" runat="server" Text='<%# Bind("SellStartDate") %>' />--%>
                    
                    <asp:Calendar runat="server" ID="CAL_InsertDate" SelectedDate='<%# Bind("SellStartDate") %>'>

                    </asp:Calendar>


                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #DCDCDC; color: #000000;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="Button4" runat="server" CommandName="Select" Text="Select" />

                     </td>
                <td>
                    <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="ProductNumberLabel" runat="server" Text='<%# Eval("ProductNumber") %>' />
                </td>
                <td>
                    <%--<asp:Label ID="StandardCostLabel" runat="server" Text='<%# Eval("StandardCost") %>' />--%>
                      <asp:Label ID="Label4" runat="server" Text='<%# string.Format("{0:c}", Eval("StandardCost")) %>' />
                </td>
                <td>
                    <%--<asp:Label ID="ListPriceLabel" runat="server" Text='<%# Eval("ListPrice") %>' />--%>
                    <asp:Label ID="Label5" runat="server" Text='<%# string.Format("{0:c}", Eval("ListPrice")) %>' />
                </td>
                <td>
                    <asp:Label ID="ProductCategoryIDLabel" runat="server" Text='<%# Eval("ProductCategoryID") %>' />
                </td>
                <td>
                    <asp:Label ID="SellStartDateLabel" runat="server" Text='<%# Eval("SellStartDate") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                <th runat="server"></th>
                                <th runat="server">Product ID</th>
                                <th runat="server">Name</th>
                                <th runat="server">Product Number</th>
                                <th runat="server">Standard Cost</th>
                                <th runat="server">List Price</th>
                                <th runat="server">Product CategoryID</th>
                                <th runat="server">First Available for Sale</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="ProductNumberLabel" runat="server" Text='<%# Eval("ProductNumber") %>' />
                </td>
                <td>
                    <%--<asp:Label ID="StandardCostLabel" runat="server" Text='<%# Eval("StandardCost") %>' />--%>
                     <asp:Label ID="Label11" runat="server" Text='<%# string.Format("{0:c}", Eval("StandardCost")) %>' />
                </td>
                <td>
                    <%--<asp:Label ID="ListPriceLabel" runat="server" Text='<%# Eval("ListPrice") %>' />--%>
                     <asp:Label ID="Label12" runat="server" Text='<%# string.Format("{0:c}", Eval("ListPrice")) %>' />
                </td>
                <td>
                    <asp:Label ID="ProductCategoryIDLabel" runat="server" Text='<%# Eval("ProductCategoryID") %>' />
                </td>
                <td>
                    <asp:Label ID="SellStartDateLabel" runat="server" Text='<%# Eval("SellStartDate") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>

    <asp:SqlDataSource runat="server" ID="SQLDS_Selected"
        ConnectionString="<%$ ConnectionStrings:msheikh11_AdventureWorksLTConnectionString %>"
        SelectCommand="SELECT
	                        sod.LineTotal,
	                        sod.OrderQty,
	                        a.CountryRegion,
	                        a.StateProvince,
	                        a.City
                        FROM
	                        msheikh11_AdventureWorksLT.SalesLT.Product as p
                        INNER JOIN
	                        msheikh11_AdventureWorksLT.SalesLT.SalesOrderDetail as sod
                        ON
	                        p.ProductID = sod.ProductID
                        INNER JOIN
	                        msheikh11_AdventureWorksLT.SalesLT.SalesOrderHeader as soh
                        ON
	                        sod.SalesOrderID = soh.SalesOrderID
                        INNER JOIN
	                        msheikh11_AdventureWorksLT.SalesLT.Address as a
                        ON
	                        soh.ShipToAddressID = a.AddressID
                        WHERE
	                        p.ProductID = @id">
        <SelectParameters>
            <asp:ControlParameter ControlID="LSV_Products" Name="id" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:DetailsView runat="server" Height="50px" Width="350px" AllowPaging="True" AutoGenerateRows="False"
        BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
        DataSourceID="SQLDS_Selected" GridLines="None">
        <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:BoundField DataField="LineTotal" HeaderText="LineTotal"
                ReadOnly="True" SortExpression="LineTotal" />
            <asp:BoundField DataField="OrderQty" HeaderText="OrderQty" SortExpression="OrderQty" />
            <asp:BoundField DataField="CountryRegion" HeaderText="CountryRegion" SortExpression="CountryRegion" />
            <asp:BoundField DataField="StateProvince" HeaderText="StateProvince" SortExpression="StateProvince" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
        </Fields>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr>
                    <td>Nothing to see here yet...</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
    </asp:DetailsView>
</asp:Content>
