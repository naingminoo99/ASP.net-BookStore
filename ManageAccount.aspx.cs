using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"]!=null)
        {
        User u = (User)Session["user"];
        tbxEmail.Text = u.Email.ToString();
        tbxUsername.Text = u.Username.ToString();
        tbxPassword.Text = u.Password.ToString();
        tbxPhnum.Text = u.Phone.ToString();
        tbxAddress.Text = u.Address.ToString();
        tbxUnitnum.Text = u.Unitnum.ToString();
        tbxZipcode.Text = u.Zipcode.ToString();
        }

    }



    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShopBook.aspx");
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        User u = (User)Session["user"];
        u.Email = tbxEmail.Text;
        u.Username = tbxUsername.Text;
        u.Password = tbxPassword.Text;
        u.Phone = tbxPhnum.Text;
        u.Address = tbxAddress.Text;
        u.Unitnum = tbxUnitnum.Text;
        u.Zipcode = Convert.ToInt32(tbxZipcode.Text);
        if (UserDB.updateAccount(u) == 1)
        {
            pnlSave.Visible = true;
            lblOutput.Text = "Sucessfully Changed";
            DataBind();
        }
    }
}