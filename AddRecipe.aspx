<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeBook.master" AutoEventWireup="true" CodeFile="AddRecipe.aspx.cs" Inherits="AddRecipe" %>

<%@ Register Src="~/IngredientList.ascx" TagPrefix="uc1" TagName="IngredientList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="591px" Width="100%">
        <div class="InputForm">
            <hr />
            <asp:Label ID="lblRecipe" runat="server" Text="Recipe:" CssClass="LabelInputControl"></asp:Label><br />
            <div class="InputControl">
                <asp:Label ID="lblName" runat="server" Text="Name" CssClass="LabelInputControl"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtName" CssClass="Validator"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtName" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
            </div>
            <div class="InputControl">
                <asp:Label ID="lblSubmittedBy" runat="server" Text="Submitted by" CssClass="LabelInputControl"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtSubmittedby" CssClass="Validator"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtSubmittedby" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
            </div>
            <div class="InputControl">
                <asp:Label ID="lblCategory" runat="server" Text="Category " CssClass="LabelInputControl"></asp:Label>&nbsp;
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="TextBoxInputControl">
                    <asp:ListItem>Dessert</asp:ListItem>
                    <asp:ListItem>Meat</asp:ListItem>
                    <asp:ListItem>Snacks</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="InputControl">
                <asp:Label ID="lblPrepareTime" runat="server" Text="Prepare time" CssClass="LabelInputControl"></asp:Label>&nbsp;
                <asp:TextBox ID="txtPrepareTime" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
            </div>
            <div class="InputControl">
                <asp:Label ID="lblNumberOfServings" runat="server" Text="Servings" CssClass="LabelInputControl"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtNumberOfServings" CssClass="Validator"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtNumberOfServings" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
            </div>
            <div class="InputControl">
                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="LabelInputControl"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtDescription" CssClass="Validator"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
            </div>
            <div class="InputControl">
                <asp:Label ID="lblImage" runat="server" Text="URL Image " CssClass="LabelInputControl"></asp:Label>&nbsp;
                <asp:TextBox ID="txtImage" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
            </div>
            <hr />
            <div>
                <asp:Label ID="lblIngredients" runat="server" Text="Ingredients:" CssClass="LabelInputControl"></asp:Label>
                <uc1:IngredientList runat="server" ID="IngredientList0"/>
                <uc1:IngredientList runat="server" ID="IngredientList1" />
                <uc1:IngredientList runat="server" ID="IngredientList2" />
                <uc1:IngredientList runat="server" ID="IngredientList3" />
                <uc1:IngredientList runat="server" ID="IngredientList4" />
                <uc1:IngredientList runat="server" ID="IngredientList5" />
                <uc1:IngredientList runat="server" ID="IngredientList6" />
                <uc1:IngredientList runat="server" ID="IngredientList7" />
                <uc1:IngredientList runat="server" ID="IngredientList8" />
                <uc1:IngredientList runat="server" ID="IngredientList9" />
                <uc1:IngredientList runat="server" ID="IngredientList10" />
                <uc1:IngredientList runat="server" ID="IngredientList11" />
                <uc1:IngredientList runat="server" ID="IngredientList12" />
                <uc1:IngredientList runat="server" ID="IngredientList13" />
                <uc1:IngredientList runat="server" ID="IngredientList14" />
            </div>

            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="ButtonControl" CausesValidation="False"/>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="ButtonControl" />
        </div>
    </asp:Panel>
</asp:Content>

