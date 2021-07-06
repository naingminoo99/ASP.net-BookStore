<%@ Page Title="" Language="C#" MasterPageFile="~/UserNoLogin.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%--Register form --%>
    <div class="page-wrapper bg-red p-t-180 p-b-100 font-robo ">
    <div class="wrapper wrapper--w960">
    <div class="card card-2">
    <div class="card-heading" style="background:url('../images/authorplaceholder.jpg')"></div>
    <div class="card-body">
        <h2 class="title"><i class="fa fa-2x fa-user"></i> Register </h2>
    <%--   For Output Text  --%> 
        <asp:Panel runat="server" ID="pnlInfo" Visible="false">
        <div class="alert alert-danger text-center">
            <i class="fa fa-info"></i>&nbsp;	<asp:Label ID="lblOutput" runat="server"></asp:Label><br />
        </div>
        </asp:Panel>  
        
        <div class="form-group">
            <label for="tbxId">Email</label>
            <asp:TextBox ID="tbxEmail" class="form-control" type="email" placeholder="Enter Email" required runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbxId">Username</label>
            <asp:TextBox ID="tbxUsername" class="form-control" type="text" placeholder="Enter Username" required runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbxPassword">Password</label>
            <asp:TextBox ID="tbxPassword" class="form-control" type="password" placeholder="Enter Password" required runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbxPhnum">Phone Number</label>
            <asp:TextBox ID="tbxPhnum" class="form-control" type="tel" placeholder="Enter Phone number" required runat="server"></asp:TextBox>
        </div>        
        <div class="form-group">
            <label for="tbxAddress">Address</label>
            <asp:TextBox ID="tbxAddress" class="form-control" type="text" placeholder="Enter Address" required runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbxName">Unit Number</label>
            <asp:TextBox ID="tbxUnitnum" class="form-control" type="text" placeholder="XX/XX" required runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbxName">Zipcode</label>
            <asp:TextBox ID="tbxZipcode" class="form-control" type="text" placeholder="Enter Address" required runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-success" OnClick="btnRegister_Click" />
        </div>
        <div class="form-group">
            <a class=" btn btn-link" href="LoginForm.aspx">Alredy Have an account ?</a>
        </div>

    </div>
    </div>
    </div>
    </div>
</asp:Content>

