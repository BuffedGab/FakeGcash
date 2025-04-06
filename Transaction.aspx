<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Transaction.aspx.vb" Inherits="Fake_Gcash.Transaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <style>
        .container {
            max-width: 800px;
            margin: auto;
            background: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .container h2 {
            text-align: center;
            color: #333;
        }
        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }
        .table th, .table td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: center;
        }
        .table th {
            background: #007bff;
            color: white;
        }
        .refresh-btn {
            display: block;
            margin: 10px auto;
            padding: 10px 15px;
            font-size: 16px;
            background: #007bff;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 5px;
        }
        .refresh-btn:hover {
            background: #004bff;
        }
    </style>
 <div class="container">
        <h2>Transaction History</h2>

        <asp:GridView ID="TransactionGrid" runat="server" AutoGenerateColumns="False" CssClass="table" GridLines="Both">
            <Columns>
                <asp:BoundField DataField="TransactionType" HeaderText="Transaction Type" />
                <asp:BoundField DataField="TransferFrom" HeaderText="Transfer From" />
                <asp:BoundField DataField="TransferTo" HeaderText="Transfer To" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="RefreshButton" runat="server" Text="Refresh Transactions" CssClass="refresh-btn" OnClick="RefreshButton_Click" />
    </div>
</asp:Content>

