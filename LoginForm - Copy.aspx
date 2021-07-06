<%@ Page Title="" Language="C#" MasterPageFile="~/UserNoLogin.master" AutoEventWireup="true" CodeFile="LoginForm - Copy.aspx.cs" Inherits="LoginForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       body {
           background-color:lightgreen !important;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <%--Login Form--%>
    <div class="page-wrapper bg-red p-t-180 p-b-100 font-robo " style="background-color:#009460 !important">
    <div class="wrapper wrapper--w960">
    <div class="card card-2">
    <div class="card-heading" style="background:url('../images/aaa.png')"></div>
    <div class="card-body">
        <h2 class="title"><i class="fa fa-2x fa-university"></i> SIM Connect</h2>
    <%--   For Output Text  --%>
        <asp:Panel runat="server" ID="pnlLoginError" Visible="false">
        <div class="alert alert-danger text-center">
            <i class="fa fa-warning"></i>&nbsp;	<asp:Label ID="lblOutput" runat="server"></asp:Label><br />
        </div>
        </asp:Panel>  
        <div class="form-group">
            <label for="tbxId">Select Your Shit</label>
                    <asp:DropDownList runat="server" CssClass="custom-select" ID="ddlFilter"  DataTextField="Name" DataValueField="Id">
                        <asp:ListItem>Student</asp:ListItem>
                        <asp:ListItem>Staff</asp:ListItem>
                        <asp:ListItem>Teacher</asp:ListItem>
                    </asp:DropDownList>        
        </div>

        <div class="form-group">
            <label for="tbxId">Email</label>
            <asp:TextBox ID="tbxEmail" class="form-control" type="email" placeholder="Enter Email" required runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbxName">Password</label>
            <asp:TextBox ID="tbxPassword" class="form-control" type="password" placeholder="Enter Password" required runat="server"></asp:TextBox>

        </div>
        <div class="form-group">
            <asp:Button ID="btnLogin" runat="server" Text="Sign In" class="btn btn-primary" OnClick="btnLogin_Click"/>
        </div>
        <%--Foget Password--%>
        <div class="form-group">
            <asp:Button ID="btnForgot" runat="server" Text="Forgot Password ?" class="btn btn-warning"  OnClick="btnForgot_Click"/>
        </div>

    </div>
    </div>
    </div>
    </div>

</asp:Content>

