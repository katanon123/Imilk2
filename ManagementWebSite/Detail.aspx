<%@ Page Title="" Language="C#" MasterPageFile="~/MetronicMaster.master" AutoEventWireup="true" CodeFile="Detail.aspx.cs" Inherits="Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CONTENTContentPlaceHolder" Runat="Server">
    <script type="text/javascript">
        function PrintConfirmDiv() {
            var divContents = document.getElementById("dvConfirmContents").innerHTML;
            var printWindow = window.open('', '', 'height=200,width=400');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(divContents);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
        }
    </script>
    <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
        <div class="alert alert-success">
            <p style="text-align: right">
                <asp:LinkButton ID="SuccessLinkButton" runat="server" OnClick="SuccessLinkButton_Click">X</asp:LinkButton>
            </p>
            <p><strong>Success! </strong></p>
            <asp:Label ID="SuccessLabel" runat="server" Text=""></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
        <div class="alert alert-danger">
            <p style="text-align: right">
                <asp:LinkButton ID="ErrorLinkButton" runat="server" OnClick="ErrorLinkButton_Click">X</asp:LinkButton>
            </p>
            <p><strong>Error! </strong></p>
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>
    </asp:Panel>

   <%-- พิมพ์ใบเสร็จ ตอนกด Confirm Order--%>
    <asp:Panel ID="ConfirmOrderPrintPanel" runat="server" Style="display: none">
        <div id="dvConfirmContents" style="border: 1px dotted black; padding: 5px; width: 300px">
            <p>
                <asp:Label ID="Label2" runat="server">DGS-</asp:Label><asp:Label ID="IDT" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="DateLabel" runat="server"></asp:Label>
            </p>
            <table>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 1%"><%# Container.ItemIndex + 1 %>
                                </td>
                                <td style="width: 200px"><%# Eval("Product") %></td>
                                <td style="width: 150px"><%# Eval("Quantity") %></td>
                                <td style="width: 150px"><%# Eval("Price") %></td>
                                <td style="width: 15%"><%# Eval("Total") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="4" style="text-align: right" class="auto-style1">
                            <strong style="vertical-align: top; font-size: medium;">Grand Total : </strong></td>
                        <td style="text-wrap: normal" class="auto-style1">
                            <asp:Label ID="Label3" runat="server" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </asp:Panel>

    <asp:Label ID="TicketOrderID_Label" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
    <asp:Label ID="ProductOrderID_Label" runat="server" Text='<%# Eval("ProductOrderID") %>' Visible="false"></asp:Label>

    <div class="col-lg-12" style="text-align: center">
        <asp:Label ID="Ticket_Label" runat="server" Font-Size="X-Large" ForeColor="Red" Font-Bold="True"></asp:Label>
    </div>

    <div class="col-lg-12">
        <div class="portlet box grey">
            <div class="portlet-title">
                <div class="caption">
                    Confirmation
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-body">
                    <div class="form-group">
                        <h4><strong>Customer : </strong></h4>
                        <asp:Label ID="Customer_Label" runat="server" CssClass="form-control"></asp:Label>
                    </div>

                    <div class="form-group">
                        <h4><strong>Confirm Date/Time : </strong></h4>
                        <asp:Label ID="Confirmdatetime_Label" runat="server" CssClass="form-control"></asp:Label>
                    </div>



                    <div class="form-group" style="text-align: center">
                        <asp:LinkButton runat="server" ID="Confirmorder_Button" class="btn purple" data-target='#myModalcon' data-toggle="modal">Confirm Order</asp:LinkButton>
                                        
                                                <div class="modal fade" id="myModalcon" role="dialog">
                                                        <div class="modal-dialog">
                                                          <div class="modal-content">
                                                            <div class="modal-header">
                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                             <h4>Press OK to confirm.</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                 <asp:LinkButton ID="ButtonConfirmorder" runat="server" CssClass="btn green" Text="Ok" OnClick="Confirmorder_Button_Click" ></asp:LinkButton>
                                                                 <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                                            </div>
                                                          </div>
                                                        </div>
                                                      </div>

                       
                    </div>
                </div>
            </div>
            <%--<div class="col-lg-4" style="text-align: right">
                <br />
                <asp:Button ID="Payment_Button" runat="server" CssClass="btn green" Text="Payment" OnClick="Payment_Button_Click" OnClientClick="return confirm('Are you payment ?');" />
            </div>
            <div class="col-lg-4" style="text-align: center">
                <br />
                <asp:Button ID="Checkin_Button" runat="server" CssClass="btn blue" Text="Check-In" OnClientClick="return confirm('Are you Check-In ?');" OnClick="Checkin_Button_Click" />
            </div>
            <div class="col-lg-4" style="text-align: left">
                <br />
                <asp:Button ID="Checkout_Button" runat="server" CssClass="btn yellow" Text="Check-Out" OnClientClick="return confirm('Are you Check-Out ?');" OnClick="Checkout_Button_Click" Visible="false" />
            </div>--%>
        </div>
    </div>

    <asp:Panel ID="orderTa" runat="server">

        <div class="col-lg-12">
            <div class="portlet box yellow">
                <div class="portlet-title">
                    <div class="caption">
                        Orders Detail
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                        </div>
                    </div>
                </div>

                <%--<div class="portlet-body">
                <p><strong>Service</strong></p>
                <asp:DropDownList ID="ServiceCategory_DropDownList" runat="server" CssClass="form-control" OnSelectedIndexChanged="ServiceCategory_DropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>--%>

                <div class="portlet-body">
                    <table class="table table-striped table-bordered table-hover table-full-width" id="sample">
                        <thead>
                            <tr>
                                <th><strong>No.</strong></th>
                                <th><strong>Product</strong></th>
                                <th><strong>Quantity</strong></th>
                                <th><strong>Price</strong></th>
                                <%--<th><strong>Check In Date</strong></th>--%>
                                <%--<th><strong>Check Out Date</strong></th>--%>
                                <th><strong>Total</strong></th>
                                <%--<th><strong>Payment Status</strong></th>
                            <th><strong>Check In Status</strong></th>
                            <th><strong>Check Out Status</strong></th>--%>
                            </tr>
                        </thead>

                        <tbody>
                            <asp:Repeater ID="DetailTicketOrderRepeater" runat="server" OnItemDataBound="DetailTicketOrderRepeater_ItemDataBound1" OnItemCommand="DetailTicketOrderRepeater_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 1%"><%# Container.ItemIndex + 1 %>
                                            <asp:Label ID="ProductOrderID_Label" runat="server" Text='<%# Eval("ProductOrderID") %>' Visible="false"></asp:Label>
                                        </td>
                                        <td style="width: 200px"><%# Eval("Product") %></td>
                                        <td style="width: 150px"><%# Eval("Quantity") %></td>
                                        <td style="width: 150px"><%# Eval("Price") %></td>
                                        <%--<td style="width: 20%"><%# Eval("Checkin") %></td>--%>
                                        <%--<td style="width: 250px"><%# Eval("Checkout") %></td>--%>
                                        <td style="width: 15%"><%# Eval("Total") %></td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                            <tr>
                                <td colspan="4" style="text-align: right" class="auto-style1">
                                    <strong style="vertical-align: top; font-size: medium;">Grand Total : </strong>
                                </td>
                                <td style="text-wrap: normal" class="auto-style1">
                                    <asp:Label ID="Label1" runat="server" ForeColor="#CC0000" Font-Size="Medium"></asp:Label>
                                </td>
                            </tr>

                        </tbody>
                    </table>


                </div>
            </div>
        </div>
    </asp:Panel>
 <asp:Panel ID="Panel1" runat="server" Visible="true">
    <div class="col-lg-12">
       
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    All Orders Detail For Payment
                </div>
                <div class="actions">
                    <div class="btn-group">

                        <%--<a class="btn default" href="#" data-toggle="dropdown">Columns <i class="fa fa-angle-down"></i></a>

                        <div id="sample_1_column_toggler" class="dropdown-menu hold-on-click dropdown-checkboxes pull-right">
                            <label>
                                <input type="checkbox" checked data-column="0" />No.
                            </label>
                            <label>
                                <input type="checkbox" checked data-column="1" />Product
                            </label>
                            <label>
                                <input type="checkbox" checked data-column="2" />Quantity
                            </label>
                            <label>
                                <input type="checkbox" checked data-column="3" />Price
                            </label>
                            <label>
                                <input type="checkbox" checked data-column="4" />Check In Date
                            </label>
                            <label>
                                <input type="checkbox" checked data-column="5" />Check Out Date
                            </label>
                            <label>
                                <input type="checkbox" checked data-column="6" />Total
                            </label>
                             <label>
                                <input type="checkbox" checked data-column="9" />Payment Status
                            </label>
                            <label>
                                <input type="checkbox" checked data-column="7" />Check In Status
                            </label>
                             <label>
                                <input type="checkbox" checked data-column="8" />Check Out Status
                            </label>
                        </div>--%>
                    </div>
                </div>
            </div>

            <%--<div class="portlet-body">
                <p><strong>Service</strong></p>
                <asp:DropDownList ID="ServiceCategory_DropDownList" runat="server" CssClass="form-control" OnSelectedIndexChanged="ServiceCategory_DropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>--%>

            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover table-full-width">
                    <thead>
                        <tr>
                            <th><strong>No.</strong></th>
                            <th><strong>Product</strong></th>
                            <th><strong>Quantity</strong></th>
                            <th><strong>Price</strong></th>
                            <%--<th><strong>Check In Date</strong></th>--%>
                            <%--<th><strong>Check Out Date</strong></th>--%>
                            <th><strong>Total</strong></th>
                            <%--<th><strong>Payment Status</strong></th>
                            <th><strong>Check In Status</strong></th>
                            <th><strong>Check Out Status</strong></th>--%>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="DetailTicketOrderRepeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 1%"><%# Container.ItemIndex + 1 %>
                                        <asp:Label ID="ProductOrderID_Label" runat="server" Text='<%# Eval("ProductOrderID") %>' Visible="false"></asp:Label>
                                    </td>
                                    <td style="width: 200px"><%# Eval("Product") %></td>
                                    <td style="width: 150px"><%# Eval("Quantity") %></td>
                                    <td style="width: 150px"><%# Eval("Price") %></td>
                                    <%--<td style="width: 20%"><%# Eval("Checkin") %></td>--%>
                                    <%--<td style="width: 250px"><%# Eval("Checkout") %></td>--%>
                                    <td style="width: 15%"><%# Eval("Total") %></td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                        <tr>
                            <td colspan="4" style="text-align: right" class="auto-style1">
                                <strong style="vertical-align: top; font-size: medium;">Grand Total : </strong>
                            </td>
                            <td style="text-wrap: normal" class="auto-style1">
                                <asp:Label ID="Total_Label" runat="server" ForeColor="#CC0000" Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>

                    </tbody>
                </table>
                <div class="form-group" style="text-align: center">
                   <asp:LinkButton  runat="server" ID="Payment_Button" class="btn green" data-target='#myModalPayment' data-toggle="modal">Payment</asp:LinkButton>
                                        
                                                <div class="modal fade" id="myModalPayment" role="dialog">
                                                        <div class="modal-dialog">
                                                          <div class="modal-content">
                                                            <div class="modal-header">
                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                             <h4>Press OK to confirm.</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <asp:LinkButton ID="Delete_LinkButton" runat="server" CssClass="btn green" Text="Ok" OnClick="Payment_Button_Click"></asp:LinkButton>
                                                                 <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                                            </div>
                                                          </div>
                                                        </div>
                                                      </div>

                   <%--<asp:LinkButton ID="BillLinkButton" runat="server" CssClass="btn green" OnClick="LinkButton1_Click">Bill</asp:LinkButton>--%>

                </div>

            </div>
        </div>
    </div>
     </asp:Panel>
    <div class="form-group" style="text-align: center">
           <asp:LinkButton runat="server" ID="Completeorder_Button" class="btn dark" data-target='#myModalComplete' data-toggle="modal">Complete Order</asp:LinkButton>
                                        
                                                <div class="modal fade" id="myModalComplete" role="dialog">
                                                        <div class="modal-dialog">
                                                          <div class="modal-content">
                                                            <div class="modal-header">
                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                             <h4>Press OK to confirm.</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <asp:LinkButton ID="Buttoncon" runat="server" CssClass="btn green" Text="Ok" OnClick="Completeorder_Button_Click"></asp:LinkButton>
                                                                 <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                                            </div>
                                                          </div>
                                                        </div>
                                                      </div>
    </div>
</asp:Content>

