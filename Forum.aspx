<%@ Page Title="" Language="C#" MasterPageFile="~/Forum.master" AutoEventWireup="true" CodeFile="Forum.aspx.cs" Inherits="Forum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    
    <h2>Categories</h2>

    <asp:Table ID="mainTable" runat="server">
    </asp:Table>

    <div id="debug" class="debug" runat="server"></div>
    
</asp:Content>

