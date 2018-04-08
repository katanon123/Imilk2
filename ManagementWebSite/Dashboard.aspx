<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" UICulture="en-US" Culture="en-US" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <asp:Literal ID="Graph_Literal" runat="server"></asp:Literal>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="Dashboard.aspx">หน้าเเรก</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CONTENTContentPlaceHolder" runat="Server">
    <div class="row">
        <a href="IncomeInfo.aspx">
            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12 margin-bottom-10">
                <div class="dashboard-stat blue">

                    <div class="visual">
                        <i class="fa fa-briefcase fa-icon-medium"></i>
                    </div>
                    <div class="details">
                        <div class="number">
                            <asp:Label ID="Lifetimesales_Label" runat="server" Text="dddd"></asp:Label>
                        </div>
                        <div class="desc">
                            รายได้ต่อปี (บาท)
                        </div>
                    </div>
                    <div class="more">
                        View more <i class="m-icon-swapright m-icon-white"></i>
                    </div>
                </div>
            </div>
        </a>

        <a href="ListPayment.aspx">
            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                <div class="dashboard-stat green">
                    <div class="visual">
                        <i class="fa fa-shopping-cart"></i>
                    </div>
                    <div class="details">
                        <div class="number">
                            <asp:Label ID="Totalorders_Label" runat="server" Text="dd"></asp:Label>
                        </div>
                        <div class="desc">
                            รายการที่ถูกสั่งทั้งหมด
                        </div>
                    </div>
                    <div class="more">
                        View more <i class="m-icon-swapright m-icon-white"></i>
                    </div>
                    <%--<a class="more" href="#">View more <i class="m-icon-swapright m-icon-white"></i>
                </a>--%>
                </div>
            </div>
        </a>

        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
            <div class="dashboard-stat yellow">
                <div class="visual">
                    <i class="fa fa-group fa-icon-medium"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <asp:Label ID="Averageorder_Label" runat="server" Text="dlf"></asp:Label>
                    </div>
                    <div class="desc">
                        ค่าเฉลี่ยต่อรายการสั่งซื้อ (บาท)
                    </div>
                </div>
               <div class="more">

                </div>
                <%--<a class="more" href="#">View more <i class="m-icon-swapright m-icon-white"></i>
                </a>--%>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- Begin: life time stats -->
            <div class="portlet box yellow">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-thumb-tack"></i>ภาพรวม
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#overview_1" data-toggle="tab">รายการยอดนิยม
                            </a>
                        </li>
                        <li>
                            <a href="#overview_2" data-toggle="tab">ลูกค้ารายใหม่
                            </a>
                        </li>
                        <li>
                            <a href="#overview_3" data-toggle="tab">รายการสั่งซื้อล่าสุด
                            </a>
                        </li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="overview_1">
                            <div class="table-responsive">
                                <table class="table table-striped table-hover table-bordered">
                                    <thead>
                                        <tr>
                                            <th><strong>รายชื่ออาหารเเละเครื่องดื่ม</strong></th>
                                            <th style="width: 25%"><strong>ราคา</strong></th>
                                            <th style="width: 25%"><strong>จำนวน</strong></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="TopRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("Thai") %><br /><%# Eval("English") %></td>
                                                    <td><%# ((decimal)Eval("Price")).ToString("#,##0.00") %>.-</td>
                                                    <td><%# Eval("Count") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="tab-pane" id="overview_2">
                            <div class="table-responsive">
                                <table class="table table-striped table-hover table-bordered">
                                    <thead>
                                        <tr>
                                            <th><strong>รายชื่อลูกค้า</strong></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="NewcustomerRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("FirstName") %> <%# Eval("LastName") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="tab-pane" id="overview_3">
                            <div class="table-responsive">
                                <table class="table table-striped table-hover table-bordered">
                                    <thead>
                                        <tr>
                                            <th style="width: 20%"><strong>รายชื่อลูกค้า</strong></th>
                                            <th style="width: 20%"><strong>วันที่</strong></th>
                                            <th style="width: 10%"><strong>ราคารวมทั้งหมด</strong></th>
                                            <th style="width: 10%"><strong>สถานะ</strong></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="NewOrdersRepeater" runat="server" OnItemDataBound="NewOrdersRepeater_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("FirstName") %> <%# Eval("LastName") %></td>
                                                    <td><%# ((DateTime)Eval("CreatedDate")).ToString("dd-MM-yyyy HH:mm") %> น.</td>
                                                    <td><%# ((decimal)Eval("Total")).ToString("#,##0.00") %>.-</td>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Status") %>'></asp:Label></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End: life time stats -->
        </div>
        <div class="col-md-12">
            <!-- Begin: life time stats -->
            <div class="portlet box blue tabbable">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-bar-chart-o"></i>รายได้
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="reload"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="well no-margin no-border;">
                        <div id="chart_div" style="width: 100%; height: 500px;"></div>
                    </div>
                    <%--<div class="well no-margin no-border">
                        <div class="row">
                            <div class="col-md-3 col-sm-3 col-xs-6 text-stat">
                                <span class="label label-success">Revenue:
                                </span>
                                <h3>$1,234,112.20</h3>
                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-6 text-stat">
                                <span class="label label-info">Tax:
                                </span>
                                <h3>$134,90.10</h3>
                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-6 text-stat">
                                <span class="label label-danger">Shipment:
                                </span>
                                <h3>$1,134,90.10</h3>
                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-6 text-stat">
                                <span class="label label-warning">Orders:
                                </span>
                                <h3>235090</h3>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
            <!-- End: life time stats -->
        </div>
    </div>
</asp:Content>

