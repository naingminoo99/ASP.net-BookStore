using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        dtlBook.DataSource = BookDB.getAllBook();
        dtlBook.DataBind();
        
    }

    protected void dtlPainting_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Book> books =BookDB.getAllBook();

        if (Session["cart"] == null)
        {
            Session["cart"] = new List<Book>();
        }
        List<Book> cart = (List<Book>)Session["cart"];
        cart.Add(books[dtlBook.SelectedIndex]);
        Session["cartcount"]= cart.Count();
        if (IsPostBack)
        {
            Response.Redirect("ShopBook.aspx");
        }
    }

    protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        string aid = /*Convert.ToInt32(*/ddlFilter.SelectedValue;
        dtlBook.DataSource = BookDB.filterBookByAuthor(aid);
        dtlBook.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string q = tbxSearch.Text;
        dtlBook.DataSource = BookDB.getBookByName(q);
        dtlBook.DataBind();
    }

    protected void dtlBook_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        int count = dtlBook.Items.Count + 1;
        lblDataCount.Text = count.ToString();
    }
}