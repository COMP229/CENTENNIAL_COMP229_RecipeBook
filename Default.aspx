<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeBook.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Renato Luiz Carneiro Junior - 300923805 -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="591">
        <label class="title">How to use:</label>

        <p>Use the menu "Recipes" to acess the list of all your recipes.</p>

        <!-- Renato Luiz Carneiro Junior - 300923805 -->

        <p>Acess the menu "Add Recipe" to add a new Recipe, include all the information anc click on the button "Save".</p>

        <p>The menu search is used to find a specific recipe. Select the Search paramters to find your recipe.</p>

        <a href="Setup.aspx">Setup page</a>
    </asp:Panel>
    <!-- Renato Luiz Carneiro Junior - 300923805 -->
</asp:Content>
