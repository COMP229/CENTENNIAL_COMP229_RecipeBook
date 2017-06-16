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
        if (!IsPostBack)
        {
            HttpContext.Current.Session["ListOfIngredients"] = new List<Ingredient>();

            List<Category> categories = Category.getCategories();

            foreach (Category category in categories)
            {
                ddlCategory.Items.Add(new ListItem(category.name, category.id.ToString()));
            }
            ddlCategory.Items.Add(new ListItem("Other", (-1).ToString()));

            List<UnitMeasure> unitMeasures = UnitMeasure.getUnitMeasures();
            foreach (UnitMeasure unitMeasure in unitMeasures)
            {
                ddlUnitMeasure.Items.Add(new ListItem(unitMeasure.name, unitMeasure.id.ToString()));
            }

            List<Ingredient> ingredients = Ingredient.getAllIngredientsName();
            ddlIngredient.Items.Add(new ListItem(String.Empty, String.Empty));
            foreach (Ingredient ingredient in ingredients)
            {
                ddlIngredient.Items.Add(new ListItem(ingredient.name, ingredient.id.ToString()));
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Recipe recipe = new Recipe();
            List<Ingredient> ingredients = (List<Ingredient>)HttpContext.Current.Session["ListOfIngredients"];
            int prepareTime = 0;

            recipe.name = txtName.Text;
            recipe.submittedBy = txtSubmittedby.Text;
            recipe.category = int.Parse(ddlCategory.SelectedValue);
            int.TryParse(txtPrepareTime.Text, out prepareTime);
            recipe.prepareTime = prepareTime;
            recipe.numberOfServings = int.Parse(txtNumberOfServings.Text);
            recipe.description = txtDescription.Text;
            recipe.directions = txtDirections.Text;
            recipe.image = txtImage.Text;

            recipe.ingredients = ingredients;
            recipe.insertRecipe();

            Response.Redirect("Recipes.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Recipes.aspx");
    }

    protected void btnAddIngredient_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            List<Ingredient> ingredients = (List<Ingredient>)HttpContext.Current.Session["ListOfIngredients"];
            bool alreadyIncluded = false;

            foreach (Ingredient ingredient in ingredients)
            {
                if (ingredient.id == int.Parse(ddlIngredient.SelectedItem.Value))
                {
                    alreadyIncluded = true;
                }
            }

            if (!alreadyIncluded)
            {
                Ingredient newIngredient = new Ingredient();

                newIngredient.id = int.Parse(ddlIngredient.SelectedItem.Value);
                newIngredient.name = ddlIngredient.SelectedItem.Text;
                newIngredient.quantity = int.Parse(txtQuantity.Text);
                newIngredient.unitMeasure = int.Parse(ddlUnitMeasure.SelectedItem.Value);

                ingredients.Add(newIngredient);

                HttpContext.Current.Session["ListOfIngredients"] = ingredients;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingredient already included')", true);
            }

            //lstIngredients.Text = "";
            //int count = 0;
            //foreach (Ingredient ingredient in ingredients)
            //{
            //    count++;
            //    UnitMeasure unitMeasure = new UnitMeasure();
            //    unitMeasure.id = ingredient.unitMeasure;
            //    unitMeasure.getUnitMeasure();

            //    lstIngredients.Text += "<div class=" + "IngredientListItem" + ">";
            //    lstIngredients.Text += "<div class=" + "" + ">";
            //    lstIngredients.Text += "<span>- ";
            //    lstIngredients.Text += ingredient.quantity + " ";
            //    lstIngredients.Text += unitMeasure.name + " ";
            //    lstIngredients.Text += ingredient.name;
            //    lstIngredients.Text += "</span>";
            //    lstIngredients.Text += "</div>";
            //    lstIngredients.Text += "</div>";
            //}

            GridView1.DataSource = (List<Ingredient>)HttpContext.Current.Session["ListOfIngredients"];
            GridView1.DataBind();
        }
    }

    protected void btnNewCategory_Click(object sender, EventArgs e)
    {
        if (txtNewCategory.Text.Trim() != "")
        {
            Category newCategory = new Category();
            newCategory.name = txtNewCategory.Text;

            newCategory.insertCategory();

            List<Category> categories = Category.getCategories();

            ddlCategory.Items.Clear();
            foreach (Category category in categories)
            {
                ddlCategory.Items.Add(new ListItem(category.name, category.id.ToString()));
            }
            ddlCategory.Items.Add(new ListItem("Other", (-1).ToString()));

            divNewCategory.Attributes["class"] = "AddCategory";
            ddlCategory.SelectedValue = newCategory.id.ToString();
        }else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid values, please try again!')", true);
        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.DataSource = (List<Ingredient>)HttpContext.Current.Session["ListOfIngredients"];
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.DataBind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            DropDownList ddlIngredientsGrid = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlIngredientsGrid");
            DropDownList ddlUnitMeasureGrid = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlUnitMeasureGrid");
            TextBox txtQuantityGrid = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtQuantityGrid");

            List<Ingredient> ingredients = (List<Ingredient>)HttpContext.Current.Session["ListOfIngredients"];

            Ingredient ingredient = ingredients.ElementAt(e.RowIndex);
            ingredients.Where(w => w.id == ingredient.id).ToList().ForEach(s => s.quantity = int.Parse(txtQuantityGrid.Text));
            ingredients.Where(w => w.id == ingredient.id).ToList().ForEach(s => s.unitMeasure = int.Parse(ddlUnitMeasure.SelectedItem.Value));
            ingredients.Where(w => w.id == ingredient.id).ToList().ForEach(s => s.id = int.Parse(ddlIngredientsGrid.SelectedItem.Value));

            GridView1.EditIndex = -1;
            GridView1.DataSource = (List<Ingredient>)HttpContext.Current.Session["ListOfIngredients"];
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid values, please try again!')", true);
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DropDownList ddlIngredientsGrid = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlIngredientsGrid");
        List<Ingredient> ingredients = (List<Ingredient>)HttpContext.Current.Session["ListOfIngredients"];

        ingredients.RemoveAt(e.RowIndex);

        HttpContext.Current.Session["ListOfIngredients"] = ingredients;
        GridView1.DataSource = ingredients;
        GridView1.DataBind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.DataSource = (List<Ingredient>)HttpContext.Current.Session["ListOfIngredients"];
        GridView1.DataBind();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue == (-1).ToString())
        {
            divNewCategory.Attributes["class"] = "AddCategory Show";
            divAddNewRecipe.Attributes["class"] = "AddRecipeInformation Show";
        }
        else
        {
            if (divNewCategory.Attributes["class"] == "AddCategory Show")
            {
                divNewCategory.Attributes["class"] = "AddCategory Hide";
            }
            else
            {
                divNewCategory.Attributes["class"] = "AddCategory";
            }

            if (divAddNewRecipe.Attributes["class"] == "AddRecipeInformation Show")
            {
                divAddNewRecipe.Attributes["class"] = "AddRecipeInformation Hide";
            }
            else
            {
                divAddNewRecipe.Attributes["class"] = "AddRecipeInformation";
            }
        }
    }
}