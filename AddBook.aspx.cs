using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddPaintingForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( ! IsPostBack)
        {
            ddlArtist.DataSource = (List<Author>)Application["authors"];
            
            ddlArtist.DataTextField = "Name";
            ddlArtist.DataValueField = "Id";
            ddlArtist.DataBind();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string imagefile = "notavailable.jpg";
        if (fldUpload.HasFile)
        {
            imagefile = fldUpload.FileName;
            fldUpload.SaveAs(Server.MapPath("~/Images/" + imagefile));
        }
        List<Author> authors = (List <Author>) Application["authors"];
        Book p = new Book()
        {
            Id = tbxId.Text,
            Title = tbxDescription.Text,
            Price = Convert.ToDecimal(tbxPrice.Text),
            Author = authors[ddlArtist.SelectedIndex],
            Imagefile = imagefile
        };
        
        imgPainting.ImageUrl = "images/" + imagefile ;
        List<Book> paintings = (List<Book>)Application["books"];
        paintings.Add(p);
    }
}