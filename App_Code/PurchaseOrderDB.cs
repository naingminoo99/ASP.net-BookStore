using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// SQL functions for Orders
/// </summary>
public class PurchaseOrderDB
{
    public static string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;//Credentials  

    //This function is to insert data to Order table
    public static int insertOrder(PurchaseOrder po)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "insert into PurchaseOrder(CustomerId,OrderDate,CreditCard,Total) values(@CustomerID,@OderDate,@CreditCard,@Total)";
            command.Parameters.AddWithValue("@CustomerId", po.User.Email);
            command.Parameters.AddWithValue("@OderDate", po.OrderDate);
            command.Parameters.AddWithValue("@CreditCard", po.CreditCard);
            command.Parameters.AddWithValue("@Total", po.Total);
            con.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                command.CommandText = "Select @@IDENTITY";
                int oderid = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "insert into OrderItems values(@oderId,@BookId)";
                foreach (Book b in po.Items)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@oderId", oderid);
                    command.Parameters.AddWithValue("@BookId", b.Id);
                    command.ExecuteNonQuery();
                }
                return oderid;
            }
            return -1;
        }
        finally
        {
            con.Close();
        }
    }

    //This function is to retrieve data from Order items BY OderID
    public static List<Book> getOrderItenmsByOID(int oderId)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            List<Book> books = new List<Book>();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "select * from OrderItems where OrderId=@id";
            command.Parameters.AddWithValue("@id", oderId);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book b = BookDB.getBookById(reader["BookId"].ToString());
                books.Add(b);
            }
            return books;
        }
        finally
        {
            con.Close();
        }
    }

    //This function is to retrieve data From purchaseOrder  BY CustomerId
    public static List<PurchaseOrder> getOrderHistoryByCID(User c)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            List<PurchaseOrder> pos = new List<PurchaseOrder>();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "Select * from PurchaseOrder where CustomerId=@cid";
            command.Parameters.AddWithValue("@cid", c.Email);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PurchaseOrder po = new PurchaseOrder
                {
                    OrderID = Convert.ToInt32(reader["OrderId"]),
                    User = c,
                    OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                    CreditCard = reader["CreditCard"].ToString(),
                    Total = Convert.ToDecimal(reader["Total"]),
                    Items = PurchaseOrderDB.getOrderItenmsByOID(Convert.ToInt32(reader["OrderId"]))
                };
                pos.Add(po);
            }
            return pos;
        }
        finally
        {
            con.Close();
        }

    }



}