<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        #login {
            background-color: #FF6813;
        }

        #loginContainer {
            width: 270px;
            margin: 0 auto;
        }

        #login1 {
            margin: 0 auto;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
        <div id="Banner">
            <div style="width:600px; margin: 0 auto;">
                <img id="logo" src="Cook-Book-icon.png" width="100" style="margin-right:8px"/>
                <div>Recipe Book</div>
            </div>
        </div>
        <div id="loginContainer">
            <asp:Login ID="Login1" runat="server"></asp:Login>
        </div>
    </div>
    </form>
</body>
</html>
