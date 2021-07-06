using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateArtistForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            Page.MaintainScrollPositionOnPostBack = true;
            databind();
    }
    private void databind()
    {
        gvArtist.DataSource = (List<Author>)Application["authors"];
        gvArtist.DataBind();
    }

    protected void gvArtist_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Author> authors = (List<Author>)Application["authors"];
        Author a = authors[gvArtist.SelectedIndex+gvArtist.PageIndex*gvArtist.PageSize];
        tbxId.Text = a.Id;
        tbxName.Text = a.Name;
        tbxProfile.Text = a.Profile;
        tbxDateOfBirth.Text = String.Format("{0:yyyy-MM-dd}", a.Dob);
        Session["authors"] = a;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Author a = (Author)Session["authors"];
        a.Name = tbxName.Text;
        a.Profile = tbxProfile.Text;
        a.Dob = Convert.ToDateTime(tbxDateOfBirth.Text);
        lblOutput.Text = "updated!";
        databind();
    }

        protected void gvArtist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvArtist.PageIndex = e.NewPageIndex;
        databind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //not done
    }

    protected void gvArtist_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<Author> authors = (List<Author>)Application["authors"];
        authors.RemoveAt(e.RowIndex);
        databind();
    }
}