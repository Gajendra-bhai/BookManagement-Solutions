<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutTemplate/Layout.Master" AutoEventWireup="true" CodeBehind="BulkInsert.aspx.cs" Inherits="BookManagement.BookModule.BulkInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcontent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="contentpage">
     <div class="row">
     <div class="col-md-6 offset-3 mt-5">
         <table class="table">
             <tr>
                 <th>Category Name</th>
                 <td>
                     <asp:TextBox runat="server" ID="txtCategoryName" CssClass="form-control"></asp:TextBox></td>
             </tr>
             <tr>
                 <th>Category Discription</th>
                 <td>
                     <asp:TextBox runat="server"
                         TextMode="MultiLine"
                         Rows="6"
                         Columns="60"
                         ID="txtAreaCategoryDiscription" CssClass="form-control"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>
                     <asp:Button runat="server" ID="btnSave" Text="Save Category"
                         CssClass="btn btn-primary" Width="100%" OnClick="btnSave_Click" />
                 </td>
                 <td>
                     <asp:Button runat="server" ID="btnClear" Text="Reset Form"
                         CssClass="btn btn-danger" Width="100%"  />
                 </td>
             </tr>
         </table>
     </div>
 </div>
 <hr />
 <div class="row">
     <div class="col-md-6 offset-3">
         <asp:GridView runat="server" ID="CategoryGrid" AutoGenerateColumns="false"
             CssClass="table table-hover"
             ShowHeaderWhenEmpty="true"
             EmptyDataText="There is not data!">
             <Columns>
                 <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                 <asp:BoundField HeaderText="Discription" DataField="Discription" />
             </Columns>
         </asp:GridView>
     </div>
 </div>
</asp:Content>
