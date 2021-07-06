using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for UserDB
/// </summary>
public class UserDB
{
    //Register Insert to Customer table
    public static int AddCustomer(User u)
    {
        SqlConnection con = CustomFunctions.DBcon();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "insert into Customer (Email, Username, Password, Phone, Address,Unitnum,Zipcode) values (@email, @uname , @password, @phone, @address, @unitnum, @zipcode)";
            command.Parameters.AddWithValue("@email", u.Email );
            command.Parameters.AddWithValue("@uname", u.Username);
            command.Parameters.AddWithValue("@password", u.Password );
            command.Parameters.AddWithValue("@phone", u.Phone );
            command.Parameters.AddWithValue("@address",   u.Address );
            command.Parameters.AddWithValue("@unitnum",u.Unitnum );
            command.Parameters.AddWithValue("@zipcode",  u.Zipcode);
            con.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                return 1;
            }
            
         return -1;
        }
        finally
        {
            con.Close();
        }
    }

    //Get all user 
    public static List<User> getAllCustomer()
    {
        SqlConnection con = CustomFunctions.DBcon();
        try
        {
            List<User> users = new List<User>();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "Select * from Customer";
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User u = new User()
                {
                    Email = reader["Email"].ToString(),
                    Username = reader["Username"].ToString(),
                    Password = reader["Password"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString(),
                    Unitnum = reader["Unitnum"].ToString(),
                    Zipcode = Convert.ToInt32(reader["Zipcode"])
                };
                users.Add(u);
            }
            return users;
        }
        finally
        {
            con.Close();
        }
    }

    //Updating User detail
    public static int updateAccount (User u)
    {
        SqlConnection con = CustomFunctions.DBcon();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "update Customer set Username=@uname, Password=@password, Phone=@phone,Address=@address,Unitnum=@unitnum,Zipcode=@zipcode where Email=@email ";
            command.Parameters.AddWithValue("@uname", u.Username);
            command.Parameters.AddWithValue("@password", u.Password);
            command.Parameters.AddWithValue("@phone", u.Phone);
            command.Parameters.AddWithValue("@address", u.Address);
            command.Parameters.AddWithValue("@unitnum", u.Unitnum);
            command.Parameters.AddWithValue("@zipcode", u.Zipcode);
            command.Parameters.AddWithValue("@email", u.Email);
            con.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            con.Close();
        }

    }

}