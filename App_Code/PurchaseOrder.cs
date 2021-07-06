using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseOrder
/// </summary>
public class PurchaseOrder
{
    public int OrderID { get; set; }
    public User User { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public string CreditCard { get; set; }
    public List<Book> Items { get; set; }

}