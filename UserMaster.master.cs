using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Server.Transfer("Default.aspx");
            lblUser.Text = "Error !!";
        }
        else
        {
            User u = (User)Session["user"];
            lblUser.Text = u.Username;
        }

        if ((Session["cartcount"] != null) && (Session["cartcount"].ToString() != ""))
        {
            lblCartCount.Text ="( "+Session["cartcount"].ToString()+" )" ;

        }


    }


    protected void lblPayment_Click(object sender, EventArgs e)
    {
        Server.Transfer("Cart.aspx");
    }

    protected void lblLogout_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["cart"] = null;
        Session["cartcount"] = null;
        Server.Transfer("Default.aspx");
    }
}       
