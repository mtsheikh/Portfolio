using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _12_Ass12 : System.Web.UI.Page
{
    List<List<string>> products;

    protected void Page_Load(object sender, EventArgs e)
    {
        products = new List<List<string>>();  // initialize list of list of string

        if (!IsPostBack)
            FillDropList("");  // populate DDL
    }

    private void FillDropList(string s)
    {
        DDL_Supliers.DataSource = NorthwindAccess.GetSuppliersSDS(TXB_Filter.Text);  // needs a string to filter by for getting the datasource

        DDL_Supliers.DataTextField = "CompanyName";  // data text and values
        DDL_Supliers.DataValueField = "SupplierID";

        DDL_Supliers.Items.Clear();
        DDL_Supliers.DataBind();  // pops all data in
        DDL_Supliers.AppendDataBoundItems = true;  // allows for dynamic adding of...  stuff...
        DDL_Supliers.Items.Insert(0, "Now Pick a Company from " + DDL_Supliers.Items.Count);  // make this the first item in the DDL
    }

    protected void BTN_Filter_Click(object sender, EventArgs e)
    {
        FillDropList(TXB_Filter.Text);  // re-run the DDL populate based on a filter
    }

    protected void DDL_Supliers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_Supliers.SelectedIndex < 1)  // if we have no filter
            return;

        products = NorthwindAccess.GetProducts(DDL_Supliers.SelectedValue);  // populate the list of list of string

        ConstructTable();  // make the table
    }

    private void TableInit()
    {
        TableHeaderRow tHead = new TableHeaderRow();

        for (int i = 0; i < products[0].Count; i++)  // move through the header entries
        {
            TableHeaderCell thCell = new TableHeaderCell();  // make a new cell each run
            thCell.Text = (products[0][i]);  // get text based on for loop position

            tHead.Cells.Add(thCell);  // and add the cell to the header
        }

        TBL_Products.Rows.Add(tHead);  // add the complete header to the table

        products.RemoveAt(0);  // and remove the header row from the list of list of string
    }

    private void ConstructTable()
    {
        TableRow tRow;
        TableCell tCell;

        TableInit();

        foreach (List<string> ls in products)  // foreach through a smaller list of string
        {
            tRow = new TableRow();  // make a new row

            foreach (string s in ls)  // foreach induvidual string in each list
            {
                tCell = new TableCell();  // make a new cell
                tCell.Text = s;  // throw in the text

                tRow.Cells.Add(tCell);  // and add the cell to the row
            }

            TBL_Products.Rows.Add(tRow);  // add the completed row to the table
        }
    }
}