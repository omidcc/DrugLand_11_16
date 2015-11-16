<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="Balancika.UserInfo" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $(document).ready(function () {
            $('#userInformationTable').DataTable({
                "paging": true,
                "lengthChange": true,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": true,
                "scrollX": true
            })

            $("#form1").validate({

                rules: {

                    '<%=txtUsername.UniqueID%>': {
                         required: true,
                       

                     },
                     '<%=txtPassword.UniqueID%>': {
                         required: true
                     },
                    
                     '<%=txtConfirmPassword.UniqueID%>': {
                            required: true,
                            equalTo: "#<%=txtPassword.ClientID%>"
                     }
              

                    



                 },
                 messages: {

                     '<%=txtUsername.UniqueID%>': {
                        required: "Please Enter Username",
                       

                    },
                    '<%=txtPassword.UniqueID%>': {
                        required: "Enter Password"
                    }
                    ,
                     '<%=txtConfirmPassword.UniqueID%>': {
                         required: "Confirm Password",
                         equalTo: "Password is not matching"
                     }
                     
                     


                }
            });
           

        });
    </script>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>


        <section class="form-horizontal">
            <div class="box">

                <div class="box-header with-border">
                    <h3 class="box-title">Add /Edit User Information</h3>
                </div>
                <div class="box-body">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtUsername" class="col-sm-4 control-label">Username</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" width="60px" id="txtUsername" name="txtUsername" placeholder="User Name" runat="server" clientidmode="Static" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtPassword" class="col-sm-4 control-label">Password</label>
                            <div class="col-xs-8">
                                <input type="password" class="form-control" width="60px" id="txtPassword" placeholder="Password" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                     <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtConfirmPassword" class="col-sm-4 control-label">Confirm Password</label>
                            <div class="col-xs-8">
                                <input type="password" class="form-control" width="60px" id="txtConfirmPassword" name="txtConfirmPassword" placeholder="Re-Enter Password" runat="server" />
                            </div>

                        </div>
                    </div>
                 

                   
                    <div class="clearfix"></div>
                   
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="CompanyNameDropDownList" class="col-sm-4 control-label">Company Name</label>
                            <div class="col-xs-8">
                             
                                
                                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                                    <telerik:RadDropDownList ID="CompanyNameDropDownList"
                                        Skin="Bootstrap"
                                        runat="server" padding-left="20px"
                                        Width="100%"
                                        AutoPostBack="true"
                                        DefaultMessage="Select Company Name"
                                      >
                                    </telerik:RadDropDownList>

                                </telerik:RadAjaxPanel>
                            </div>

                        </div>
                    </div>
                  
                    <div class="clearfix"></div>



                    <div class="col-md-6">
                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-8">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="chkIsActive" runat="server" value="false" />
                                        <strong>Is Active</strong>
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                   



                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save User Information" OnClientClick="return validate()" OnClick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server" type="button" value="Clear Information" onserverclick="btnClear_Click" />

                        </div>
                    </div>
                </div>

            </div>

            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">User List</h3>
                </div>
                <div class="box-body">
                    <div id="divUserTable" class="dataTables_wrapper form-inline dt-bootstrap">
                        <div class="row">
                            <div class="col-sm-6"></div>
                            <div class="col-sm-6"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <table id="userInformationTable" class="table table-bordered table-hover dataTable">
                                    <thead>
                                        <tr role="row">
                                            <th>Username</th>
                                            <th>Update By</th>
                                            <th>Update Date</th>
                                            <th>Company Name</th>
                                            <th>Is Active</th>

                                        </tr>
                                    </thead>
                                    <tbody id="userInformationTableBody" runat="server">
                                        </tbody>

                                    <tfoot>
                                      <tr role="row"></tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section>
    </form>

</asp:Content>
