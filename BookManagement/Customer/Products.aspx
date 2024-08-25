<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutTemplate/Layout.Master"
    AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="BookManagement.Customer.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcontent" runat="server">
    <style>
        .imagesize{
            width : 180px;
            height : 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentpage" runat="server">

    <div class="row mt-5 mb-5">
        <asp:Repeater runat="server" ID="productsrept">
            <ItemTemplate>
                <div class="col-3">
                    <div class="card" style="width: 18rem;">
                       <%-- <img src="../Content/BookCoverPhotot/images.jpg" class="card-img-top" />--%>
                        
                        <asp:Image runat="server" ImageUrl='<%# Eval("CoverPhotoPath") %>' CssClass="card-img-top imagesize" />
                        <div class="card-body">
                            <h5 class="card-title">
                                <asp:Label runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                            </h5>
                            <h5 class="card-title">Price &#8377; &nbsp; 
                                <asp:Label runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                            </h5>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>



</asp:Content>
