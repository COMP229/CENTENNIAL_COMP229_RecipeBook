<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeBook.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="591">
        <label class="title">How to use:</label>

        <p>Use the menu "Recipes" to acess the list of all your recipes.</p>

        <p>Acess the menu "Add Recipe" to add a new Recipe, include all the information anc click on the button "Save".</p>

        <p>The menu search is used to find a specific recipe. Include the name or a part of it and click on the button "Search" to find your recipe.</p>

        <a href="Setup.aspx">Setup page</a>
    </asp:Panel>
</asp:Content>

