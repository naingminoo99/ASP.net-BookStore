<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="ManageAccount.aspx.cs" Inherits="ManageAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-wrapper bg-red p-t-180 p-b-100 font-robo ">
    <div class="wrapper wrapper--w960">
    <div class="card card-2">
    <div class="card-body">
    <h2 class="title">Manage Account Info  <i class="fa fa-edit"></i></h2>
        <div class="col-6">
    <%--   For Output Text  --%>
        <asp:Panel runat="server" ID="pnlSave" Visible="false">
        <div class="alert alert-success text-center">
            <i class="fa fa-save"></i>&nbsp;	<asp:Label ID="lblOutput" runat="server"></asp:Label><br />
        </div>
        </asp:Panel>  
        
        <div class="form-group">
            <label for="tbxId">Email</label>
            <asp:TextBox ID="tbxEmail" class="form-control" type="email" placeholder="Enter Email" ReadOnly required runat="server"></asp:TextBox>
        </div>        
        <div class="form-group">
            <label for="tbxId">User Name</label>
            <asp:TextBox ID="tbxUsername" class="form-control" type="text" placeholder="Enter Username" required runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbxName">Password</label>
            <asp:TextBox ID="tbxPassword" class="form-control" type="password" placeholder="Enter Password" required runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbxPhnum">Phone Number</label>
            <asp:TextBox ID="tbxPhnum" class="form-control" type="tel" placeholder="Enter Phone number" required runat="server"></asp:TextBox>
        </div>  
        <div class="form-group">
            <label for="tbxName">Address</label>
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
            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancle" runat="server" Text="Cancle" class="btn btn-danger" OnClick="btnCancle_Click" OnClientClick="return confirm('Are You Sure ?')"/>

        </div>


        </div>
    </div>
    </div>
    </div>
    </div>


</asp:Content>

