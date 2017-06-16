using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Ingredient
/// </summary>
public class Ingredient
{
    public int id { get; set; }
    public String name { get; set; }
    public double quantity { get; set; }
    public int unitMeasure { get; set; }

    public Ingredient()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void insertIngredient(int idRecipe)
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("InsertRecipeIngredients", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idRecipe", idRecipe));
            cmd.Parameters.Add(new SqlParameter("@idIngredient", id));
            cmd.Parameters.Add(new SqlParameter("@quantity", quantity));
            cmd.Parameters.Add(new SqlParameter("@idUnitMeasure", unitMeasure));

            // execute the command
            rdr = cmd.ExecuteReader();
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

    public static List<Ingredient> getIngredients(int idRecipe)
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;
        List<Ingredient> ingredients = new List<Ingredient>();

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectIngredients", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idRecipe", idRecipe));

            // execute the command
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Ingredient ingredient = new Ingredient();
                ingredient.id = (int)rdr["idIngredient"];
                ingredient.name = (String)rdr["name"];
                ingredient.quantity = (double)rdr["quantity"];
                ingredient.unitMeasure = (int)rdr["idUnitMeasure"];
                ingredients.Add(ingredient);
            }

            return ingredients;
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

    public static List<Ingredient> getAllIngredientsName()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;
        List<Ingredient> ingredients = new List<Ingredient>();

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectAllIngredients", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Ingredient ingredient = new Ingredient();
                ingredient.id = (int)rdr["idIngredient"];
                ingredient.name = (String)rdr["name"];
                ingredients.Add(ingredient);
            }

            return ingredients;
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