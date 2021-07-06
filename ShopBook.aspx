<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="ShopBook.aspx.cs" Inherits="test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .itemblock {
    display: block;
    width: auto;
    background-color: dimgrey;
    color: white;
    border-radius: 5px;
    font-family: 'Comfortaa', cursive;
    text-align: center;
    margin: 7px 0px 7px 0px;
    padding: 0px 0px 10px 0px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

        .auto-style1 {
            left: 0px;
            top: 14px;
        } 

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="page-wrapper bg-red p-t-180 p-b-100 font-robo ">
    <div class="wrapper wrapper--w960">
    <div class="card card-2">
    <div class="card-body">
    <h2 class="title">Shop <i class="fa fa-book"></i></h2>
    <div class="container-fluid">
        <%--Category and search filters--%>
        <div class="row" style="height:100px;">
            <div class="col">
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <asp:DropDownList runat="server" CssClass="custom-select" ID="ddlFilter" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookstoreConnectionString %>" SelectCommand="SELECT [Id], [Name] FROM [Author]"></asp:SqlDataSource>
                </div>
                <asp:TextBox runat="server" ID="tbxSearch" class="form-control" placeholder="Enter Keyword to Search" type="text"></asp:TextBox>
              <div class="input-group-append">
                  <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-primary" OnClick="btnSearch_Click"><small class="fa fa-search"></small> Search</asp:LinkButton>
              </div>
            </div>
            <small>Showing <asp:Label runat="server" ID="lblDataCount"></asp:Label> Items</small>
            </div>

        </div>
        <%--End of filter box--%>
    <asp:DataList ID="dtlBook" runat="server" CellPadding="10" RepeatColumns="4" OnSelectedIndexChanged="dtlPainting_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="100%" RepeatDirection="Horizontal" OnItemDataBound="dtlBook_ItemDataBound">
    <FooterStyle BackColor="White" ForeColor="#000066" />
    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <ItemStyle ForeColor="#000066" />
    <ItemTemplate>
        <table class="itemblock">

            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" Height="250px" ImageUrl='<%# "~/images/" + Eval("imagefile") %>' Width="100%" />
                    <small>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                    </small>
                </td>
            </tr>
            <tr>
                <td>
                    <small>
                    Written By:
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("AuthorName") %>'></asp:Label>
                    </small>
                </td>
            </tr>
            <tr>
                <td>
                    <small>
                    <asp:Label ID="Label3" runat="server" Text='<%# String.Format("{0:c}", Eval("Price")) %>'></asp:Label>
                    </small>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:LinkButton CssClass="btn btn-primary fa fa-shopping-cart" ID="LinkButton1" runat="server" CommandName="Select">Add to Cart</asp:LinkButton>
                </td>
            </tr>
        </table>
    </ItemTemplate>
    <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
</asp:DataList>
        <//div>

    </div>
    </div>
    </div>
    </div>
</asp:Content>

