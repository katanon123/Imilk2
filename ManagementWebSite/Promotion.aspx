<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Promotion.aspx.cs" Inherits="MenuBeverage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" Runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><asp:HyperLink ID="BackMenu_HyperLink" runat="server">โปรโมชั่น</asp:HyperLink>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CONTENTContentPlaceHolder" Runat="Server">
    <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
        <div class="alert alert-success">
            <div style="float:left"><strong>Success!</strong>
            <asp:Label ID="SuccessLabel" runat="server"></asp:Label></div>
                <div style="float:right"> <asp:LinkButton ID="SuccessLinkButton" runat="server" OnClick="SuccessLinkButton_Click">X</asp:LinkButton></div>
          <br />
        </div>
    </asp:Panel>

     <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
       <div class="alert alert-danger">
            <div style="float:left"><strong>Error!</strong>
            <asp:Label ID="ErrorLabel" runat="server"></asp:Label></div>
                <div style="float:right">  <asp:LinkButton ID="ErrrorLinkButton" runat="server" OnClick="ErrorLinkButton_Click">X</asp:LinkButton></div>
          <br />
        </div>
    </asp:Panel>

    <div class="col-lg-12">
        <div class="portlet box yellow">
            <div class="portlet-title">
                <div class="caption">
                    <asp:Label ID="Menu2_Label" runat="server">โปรโมชั่น</asp:Label>
                </div>
                 <div class="actions">
                        <div class="btn-group">

                            <asp:Button ID="AddButton" runat="server" Text="+" CssClass="btn green" OnClick="AddButton_Click" />

                        </div>
                    </div>
            </div>

            <div class="portlet-body">
                <table class="table table-bordered table-hover table-full-width" id="sample_2">
                    <thead>
                        <tr>
                            <th><strong>ลำดับ.</strong></th>
                            <th><strong>ชื่อ</strong></th>
                            <th><strong>รายละเอียด</strong></th>
                             <th><strong>รูปภาพ</strong></th>
                            <th><strong>จัดการ</strong></th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="BeverageRepeater" runat="server" OnItemDataBound="BeverageRepeater_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td style="width:1%; text-align:center;"><%# Container.ItemIndex + 1 + "."%>
                                        <asp:Label ID="IDProduct" runat="server" Text='<%# Eval("IDProduct") %>' Visible="false"></asp:Label>
                                    </td>
                                    <td style="width:30%"><%# Eval("Name") %><br /><%# Eval("NameEN") %></td>
                                    <td style="word-wrap: break-word;min-width: 160px;max-width: 160px;white-space:normal;"><%# Eval("Detail") %> <br />  <%# Eval("DetailEn") %>  </td>
                                      <td style="width: 120px;">
                                                            <%--<img src='<%#Eval("ImageURL")%>' width="100px" height="100px" class="center-block" />--%>
                                <a class="btn purple fancybox" href="<%#Eval("ImageURL")%>"><i class="fa fa-picture-o" aria-hidden="true"> ดูรูปภาพ</i></a>
                                    <td style="width:10%">
                                        <asp:LinkButton ID="Edit_LinkButton" runat="server" CssClass="btn blue" Text="แก้ไข" CommandArgument='<%# Eval("IDProduct") %>' OnCommand="linkEdit"></asp:LinkButton>
                                        
                                        <a class="btn btn-warning" data-target='#myModalD-<%# Eval("IDProduct") %>' data-toggle="modal">ลบ</a>
                                        
                                                <div class="modal fade" id="myModalD-<%# Eval("IDProduct") %>" role="dialog">
                                                        <div class="modal-dialog">
                                                          <div class="modal-content">
                                                            <div class="modal-header">
                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                             <h4>ยืนยันการลบ</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <asp:LinkButton ID="Delete_LinkButton" runat="server" CssClass="btn yellow" Text="ยืนยัน" OnCommand="linkDelete" CommandArgument='<%# Eval("IDProduct") %>'></asp:LinkButton>
                                                                 <button type="button" class="btn btn-default" data-dismiss="modal">ยกเลิก</button>
                                                            </div>
                                                          </div>
                                                        </div>
                                                      </div>
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

