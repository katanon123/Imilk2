<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="ManageAccount.aspx.cs" Inherits="ManageAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TITLE_BREADCRUMBContentPlaceHolder" Runat="Server">
    <ul class="page-breadcrumb breadcrumb">
        <li>
            <i class="fa fa-home"></i><a href="ManageAccount.aspx">จัดการบัญชีร้าน</a>
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
     <div class="col-lg-12" runat="server" id="account">
        <div class="portlet box yellow">
            <div class="portlet-title">
                <div class="caption">
                    บัญชีธนาคาร
                </div>
                 <div class="actions">
                    <div class="btn-group">   
                           
                                <asp:Button ID="AddButton" runat="server" Text="+" CssClass="btn green" OnClick="AddButton_Click"  />
                        
                       </div>
                       </div>
            </div>
            
            <div class="portlet-body">
        <table class="table table-striped table-bordered table-hover table-full-width" style="text-align:center">
            <thead>
            <tr>

                <%--<th class="text-center"><strong>ลำดับ</strong></th>--%>
                <th class="text-center"><strong>ชื่อบัญชี</strong></th>
                <th class="text-center"><strong>เลขที่บัญชี</strong></th>
                <th class="text-center"><strong>ธนาคาร</strong></th>
                <th class="text-center"><strong>สาขา</strong></th>
                <th class="text-center"><strong>จัดการ</strong></th>
             </tr>
            </thead>
            <tbody>

        <asp:Repeater ID="detailaccount" runat="server">
         <ItemTemplate>
            <tr>
                <%--<td><asp:Label ID="No_label" runat="server" Text='<%#Container.ItemIndex + 1 %>'></asp:Label></td>--%>
                <td><%# Eval("Name") %></td>
                <td><%# Eval("Idname") %></td>
                <td><%# Eval("Bank") %></td>
                <td><%# Eval("Sector") %></td>
                
                <td>

                    <asp:LinkButton ID="buttonedit" runat="server" CssClass="btn yellow" CommandArgument='<%# Eval("Id") %>' OnCommand="buttonedit_Command" >แก้ไข</asp:LinkButton>
                 
                    <a class="btn red" data-target='#myModalD-<%# Eval("Id") %>' data-toggle="modal">ลบ</a>
                                        
                                                <div class="modal fade" id="myModalD-<%# Eval("Id") %>" role="dialog">
                                                        <div class="modal-dialog">
                                                          <div class="modal-content">
                                                            <div class="modal-header">
                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                             <h4>ยืนยันการลบ</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <asp:LinkButton ID="Delete_LinkButton" runat="server" CssClass="btn yellow" Text="ยืนยัน" OnCommand="Delete_LinkButton_Command" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                                 <button type="button" class="btn btn-default" data-dismiss="modal">ยกเลิก</button>
                                                            </div>
                                                          </div>
                                                        </div>
                                                      </div>

                </td>
            </tr>
         </ItemTemplate>
        </asp:Repeater>
        </tbody></table>
           

            </div>
        </div>
    </div>






    




      <div class="col-lg-12" runat="server" id="addaccount" Visible="false">
        <div class="portlet box yellow">
            <div class="portlet-title">
                <div class="caption">
                    เพิ่มบัญชีธนาคาร
                </div>
                 <div class="actions">
                    <div class="btn-group">   
                        
                       </div>
                       </div>
            </div>
            <div class="portlet-body">
                <div class="form-body">

                    <div class="form-group">
                        <asp:Label runat="server" ID="Idaccount" Visible="false"></asp:Label>
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ชื่อบัญชี : </strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="Name_account" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Name_account" runat="server" CssClass="form-control" placeholder="กรุณากรอกชื่อบัญชี"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>เลขที่บัญชี :</strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="No_account" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล"></asp:RequiredFieldValidator>
             <asp:TextBox ID="No_account" runat="server" CssClass="form-control" placeholder="กรุณากรอกเลขที่บัญชี" onkeyup="value=value.replace(/[^0-9,'.']/g-'')"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ธนาคาร :</strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="Name_bank" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Name_bank" runat="server" CssClass="form-control" placeholder="กรุณากรอกชื่อธนาคาร" ></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>สาขา :</strong></p>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="Sector_bank" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Sector_bank" runat="server" CssClass="form-control" placeholder="กรุณากรอกสาขา"></asp:TextBox>
                    </div>

                    <div class="form-group;" style="text-align: center;">
                        <asp:Button ID="Confirm_Button" runat="server" CssClass="btn green" Text="ยืนยัน" OnClick="Confirm_Button_Click" />
                        <asp:Button ID="Cancel_Button" runat="server" CssClass="btn grey" Text="ยกเลิก" OnClientClick="this.form.reset();return false;"/>
                    </div>
                </div>
            </div>
            </div>
      </div>












    <div class="col-lg-12" runat="server" id="editform" Visible="false">
        <div class="portlet box yellow">
            <div class="portlet-title">
                <div class="caption">
                    แก้ไขบัญชีธนาคาร
                </div>
                 <div class="actions">
                    <div class="btn-group">   
                        
                       </div>
                       </div>
            </div>
            <div class="portlet-body">
                <div class="form-body">

                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ชื่อบัญชี : </strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="Name_account" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="editname" runat="server" CssClass="form-control" placeholder="กรุณากรอกชื่อบัญชี"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>เลขที่บัญชี :</strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="No_account" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="editno" runat="server" CssClass="form-control" placeholder="กรุณากรอกเลขที่บัญชี" onkeyup="value=value.replace(/[^0-9,'.']/g,'')"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>ธนาคาร :</strong></p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ControlToValidate="Name_bank" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="editbank" runat="server" CssClass="form-control" placeholder="กรุณากรอกชื่อธนาคาร" ></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <p><strong>สาขา :</strong></p>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="Sector_bank" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="editbran" runat="server" CssClass="form-control" placeholder="กรุณากรอกสาขา"></asp:TextBox>
                    </div>

                    <div class="form-group;" style="text-align: center;">
                        <asp:Button ID="editbutton" runat="server" CssClass="btn green" Text="ยืนยัน" OnClick="editbutton_Click" />
                        <asp:Button ID="Button2" runat="server" CssClass="btn grey" Text="ยกเลิก" OnClientClick="this.form.reset();return false;"/>
                    </div>
                </div>
            </div>
            </div>
      </div>
</asp:Content>

