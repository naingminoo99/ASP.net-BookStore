<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>.input-group-addon {
.input-group-addon{
        background-color: transparent;
        border-left: 0;
    }

.cc-number.identified {
    background-repeat: no-repeat;
	background-position-y: 3px;
	background-position-x: 99%;
}


.one-card > div {
    height: 150px;
    background-position: center center;
    background-repeat: no-repeat;
}

.two-card > div {
    height: 80px;
    background-position: center center;
    background-repeat: no-repeat;
    background-size: contain;
    width: 48%;
}

.two-card div.amex-cvc-preview {
    float: right;
}

</style>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.2.0/js/tether.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-wrapper bg-red p-t-180 p-b-100 font-robo ">
    <div class="wrapper wrapper--w960">
    <div class="card card-2">
    <div class="card-body">
        <h2 class="title">Shopping Cart <i class="fa fa-shopping-cart"></i></h2>

                <%--If no item in cart this Panel will be rendered--%>
                <asp:Panel ID="pnlCartEmpty" runat="server" Visible="false">
                    <div class="alert alert-warning text-center">
                    Your Shopping Cart Is Empty 
                    Go to Shop and Pick Up Something <a href="ShopBook.aspx" class="btn btn-link"> Go to Shop <i class="fa fa-arrow-circle-right"></i></a>
                    </div>    
                </asp:Panel>

                <%--Ordersucess--%>
                <asp:Panel ID="pnlOrderSuccess" runat="server" Visible="false">
                    <div class="alert alert-success text-center">
                    
                    Your Recent Order : ( OrderID <asp:Label ID="lblOdnum" runat="server"></asp:Label> ) is  Sucessfull  <br />
                    Check Purchased History<a href="OrderHistory.aspx" class="btn btn-link"> Go <i class="fa fa-arrow-circle-right"></i></a><br />
                    <asp:LinkButton CssClass="btn btn-danger fa fa-close" runat="server" ID="btnOdClear" OnClick="btnOdClear_Click" Text="Close"></asp:LinkButton>
                    </div>    
                </asp:Panel>

                <%--this panel contain the Shopping cart and payment content--%>
                <asp:Panel ID="pnlPayment" runat="server" Visible="false">
                    
                <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gvCart_RowDeleting" Width="100%" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <div class="alert alert-info text-right" style="margin-top:10px;">
                Total Amount is =  <asp:Label ID="lblAmount" runat="server"></asp:Label>
                </div>                             
                <asp:LinkButton  ID="lblClearCart" Text="Clear Cart" class="btn btn-danger float-right"  runat="server" OnClientClick="return confirm ('Are You sure To Clear the cart ?')" OnClick="lblClearCart_Click" ></asp:LinkButton>
                <br /><br /><br />
                <hr class="">
                <br /><br />

                <%--Payment Form--%>
                    <div class="container-fluid py-3">
                        <div class="row">
                            <div class="mx-auto" style="width:70%;">
                                <div id="pay-invoice" class="card">
                                    <div class="card-body">
                                        <div class="card-title">
                                        </div>
                                            <div class="form-group text-center">
                                                <ul class="list-inline">
                                                    <li class="list-inline-item"><i class="fa fa-cc-visa fa-2x"></i></li>
                                                    <li class="list-inline-item"><i class="fa fa-cc-mastercard fa-2x"></i></li>
                                                    <li class="list-inline-item"><i class="fa fa-cc-amex fa-2x"></i></li>
                                                    <li class="list-inline-item"><i class="fa fa-cc-discover fa-2x"></i></li>
                                                </ul>
                                            </div>
                                            <div class="form-group">
                                                <label>Payment amount</label>
                                                <h2><asp:Label runat="server" ID="lbltotalP"></asp:Label></h2>
                                            </div>
                                            <div class="form-group">
                                                <label for="cc-name" class="control-label mb-1">Name on card</label>
                                                <asp:TextBox ID="tbxNameOC" type="text" class="form-control cc-name" required="" autocomplete="cc-name" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="cc-number" class="control-label mb-1">Card number
                                                </label>
                                                <asp:TextBox ID="tbxCreditCard" type="tel" class="form-control cc-number " required="" pattern="[0-9]{16}" title="Enter A Valid Card Number (16 digits)" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="row">
                                                <div class="col-6">
                                                    <div class="form-group">
                                                        <label for="cc-exp" class="control-label mb-1">Expiration</label>
                                                        <asp:TextBox ID="tbxExp" type="tel" ctype="tel" class="form-control cc-exp" required placeholder="MM / YY" autocomplete="cc-exp" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-6">
                                                    <label for="x_card_code" class="control-label mb-1">Security code</label>
                                                    <div class="input-group">
                                                        <asp:TextBox ID="tbxCVC" name="x_card_code" type="tel" class="form-control cc-cvc" required autocomplete="off" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="x_zip" class="control-label mb-1">Postal code</label>
                                                <asp:TextBox ID="tbxZIP" name="x_zip" type="text" class="form-control" autocomplete="postal-code" required runat="server"></asp:TextBox>
                                            </div>
                                            <div>
                                            <asp:Button runat="server" ID="btnPay" OnClick="btnPay_Click" class="btn btn-lg btn-info btn-block" Text="Pay" />
                                            <asp:Label ID="lblOutput" runat="server"></asp:Label>
                                            </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
    </div>  
    </div>
    </div>
    </div>
</asp:Content>

