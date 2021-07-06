using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// SQL functions for Book table
/// </summary>
public class BookDB
{
    public static string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;//Credentials  

    //function for inserting to Book table
    public static string insertBook(Book b)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "insert into Book (Title, AuthorId, price, imagefile) values (@title, @authorId , @price, '@imageFile')";
            command.Parameters.AddWithValue("@title", b.Id);
            command.Parameters.AddWithValue("@authorId", b.Author.Id);
            command.Parameters.AddWithValue("@price", b.Price);
            command.Parameters.AddWithValue("@imageFile", b.Imagefile);
            con.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                command.CommandText = "select id from Book where sno=@@IDENTITY";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return reader["id"].ToString();
                }
            }
            return null;
        }
        finally
        {
            con.Close();
        }
    }

    //function that retreive all data from Book table
    public static List<Book> getAllBook()
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            List<Book> books = new List<Book>();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "Select * from Book";
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book b = new Book()
                {
                    Id = reader["Id"].ToString(),
                    Title = reader["Title"].ToString(),
                    Price = Convert.ToDecimal(reader["price"]),
                    Author = AuthorDB.getAuthorById(reader["AuthorId"].ToString()),
                    Imagefile = reader["ImageFile"].ToString()
                };
                books.Add(b);
            }
            return books;
        }
        finally
        {
            con.Close();
        }
    }

    //function that retreive data from Book table By ID
    public static Book getBookById(string id)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            Book b = null;
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "Select * from Book where id=@id";
            command.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                b = new Book()
                {
                    Id = reader["Id"].ToString(),
                    Title = reader["Title"].ToString(),
                    Price = Convert.ToDecimal(reader["price"]),
                    Author = AuthorDB.getAuthorById(reader["AuthorId"].ToString()),
                    Imagefile = reader["ImageFile"].ToString()
                };
            }
            return b;
        }
        finally
        {
            con.Close();
        }
    }
    //function that retreive certain data from Book table (FOR SEARCH)
    public static List<Book> getBookByName(string q)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            List<Book> books = new List<Book>();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "Select * from Book where Title like @name";
            command.Parameters.AddWithValue("@name", q);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book b = new Book()
                {
                    Id = reader["Id"].ToString(),
                    Title = reader["Title"].ToString(),
                    Price = Convert.ToDecimal(reader["price"]),
                    Author = AuthorDB.getAuthorById(reader["AuthorId"].ToString()),
                    Imagefile = reader["ImageFile"].ToString()
                };
                books.Add(b);
            }
            return books;
        }
        finally
        {
            con.Close();
        }
    }

    //function that retreive data from Book table By author (FOR filter)
    public static List<Book> filterBookByAuthor(string q)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            List<Book> books = new List<Book>();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "Select * from Book where AuthorId=@aid";
            command.Parameters.AddWithValue("@aid", q);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book b = new Book()
                {
                    Id = reader["Id"].ToString(),
                    Title = reader["Title"].ToString(),
                    Price = Convert.ToDecimal(reader["price"]),
                    Author = AuthorDB.getAuthorById(reader["AuthorId"].ToString()),
                    Imagefile = reader["ImageFile"].ToString()
                };
                books.Add(b);
            }
            return books;
        }
        finally
        {
            con.Close();
        }
    }


}