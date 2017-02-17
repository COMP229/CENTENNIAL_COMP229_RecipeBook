using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RecipeRepository
/// </summary>
public class RecipeRepository
{
    List<Recipe> recipes = new List<Recipe>();

    public RecipeRepository()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void createStartingRecipeList()
    {
        Recipe recipe = new Recipe();
        Recipe recipe2 = new Recipe();
        Recipe recipe3 = new Recipe();
        Recipe recipe4 = new Recipe();

        recipe.id = 1;
        recipe.name = "Coxinha";
        recipe.submittedBy = "Renato";
        recipe.category = "Snacks";
        recipe.prepareTime = DateTime.Parse("2:00:00");
        recipe.numberOfServings = 15;
        recipe.description = "Very good brazilian food";
        recipe.image = "http://www.guiadasemana.com.br/contentFiles/system/pictures/2014/5/114991/original/coxinha.jpg";
        recipes.Add(recipe);

        recipe2.id = 2;
        recipe2.name = "Brigadeiro";
        recipe2.submittedBy = "Renato";
        recipe2.category = "Dessert";
        recipe2.prepareTime = DateTime.Parse("1:30:00");
        recipe2.numberOfServings = 50;
        recipe2.description = "Very good brazilian dessert";
        recipe2.image = "https://gds-wifmtpphmjvvgffvmg.netdna-ssl.com/contentFiles/system/pictures/2015/7/139072/original/brigadeiro.jpg";
        recipes.Add(recipe2);

        recipe3.id = 3;
        recipe3.name = "Strogonoff";
        recipe3.submittedBy = "Renato";
        recipe3.category = "Meat";
        recipe3.prepareTime = DateTime.Parse("1:00:00");
        recipe3.numberOfServings = 4;
        recipe3.description = "Delicious cream meat";
        recipe3.image = "https://s-media-cache-ak0.pinimg.com/originals/bc/f4/7e/bcf47eef8822b33ec8a565617d153fd6.jpg";
        recipes.Add(recipe3);

        recipe4.id = 4;
        recipe4.name = "Pizza";
        recipe4.submittedBy = "Renato";
        recipe4.category = "Snacks";
        recipe4.prepareTime = DateTime.Parse("0:40:00");
        recipe4.numberOfServings = 4;
        recipe4.description = "Famous pizza";
        recipe4.image = "https://imagesapt.apontador-assets.com/fit-in/640x480/c262f35dac0742e4b26b1af5e7ca467c/pizzaria-napoli-5302257801299468.jpg";
        recipes.Add(recipe4);
    }

    public List<Recipe> getRecipes()
    {
        return recipes;
    }

    public void addNewRecipe(Recipe recipe)
    {
        recipes.Add(recipe);
    }
}