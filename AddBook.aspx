<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddBook.aspx.cs" Inherits="AddPaintingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 145px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td class="auto-style1">Painting Id</td>
            <td>
                <asp:TextBox ID="tbxId" runat="server" Width="89px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Artist</td>
            <td>
                <asp:DropDownList ID="ddlArtist" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Description</td>
            <td>
                <asp:TextBox ID="tbxDescription" runat="server" TextMode="MultiLine" Width="232px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Price</td>
            <td>
                <asp:TextBox ID="tbxPrice" runat="server" Height="27px" Width="121px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Imagefile</td>
            <td>
                <asp:FileUpload ID="fldUpload" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Image ID="imgPainting" runat="server" Height="50px" Width="50px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

