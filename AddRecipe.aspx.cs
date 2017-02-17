using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddRecipe : System.Web.UI.Page
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        RecipeRepository recipeRepository = (RecipeRepository)(Application["RecipeRepository"]);
        IngredientList[] ingredientList = new IngredientList[]{IngredientList0, IngredientList1, IngredientList2, IngredientList3, IngredientList4, IngredientList5,
                                                               IngredientList6, IngredientList7, IngredientList8, IngredientList9, IngredientList10, IngredientList11,
                                                                IngredientList12, IngredientList13, IngredientList14};
            
        Recipe recipe = new Recipe();
        List<Ingredient> ingredients = new List<Ingredient>();

        recipe.id = recipeRepository.getRecipes().Count + 1;
        recipe.name = txtName.Text;
        recipe.submittedBy = txtSubmittedby.Text;
        recipe.category = ddlCategory.SelectedValue.ToString();
        //recipe.prepareTime = DateTime.Parse(txtPrepareTime.Text);
        recipe.numberOfServings = int.Parse(txtNumberOfServings.Text);
        recipe.description = txtDescription.Text;
        recipe.image = txtImage.Text;
        recipe.ingredients = ingredients;
        
        foreach (IngredientList ingredientUC in ingredientList)
        {
            TextBox txtNameUC = (TextBox)ingredientUC.FindControl("txtName");
            TextBox txtQuantityUC = (TextBox)ingredientUC.FindControl("txtQuantity");
            DropDownList ddlUnitMeasureUC = (DropDownList)ingredientUC.FindControl("ddlUnitMeasure");

            if (txtNameUC.Text.Trim() != String.Empty)
            {
                Ingredient ingredient = new Ingredient();
                ingredient.id = ingredients.Count() + 1;
                ingredient.name = txtNameUC.Text;
                ingredient.quantity = Double.Parse(txtQuantityUC.Text);
                ingredient.unitMeasure = ddlUnitMeasureUC.SelectedValue;

                ingredients.Add(ingredient);
            }
        }

        recipeRepository.addNewRecipe(recipe);

        Application["RecipeRepository"] = recipeRepository;
        Response.Redirect("Recipes.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Recipes.aspx");
    }
}