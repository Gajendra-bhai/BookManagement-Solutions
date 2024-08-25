<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="BookCategory.aspx.cs" Inherits="BookManagement.BookModule.BookCategory"
    MasterPageFile="~/LayoutTemplate/Layout.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="headcontent">
 <title>Manage Category</title>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="contentpage">
     <div class="row">
     <div class="col-md-6 offset-3 mt-5">
         <asp:HiddenField runat="server" ID="hdbCategoryId"></asp:HiddenField>
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
                         CssClass="btn btn-danger" Width="100%" OnClick="btnClear_Click" />
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
             EmptyDataText="There is not data!"
             DataKeyNames="CategoryId"
             OnRowDeleting="CategoryGrid_RowDeleting"
             OnSelectedIndexChanged="CategoryGrid_SelectedIndexChanged">
             <Columns>
                 <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                 <asp:BoundField HeaderText="Discription" DataField="Discription" />
                 <asp:CommandField HeaderText ="Action" 
                     ShowDeleteButton="true"
                     ButtonType="Button" DeleteText="Remove"
                     ShowSelectButton="true" SelectText="Modify"/>
             </Columns>
         </asp:GridView>
     </div>
 </div>
</asp:Content>
