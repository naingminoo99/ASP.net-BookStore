<%@ Page Title="" Language="C#" MasterPageFile="~/UserNoLogin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--datalist--%>
    <div class="page-wrapper bg-red p-t-180 p-b-100 font-robo ">
    <div class="wrapper wrapper--w960">
    <div class="card card-2">
    <div class="card-body">
    <div class="alert alert-warning text-center">
        <i class="fa fa-2x fa-info-circle"></i> Please <a href="LoginForm.aspx">Sign In</a> To Start Shopping
    </div>
    <h2 class="title">Browse <i class="fa fa-book"></i></h2>

    <asp:DataList ID="dtlBookNS" runat="server" CellPadding="10" RepeatColumns="4"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
    <FooterStyle BackColor="White" ForeColor="#000066" />
    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <ItemStyle ForeColor="#000066" />
    <ItemTemplate>
        <table class="itemblock">

            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" Height="250px" ImageUrl='<%# "~/images/" + Eval("imagefile") %>' Width="100%" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <small><asp:Label ID="Label3" runat="server" Text='<%# String.Format("{0:c}", Eval("Price")) %>'></asp:Label></small>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:LinkButton CssClass="btn btn-primary fa fa-shopping-cart" ID="LinkButton1" runat="server" OnClientClick="return alert('Sign In To Start Shopping')" CommandName="Select">Add to Cart</asp:LinkButton>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
            </div>
    </div>
    </div>
    </div>

</asp:Content>

