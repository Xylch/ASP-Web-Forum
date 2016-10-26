<%@ Page Title="" Language="C#" MasterPageFile="~/Forum.master" AutoEventWireup="true" CodeFile="CreatePost.aspx.cs" Inherits="ForumPostAddTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <table>
        <tr>
            <td>Title:</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Columns="60"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Message:</td>
            <td>
                <asp:TextBox ID="txtMessage" runat="server" Columns="50" Rows="15" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            </td>
        </tr>
    </table>
</asp:Content>

