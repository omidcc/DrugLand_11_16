<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DepartmentInfo.aspx.cs" Inherits="Balancika.DepartmentInfo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">

    <h1>Department Information</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $(document).ready(function () {
            $('#DepartmentTable').DataTable({
                "paging": true,
                "lengthChange": true,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": false,
                "scrollX": true
            });
            $("#form1").validate({
                
                rules: {

                    '<%=txtDepartmentName.UniqueID%>': {
                        required: true,
                        minlength: 3

                    }
                  
                },
                messages: {

                    '<%=txtDepartmentName.UniqueID%>': {
                        required: "Please Enter Department Name",
                        minlength: "Minimum Length should be 3"

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
                    <h3 class="box-title">Add /Edit Department Information</h3>
                </div>
                <div class="box-body">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtDepartmentName" class="col-sm-4 control-label">Department Name</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" width="60px" id="txtDepartmentName" name="txtDepartmentName" placeholder="Name" runat="server" clientidmode="Static" />
                            </div>
                        </div>
                    </div>
                   
                    <div class="clearfix"></div>

                   <%-- <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtPhoneNo" class="col-sm-4 control-label">Phone Number</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtPhoneNo" id="txtPhoneNo" placeholder="Update By" runat="server" />
                            </div>

                        </div>
                    </div>--%>
                 <%-- <div class="col-md-6">
                        <div class="form-group ">
                            <label for="RadDatePicker1" class="col-sm-4 control-label">Update Date</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                
                                
                            </div>

                        </div>
                    </div>--%>
                    <div class="clearfix"></div>

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
                    <div class="clearfix"></div>



                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Department Information" OnClientClick="return validate()" onclick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server"  type="button" value="Clear Information" OnServerClick="btnClear_Click"/>
                           
                        </div>
                    </div>
                </div>

            </div>

           
              <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Department Information List</h3>
                </div>
                <div class="box-body">
                    <div id="divDepartmentTable" class="dataTables_wrapper form-inline dt-bootstrap">
                        <div class="row">
                            <div class="col-sm-6"></div>
                            <div class="col-sm-6"></div>
                        </div>
                       <div class="box-body">
                            <div class="col-sm-12">
                                <table id="DepartmentTable" class="table table-bordered table-hover dataTable">
                                    <thead>
                                        <tr role="row">
                                            <th>Department Name</th>
                                            <th>Parent Department</th>
                                            <th>Is Active</th>
                                            <th>Update By</th>
                                            <th>Update Date</th>
                                        </tr>
                                    </thead>
                                    <tbody id="DepartmentTableBody" runat="server">
                                    
                                    </tbody>
                                    <tfoot>
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
