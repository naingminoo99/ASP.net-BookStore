using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User u = (User)Session["user"];
        int check = Convert.ToInt32(Session["cartcount"]);
        int odstatus = Convert.ToInt32(Session["odStatus"]);
        if (check > 0)
        {
            pnlPayment.Visible = true;
            gvCart.DataSource = (List<Book>)Session["cart"];
            gvCart.DataBind();
            displayTotal();
            tbxNameOC.Text = u.Username.ToString();

        }
        else if (odstatus>0)
        {
            pnlOrderSuccess.Visible = true;
            lblOdnum.Text = Session["odStatus"].ToString();
        }
        else
        {
            pnlCartEmpty.Visible = true;

        }

    }
    public void displayTotal()
    {
        List<Book> sc = (List<Book>)Session["cart"];
        decimal total = 0;
        foreach (Book p in sc)
        {
            total += p.Price;
        }
        lblAmount.Text = total.ToString("c");
        lbltotalP.Text = total.ToString("c");
    }

    protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<Book> sc = (List<Book>)Session["cart"];
        sc.RemoveAt(e.RowIndex);
        gvCart.DataSource = (List<Book>)Session["cart"];
        gvCart.DataBind();
        displayTotal();
        Session["cartcount"] = Convert.ToInt32(Session["cartcount"]) - 1;
        Response.Redirect("Cart.aspx");

    }
    protected void btnPay_Click(object sender, EventArgs e)
    {
        PurchaseOrder po = new PurchaseOrder()
        {
            User = (User)Session["user"],
            OrderDate = DateTime.Now,
            CreditCard = tbxCreditCard.Text,
            Total = Decimal.Parse(lblAmount.Text, System.Globalization.NumberStyles.Currency),
            Items = (List<Book>)Session["cart"]
        };
        //if (Session["orders"] == null)//no purchase history
        //{
        //    Session["orders"] = new List<PurchaseOrder>();
        //}
        //List<PurchaseOrder> orders = (List<PurchaseOrder>)Session["orders"];
        //orders.Add(po);
        //lblOutput.Text = "Order ID is " + num;
        int orderid = PurchaseOrderDB.insertOrder(po);
        if (orderid > 0)
            lblOutput.Text = "Order ID is " + orderid;
        Session["cart"] = null;
        Session["cartcount"] = 0;
        //i am using mailkit instaed of SmtpClient because it is officially replaced in place of smtpClient by microsoft
        User u = (User)Session["user"];
        string EmailMsg = "Hello "+ u.Username +"  Your Order " + orderid.ToString() + " is Confirmed. You can check your Order history by logging into your acccount";
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Book Sore", "noreply.BookStore@mail.com"));
        message.To.Add(new MailboxAddress(u.Username, u.Email));
        message.Subject = "Order Comfirmed";
        message.Body = new TextPart("plain")
        {
            Text = EmailMsg 
        };

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 465, true);//smtp connect
            client.Authenticate("kyawfamily10100@gmail.com", "Kk63996399");//email login
            client.Send(message);
            client.Disconnect(true);

        }
        Session["odStatus"] = orderid;
        Response.Redirect("Cart.aspx");

    }
    protected void lblClearCart_Click(object sender, EventArgs e)
    {
        Session["cart"] = null;
        Session["cartcount"] = 0;
        Response.Redirect("Cart.aspx");
    }


    protected void btnOdClear_Click(object sender, EventArgs e)
    {
        Session["odStatus"] = 0;
        Server.Transfer("Cart.aspx");
    }
}