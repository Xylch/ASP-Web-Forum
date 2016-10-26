<%@ Page Title="" Language="C#" MasterPageFile="~/Forum.master" AutoEventWireup="true" CodeFile="CreateReply.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <asp:Label ID="lblPost" CssClass="replyHeader" runat="server"></asp:Label>
<br />
<asp:TextBox ID="txtContent" runat="server" Columns="75" Rows="20" TextMode="MultiLine"></asp:TextBox>
<br />
<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
</asp:Content>

