<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeBook.master" AutoEventWireup="true" CodeFile="AddRecipe.aspx.cs" Inherits="AddRecipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Renato Luiz Carneiro Junior - 300923805 -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="AddRecipeForm">
        <div class="AddRecipeDetails">
            <div class="AddRecipeContent FloatLeft">
                <div id="divAddNewRecipe" runat="server" class="AddRecipeInformation">
                    <asp:Label ID="lblRecipe" runat="server" Text="Recipe:" CssClass="title"></asp:Label><br />
                    <div class="InputControl">
                        <div style="float: left">
                            <asp:Label ID="lblName" runat="server" Text="Name" CssClass="LabelInputControl"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name of the recipe is empty" ControlToValidate="txtName" CssClass="Validator" ValidationGroup="AddRecipe">*</asp:RequiredFieldValidator>
                        </div>
                        <div style="float: right">
                            <asp:TextBox ID="txtName" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
                        </div>
                    </div>
                    <div class="InputControl">
                        <div style="float: left">
                            <asp:Label ID="lblSubmittedBy" runat="server" Text="Submitted by" CssClass="LabelInputControl"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Submitted by field is empty" ControlToValidate="txtSubmittedby" CssClass="Validator" ValidationGroup="AddRecipe">*</asp:RequiredFieldValidator>
                        </div>
                        <div style="float: right">
                            <asp:TextBox ID="txtSubmittedby" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
                        </div>
                    </div>
                    <div class="InputControl">
                        <div style="float: left">
                            <asp:Label ID="lblCategory" runat="server" Text="Category " CssClass="LabelInputControl"></asp:Label>&nbsp;
                        </div>
                        <div style="float: right">
                            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" CssClass="TextBoxInputControl" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" />
                        </div>
                    </div>
                    <div class="InputControl">
                        <div style="float: left">
                            <asp:Label ID="lblPrepareTime" runat="server" Text="Prepare time" CssClass="LabelInputControl"></asp:Label>&nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Prepare time needs to be numeric" ControlToValidate="txtPrepareTime" ValidationExpression="^[0-9]*$" CssClass="Validator" ValidationGroup="AddRecipe">*</asp:RegularExpressionValidator>
                        </div>
                        <div style="float: right">
                            <asp:TextBox ID="txtPrepareTime" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
                        </div>

                    </div>

                    <!-- Renato Luiz Carneiro Junior - 300923805 -->

                    <div class="InputControl">
                        <div style="float: left">
                            <asp:Label ID="lblNumberOfServings" runat="server" Text="Servings" CssClass="LabelInputControl"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Number of servings needs to be numeric" ControlToValidate="txtNumberOfServings" ValidationExpression="^[0-9]*$" CssClass="Validator" ValidationGroup="AddRecipe">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Number of servings is empty" ControlToValidate="txtNumberOfServings" CssClass="Validator" ValidationGroup="AddRecipe">*</asp:RequiredFieldValidator>
                        </div>
                        <div style="float: right">
                            <asp:TextBox ID="txtNumberOfServings" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
                        </div>
                    </div>
                    <div class="InputControl">
                        <div style="float: left">
                            <asp:Label ID="lblImage" runat="server" Text="URL Image " CssClass="LabelInputControl"></asp:Label>&nbsp;
                        </div>
                        <div style="float: right">
                            <asp:TextBox ID="txtImage" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
                        </div>
                    </div>
                    <div class="InputControl">
                        <div style="float: left">
                            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="LabelInputControl"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Description field is empty" ControlToValidate="txtDescription" CssClass="Validator" ValidationGroup="AddRecipe">*</asp:RequiredFieldValidator>
                        </div>
                        <div style="float: right">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="TextBoxInputControl" TextMode="MultiLine" Width="295px" Height="50px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="InputControl">
                        <div style="float: left">
                            <asp:Label ID="lblDirections" runat="server" Text="Directions" CssClass="LabelInputControl"></asp:Label>&nbsp;
                        </div>
                        <div style="float: right">
                            <asp:TextBox ID="txtDirections" runat="server" CssClass="TextBoxInputControl" TextMode="MultiLine" Width="295px" Height="50px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div runat="server" id="divNewCategory" class="AddCategory">
                    <div>
                        <asp:Label ID="lblNewCategory" runat="server" Text="Category name" CssClass="LabelInputControl"></asp:Label>
                        <asp:TextBox ID="txtNewCategory" runat="server"></asp:TextBox>
                        <asp:Button ID="btnNewCategory" runat="server" Text="Add New Category" OnClick="btnNewCategory_Click" />
                    </div>
                </div>
            </div>
            <div class="AddRecipeContent FloatRight">
                <div>
                    <asp:Label ID="lblIngredients" runat="server" Text="Ingredients:" CssClass="title"></asp:Label>
                    <div class="InputControl" style="width: 100%">
                        <div class="InputControl">
                            <div style="float: left">
                                <asp:Label ID="Label1" runat="server" Text="Name" CssClass="LabelInputControl"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Name of ingredient field is empty" ControlToValidate="ddlIngredient" CssClass="Validator" ValidationGroup="AddIngredient">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float: right">
                                <asp:DropDownList ID="ddlIngredient" runat="server" CssClass="TextBoxInputControl"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="InputControl">
                            <div style="float: left">
                                <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="LabelInputControl"></asp:Label>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Quantity needs to be numeric" ControlToValidate="txtQuantity" ValidationExpression="^[0-9]*$" CssClass="Validator" ValidationGroup="AddIngredient">*</asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Quantity field is empty" ControlToValidate="txtQuantity" CssClass="Validator" ValidationGroup="AddIngredient">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float: right">
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
                            </div>
                        </div>

                        <div class="InputControl">
                            <div style="float: left">
                                <asp:Label ID="lblUnitMeasure" runat="server" Text="Unit Measure" CssClass="LabelInputControl"></asp:Label>&nbsp;
                            </div>
                            <div style="float: right">
                                <asp:DropDownList ID="ddlUnitMeasure" runat="server" CssClass="TextBoxInputControl" />
                            </div>
                        </div>

                        <br />

                        <asp:Button ID="btnAddIngredient" runat="server" Text="Add Ingredient" OnClick="btnAddIngredient_Click" CssClass="ButtonControl" ValidationGroup="AddIngredient" />

                        <br />

                        <asp:Panel ID="pnIngredients" runat="server" ScrollBars="Auto" Width="98%" Height="220px">
                            <%-- <asp:Literal ID="lstIngredients" runat="server" />--%>
                            <asp:GridView ID="GridView1" CssClass="IngredientsGrid" runat="server" AutoGenerateEditButton="True" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AutoGenerateDeleteButton="true" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" AutoGenerateColumns="False">
                                <Columns>

                                    <asp:TemplateField HeaderText="name">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlIngredientsGrid" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="idIngredient" SelectedValue='<%# Bind("id") %>'></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RecipeBook %>" SelectCommand="SELECT * FROM [Ingredient]"></asp:SqlDataSource>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlIngredientsGrid" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="idIngredient" SelectedValue='<%# Bind("id") %>' Enabled="false"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RecipeBook %>" SelectCommand="SELECT * FROM [Ingredient]"></asp:SqlDataSource>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtQuantityGrid" runat="server" Text='<%# Bind("quantity") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantityGrid" runat="server" Text='<%# Bind("quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="unitMeasure">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlUnitMeasureGrid" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="idUnitMeasure" SelectedValue='<%# Bind("unitMeasure") %>'></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RecipeBook %>" SelectCommand="SELECT * FROM [UnitMeasure]"></asp:SqlDataSource>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlUnitMeasureGrid" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="idUnitMeasure" SelectedValue='<%# Bind("unitMeasure") %>' Enabled="false"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RecipeBook %>" SelectCommand="SELECT * FROM [UnitMeasure]"></asp:SqlDataSource>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
        <div class="AddRecipeComponents">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="ButtonControl" CausesValidation="False" />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="ButtonControl" ValidationGroup="AddRecipe" />

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="ValidatorSummary" ValidationGroup="AddRecipe" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="ValidatorSummary" ValidationGroup="AddIngredient" />
        </div>
    </div>
    <!-- Renato Luiz Carneiro Junior - 300923805 -->
</asp:Content>
