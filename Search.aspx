<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeBook.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="InputForm">
        <div class="InputControl">
            <asp:Label ID="lblSearch" runat="server" Text="Search" CssClass="LabelInputControl"></asp:Label>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
        </div>
        
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="ButtonControl" OnClick="btnSearch_Click" />
    </div>
    <div>
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="460px">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>       
        </asp:Panel>
    </div>
</asp:Content>

