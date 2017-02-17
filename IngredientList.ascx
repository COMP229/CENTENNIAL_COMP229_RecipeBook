<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IngredientList.ascx.cs" Inherits="IngredientList" %>
<div class="InputControl" style="width:100%">
    <div class="InputControl">
        <asp:Label ID="lblName" runat="server" Text="Name" CssClass="LabelInputControl"></asp:Label>&nbsp;
        <asp:TextBox ID="txtName" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
    </div>

    <div class="InputControl">
        <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="LabelInputControl"></asp:Label>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtQuantity" ValidationExpression="^[0-9]*$" CssClass="Validator"></asp:RegularExpressionValidator>
        <asp:TextBox ID="txtQuantity" runat="server" CssClass="TextBoxInputControl"></asp:TextBox>
    </div>

    <div class="InputControl">
        <asp:Label ID="lblUnitMeasure" runat="server" Text="Unit Measure" CssClass="LabelInputControl"></asp:Label>&nbsp;
        <asp:DropDownList ID="ddlUnitMeasure" runat="server" CssClass="TextBoxInputControl">
            <asp:ListItem>Kg</asp:ListItem>
            <asp:ListItem>g</asp:ListItem>
            <asp:ListItem>l</asp:ListItem>
            <asp:ListItem>cups</asp:ListItem>
            <asp:ListItem>pieces</asp:ListItem>
            <asp:ListItem>spoons</asp:ListItem>
        </asp:DropDownList>
    </div>
</div>