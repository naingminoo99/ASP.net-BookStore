using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            Server.Transfer("ShopBook.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        List<User> users = UserDB.getAllCustomer();
        foreach (User u in users)
        {
            if (tbxEmail.Text == u.Email && tbxPassword.Text == u.Password)
            {
                Session["user"] = u;
                Server.Transfer("ShopBook.aspx");
            }
            else
            {
                List<Member> admins = (List<Member>)Application["admins"];
                foreach (Member a in admins)
                {
                    if (tbxEmail.Text == a.Email && tbxPassword.Text == a.Password)
                    {
                        Session["admin"] = a;
                        Response.Write("<script>alert('Redirecting to Admin Site');</script>");
                        Server.Transfer("UpdateBook.aspx");
                    }
                }
            }
        }
        pnlLoginError.Visible = true;
        lblOutput.Text = "invalid Email Or Password!";
    }

    protected void btnForgot_Click(object sender, EventArgs e)
    {
        Server.Transfer("ForgotPassword.aspx");
    }
}