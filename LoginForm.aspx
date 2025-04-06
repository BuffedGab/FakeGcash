<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginForm.aspx.vb" Inherits="Fake_Gcash.LoginForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            text-align: center;
            padding: 50px;
        }
        .login-container {
            background-color: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.2);
            display: inline-block;
        }
        input[type="text"] {
            width: 200px;
            padding: 10px;
            margin: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        button {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 5px;
            cursor: pointer;
        }
        button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>GCash Login</h2>
            <asp:TextBox ID="txtAccountNumber" runat="server" placeholder="Enter Account Number"></asp:TextBox><br />
            <asp:Button ID="btnLogin" runat="server" Text="Enter" OnClick="btnLogin_Click" />
        </div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    </form>
</body>
</html>
