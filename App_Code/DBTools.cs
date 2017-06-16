using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DBTools
/// </summary>
public class DBTools
{
    public DBTools()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static SqlConnection createConnection()
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RecipeBook"].ConnectionString);
        conn.Open();
        return conn;
    }
}