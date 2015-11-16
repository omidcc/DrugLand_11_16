<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChartOfAccountGroupInfo.aspx.cs" Inherits="Balancika.ChartOfAccountGroupInfo" %>
<%@ Register TagPrefix="telerik1" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <script>

        $(document).ready(function () {
            $('#coaTable').DataTable({
                "paging": true,
                "lengthChange": true,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": true,
                "scrollX": true
            });
            $("#form1").validate({

                rules: {

                    '<%=txtGroupName.UniqueID%>': {
                        required: true


                    }


                },
                messages: {

                    '<%=txtGroupName.UniqueID%>': {
                        required: "Please Enter Group Name"


                    }
                   



                }
            });

        });
    </script>

    <form id="form1" runat="server">
        <telerik1:RadScriptManager ID="RadScriptManager1" runat="server"></telerik1:RadScriptManager>
        <section class="form-horizontal">
            <div class="box">

                <div class="box-header with-border">
                    <h3 class="box-title">Add /Edit COA Group</h3>
                </div>
                <div class="box-body">
                   
                    
                    <div class="clearfix"></div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtGroupName" class="col-sm-4 control-label">Group Name</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtGroupName" id="txtGroupName" placeholder="Group Name" runat="server" />
                            </div>

                        </div>
                    </div>


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
                            <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Chart of Account Group" OnClick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                        </div>
                    </div>
                </div>

            </div>
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title"> COA Groups</h3>
                </div>
                <div class="box-body">
                    <div id="divCompanyTable" class="dataTables_wrapper form-inline dt-bootstrap">
                        <div class="row">
                            <div class="col-sm-6"></div>
                            <div class="col-sm-6"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <table id="coaTable" class="table table-bordered table-hover dataTable">
                                    <thead>
                                        <tr role="row">
                                            <th>Group Name</th>
                                            <th>Parent Group</th>
                                       
                                             <th>Is Active</th>
                                            <th>Update By</th>
                                            <th>Update Date</th>

                                            <th>Company</th>
                                           
                                           
                                        </tr>
                                    </thead>
                                    <div id="coaTableBody" runat="server">
                                    </div>
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
