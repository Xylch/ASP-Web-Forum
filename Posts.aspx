<%@ Page Title="" Language="C#" MasterPageFile="~/Forum.master" AutoEventWireup="true" CodeFile="Posts.aspx.cs" Inherits="Categories" %>

<asp:Content ID="Head1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Forum.css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">

    <asp:LinkButton ID="lbCreatePost" runat="server" CssClass="createPost" PostBackUrl="~/CreatePost.aspx">Create Post</asp:LinkButton>
    <hr />

    <asp:Table ID="mainTable" runat="server">
    </asp:Table>

    <div id="debug" class="debug" runat="server"></div>

</asp:Content>

