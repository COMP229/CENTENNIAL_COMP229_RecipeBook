using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Recipe
/// </summary>
public class Recipe
{
    public int id { get; set; }
    public String name { get; set; }
    public String submittedBy { get; set; }
    public String category { get; set; }
    public DateTime prepareTime { get; set; }
    public int numberOfServings { get; set; }
    public String description { get; set; }
    public List<Ingredient> ingredients { get; set; }
    public String image { get; set; }

    public Recipe()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Ingredient> getIngredients()
    {
        return ingredients;
    }
}