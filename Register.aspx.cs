using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        List<User> users = UserDB.getAllCustomer();
        foreach (User i in users)
        {
            if (tbxEmail.Text == i.Email)
            {
                pnlInfo.Visible = true;
                lblOutput.Text = "Account Already Exists";
                break;
            }
            else
            {
            User u = new User(){Email = tbxEmail.Text, Username = tbxUsername.Text,Password = tbxPassword.Text, Phone=tbxPhnum.Text,Address=tbxAddress.Text, Unitnum=tbxUnitnum.Text, Zipcode=Convert.ToInt32(tbxZipcode.Text)};
            UserDB.AddCustomer(u);
            Response.Write("<script>alert('Registered Succesfull. Log In to start Shopping!');</script>");
            Server.Transfer("LoginForm.aspx");
            }

        }
    }
}