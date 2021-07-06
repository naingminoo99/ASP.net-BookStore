using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Customfunctions to reduces code redunduncy
/// </summary>
public class CustomFunctions
{
    // A function that will conncect to database
    public static SqlConnection DBcon()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        return con;
    }
}