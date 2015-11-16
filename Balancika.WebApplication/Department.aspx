<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="IndentApplicationManagement.Department" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>DrugLand|Comapany</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
    <link href="Content/DataTables/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/iCheck/flat/blue.css">
    <!-- Morris chart -->
    <link rel="stylesheet" href="plugins/morris/morris.css">
    <!-- jvectormap -->
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css">
    <!-- Date Picker -->
    <link rel="stylesheet" href="plugins/datepicker/datepicker3.css">
    <!-- Daterange picker -->
    <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker-bs3.css">
    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
<script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
<![endif]-->
    <link href="Kendo/styles/kendo.rtl.css" rel="stylesheet" />
    <link href="Kendo/styles/kendo.common.min.css" rel="stylesheet" />
    <link href="Kendo/styles/kendo.default.min.css" rel="stylesheet" />
    <link href="Kendo/styles/kendo.mobile.all.min.css" rel="stylesheet" />
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form runat="server" class="form-group" role="form">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

        <div class="wrapper">
            <header class="main-header">
                <a href="index2.html" class="logo">
                    <span class="logo-mini"><b>A</b>LT</span>
                    <span class="logo-lg"><b>DrugLand</b></span>
                </a>
                <nav class="navbar navbar-static-top" role="navigation">
                    <!-- Sidebar toggle button-->
                    <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
                        <span class="sr-only">Toggle navigation</span>
                    </a>
                    <div class="navbar-custom-menu">
                        <ul class="nav navbar-nav">
                            <!-- Messages: style can be found in dropdown.less-->
                            <li class="dropdown messages-menu"></li>
                            <!-- Notifications: style can be found in dropdown.less -->
                            <li class="dropdown notifications-menu"></li>
                            <!-- Tasks: style can be found in dropdown.less -->
                            <li class="dropdown tasks-menu"></li>
                            <!-- User Account: style can be found in dropdown.less -->
                            <li class="dropdown user user-menu">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                    <img src="dist/img/user2-160x160.jpg" class="user-image" alt="User Image">
                                    <span class="hidden-xs">DrugLand</span>
                                </a>
                                <ul class="dropdown-menu">
                                    <!-- User image -->

                                    <!-- Menu Body -->

                                    <!-- Menu Footer-->

                                </ul>
                            </li>
                            <!-- Control Sidebar Toggle Button -->

                        </ul>
                    </div>
                </nav>
            </header>
            <!-- Left side column. contains the logo and sidebar -->
            <aside class="main-sidebar">
                <!-- sidebar: style can be found in sidebar.less -->
                <section class="sidebar">
                    <!-- Sidebar user panel -->
                    <div class="user-panel">
                        <div class="pull-left image">
                            <img src="dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">
                        </div>
                        <div class="pull-left info">
                            <p>DrugLand</p>
                            <a href="#"><i class="fa fa-circle text-success"></i>Indenting Management</a>
                        </div>
                    </div>
                    <!-- search form -->
                    <form action="#" method="get" class="sidebar-form">
                        <div class="input-group">
                            <input type="text" name="q" class="form-control" placeholder="Search...">
                            <span class="input-group-btn">
                                <button type="submit" name="search" id="search-btn" class="btn btn-flat"><i class="fa fa-search"></i></button>
                            </span>
                        </div>
                    </form>
                    <!-- /.search form -->
                    <!-- sidebar menu: : style can be found in sidebar.less -->
                    <ul class="sidebar-menu">
                        <li class="header"><b>Indenting Menu</b></li>
                        <li class="active treeview">
                            <a href="#">
                                <i class="fa fa-dashboard"></i><span>Dashboard</span> <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li class="active"><a href="index.html"><i class="fa fa-circle-o"></i>Dashboard v1</a></li>
                                <li><a href="index2.html"><i class="fa fa-circle-o"></i>Dashboard v2</a></li>
                            </ul>
                        </li>
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-files-o"></i>
                                <span>Layout Options</span>
                                <span class="label label-primary pull-right">4</span>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="pages/layout/top-nav.html"><i class="fa fa-circle-o"></i>Top Navigation</a></li>
                                <li><a href="pages/layout/boxed.html"><i class="fa fa-circle-o"></i>Boxed</a></li>
                                <li><a href="pages/layout/fixed.html"><i class="fa fa-circle-o"></i>Fixed</a></li>
                                <li><a href="pages/layout/collapsed-sidebar.html"><i class="fa fa-circle-o"></i>Collapsed Sidebar</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="pages/widgets.html">
                                <i class="fa fa-th"></i><span>Widgets</span> <small class="label pull-right bg-green">new</small>
                            </a>
                        </li>
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-pie-chart"></i>
                                <span>Charts</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="pages/charts/chartjs.html"><i class="fa fa-circle-o"></i>ChartJS</a></li>
                                <li><a href="pages/charts/morris.html"><i class="fa fa-circle-o"></i>Morris</a></li>
                                <li><a href="pages/charts/flot.html"><i class="fa fa-circle-o"></i>Flot</a></li>
                                <li><a href="pages/charts/inline.html"><i class="fa fa-circle-o"></i>Inline charts</a></li>
                            </ul>
                        </li>
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-laptop"></i>
                                <span>UI Elements</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="pages/UI/general.html"><i class="fa fa-circle-o"></i>General</a></li>
                                <li><a href="pages/UI/icons.html"><i class="fa fa-circle-o"></i>Icons</a></li>
                                <li><a href="pages/UI/buttons.html"><i class="fa fa-circle-o"></i>Buttons</a></li>
                                <li><a href="pages/UI/sliders.html"><i class="fa fa-circle-o"></i>Sliders</a></li>
                                <li><a href="pages/UI/timeline.html"><i class="fa fa-circle-o"></i>Timeline</a></li>
                                <li><a href="pages/UI/modals.html"><i class="fa fa-circle-o"></i>Modals</a></li>
                            </ul>
                        </li>
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-edit"></i><span>Forms</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="pages/forms/general.html"><i class="fa fa-circle-o"></i>General Elements</a></li>
                                <li><a href="pages/forms/advanced.html"><i class="fa fa-circle-o"></i>Advanced Elements</a></li>
                                <li><a href="pages/forms/editors.html"><i class="fa fa-circle-o"></i>Editors</a></li>
                            </ul>
                        </li>
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-table"></i><span>Tables</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="pages/tables/simple.html"><i class="fa fa-circle-o"></i>Simple tables</a></li>
                                <li><a href="pages/tables/data.html"><i class="fa fa-circle-o"></i>Data tables</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="pages/calendar.html">
                                <i class="fa fa-calendar"></i><span>Calendar</span>
                                <small class="label pull-right bg-red">3</small>
                            </a>
                        </li>
                        <li>
                            <a href="pages/mailbox/mailbox.html">
                                <i class="fa fa-envelope"></i><span>Mailbox</span>
                                <small class="label pull-right bg-yellow">12</small>
                            </a>
                        </li>
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-folder"></i><span>Examples</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="pages/examples/invoice.html"><i class="fa fa-circle-o"></i>Invoice</a></li>
                                <li><a href="pages/examples/profile.html"><i class="fa fa-circle-o"></i>Profile</a></li>
                                <li><a href="pages/examples/login.html"><i class="fa fa-circle-o"></i>Login</a></li>
                                <li><a href="pages/examples/register.html"><i class="fa fa-circle-o"></i>Register</a></li>
                                <li><a href="pages/examples/lockscreen.html"><i class="fa fa-circle-o"></i>Lockscreen</a></li>
                                <li><a href="pages/examples/404.html"><i class="fa fa-circle-o"></i>404 Error</a></li>
                                <li><a href="pages/examples/500.html"><i class="fa fa-circle-o"></i>500 Error</a></li>
                                <li><a href="pages/examples/blank.html"><i class="fa fa-circle-o"></i>Blank Page</a></li>
                            </ul>
                        </li>
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-share"></i><span>Multilevel</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="#"><i class="fa fa-circle-o"></i>Level One</a></li>
                                <li>
                                    <a href="#"><i class="fa fa-circle-o"></i>Level One <i class="fa fa-angle-left pull-right"></i></a>
                                    <ul class="treeview-menu">
                                        <li><a href="#"><i class="fa fa-circle-o"></i>Level Two</a></li>
                                        <li>
                                            <a href="#"><i class="fa fa-circle-o"></i>Level Two <i class="fa fa-angle-left pull-right"></i></a>
                                            <ul class="treeview-menu">
                                                <li><a href="#"><i class="fa fa-circle-o"></i>Level Three</a></li>
                                                <li><a href="#"><i class="fa fa-circle-o"></i>Level Three</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li><a href="#"><i class="fa fa-circle-o"></i>Level One</a></li>
                            </ul>
                        </li>
                        <li><a href="documentation/index.html"><i class="fa fa-book"></i><span>Documentation</span></a></li>
                        <li class="header">LABELS</li>
                        <li><a href="#"><i class="fa fa-circle-o text-red"></i><span>Important</span></a></li>
                        <li><a href="#"><i class="fa fa-circle-o text-yellow"></i><span>Warning</span></a></li>
                        <li><a href="#"><i class="fa fa-circle-o text-aqua"></i><span>Information</span></a></li>
                    </ul>
                </section>
                <!-- /.sidebar -->
            </aside>
            <!-- Content Wrapper. Contains page content -->
            <div class="content-wrapper">
                <div class="container form-horizontal">

                    <div>
                        <h1><strong>Add Department Information</strong></h1>
                        <br />
                        <br />
                        <br />
                    </div>



                    <div class="form-group responsive-bootstrap-section">
                        <label for="departmentNameTextBox" class="col-sm-2 control-label">Department Name</label>
                        <div class="col-xs-4">
                            <input type="text" class="form-control" width="60px" id="departmentNameTextBox" placeholder="Name" runat="server" />
                        </div>

                    </div>
                    <div class="form-group responsive-bootstrap-section">
                        <label for="parentDepartmentID" class="col-sm-2 control-label">Parent Department</label>
                        <div class="col-xs-4">
                            <input type="text" class="form-control" width="60px" id="parentDepartmentID" placeholder="Address" runat="server" />
                        </div>

                    </div>
                    <div class="form-group ">
                        <label for="updateByTextBox" class="col-sm-2 control-label">Update By</label>
                        <div class="col-xs-4">
                            <input type="text" class="form-control" width="60px" id="updateByTextBox" placeholder="Phone Number" runat="server" />
                        </div>

                    </div>

                    <div class="form-group">
                        <label for="datetimepicker" class="col-sm-2 control-label">Update Date</label>
                        <div class="col-lg-4">
                            <input data-provide="datepicker" class="form-control" width="60px" id="datetimepicker" placeholder="" runat="server" clientidmode="static" />
                        </div>

                    </div>
                    <div class="form-group">
                        <label for="RadDropDownList1" class="col-sm-2 control-label">Company Name</label>
                        <div class="col-lg-4">
                             
                            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                                <telerik:RadDropDownList ID="RadDropDownList1"
                                    CssClass="form-control"
                                    runat="server" padding-left="20px"
                                   Width="100%"
                                    AutoPostBack="true"
                                    DefaultMessage="Select Company"
                                    OnItemSelected="RadDropDownList1_ItemSelected"
                                    OnSelectedIndexChanged="RadDropDownList1_SelectedIndexChanged">
                                </telerik:RadDropDownList>

                            </telerik:RadAjaxPanel>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" id="isActiveCheckBox" runat="server" value="false" />
                                    <strong>Is Active</strong>
                                </label>
                            </div>
                        </div>


                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <input class="btn btn-success" runat="server" onserverclick="btnSave_Click" type="button" value="Save Company Information" />
                            <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                        </div>
                    </div>




                    <div>
                        <h1>Company Information Details</h1>
                        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>Company Name</th>
                                    <th>Address</th>
                                    <th>Phone Number</th>
                                    <th>Email</th>
                                    <th>Web Address</th>
                                    <th>Logo Path</th>
                                    <th>Update By</th>
                                    <th>Update Date</th>
                                    <th>Is Active</th>
                                </tr>
                            </thead>

                            <tfoot>
                                <tr>
                                    <th>Company Name</th>
                                    <th>Address</th>
                                    <th>Phone Number</th>
                                    <th>Email</th>
                                    <th>Web Address</th>
                                    <th>Logo Path</th>
                                    <th>Update By</th>
                                    <th>Update Date</th>
                                    <th>Is Active</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>



            </div>

            <footer class="main-footer">
                <div class="pull-right hidden-xs">
                    <b>Version</b> 2.3.0
                </div>
                <strong>Copyright &copy; 2015 <a href="http://balancika.com">Balancika Outsourcing</a>.</strong> All rights reserved.
            </footer>
            <!-- Control Sidebar -->
            <aside class="control-sidebar control-sidebar-dark">
                <!-- Create the tabs -->
                <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
                    <li><a href="#control-sidebar-home-tab" data-toggle="tab"><i class="fa fa-home"></i></a></li>
                    <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i class="fa fa-gears"></i></a></li>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content">
                    <!-- Home tab content -->
                    <div class="tab-pane" id="control-sidebar-home-tab">
                        <h3 class="control-sidebar-heading">Recent Activity</h3>
                        <ul class="control-sidebar-menu">
                            <li>
                                <a href="javascript::;">
                                    <i class="menu-icon fa fa-birthday-cake bg-red"></i>
                                    <div class="menu-info">
                                        <h4 class="control-sidebar-subheading">Langdon's Birthday</h4>
                                        <p>Will be 23 on April 24th</p>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript::;">
                                    <i class="menu-icon fa fa-user bg-yellow"></i>
                                    <div class="menu-info">
                                        <h4 class="control-sidebar-subheading">Frodo Updated His Profile</h4>
                                        <p>New phone +1(800)555-1234</p>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript::;">
                                    <i class="menu-icon fa fa-envelope-o bg-light-blue"></i>
                                    <div class="menu-info">
                                        <h4 class="control-sidebar-subheading">Nora Joined Mailing List</h4>
                                        <p>nora@example.com</p>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript::;">
                                    <i class="menu-icon fa fa-file-code-o bg-green"></i>
                                    <div class="menu-info">
                                        <h4 class="control-sidebar-subheading">Cron Job 254 Executed</h4>
                                        <p>Execution time 5 seconds</p>
                                    </div>
                                </a>
                            </li>
                        </ul>
                        <!-- /.control-sidebar-menu -->
                        <h3 class="control-sidebar-heading">Tasks Progress</h3>
                        <ul class="control-sidebar-menu">
                            <li>
                                <a href="javascript::;">
                                    <h4 class="control-sidebar-subheading">Custom Template Design
                                    <span class="label label-danger pull-right">70%</span>
                                    </h4>
                                    <div class="progress progress-xxs">
                                        <div class="progress-bar progress-bar-danger" style="width: 70%"></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript::;">
                                    <h4 class="control-sidebar-subheading">Update Resume
                                    <span class="label label-success pull-right">95%</span>
                                    </h4>
                                    <div class="progress progress-xxs">
                                        <div class="progress-bar progress-bar-success" style="width: 95%"></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript::;">
                                    <h4 class="control-sidebar-subheading">Laravel Integration
                                    <span class="label label-warning pull-right">50%</span>
                                    </h4>
                                    <div class="progress progress-xxs">
                                        <div class="progress-bar progress-bar-warning" style="width: 50%"></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript::;">
                                    <h4 class="control-sidebar-subheading">Back End Framework
                                    <span class="label label-primary pull-right">68%</span>
                                    </h4>
                                    <div class="progress progress-xxs">
                                        <div class="progress-bar progress-bar-primary" style="width: 68%"></div>
                                    </div>
                                </a>
                            </li>
                        </ul>
                        <!-- /.control-sidebar-menu -->
                    </div>
                    <!-- /.tab-pane -->
                    <!-- Stats tab content -->
                    <div class="tab-pane" id="control-sidebar-stats-tab">Stats Tab Content</div>
                    <!-- /.tab-pane -->
                    <!-- Settings tab content -->
                    <div class="tab-pane" id="control-sidebar-settings-tab">
                        <form method="post">
                            <h3 class="control-sidebar-heading">General Settings</h3>
                            <div class="form-group">
                                <label class="control-sidebar-subheading">
                                    Report panel usage
                                <input type="checkbox" class="pull-right" checked>
                                </label>
                                <p>
                                    Some information about this general settings option
                                </p>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label class="control-sidebar-subheading">
                                    Allow mail redirect
                                <input type="checkbox" class="pull-right" checked>
                                </label>
                                <p>
                                    Other sets of options are available
                                </p>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label class="control-sidebar-subheading">
                                    Expose author name in posts
                                <input type="checkbox" class="pull-right" checked>
                                </label>
                                <p>
                                    Allow the user to show his name in blog posts
                                </p>
                            </div>
                            <!-- /.form-group -->
                            <h3 class="control-sidebar-heading">Chat Settings</h3>
                            <div class="form-group">
                                <label class="control-sidebar-subheading">
                                    Show me as online
                                <input type="checkbox" class="pull-right" checked>
                                </label>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label class="control-sidebar-subheading">
                                    Turn off notifications
                                <input type="checkbox" class="pull-right">
                                </label>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label class="control-sidebar-subheading">
                                    Delete chat history
                                <a href="javascript::;" class="text-red pull-right"><i class="fa fa-trash-o"></i></a>
                                </label>
                            </div>
                            <!-- /.form-group -->
                        </form>
                    </div>
                    <!-- /.tab-pane -->
                </div>
            </aside>
            <!-- /.control-sidebar -->
            <!-- Add the sidebar's background. This div must be placed
immediately after the control sidebar -->
            <div class="control-sidebar-bg"></div>
        </div>

        <!-- ./wrapper -->
        <!-- jQuery 2.1.4 -->
        <script src="plugins/jQuery/jQuery-2.1.4.min.js"></script>
        <!-- jQuery UI 1.11.4 -->
        <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
        <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
        <script>
            $.widget.bridge('uibutton', $.ui.button);
        </script>
        <!-- Bootstrap 3.3.5 -->
        <script src="bootstrap/js/bootstrap.min.js"></script>
        <script src="Scripts/DataTables/jquery.dataTables.min.js"></script>
        <script src="Scripts/DataTables/dataTables.bootstrap.min.js"></script>
        <!-- Morris.js charts -->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
        <script src="plugins/morris/morris.min.js"></script>
        <!-- Sparkline -->
        <script src="plugins/sparkline/jquery.sparkline.min.js"></script>
        <!-- jvectormap -->
        <script src="plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
        <script src="plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
        <!-- jQuery Knob Chart -->
        <script src="plugins/knob/jquery.knob.js"></script>
        <!-- daterangepicker -->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>
        <script src="plugins/daterangepicker/daterangepicker.js"></script>
        <!-- datepicker -->
        <script src="plugins/datepicker/bootstrap-datepicker.js"></script>
        <!-- Bootstrap WYSIHTML5 -->
        <script src="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
        <!-- Slimscroll -->
        <script src="plugins/slimScroll/jquery.slimscroll.min.js"></script>
        <!-- FastClick -->
        <script src="plugins/fastclick/fastclick.min.js"></script>
        <!-- AdminLTE App -->
        <script src="dist/js/app.min.js"></script>
        <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
        <script src="dist/js/pages/dashboard.js"></script>
        <!-- AdminLTE for demo purposes -->
        <script src="dist/js/demo.js"></script>
        <script src="Kendo/examples/content/shared/js/products.js"></script>


        <script>

            $(document).ready(function () {

                $("#divClass").formValidation();
                $('#example').DataTable();
            });

        </script>





    </form>
</body>
</html>




