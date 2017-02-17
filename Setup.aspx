<%@ Page Title="" Language="C#" MasterPageFile="~/RecipeBook.master" AutoEventWireup="true" CodeFile="Setup.aspx.cs" Inherits="Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="InputForm">
        <div class="InputControl">
            <asp:RadioButton ID="rdbLight" runat="server" Text="Light" GroupName="Theme" Checked="true" CssClass="LabelInputControl"/>
        </div>
        <div class="InputControl">
            <asp:RadioButton ID="rdbDark" runat="server" Text="Dark" GroupName="Theme" CssClass="LabelInputControl"/>
        </div>

        <asp:Button ID="btnChange" runat="server" Text="Change" OnClick="btnChange_Click" CssClass="ButtonControl"/>
    </div>
</asp:Content>

