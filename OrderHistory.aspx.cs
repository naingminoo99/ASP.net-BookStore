using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User c = (User)Session["user"];
        gvOrder.DataSource = PurchaseOrderDB.getOrderHistoryByCID(c);
        gvOrder.DataBind();
    }

    protected void gvOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        User c = (User)Session["user"];
        List<PurchaseOrder> orders = PurchaseOrderDB.getOrderHistoryByCID(c);
        PurchaseOrder po = orders[gvOrder.SelectedIndex];
        gvItems.DataSource = PurchaseOrderDB.getOrderItenmsByOID(po.OrderID);
        gvItems.DataBind();
    }
}