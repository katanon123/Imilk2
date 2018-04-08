 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" EnableEventValidation="false" %>

<!DOCTYPE html>


<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Login</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />

    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="http://services.totiti.net/MetronicAdminTemplate/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="http://services.totiti.net/MetronicAdminTemplate/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="http://services.totiti.net/MetronicAdminTemplate/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link rel="stylesheet" type="text/css" href="http://services.totiti.net/MetronicAdminTemplate/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="http://services.totiti.net/MetronicAdminTemplate/plugins/select2/select2-metronic.css" />
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- BEGIN THEME STYLES -->
    <link href="http://services.totiti.net/MetronicAdminTemplate/css/style-metronic.css" rel="stylesheet" type="text/css" />
    <link href="http://services.totiti.net/MetronicAdminTemplate/css/style.css" rel="stylesheet" type="text/css" />
    <link href="http://services.totiti.net/MetronicAdminTemplate/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="http://services.totiti.net/MetronicAdminTemplate/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="http://services.totiti.net/MetronicAdminTemplate/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="http://services.totiti.net/MetronicAdminTemplate/css/pages/login.css" rel="stylesheet" type="text/css" />
    <link href="http://services.totiti.net/MetronicAdminTemplate/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- BEGIN BODY -->
<body class="login" runat="server">
    <form id="form1" runat="server">
        <!-- BEGIN LOGO -->
        <div class="logo">
            <a href="#">
                <img src="Image/innofood.png" alt="" width="10%" height="10%"/>
            </a>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content">
            <!-- BEGIN LOGIN FORM -->
            <form class="login-form" action="index.html" method="post">
                <h3 class="form-title">กรุณาเข้าสู่ระบบ</h3>
                <asp:Panel ID="NotificationPanel" runat="server" CssClass="notification">
                    <asp:Label ID="NotificationLabel" runat="server" Font-Size="16px" ForeColor="Red"></asp:Label>
                </asp:Panel>
                <br>
                <div class="alert alert-danger display-hide">
                    <button class="close" data-close="alert"></button>
                    <span>Enter any username and password.
                    </span>
                </div>
                <div class="form-group">
                    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                    <asp:Label ID="UsernameLabel" runat="server" Text="Username" CssClass="control-label visible-ie8 visible-ie9"></asp:Label>
                    <div class="input-icon">
                        <i class="fa fa-user"></i>
                        <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control placeholder-no-fix" autocomplete="off" placeholder="ชื่อผู้ใช้"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="PasswordLabel" runat="server" Text="Password" CssClass="control-label visible-ie8 visible-ie9"></asp:Label>
                    <div class="input-icon">
                        <i class="fa fa-lock"></i>
                        <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="form-control placeholder-no-fix" autocomplete="off" placeholder="รหัสผ่าน" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="form-actions">
                    <label class="checkbox">
                        <asp:CheckBox runat="server" ID="checkremember" />
                        จำรหัสผ่าน
                    </label>
                    <asp:Button ID="submitButton" runat="server" Text="เข้าสู่ระบบ" CssClass="btn green pull-right" OnClick="submitButton_Click1" />
                </div>
               <%-- <div class="create-account">
                    <p>
                        Don't have an account yet ?&nbsp;
                <asp:HyperLink ID="RegisterLink" runat="server" NavigateUrl="~/Register.aspx" CssClass="active" Style="text-decoration: none;" Text="Create an account"></asp:HyperLink>
                    </p>
                </div>--%>
            </form>
    <!-- END LOGIN FORM -->
    </div>
        <!-- END LOGIN -->
    <!-- BEGIN COPYRIGHT -->
    <div class="copyright">TOT IT Incubator
        2017© <a href="https://www.facebook.com/softwarenpru/" target="_blank">SoftWare Engneer</a>
    </div>
    <!-- END COPYRIGHT -->
    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    <!--[if lt IE 9]>
	<script src="http://services.totiti.net/MetronicAdminTemplate/plugins/respond.min.js"></script>
	<script src="http://services.totiti.net/MetronicAdminTemplate/plugins/excanvas.min.js"></script> 
	<![endif]-->
    <script src="http://services.totiti.net/MetronicAdminTemplate/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="http://services.totiti.net/MetronicAdminTemplate/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="http://services.totiti.net/MetronicAdminTemplate/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="http://services.totiti.net/MetronicAdminTemplate/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="http://services.totiti.net/MetronicAdminTemplate/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="http://services.totiti.net/MetronicAdminTemplate/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="http://services.totiti.net/MetronicAdminTemplate/plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="http://services.totiti.net/MetronicAdminTemplate/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="http://services.totiti.net/MetronicAdminTemplate/plugins/jquery-validation/dist/jquery.validate.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://services.totiti.net/MetronicAdminTemplate/plugins/select2/select2.min.js"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="http://services.totiti.net/MetronicAdminTemplate/scripts/core/app.js" type="text/javascript"></script>
    <script src="http://services.totiti.net/MetronicAdminTemplate/scripts/custom/login.js" type="text/javascript"></script>
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
