<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="OrdersManagement.aspx.cs" Inherits="TicketOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    .mybtnstyle
{
 border:1px solid Red;
 background-color:Red;
 border-style:groove;
 border-top:5px;
 outline-style:dotted;
}

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="OrdersManagement.aspx">จัดการออเดอร์</a>
        </li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CONTENTContentPlaceHolder" runat="Server">
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

     <asp:Panel ID="Panel1" runat="server" Visible="false">
<audio autoplay="autoplay" >
  <source src="assets/audio/alarm.ogg" type="audio/ogg">
  <source src="assets/audio/alarm.mp3" type="audio/mpeg">
</audio>
        </asp:Panel>


    <div class="col-lg-12">
        <div class="portlet box red">
            <div class="portlet-title">
                <div class="caption">
                    จัดการออเดอร์
                </div>
                <div class="actions">
                    <div class="btn-group">

                        <%--<a class="btn default" href="#" data-toggle="dropdown">Columns <i class="fa fa-angle-down"></i></a>

                        <div id="sample_1_column_toggler" class="dropdown-menu hold-on-click dropdown-checkboxes pull-right">
                            <label>
                                <input type="checkbox" checked data-column="0" />No.
                            </label>
                            <label>
                                <input type="checkbox" checked data-column="1" />Ticket
                            </label>
                            <label>
                                <input type="checkbox" checked data-column="2" />Confirm Date/Time
                            </label>
                            <label>
                                <input type="checkbox" checked data-column="3" />Detail
                            </label>
                        </div>--%>
                    </div>
                </div>
            </div>

            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover table-full-width" id="sample_2">
                    <thead>
                        <tr>
                            <th><strong>ลำดับ.</strong></th>
                                                
                            <th><strong>เลขที่การสั่งซื้อ</strong></th>
                            <th><strong>สถานะ</strong></th>
                              <th><strong>วัน/เวลา</strong></th>    
                            <th><strong>จัดการ</strong></th>
                        </tr>
                    </thead>
                    
                    <tbody>
                        <asp:Repeater ID="TicketOrderRepeater" runat="server" OnItemDataBound="TicketOrderRepeater_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 25px; text-align: center;"><%# Container.ItemIndex + 1 %></td>                                   
                                    
                                    <td style="width: 250px">
                                      
                                        <strong> 
                                            <asp:Label ID="Label1" runat="server" Text= 'DGS-' ForeColor="Orange" Font-Size="Larger"></asp:Label>
                                            <asp:Label ID="TicketCode_Label" runat="server" Text= '<%# Eval("Id") %>' ForeColor="Orange" Font-Size="Larger"></asp:Label>

                                        </strong>
                                            
                                          <br/>
                                      <%# Eval("FirstName") %>  <%# Eval("LastName") %>
                                    </td>
                                      <td><asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' ></asp:Label>
                                          <br />
                                          <asp:Label ID="statusconfirm" runat="server" ForeColor="Green" Text='<%# Eval("ChkPayment") %>' Visible="false"></asp:Label>
                                      </td>
                                     <td><asp:Label ID="Day_Label" runat="server" Text='<%# Eval("LastUpdated") %>' ></asp:Label> </td>
                                    <td style="width: 300px">
                                        <asp:Label ID="TicketOrderIdLabel" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="EditServicesProduct_Button" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="linkDetail" Text="รายละเอียด"  CssClass="btn red"></asp:LinkButton>
                                        <asp:HiddenField ID="Status_HiddenField" runat="server" Value='<%# Eval("Status") %>' />
                                        
                                       <%-- <asp:Button ID="Button1" runat="server" Text="Button" />--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                          
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

