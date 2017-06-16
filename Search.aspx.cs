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
        if (!IsPostBack)
        {
            List<String> users = Recipe.getUsers();

            ddlSubmittedBy.Items.Add(new ListItem("All", ""));
            foreach(String user in users)
            {
                ddlSubmittedBy.Items.Add(new ListItem(user, "SubmittedBy='" + user + "'"));
            }

            List<Category> categories = Category.getCategories();

            ddlCategory.Items.Add(new ListItem("All", ""));
            foreach(Category category in categories)
            {
                ddlCategory.Items.Add(new ListItem(category.name, "idCategory=" + category.id.ToString()));
            }

            List<Ingredient> ingredients = Ingredient.getAllIngredientsName();

            ddlNameOfIngredient.Items.Add(new ListItem("All", ""));
            foreach(Ingredient ingredient in ingredients)
            {
                ddlNameOfIngredient.Items.Add(new ListItem(ingredient.name, "idIngredient=" + ingredient.id.ToString()));
            }

            ddl_SelectedIndexChanged(null, null);
        }
    }

    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        String html = "";
        List<Recipe> recipes = new List<Recipe>();

        recipes = Recipe.getRecipesByParamters(ddlSubmittedBy.SelectedValue, ddlNameOfIngredient.SelectedValue, ddlCategory.SelectedValue);

        foreach (Recipe recipe in recipes)
        {
            html += "<a href=ViewRecipe.aspx?idRecipe=" + recipe.id + ">";
            html += "<div class=RecipeListItemContainerSearch>";
            html += "<img class=" + "RecipeListItemImgSearch" + " src=" + recipe.image + ">" + "</img>";
            html += "<div class=" + "RecipeListItemTxtSearch>" + recipe.name.Substring(0, 16) + (recipe.name.Trim().Length > 16 ? "..." : String.Empty) + "</div>";
            html += "</div>\n";
            html += "</a>";
        };

        Literal1.Text = html;
    }
}