<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Application</title>
    <style>
        body {
            background-image: url('E:\\Ran_PLc_vb_Programming1\\VB_Projects\\PLC\\Images\\depositphotos_35401749-stock-photo-colour-abstract-background.jpg');
            background-size: cover;
            background-repeat: no-repeat;
            background-attachment: fixed;
        }
        .login-form, .action-buttons {
            text-align: center;
            margin-top: 50px;
        }
        .logout-button {
            position: absolute;
            top: 10px;
            left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Logout button, initially hidden -->
        <div class="logout-button" runat="server" id="logoutDiv" visible="false">
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>

        <!-- Login form -->
        <div class="login-form" runat="server" id="loginDiv">
            <h2>Login</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <p>
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
            </p>
            <p>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </p>
        </div>

        <!-- Action buttons, initially hidden -->
        <div class="action-buttons" runat="server" id="actionButtonsDiv" visible="false">
            <asp:Button ID="btnDataReport" runat="server" Text="Data Report" OnClick="btnDataReport_Click" />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
