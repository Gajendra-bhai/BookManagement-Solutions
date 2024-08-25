<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book.aspx.cs"
    Inherits="BookManagement.BookModule.Book"
    MasterPageFile="~/LayoutTemplate/Layout.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="headcontent">
    <title>Manage Books</title>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="contentpage">
     <div class="container-fluid">
     <div class="row">
         <div class="col-md-6 offset-3 mt-5">
             <table class="table">
                 <tr>
                     <th>Book Category</th>
                     <td>
                         <asp:DropDownList runat="server" ID="DdlCategory" CssClass="form-control"
                             DataValueField="CategoryId" DataTextField="CategoryName">
                         </asp:DropDownList></td>
                 </tr>
                 <tr>
                     <th>Book Author</th>
                     <td>
                         <asp:DropDownList runat="server" ID="DdlAuthors" CssClass="form-control">
                             <asp:ListItem Value="-1">Select Author</asp:ListItem>
                             <asp:ListItem Value="Bal Guru Swami">Bal Guru Swami</asp:ListItem>
                             <asp:ListItem Value="John Smith">John Smith</asp:ListItem>
                         </asp:DropDownList></td>
                 </tr>
                 <tr>
                     <th>Book Title</th>
                     <td>
                         <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <th>SBIN</th>
                     <td>
                         <asp:TextBox runat="server" ID="txtSBIN" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <th>Price</th>
                     <td>
                         <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <th>Discription</th>
                     <td>
                         <asp:TextBox runat="server"
                             TextMode="MultiLine"
                             Rows="6"
                             Columns="60"
                             ID="txtAreabookDiscription" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <th>Book Cover Photo</th>
                     <td>
                         <asp:FileUpload runat="server" ID="fileCoverPhoto" CssClass="form-control"></asp:FileUpload>

                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Button runat="server" ID="btnSave" Text="Save Book"
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
             <asp:GridView runat="server" ID="BookGrid" AutoGenerateColumns="false"
                 CssClass="table table-hover"
                 ShowHeaderWhenEmpty="true"
                 EmptyDataText="There is not data!">
                 <Columns>
                     <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                     <asp:BoundField HeaderText="Discription" DataField="Discription" />
                     <asp:CommandField HeaderText="Action"
                         ShowDeleteButton="true"
                         ButtonType="Button" DeleteText="Remove"
                         ShowSelectButton="true" SelectText="Modify" />
                 </Columns>
             </asp:GridView>
         </div>
     </div>

 </div>
</asp:Content>


