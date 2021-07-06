<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-wrapper bg-red p-t-180 p-b-100 font-robo ">
    <div class="wrapper wrapper--w960">
    <div class="card card-2">
    <div class="card-heading" style="background:url('../images/authorplaceholder.jpg')"></div>
    <div class="card-body">
    <h2 class="title"><i class="fa fa-2x fa-warning"></i> Error </h2>
    <div class="alert alert-danger">
    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    </div>
    </div>
    </div>
    </div>
    </div>

</asp:Content>

