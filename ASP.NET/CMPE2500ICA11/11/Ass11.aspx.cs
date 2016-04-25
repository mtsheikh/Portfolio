using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _11_Ass11 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListItem firstAdd = new ListItem("Choose a Product Category", "0");

            DDL_ProdNames.Items.Add(firstAdd);

            DDL_ProdNames.SelectedItem.Text = firstAdd.Text;
        }
    }
}
