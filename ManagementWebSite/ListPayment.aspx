<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="ListPayment.aspx.cs" Inherits="ListPayment"  UICulture="en-US" Culture="en-US" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     .mybtnstyle
{
 border:1px solid Red;
 background-color:Red;
 border-style:groove;
 border-top:5px;
 outline-style:dotted;+
}
 
    


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" Runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="IncomeInfo.aspx">รายการสั่งซื้อ</a>
        </li>

    </ul>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CONTENTContentPlaceHolder" Runat="Server">
     
     <div class="col-lg-12">
        <div class="portlet box alert-info">
            <div class="portlet-title">
                <div class="caption"></div>
            </div>

          

            <div class="portlet-body">

<%--                <asp:Calendar ID="Calendar1" runat="server" Visible="false" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                <asp:Button ID="Button1" runat="server" Text="วันที่เริ่มต้น" ForeColor="#CC0000" OnClick="Button1_Click" />

                <asp:Calendar ID="Calendar2" runat="server" Visible="false" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
                <asp:Button ID="Button2" runat="server" Text="วันที่สิ้นสุด" ForeColor="#CC0000" OnClick="Button2_Click" />
              --%>
                <div class="form-group">
                    <div class="row">
                    <label class="control-label col-md-2">วันที่เริ่มต้นการค้นหา</label>
                    <div class="col-md-3">
                        <div class="input-group input-medium date date-picker" data-date-format="yyyy-MM-dd">
                             <asp:TextBox ID="Date_TextBox1" runat="server" Class="form-control" ></asp:TextBox>
                            <span class="input-group-btn">
                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                            </span>
                        </div>
                        <!-- /input-group -->
                        <span class="help-block">
                        </span>
                    </div>
                
                    <label class="control-label col-md-2">วันที่สุดท้ายการค้นหา</label>
                    <div class="col-md-3">
                        <div class="input-group input-medium date date-picker" data-date-format="yyyy-MM-dd">
                             <asp:TextBox ID="Date_TextBox2" runat="server" Class="form-control" ></asp:TextBox>
                            <span class="input-group-btn">
                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                            </span>
                        </div>
                        <!-- /input-group -->
                        <span class="help-block">
                        </span>
                    </div>
                        </div>
            </div>
<div class="form-group" style="text-align:center;">
                    <hr />
                <asp:Button ID="Button3" runat="server" Text="ค้นหา" CssClass="btn btn-primary" Width="200px" OnClick="Button3_Click" />
                <asp:Button ID="Button4" runat="server" Text="วันนี้" CssClass="btn btn-info" Width="200px" OnClick="Button4_Click" />
</div>
                </div>
                </div>

                    </div>
    <div class="col-lg-12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">รายได้</div>
            </div>

            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover table-full-width" id="sample_4">
                    <thead>
                        <tr>
                            <th><strong>No.</strong></th>
                            <th>วัน/เดือน/ปี</th>
                            <th><strong>เลขที่สั่งซื้อ</strong></th>
                            <th>จำนวนเงิน</th>
                            <th>ชื่อลูกค้า</th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="TicketOrderRepeater" runat="server">
                            <ItemTemplate>
                                <tr>

                                  

                                   <td style="width: 25px; text-align: center;"><asp:Label ID="No_Label" runat="server" Text='<%# Container.ItemIndex + 1 %>' ></asp:Label></td>
                                    <td style="width: 300px;" ><asp:Label ID="Day_Label" runat="server" Text='<%# Eval("Day") %>'  ForeColor="#CC0000"></asp:Label></td>
                                    <td style="width: 300px"><asp:Label ID="TicketCode_Label" runat="server" Text='<%# Eval("Code") %>'  ForeColor="#333399"></asp:Label></td>      <%--//รายการ--%>
                                    <td style="width: 300px"><asp:Label ID="Label1" runat="server" Text='<%# Eval("Total") %>'  ForeColor="#333399"></asp:Label>                    <%-- //จำนวนเงิน--%>
                                        <td style="width: 300px"><asp:Label ID="Label2" runat="server" Text='<%# Eval("FirstName") %>'  ForeColor="#333399"></asp:Label>                <%--//ชื่อลูกค้า--%>
                                     
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

