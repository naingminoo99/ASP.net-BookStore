using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {

            Server.Transfer("Default.aspx");
        }
    }

    //protected void btnLogin_Click(object sender, EventArgs e)
    //{

    //    if (btnLogin.Text == "Login")
    //    {
    //        Server.Transfer("LoginForm.aspx");
    //    }
    //    else
    //    {
    //        Session["admin"] = null;
    //        lblUser.Text = "";
    //        btnLogin.Text = "LogOut";
    //    }

    //}

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["admin"] = null;
        Response.Write("<script>alert('Succesfully Logged Out');</script>");
        Server.Transfer("Default.aspx");
    }
}
