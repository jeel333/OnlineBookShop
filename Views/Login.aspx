<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineBookShop.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - BookShop Management</title>
    <link rel="stylesheet" href="../Assets/Lib/css/bootstrap.min.css" />
    <style>
        body {
            background: linear-gradient(135deg, #009688, #4caf50);
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            font-family: 'Segoe UI', sans-serif;
            margin: 0;
        }

        .login-container {
            background-color: #ffffff;
            border-radius: 15px;
            padding: 40px 30px;
            box-shadow: 0px 10px 30px rgba(0, 0, 0, 0.2);
            width: 100%;
            max-width: 400px;
            text-align: center;
            animation: fadeIn 1s ease;
        }

        @keyframes fadeIn {
            from { opacity: 0; transform: scale(0.95); }
            to { opacity: 1; transform: scale(1); }
        }

        .login-container h2 {
            color: #00796b;
            font-weight: 600;
            margin-bottom: 15px;
        }

        .login-container img {
            width: 100px; /* increased from 70px */
            margin-bottom: 20px;
        }

        .form-control {
            border-radius: 10px;
            height: 45px;
        }

        .btn-success {
            border-radius: 10px;
            height: 45px;
            font-weight: 600;
        }

        .btn-success:hover {
            background-color: #00695c;
        }

        #ErrMsg {
            font-weight: 500;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>BookShop Management</h2>
            <img src="../Assets/Images/—Pngtree—education logo with shape of_6958784.png" alt="BookShop" />

            <div class="text-start mt-3">
                <label class="form-label">User Name</label>
                <input type="email" placeholder="Enter your Email..." autocomplete="off" runat="server" id="UnameTb" class="form-control" />
            </div>

            <div class="text-start mt-3">
                <label class="form-label">Password</label>
                <input type="password" placeholder="Password" autocomplete="off" runat="server" id="PasswordTb" class="form-control" />
            </div>

            <div class="mt-4 d-grid">
                <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger text-center"></asp:Label>
                <asp:Button Text="Login" runat="server" class="btn btn-success mt-2" ID="LoginBtn" OnClick="LoginBtn_Click" />
            </div>
        </div>
    </form>
</body>
</html>
