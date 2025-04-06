<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Home.aspx.vb" Inherits="Fake_Gcash.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css">
<style>
    .quick-actions {
        display: flex;
        justify-content: center;
        gap: 50px;
        padding: 40px;
        text-align: center;
    }
    .action {
        width: 180px;
        padding: 20px;
        background: #f8f9fa;
        border-radius: 12px;
        box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
        transition: all 0.3s ease;
    }
    .action:hover {
        transform: scale(1.1);
        background: #e9ecef;
    }
    .icon {
        font-size: 36px;
        display: block;
        color: #007bff;
        margin-bottom: 10px;
    }
    .action p {
        margin: 0;
        font-size: 16px;
        font-weight: bold;
        color: #333;
    }
    .action-link {
        text-decoration: none;
        color: inherit;
    }
    .promotions {
        text-align: center;
        margin-top: 20px;
        font-size: 18px;
        font-weight: bold;
        color: #007bff;
        padding: 10px;
    }
    .promo-image {
        width: 1700px;
        height: 400px;
        display: block;
        margin: 0 auto 10px;
        border-radius: 10px;
    }
</style>

<div class="quick-actions">
    <div class="action">
        <a href="BankTransfer.aspx" class="action-link">
            <i class="fas fa-university icon"></i>
            <p>Bank Transfer</p>
        </a>
    </div>
    <div class="action">
        <a href="Transaction.aspx" class="action-link">
            <i class="fas fa-list-alt icon"></i>
            <p>Transaction History</p>
        </a>
    </div>
</div>

 <div class="promotions">
        <span class="promo-banner">🌟 Special Promo! Invest now and earn more! 🌟</span>
        <img src="promo-image.jpg" alt="Promotion" class="promo-image">
    </div>
</asp:Content>
