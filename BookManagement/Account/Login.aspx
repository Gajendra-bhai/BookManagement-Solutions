<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutTemplate/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookManagement.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentpage" runat="server">
    <div class="row">
        <div class="col-md-6 offset-3 mt-5">
            <asp:HiddenField runat="server" ID="hdbCategoryId"></asp:HiddenField>
            <table class="table">
                <tr>
                    <th>UserId</th>
                    <td>
                        <asp:TextBox runat="server" ID="txtUserId" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <th>Password</th>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control"></asp:TextBox></td>

                </tr>
                <tr>
                    <th>Remember me</th>
                    <td>
                        <asp:CheckBox runat="server" ID="chkRemberme" CssClass=""></asp:CheckBox></td>

                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="btnLogin" Text="Login"
                            CssClass="btn btn-primary" Width="100%" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
