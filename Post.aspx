<%@ Page Title="" Language="C#" MasterPageFile="~/Forum.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Post" %>

<asp:Content ID="Head1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Forum.css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">

    <asp:Table ID="mainTable" class="postMainTable" runat="server">
    </asp:Table>

    <div id="debug" class="debug" runat="server"></div>

</asp:Content>

