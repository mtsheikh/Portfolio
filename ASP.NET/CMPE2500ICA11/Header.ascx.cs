using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MenuItem mi = new MenuItem();
            mi.NavigateUrl = "~/Default.aspx";
            mi.Text = "Home";
            HeadMenu.Items.Add(mi);

            mi = new MenuItem();
            mi.NavigateUrl = "~/11/Ass11.aspx";
            mi.Text = "Assignment 11";
            HeadMenu.Items.Add(mi);

            mi = new MenuItem();
            mi.NavigateUrl = "~/12/Ass12.aspx";
            mi.Text = "Assignment 12";
            HeadMenu.Items.Add(mi);

            mi = new MenuItem();
            mi.NavigateUrl = "~/13/Ass13.aspx";
            mi.Text = "Assignment 13";
            HeadMenu.Items.Add(mi);

            mi = new MenuItem();
            mi.NavigateUrl = "~/14/Ass14.aspx";
            mi.Text = "Assignment 14";
            HeadMenu.Items.Add(mi);
        }
    }
}