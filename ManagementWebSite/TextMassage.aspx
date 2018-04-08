<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="TextMassage.aspx.cs" Inherits="TextMassage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" Runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="  TextMessage.aspx">Text Message</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CONTENTContentPlaceHolder" Runat="Server">
     <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
        <div class="alert alert-success">
            <p style="text-align: right">
                <asp:LinkButton ID="SuccessLinkButton" runat="server" OnClick="SuccessLinkButton_Click">X</asp:LinkButton>
            </p>
            <p><strong>Success!</strong></p>
            <asp:Label ID="SuccessLabel" runat="server"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
        <div class="alert alert-danger">
            <p style="text-align: right">
                <asp:LinkButton ID="ErrrorLinkButton" runat="server" OnClick="ErrorLinkButton_Click">X</asp:LinkButton>
            </p>
            <p><strong>Error!</strong></p>
            <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
        </div>
    </asp:Panel>
  <asp:Panel ID="AddPanel" runat="server" Visible="false">
    <div class="col-lg-12">
        <div class="portlet box red">
            <div class="portlet-title">
                <div class="caption">
                  Text Message
                </div>
            </div>
            <div class="portlet-body form">
                 
                <div class="form-body">

                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ชื่อ : </strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="Name_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Name_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาไทย"></asp:TextBox>
                        <br />
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="NameEN_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="NameEN_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาอังกฤษ"></asp:TextBox>
                        <%--  <br />
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="NameCH_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="NameCH_TextBox" runat="server" CssClass="form-control" placeholder="Enter Name  CN"></asp:TextBox>--%>
                    </div>
                    <div class="form-group;" style="text-align: center;">
                        <asp:Button ID="Confirm_Button" runat="server" CssClass="btn purple" Text="ตกลง"  OnClick="Confirm_Button_Click" />
                        <asp:Button ID="Cancel_Button" runat="server" CssClass="btn grey" Text="ยกเลิก" OnClientClick="this.form.reset();return false;"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
 </asp:Panel>
    <asp:Panel ID ="ShowPanel" runat="server">
 <div class="col-lg-12">
            <div class="portlet box yellow">
                <div class="portlet-title">
                    <div class="caption">
                         Text Message
                    </div>
                 <div class="actions">
                    <div class="btn-group">   
                           
                                <asp:Button ID="AddButton" runat="server" Text="+" CssClass="btn green" OnClick="AddButton_Click"  />
                        
                       </div>
                       </div>
                </div>
            <div class="portlet-body">
                <table class="table table-striped table-bordered table-hover table-full-width" id="sample_2">
                    <thead>
                        <tr>
                            <th><strong>ลำดับ.</strong></th>
                             <%--<th><strong>ID</strong></th>--%>
                            <th><strong>ไทย</strong></th>
                            <th><strong>อังกฤษ</strong></th>
                              <%--  <th><strong>Remark</strong></th>--%>
                            <th><strong>จัดการ</strong></th>
                        </tr>
                    </thead>
                    
                    <tbody>
                        <asp:Repeater ID="TicketOrderRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    
                                    <td style="width: 90px"><%# Container.ItemIndex + 1 %>
                                      <%-- <td style="width: 200px">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Id") %>'  ForeColor="#ff9900" Visible="true"></asp:Label></td>--%>
                                    <td style="width: 250px"><asp:Label ID="Time_Label" runat="server" Text='<%# Eval("NameTH") %>' ></asp:Label></td>
                                    <td style="width: 250px"><asp:Label ID="TicketCode_Label" runat="server" Text='<%# Eval("NameEN") %>' ></asp:Label></td>
                                      
                                    <td>
                                        <asp:LinkButton ID="Edit_Button" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="linkEdit" Text="แก้ไข" CssClass="btn blue"></asp:LinkButton>
                                        
                                        
                                        
                                        <a class="btn btn-warning" data-target='#myModalD-<%# Eval("Id") %>' data-toggle="modal">ลบ</a>
                                        
                                                <div class="modal fade" id="myModalD-<%# Eval("Id") %>" role="dialog">
                                                        <div class="modal-dialog">
                                                          <div class="modal-content">
                                                            <div class="modal-header">
                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                             <h4>ยืนยันการลบ</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                 <asp:LinkButton ID="Delete_Button" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="linkDelete" Text="ยืนยัน"  CssClass="btn yellow"></asp:LinkButton>
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
    </asp:Panel>
     <asp:Panel ID="EditPanel" runat="server" Visible="false">
    <div class="col-lg-12">
        <div class="portlet box red">
            <div class="portlet-title">
                <div class="caption">
                  Text Message
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-body">

                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ชื่อ : </strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="EditName_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="EditName_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาไทย"></asp:TextBox>
                        <br />
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="EditNameEN_TextBox" Display="Dynamic" ErrorMessage="กรุณากรอกข้อความ"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="EditNameEN_TextBox" runat="server" CssClass="form-control" placeholder="กรุณากรอกข้อมูลภาษาอังกฤษ"></asp:TextBox>
                       
                    </div> 
                      <div class="form-group;" style="text-align: center;">
                         <asp:Button ID="Button1" runat="server" CssClass="btn purple" Text="ตกลง"  ValidationGroup="3" OnClick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server" CssClass="btn grey" Text="ยกเลิก" OnClientClick="this.form.reset();return false;" />
                          </div>
                </div>
            </div>
        </div>
    </div>
 </asp:Panel>
</asp:Content>

