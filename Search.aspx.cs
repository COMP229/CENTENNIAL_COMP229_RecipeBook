using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
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
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        RecipeRepository recipeRepository = (RecipeRepository)(Application["RecipeRepository"]);
        String html = "";

        foreach (Recipe recipe in recipeRepository.getRecipes())
        {
            html += "<div class=RecipeListItemContainerSearch>";
            html += "<a href=ViewRecipe.aspx?Recipe=" + recipe.id + ">";
            html += "<img class=" + "RecipeListItemImgSearch" + " src=" + recipe.image + ">" + "</img>";
            html += "</a>";
            html += "<div class=" + "RecipeListItemTxtSearch>" + recipe.name + "</div>";
            html += "</div>\n";
        };

        Literal1.Text = html;
    }
}