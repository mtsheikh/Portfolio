using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _14_Ass14 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            NorthwindAccess.FillProductsDDL(ddlProducts);
        }
    }

    protected void btnGetOrderDetails_Click(object sender, EventArgs e)
    {
        int orderID = 0;
        if (int.TryParse(tbOrderID.Text, out orderID))
        {
            gvOrders.DataSource = NorthwindAccess.GetOrderDetails(orderID);
            gvOrders.DataBind();
            lblInsStatus.Text = " status";
            lblStatus.Text = "Status: status";
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        int orderID = 0;
        int productID = 0;
        int quantity = 0;
        if (int.TryParse(tbInsOrderID.Text, out orderID))
            if (int.TryParse(tbQuantity.Text, out quantity))
                if (int.TryParse(ddlProducts.SelectedValue, out productID))
                {
                    lblInsStatus.Text = NorthwindAccess.InsertOrderDetails(orderID, productID, quantity);
                      
                }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (gvOrders.SelectedIndex > -1 && gvOrders.Rows.Count > 0) 
        {
            GridViewRow row = gvOrders.SelectedRow;
            int orderID = 0;
            if (int.TryParse(row.Cells[1].Text, out orderID))
                lblStatus.Text = NorthwindAccess.DeleteOrderDetails(orderID, row.Cells[2].Text);
        }
    }
}