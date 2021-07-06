using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddArtistForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Author a = new Author()
        {
            Id = tbxId.Text,
            Name = tbxName.Text,
            Dob = Convert.ToDateTime(tbxDateOfBirth.Text),
            Profile = tbxProfile.Text,
        };
        lblOutput.Text = "added!";
        List<Author> artistList = (List<Author>) Application["authors"];
        artistList.Add(a);
        
    }
}