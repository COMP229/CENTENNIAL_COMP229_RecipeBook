using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewRecipe : System.Web.UI.Page
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
            Recipe recipe = new Recipe();

            recipe.id = int.Parse(Request.QueryString["idRecipe"]);
            recipe.getRecipe();

            Category category = new Category();
            category.id = recipe.category;
            category.getCategory();

            lblName.Text = recipe.name;
            lblCategory.Text = category.name;
            lblPrepareTime.Text = recipe.prepareTime.ToString();
            lblNumberOfServings.Text = recipe.numberOfServings.ToString();
            lblDescription.Text = recipe.description;
            lblDirections.Text = recipe.directions;
            lblSubmittedBy.Text = "Submitted By: " + recipe.submittedBy;

            List<Category> categories = Category.getCategories();

            foreach (Category categoryOption in categories)
            {
                ddlCategoryEdit.Items.Add(new ListItem(categoryOption.name, categoryOption.id.ToString()));

                if (recipe.category == categoryOption.id)
                {
                    ddlCategoryEdit.SelectedIndex = ddlCategoryEdit.Items.Count - 1;
                }
            }

            txtNameEdit.Text = recipe.name;
            txtPrepareTimeEdit.Text = recipe.prepareTime.ToString();
            txtNumberOfServingsEdit.Text = recipe.numberOfServings.ToString();
            txtDescriptionEdit.Text = recipe.description;

            imgRecipe.ImageUrl = recipe.image;

            foreach (Ingredient ingredient in recipe.ingredients)
            {
                UnitMeasure unitMeasure = new UnitMeasure();
                unitMeasure.id = ingredient.unitMeasure;
                unitMeasure.getUnitMeasure();

                lstIngredients.Text += "<div class=" + "IngredientListItem" + ">";
                lstIngredients.Text += "<div class=" + "IngredientListText" + ">";
                lstIngredients.Text += "<span>- ";
                lstIngredients.Text += ingredient.quantity + " ";
                lstIngredients.Text += unitMeasure.name + " ";
                lstIngredients.Text += ingredient.name;
                lstIngredients.Text += "</span>";
                lstIngredients.Text += "</div>";
                lstIngredients.Text += "</div>";
            }

            RadRating1.Value = recipe.getRating();
            //RadRating1.ReadOnly = recipe.isRated();

            HttpContext.Current.Session["Recipe"] = recipe;
        }
    }

    protected void btnDeleteRecipe_Click(object sender, EventArgs e)
    {
        Recipe recipe = new Recipe();

        recipe.id = int.Parse(Request.QueryString["idRecipe"]);
        recipe.deleteRecipe();

        Response.Redirect("Recipes.aspx");
    }

    protected void btnEditRecipe_Click(object sender, EventArgs e)
    {
        pnRecipeInformationView.Visible = false;
        pnRecipeInformationEdit.Visible = true;
    }

    protected void btnSaveEdit_Click(object sender, EventArgs e)
    {
        Recipe recipe = (Recipe)HttpContext.Current.Session["Recipe"];

        recipe.name = txtNameEdit.Text;
        recipe.category = int.Parse(ddlCategoryEdit.SelectedItem.Value);
        recipe.prepareTime = int.Parse(txtPrepareTimeEdit.Text);
        recipe.numberOfServings = int.Parse(txtNumberOfServingsEdit.Text);
        recipe.description = txtDescriptionEdit.Text;

        recipe.updateRecipe();
        Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
    }

    protected void btnCancelEdit_Click(object sender, EventArgs e)
    {
        pnRecipeInformationView.Visible = true;
        pnRecipeInformationEdit.Visible = false;
    }

    protected void rating1_onClientRating(object sender, EventArgs e)
    {
        Recipe recipe = (Recipe)HttpContext.Current.Session["Recipe"];
        recipe.rateRecipe(RadRating1.Value);
        RadRating1.Value = recipe.getRating();
        //RadRating1.ReadOnly = true;
    }
}