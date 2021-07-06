using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdatePaintingForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( ! IsPostBack)
            databind();
    }

    private void databind()
    {
        gvPainting.DataSource = BookDB.getAllBook();
        gvPainting.DataBind();
    }

    protected void gvPainting_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvPainting.EditIndex = e.NewEditIndex;
        databind();
    }

    protected void gvPainting_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPainting.EditIndex = -1;
        databind();
    }

    protected void gvPainting_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        List<Book> books = (List<Book>)Application["books"];
        Book p = books[e.RowIndex];
        p.Price = Convert.ToDecimal(e.NewValues["Price"]);

        gvPainting.EditIndex = -1;
        databind();
    }

   
}