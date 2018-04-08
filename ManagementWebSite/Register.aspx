<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" enableEventValidation="false"%>

<!DOCTYPE html>

<!-- 
Template Name: Metronic - Responsive Admin Dashboard Template build with Twitter Bootstrap 3.1.1
Version: 2.0.2
Author: KeenThemes
Website: http://www.keenthemes.com/
Contact: support@keenthemes.com
Purchase: http://themeforest.net/item/metronic-responsive-admin-dashboard-template/4021469?ref=keenthemes
License: You must have a valid license purchased only from themeforest(the above link) in order to legally use the theme for your project.
-->
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Register</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />

    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2-metronic.css" />
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- BEGIN THEME STYLES -->
    <link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/css/pages/login.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- BEGIN BODY -->
<body class="login" runat="server">
    <form id="form1" runat="server">
        <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
            <div class="alert alert-success">
                <p style="text-align: right">
                    <asp:LinkButton ID="SuccessLinkButton" runat="server" OnClick="SuccessLinkButton_Click">X</asp:LinkButton>
                </p>
                <strong>Success! </strong>
                <asp:Label ID="SuccessLabel" runat="server" Text=""></asp:Label>
                
        </asp:Panel>
        <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
            <div class="alert alert-danger">
                <p style="text-align: right">
                    <asp:LinkButton ID="ErrorLinkButton" runat="server" OnClick="ErrorLinkButton_Click">X</asp:LinkButton>
                </p>
                <strong>Error! </strong>
                <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
                
            </div>
        </asp:Panel>


        <!-- BEGIN LOGO -->
        <div class="logo">
            <a href="Login.aspx">
                <img src="assets/img/icon_Restaurant.png" alt="" width="10%" height="10%"/>
            </a>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content">
            <!-- BEGIN REGISTRATION FORM -->
            <form class="register-form" action="index.html" method="post">
                <h3>Sign Up</h3>
                <p>
                    Enter your personal details below:
                </p>

                <div class="form-group">
                    <asp:Label ID="EmailLabel" runat="server" Text="Email" CssClass="control-label visible-ie8 visible-ie9"></asp:Label>
                    <div class="input-icon">
                        <i class="fa fa-font"></i>
                        <asp:TextBox ID="Email_TextBox" runat="server" CssClass="form-control placeholder-no-fix" placeholder="E-mail"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="***กรุณากรอกข้อมูล" ControlToValidate="Email_TextBox" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="PasswordLabel" runat="server" Text="Password" CssClass="control-label visible-ie8 visible-ie9"></asp:Label>
                    <div class="input-icon">
                        <i class="fa fa-font"></i>
                        <asp:TextBox ID="Password_TextBox" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="***กรุณากรอกข้อมูล" ControlToValidate="Password_TextBox" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="FirstnameLabel" runat="server" Text="Firstname" CssClass="control-label visible-ie8 visible-ie9"></asp:Label>
                    <div class="input-icon">
                        <i class="fa fa-font"></i>
                        <asp:TextBox ID="Firstname_TextBox" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Firstname"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="***กรุณากรอกข้อมูล" ControlToValidate="Firstname_TextBox" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="LastnameLabel" runat="server" Text="Lastname" CssClass="control-label visible-ie8 visible-ie9"></asp:Label>
                    <div class="input-icon">
                        <i class="fa fa-font"></i>
                        <asp:TextBox ID="Lastname_TextBox" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Lastname"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="***กรุณากรอกข้อมูล" ControlToValidate="Lastname_TextBox" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="MobilephoneLabel" runat="server" Text="Mobilephone" CssClass="control-label visible-ie8 visible-ie9"></asp:Label>
                    <div class="input-icon">
                        <i class="fa fa-font"></i>
                        <asp:TextBox ID="Mobilephone_TextBox" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Mobilephone" onkeyup="value=value.replace(/[^0-9,'.']/g,'')"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="***กรุณากรอกข้อมูล" ControlToValidate="Mobilephone_TextBox" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-actions">
                    <asp:Button ID="BackButton" runat="server" Text="Back" CssClass="btn red" OnClick="BackButton_Click" ValidationGroup="Back" />
                    <asp:Button ID="SignUpButton" runat="server" Text="Sign Up" CssClass="btn green pull-right" OnClick="SignUpButton_Click" />
                </div>
            </form>
            <!-- END REGISTRATION FORM -->
        </div>
        <!-- END LOGIN -->
        <!-- BEGIN COPYRIGHT -->
        <div class="copyright">
            2015 &copy; <a href="http://totiti.net" target="_blank">TOT IT Incubator</a>
        </div>
        <!-- END COPYRIGHT -->
        <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
        <!-- BEGIN CORE PLUGINS -->
        <!--[if lt IE 9]>
	<script src="assets/plugins/respond.min.js"></script>
	<script src="assets/plugins/excanvas.min.js"></script> 
	<![endif]-->
        <script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
        <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
        <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="assets/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
        <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
        <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="assets/plugins/jquery.cokie.min.js" type="text/javascript"></script>
        <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="assets/scripts/core/app.js" type="text/javascript"></script>
        <script src="assets/scripts/custom/login.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL SCRIPTS -->
        <script>
            jQuery(document).ready(function () {
                App.init();
                Login.init();
            });
        </script>
        <!-- END JAVASCRIPTS -->
    </form>
</body>
<!-- END BODY -->
</html>
