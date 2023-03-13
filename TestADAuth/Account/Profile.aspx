<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TestADAuth.Account.Profile" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="UTF-8" />
    <title>Profile Page</title>
    <style>
        .logo{
            margin:0 auto !important;
            text-align: center;
        }
        /* Profile Container */
        .profile-container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f7f7f7;
            border: 1px solid #ddd;
            box-shadow: 0px 0px 5px #ddd;
            border-radius: 5px;
        }

        /* Profile Picture */
        .profile-picture {
            width: 150px;
            height: 150px;
            margin-bottom: 20px;
            overflow: hidden;
            border-radius: 50%;
        }

            .profile-picture img {
                width: 100%;
                height: 100%;
                object-fit: cover;
            }

        /* Form Fields */
        label {
            display: block;
            margin-bottom: 10px;
            font-weight: bold;
        }

        input[type="text"], input[type="email"], select, textarea {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border-radius: 5px;
            border: 1px solid #ddd;
            box-sizing: border-box;
        }

        input[type="submit"] {
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">

        <div class="logo">
            <asp:Image  runat="server" ImageUrl="https://uploads-ssl.webflow.com/5ff406c4e45fe6675ccc0ec4/625e7b7532d684e751be6fa8_Logo_Quadra_Small_200x52.png"/>
        </div>
        <div style="text-align: center; margin-bottom: 2%">
            <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Sign out"
                LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" />
        </div>
        <div class="profile-container">
        <%--    <div class="profile-picture">
                <asp:Image ID="imgProfile" runat="server" AlternateText="Profile Picture Loading...." />
            </div>--%>


            <label for="email">Email:</label>

            <asp:TextBox ID="tbEmail" Enabled="false" runat="server"></asp:TextBox>

            <label for="name">FullName:</label>
            <asp:TextBox ID="tbfullName" Enabled="false" runat="server"></asp:TextBox>

            <label for="name">FirstName:</label>
            <asp:TextBox ID="tbfirstName" Enabled="false" runat="server"></asp:TextBox>

            <%--<input type="submit" value="Save" />--%>
        </div>
    </form>
</body>
</html>
