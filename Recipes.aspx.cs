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
        String html = "";

        foreach (Recipe recipe in Recipe.getRecipes())
        {
            html += "<a href=ViewRecipe.aspx?idRecipe=" + recipe.id + ">";
            html += "<div class=RecipeListItemContainer>";
            html += "<img class=" + "RecipeListItemImg" + " src=" + recipe.image + ">" + "</img>";
            html += "<div class=" + "RecipeListItemTxt>";
            html += "<span>Name: " + recipe.name.Substring(0, 25) + (recipe.name.Trim().Length > 25 ? "..." : String.Empty) + "</span>";
            html += "<span>Description: " + (recipe.description.Trim().Length > 25 ? recipe.description.Substring(0, 25) : recipe.description) + (recipe.description.Trim().Length > 25 ? "..." : String.Empty) + "</span>";
            html += "<span>Submitted by: " + recipe.submittedBy.Substring(0, 25) + (recipe.submittedBy.Trim().Length > 25 ? "..." : String.Empty) + "</span>";
            html += "</div>";
            html += "</div>\n";
            html += "</a>";
        };

        Literal1.Text = html;
    }
}