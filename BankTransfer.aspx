<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="BankTransfer.aspx.vb" Inherits="Fake_Gcash.BankTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <style>
        .transfer-form {
            padding: 50px;
            background-color: #f8f9fa;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            max-width: 500px;
            margin: 30px auto;
        }
        .transfer-form h2 {
            text-align: center;
            margin-bottom: 20px;
            color: #007bff;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .form-group label {
            font-weight: bold;
            color: #333;
        }
        .form-control {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            border-radius: 6px;
            border: 1px solid #ccc;
        }
        .btn-primary {
            width: 100%;
            padding: 12px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 6px;
            font-size: 16px;
            cursor: pointer;
        }
        .btn-primary:hover {
            background-color: #0056b3;
        }
    </style>
    <div class="transfer-form">
        <h2>Bank Transfer</h2>
        <div class="form-group">
              <label for="accountNumber">Account Number:</label>
              <asp:TextBox ID="txtaccountNumber" CssClass="form-control" placeholder="Enter Account Number" runat="server" TextMode="Number" />
          </div>
          <div class="form-group">
              <label for="amount">Amount:</label>
              <asp:TextBox ID="txtamount" CssClass="form-control" placeholder="Enter Amount" runat="server" TextMode="Number" />
          </div>
          <div class="form-group">
              <label for="transactionType">Transaction Type:</label>
              <asp:DropDownList ID="ddltransactionType" CssClass="form-control" runat="server">
                  <asp:ListItem Value="Deposit">Deposit</asp:ListItem>
                  <asp:ListItem Value="Withdraw">Withdraw</asp:ListItem> 
              </asp:DropDownList>
          </div>
          <div class="form-group">
              <label for="transactionDate">Date:</label>
              <input type="text" id="transactionDate" class="form-control" value="<%= DateTime.Now.ToString("yyyy-MM-dd") %>" readonly="true" />
          </div>
          <asp:Button ID="sendButton" CssClass="btn btn-primary" runat="server" Text="Send" OnClick="SendButton_Click" />
  </div>
    </div>
</asp:Content>