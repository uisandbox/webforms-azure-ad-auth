<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestADAuth.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <style>
        .logo{
            margin:0 auto !important;
            text-align: center;
        }
        .login-box {
            width: 350px;
            margin: 0 auto;
            background-color: #f2f2f2;
            padding: 20px;
            border: 1px solid #ccc;
            margin-top: 10%;
        }

            .login-box h2 {
                text-align: center;
                margin-bottom: 20px;
            }

        .textbox {
            margin-bottom: 10px;
        }

            .textbox label {
                display: block;
                margin-bottom: 5px;
            }

            .textbox input[type="text"],
            .textbox input[type="password"] {
                width: 100%;
                padding: 10px;
                border: 1px solid #ccc;
                border-radius: 4px;
                box-sizing: border-box;
            }

        button[type="submit"],
        input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="logo">
            <asp:Image  runat="server" ImageUrl="https://uploads-ssl.webflow.com/5ff406c4e45fe6675ccc0ec4/625e7b7532d684e751be6fa8_Logo_Quadra_Small_200x52.png"/>
        </div>
        <div class="login-box">
            <h2>Login</h2>
            <div class="textbox">
                <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div class="textbox">
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Enabled="false"></asp:TextBox>
            </div>
            <asp:LinkButton runat="server" OnClick="Unnamed_Click">
                <asp:Image runat="server" ImageUrl="/Images/ms-sign.svg" />
            </asp:LinkButton>
        </div>
    </form>
</body>
</html>
