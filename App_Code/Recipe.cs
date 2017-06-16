using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Recipe
/// </summary>
public class Recipe
{
    public int id { get; set; }
    public String name { get; set; }
    public String submittedBy { get; set; }
    public int category { get; set; }
    public int prepareTime { get; set; }
    public int numberOfServings { get; set; }
    public String description { get; set; }
    public String directions { get; set; }
    public List<Ingredient> ingredients { get; set; }
    public String image { get; set; }

    public Recipe()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void insertRecipe()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("InsertRecipe", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@submittedBy", submittedBy));
            cmd.Parameters.Add(new SqlParameter("@idCategory", category));
            cmd.Parameters.Add(new SqlParameter("@prepareTime", prepareTime));
            cmd.Parameters.Add(new SqlParameter("@numberOfServings", numberOfServings));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@directions", directions));
            cmd.Parameters.Add(new SqlParameter("@imageURL", image));

            // execute the command
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                id = (int)rdr["idRecipe"];
            }

            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.insertIngredient(id);
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

    public void updateRecipe()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("UpdateRecipe", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idRecipe", id));
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@idCategory", category));
            cmd.Parameters.Add(new SqlParameter("@prepareTime", prepareTime));
            cmd.Parameters.Add(new SqlParameter("@numberOfServings", numberOfServings));
            cmd.Parameters.Add(new SqlParameter("@description", description));

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

    public static List<Recipe> getRecipes()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;
        List<Recipe> recipes = new List<Recipe>();

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectRecipes", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Recipe recipe = new Recipe();
                recipe.id = (int)rdr["idRecipe"];
                recipe.name = (String)rdr["name"];
                recipe.submittedBy = (String)rdr["SubmittedBy"];
                recipe.category = (int)rdr["idCategory"];
                recipe.prepareTime = (int)rdr["prepareTime"];
                recipe.numberOfServings = (int)rdr["numberOfServings"];
                recipe.description = (String)rdr["description"];
                recipe.directions = (String)rdr["directions"].ToString();
                recipe.image = (String)rdr["imageURL"].ToString();
                recipes.Add(recipe);
            }

            return recipes;
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

    public static List<Recipe> getRecipesByParamters(String submittedBy, String ingredients, String category)
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;
        List<Recipe> recipes = new List<Recipe>();
        String sqlCommand = "SELECT DISTINCT R.idRecipe FROM Recipe R LEFT JOIN RecipeIngredients RI ON R.idRecipe=RI.idRecipe WHERE 1=1";

        if (submittedBy != "")
        {
            sqlCommand += " AND " + submittedBy;
        }

        if (ingredients != "")
        {
            sqlCommand += " AND " + ingredients;
        }

        if (category != "")
        {
            sqlCommand += " AND " + category;
        }

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand(sqlCommand, conn);

            // execute the command
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Recipe recipe = new Recipe();
                recipe.id = (int)rdr["idRecipe"];
                recipe.getRecipe();
                recipes.Add(recipe);
            }

            return recipes;
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

    public void getRecipe()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectRecipe", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idRecipe", id));

            // execute the command
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                name = (String)rdr["name"];
                submittedBy = (String)rdr["SubmittedBy"];
                category = (int)rdr["idCategory"];
                prepareTime = (int)rdr["prepareTime"];
                numberOfServings = (int)rdr["numberOfServings"];
                description = (String)rdr["description"];
                directions = (String)rdr["directions"].ToString();
                image = (String)rdr["imageURL"].ToString();
                ingredients = Ingredient.getIngredients(id);
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

    public void deleteRecipe()
    {
        SqlConnection conn = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("DeleteRecipe", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idRecipe", id));

            // execute the command
            cmd.ExecuteNonQuery();
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }

    public static List<String> getUsers()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;
        List<String> users = new List<String>();

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectUsers", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                String user = (String)rdr["SubmittedBy"];
                users.Add(user);
            }

            return users;
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

    public void rateRecipe(decimal rate)
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("RateRecipe", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idRecipe", id));
            cmd.Parameters.Add(new SqlParameter("@idUser", System.Web.Security.Membership.GetUser().ProviderUserKey.ToString()));
            cmd.Parameters.Add(new SqlParameter("@rate", rate));

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

    public int getRating()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectRating", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idRecipe", id));

            // execute the command
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                return (int)rdr["rate"];
            }

            return 0;
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

    public bool isRated()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectIsRated", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idRecipe", id));
            cmd.Parameters.Add(new SqlParameter("@idUser", System.Web.Security.Membership.GetUser().ProviderUserKey.ToString()));

            // execute the command
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                return (bool)rdr["isRated"];
            }

            return false;
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