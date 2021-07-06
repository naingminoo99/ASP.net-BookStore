using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

/// <summary>
/// SQL functions for Author
/// </summary>
public class AuthorDB
{
    public static string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;//Credentials  
    
    //function for inserting to author table
    public static int insertAuthor(Author a)
    {
        SqlConnection con = new SqlConnection(constr);//connection
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "insert into Author values (@name,@profile,@dob)";
            command.Parameters.AddWithValue("@name", a.Name);
            command.Parameters.AddWithValue("@Profile", a.Profile);
            command.Parameters.AddWithValue("@dob", a.Dob);
            con.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            con.Close();
        }

    }

    //function for updating to author table
    public static int updateAuthor(Author a)
    {
        SqlConnection con = new SqlConnection(constr);//connection
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "update Author set Name=@name, profile=@profile, dob=@dob where id=@id";
            command.Parameters.AddWithValue("@name", a.Name);
            command.Parameters.AddWithValue("@Profile", a.Profile);
            command.Parameters.AddWithValue("@dob", a.Dob);
            command.Parameters.AddWithValue("@id", a.Id);
            con.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            con.Close();
        }

    }

    //function for deleting items from author table
    public static int deleteAuthor(Author a)
    {
        SqlConnection con = new SqlConnection(constr);//connection
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "delete from Author where id=@id";
            command.Parameters.AddWithValue("@id", a.Id);
            con.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            con.Close();
        }

    }

    //function to retreive all data from author table
    public static List<Author> getallAuthor()
    {
        SqlConnection con = new SqlConnection(constr);//connection
        try
        {
            List<Author> authors = new List<Author>();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "select * from Author";
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Author a = new Author()
                {
                    Id = reader["Id"].ToString(),
                    Name = reader["Name"].ToString(),
                    Profile = reader["Profile"].ToString(),
                    Dob = Convert.ToDateTime(reader["Dob"])
                };
                authors.Add(a);
            }
            return authors;
        }
        finally
        {
            con.Close();
        }

    }

    //function to retreive data from author table BY id 
    public static Author getAuthorById(string id)
    {
        SqlConnection con = new SqlConnection(constr);//connection
        try
        {
            List<Author> authors = new List<Author>();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "select * from Author where id=@id";
            command.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Author a = new Author()
                {
                    Id = reader["Id"].ToString(),
                    Name = reader["Name"].ToString(),
                    Profile = reader["Profile"].ToString(),
                    Dob = Convert.ToDateTime(reader["Dob"])
                };
                return a;
            }
            return null;
        }
        finally
        {
            con.Close();
        }

    }

    //function to retreive data from author table BY Name (FOR SEARCH)
    public static List<Author> getAuthorByName(string name)
    {
        SqlConnection con = new SqlConnection(constr);//connection
        try
        {
            List<Author> authors = new List<Author>();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "select * from Author where name like @name";
            command.Parameters.AddWithValue("@name", "%"+name+"%");
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Author a = new Author()
                {
                    Id = reader["Id"].ToString(),
                    Name = reader["Name"].ToString(),
                    Profile = reader["Profile"].ToString(),
                    Dob = Convert.ToDateTime(reader["Dob"])
                };
                authors.Add(a);
            }
            return authors;
        }
        finally
        {
            con.Close();
        }

    }


}