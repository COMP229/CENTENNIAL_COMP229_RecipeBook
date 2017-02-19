using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Recipes : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        String theme = "Light";

        if (Request.Cookies["Theme"] != null)
        {
            theme = Server.HtmlEncode(Request.Cookies["Theme"].Value);
        }

        Page.Theme = theme;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RecipeRepository recipeRepository = (RecipeRepository)(Application["RecipeRepository"]);
        String html = "";

        foreach (Recipe recipe in recipeRepository.getRecipes())
        {
            //html += "<div class=RecipeListItemContainer>";
            //html += "<a href=ViewRecipe.aspx?Recipe=" + recipe.id + ">";
            //html += "<img class=" + "RecipeListItemImg" + " src=" + recipe.image + ">" + "</img>";
            //html += "</a>";
            //html += "<div class=" + "RecipeListItemTxt>" + recipe.name + "</div>";
            //html += "</div>\n";

            html += "<div class=RecipeListItemContainer>";
            html += "<a href=ViewRecipe.aspx?Recipe=" + recipe.id + ">";
            html += "<img class=" + "RecipeListItemImg" + " src=" + recipe.image + ">" + "</img>";
            html += "</a>";
            html += "<div class=" + "RecipeListItemTxt>";
            html += "<span>Name: " + recipe.name + "</span>";
            html += "<span>Description:" + recipe.description + "</span>";
            html += "<span>Submitted by:" + recipe.submittedBy + "</span>";
            html += "</div>";
            html += "</div>\n";
        };

        Literal1.Text = html;
    }
}