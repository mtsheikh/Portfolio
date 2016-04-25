using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;  // additional usings
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class _13_Ass13 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillDropList("");  // populate DDL
    }

    private void FillDropList(string s)
    {
        NorthwindAccess.GetCustomers(TXB_FilterCust.Text, DDL_Customers);  // needs a string to filter by for getting the datasource
    }

    protected void BTN_FilterCust_Click(object sender, EventArgs e)
    {
        FillDropList(TXB_FilterCust.Text);  // re-run the DDL populate based on a filter
    }

    protected void DDL_Customers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_Customers.SelectedIndex < 1)  // if we have no filter
            return;
        
        SqlDataReader poop = NorthwindAccess.CustomerCategorySummary(DDL_Customers.SelectedValue);
        GridView1.DataSource = poop;
        GridView1.DataBind();
    }
}