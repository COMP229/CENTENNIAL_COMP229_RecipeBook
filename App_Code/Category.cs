using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
    public int id;
    public String name;

    public Category()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void insertCategory()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("InsertCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@name", name));

            // execute the command
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                id = (int)rdr["idCategory"];
            }
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
            if (rdr != null)
            {
                rdr.Close();
            }
        }
    }

    public static List<Category> getCategories()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;
        List<Category> categories = new List<Category>();

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectCategories", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Category category = new Category();
                category.id = (int)rdr["idCategory"];
                category.name = (String)rdr["name"];
                categories.Add(category);
            }

            return categories;
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
            if (rdr != null)
            {
                rdr.Close();
            }
        }
    }

    public void getCategory()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idCategory", id));

            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                name = (String)rdr["name"];
            }
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
            if (rdr != null)
            {
                rdr.Close();
            }
        }
    }
}