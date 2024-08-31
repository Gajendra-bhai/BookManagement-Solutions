<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutTemplate/Layout.Master" 
    AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" 
    Inherits="BookManagement.Customer.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentpage" runat="server">
    <h3>User want to see the details of book whose id is 
        <asp:Label runat="server" ID="lblBookId"></asp:Label>
    </h3>
</asp:Content>
