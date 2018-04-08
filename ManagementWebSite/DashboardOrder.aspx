<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="DashboardOrder.aspx.cs" Inherits="DashboardOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" runat="Server">
    <h3 class="page-title">Dashboard Orders</h3>
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="Dashboard.aspx">Dashboard</a><i class="fa fa-angle-right"></i>
        </li>
        <li>Dashboard Orders
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CONTENTContentPlaceHolder" runat="Server">
    <div class="row">
        <a href="DashboardOrder.aspx">
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
                            รายได้ (บาท)
                        </div>
                    </div>
                    <div class="more">
                        View more <i class="m-icon-swapright m-icon-white"></i>
                    </div>
                </div>
            </div>
        </a>
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
                        รายการที่ถูกสั่งจอง
                    </div>
                </div>
                <div class="more">
                </div>
            </div>
        </div>
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
                        ค่าเฉลี่ยต่อรายการสั่งจอง (บาท)
                    </div>
                </div>
                <div class="more">
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-12">
        <br />
        <br />
        <div class="col-lg-3"></div>
        <div class="col-lg-3" style="text-align: center">
            <div class="input-group input-medium date date-picker col-lg-6" data-date-format="dd-mm-yyyy" data-date-start-date="+0d">
                <asp:TextBox ID="Date_TextBox" runat="server" Class="form-control"></asp:TextBox>
                <span class="input-group-btn">
                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                </span>
            </div>
        </div>
        <div class="col-lg-3" style="text-align: center">
            <div class="input-group input-medium date date-picker col-lg-6" data-date-format="dd-mm-yyyy" data-date-start-date="+0d">
                <asp:TextBox ID="TextBox1" runat="server" Class="form-control"></asp:TextBox>
                <span class="input-group-btn">
                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                </span>
            </div>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="col-lg-12" style="text-align:center">
        <br />
        <br />
        <asp:Button ID="OK_Button" runat="server" Text="ยืนยัน" CssClass="btn red" />
    </div>

    <div class="col-lg-12">
        <br />
        <br />
        <div class="portlet box purple">
            <div class="portlet-title">
                <div class="caption">
                    รายการทั้งหมด
                </div>
            </div>
            <div class="portlet-body">
                <table class="table table-hover table-bordered table-full-width" id="simple_2">
                    <thead>
                        <tr>
                            <th><strong>รหัสอาหารเเละเครื่องดื่ม</strong></th>
                            <th><strong>ชื่อลูกค้า</strong></th>
                            <th><strong>วันที่</strong></th>
                            <th><strong>เวลา</strong></th>
                            <th><strong>ราคา</strong></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="AllOrders_Repeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("TicketOrder") %></td>
                                    <td><%# Eval("FirstName") %> <%# Eval("LastName") %></td>
                                    <td><%# ((DateTime)Eval("CreatedDate")).ToString("dd-MM-yyyy") %></td>
                                    <td><%# ((DateTime)Eval("CreatedDate")).ToString("HH:mm") %> น.</td>
                                    <td><%# ((decimal)Eval("Total")).ToString("#,##0.00") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

