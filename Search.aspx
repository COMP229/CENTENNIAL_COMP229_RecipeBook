<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeBook.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Renato Luiz Carneiro Junior - 300923805 -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="InputForm">
        <div class="InputControl">
            <asp:Label ID="lblSubmittedBy" runat="server" Text="Submitted By" CssClass="LabelInputControl"></asp:Label>
            <asp:DropDownList ID="ddlSubmittedBy" runat="server" AutoPostBack="true" CssClass="TextBoxInputControl" OnSelectedIndexChanged="ddl_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="InputControl">
            <asp:Label ID="lblCategory" runat="server" Text="Category" CssClass="LabelInputControl"></asp:Label>
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" CssClass="TextBoxInputControl" OnSelectedIndexChanged="ddl_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <!-- Renato Luiz Carneiro Junior - 300923805 -->

        <div class="InputControl">
            <asp:Label ID="lblNameOfIngredient" runat="server" Text="Ingredients" CssClass="LabelInputControl"></asp:Label>
            <asp:DropDownList ID="ddlNameOfIngredient" runat="server" AutoPostBack="true" CssClass="TextBoxInputControl" OnSelectedIndexChanged="ddl_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <div>
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="520px">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>       
        </asp:Panel>
    </div>
    <!-- Renato Luiz Carneiro Junior - 300923805 -->
</asp:Content>