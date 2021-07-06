<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateAuthor.aspx.cs" Inherits="UpdateArtistForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style1 {
            width: 133px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td>search
                <asp:TextBox ID="tbxSearch" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvArtist" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-nonfluid  .table-striped  .table-condensed table-responsive" AutoGenerateColumns="False" OnSelectedIndexChanged="gvArtist_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvArtist_PageIndexChanging" PageSize="3" OnRowDeleting="gvArtist_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Dob" DataFormatString="{0:yyyy-MM-dd}" HeaderText="Date of Birth" />
                        <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="w-100">
                    <tr>
                        <td class="auto-style1">Id</td>
                        <td>
                            <asp:TextBox ID="tbxId" runat="server" required=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Name</td>
                        <td>
                            <asp:TextBox ID="tbxName" runat="server" required=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Date of Birth</td>
                        <td>
                            <asp:TextBox ID="tbxDateOfBirth" runat="server" required="" type="date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Profile</td>
                        <td>
                            <asp:TextBox ID="tbxProfile" runat="server" Height="57px" TextMode="MultiLine" Width="275px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnAdd_Click" Text="Update" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>
                            <asp:Label ID="lblOutput" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
</asp:Content>

