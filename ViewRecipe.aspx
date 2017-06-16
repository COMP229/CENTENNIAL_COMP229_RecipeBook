<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeBook.master" AutoEventWireup="true" CodeFile="ViewRecipe.aspx.cs" Inherits="ViewRecipe" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Renato Luiz Carneiro Junior - 300923805 -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ViewRecipeContent">
        <div class="ViewRecipeOverview">
            <div class="ViewRecipeImageContainer">
                <asp:Image ID="imgRecipe" runat="server" CssClass="ViewRecipeImage" />
            </div>
            <div class="ViewRecipeInformation">
                <div class="ViewRecipeDescription">
                    <asp:Panel ID="pnRecipeInformationView" runat="server">
                        <asp:Label ID="lblName" runat="server" CssClass="title" />
                        <br />
                        <center>
                            <telerik:RadRating RenderMode="Lightweight" ID="RadRating1" runat="server" ItemCount="5"
                                Value="3" SelectionMode="Continuous" Precision="Item" Orientation="Horizontal" AutoPostBack="True" OnRate="rating1_onClientRating">
                            </telerik:RadRating>
                        </center>
                        <br />
                        Category:
                        <asp:Label ID="lblCategory" runat="server" /><br />
                        Prepare Time:
                        <asp:Label ID="lblPrepareTime" runat="server" /><br />
                        Number of Servings:
                        <asp:Label ID="lblNumberOfServings" runat="server" /><br />
                        Description:
                        <asp:Label ID="lblDescription" runat="server" /><br /><br />
                        <asp:Button id="btnEditRecipe" runat="server" Text="Edit" OnClick="btnEditRecipe_Click"/>
                        <asp:Button id="btnDeleteRecipe" runat="server" Text="Delete" OnClick="btnDeleteRecipe_Click"/>
                    </asp:Panel>
                    <asp:Panel ID="pnRecipeInformationEdit" runat="server" Visible="false">
                        <div class="InputControl EditMode">
                            <div style="float:left">
                                <asp:Label ID="lblNameEdit" runat="server" Text="Name" CssClass="LabelInputControl EditMode"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name field is empty" ControlToValidate="txtNameEdit" CssClass="Validator" ValidationGroup="EditRecipe">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float:right">
                                <asp:TextBox ID="txtNameEdit" runat="server" CssClass="TextBoxInputControl EditMode"></asp:TextBox>
                            </div>
                        </div>
                        <div class="InputControl EditMode">
                            <div style="float:left">
                                <asp:Label ID="lblCategoryEdit" runat="server" Text="Category" CssClass="LabelInputControl EditMode"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Category field is empty" ControlToValidate="ddlCategoryEdit" CssClass="Validator" ValidationGroup="EditRecipe">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float:right">
                                <asp:DropDownList ID="ddlCategoryEdit" runat="server" CssClass="TextBoxInputControl EditMode"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="InputControl EditMode">
                            <div style="float:left">
                                <asp:Label ID="lblPrepareTimeEdit" runat="server" Text="PrepareTime" CssClass="LabelInputControl EditMode"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Prepare time field is empty" ControlToValidate="txtPrepareTimeEdit" CssClass="Validator" ValidationGroup="EditRecipe">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Prepare time needs to be numeric" ControlToValidate="txtPrepareTimeEdit" ValidationExpression="^[0-9]*$" CssClass="Validator" ValidationGroup="EditRecipe">*</asp:RegularExpressionValidator>
                            </div>
                            <div style="float:right">
                                <asp:TextBox ID="txtPrepareTimeEdit" runat="server" CssClass="TextBoxInputControl EditMode"></asp:TextBox>
                            </div>
                        </div>
                        <div class="InputControl EditMode">
                            <div style="float:left">
                                <asp:Label ID="lblNumberOfServingsEdit" runat="server" Text="Servings" CssClass="LabelInputControl EditMode"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Number of servings field is empty" ControlToValidate="txtNumberOfServingsEdit" CssClass="Validator" ValidationGroup="EditRecipe">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Number of servings needs to be numeric" ControlToValidate="txtNumberOfServingsEdit" ValidationExpression="^[0-9]*$" CssClass="Validator" ValidationGroup="EditRecipe">*</asp:RegularExpressionValidator>
                            </div>
                            <div style="float:right">
                                <asp:TextBox ID="txtNumberOfServingsEdit" runat="server" CssClass="TextBoxInputControl EditMode"></asp:TextBox>
                            </div>
                        </div>
                        <div class="InputControl EditMode">
                            <div style="float:left">
                                <asp:Label ID="lblDescriptionEdit" runat="server" Text="Description" CssClass="LabelInputControl EditMode"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Description field is empty" ControlToValidate="txtDescriptionEdit" CssClass="Validator" ValidationGroup="EditRecipe">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float:right">
                                <asp:TextBox ID="txtDescriptionEdit" runat="server" CssClass="TextBoxInputControl EditMode"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button id="btnSaveEdit" runat="server" Text="Save" OnClick="btnSaveEdit_Click" ValidationGroup="EditRecipe"/>
                        <asp:Button id="btnCancelEdit" runat="server" Text="Cancel" OnClick="btnCancelEdit_Click"/>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="ValidatorSummary" ValidationGroup="EditRecipe" />
                    </asp:Panel>
                </div>
                <!-- Renato Luiz Carneiro Junior - 300923805 -->
                <div class="ViewRecipeSubmittedBy">
                    <asp:Label ID="lblSubmittedBy" runat="server" />
                </div>
            </div>
        </div>
        <div class="ViewRecipeDetails">
            <div class="ViewRecipeIngredients">
                <asp:Panel ID="pnIngredients" runat="server" ScrollBars="Auto" Height="98%" Width="98%">
                    <span class="title">Ingredients</span>
                    <asp:Literal ID="lstIngredients" runat="server" />
                </asp:Panel>
            </div>
            <div class="ViewRecipeDirections">
                <asp:Panel ID="pnDirections" runat="server" ScrollBars="Auto" Height="98%" Width="98%">
                    <span class="title">Directions</span><br />
                    <asp:Label ID="lblDirections" runat="server" Text="Directions" CssClass="DirectionsText" />
                </asp:Panel>
            </div>
        </div>
    </div>
    <!-- Renato Luiz Carneiro Junior - 300923805 -->
</asp:Content>

