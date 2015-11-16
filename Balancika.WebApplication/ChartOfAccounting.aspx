<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChartOfAccounting.aspx.cs" Inherits="Balancika.ChartOfAccounting" %>

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

                    '<%=txtChartOfAccountCode.UniqueID%>': {
                        required: true


                    },
                    '<%=txtChartOfAccountTitle.UniqueID%>': {
                        required: true
                    }

                    




                },
                messages: {

                    '<%=txtChartOfAccountCode.UniqueID%>': {
                        required: "Please Enter Code",


                    },
                    '<%=txtChartOfAccountTitle.UniqueID%>': {
                        required: "Enter Parent BankInfo Name"
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
                    <h3 class="box-title">Add /Edit Chart of Accounts</h3>
                </div>
                <div class="box-body">
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="chartOfAccountTypeDropDownList" class="col-sm-4 control-label">Account Type</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik1:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                                    <telerik1:RadDropDownList ID="chartOfAccountTypeDropDownList"
                                        name="chartOfAccountTypeDropDownList"

                                        runat="server" padding-left="20px"
                                        Width="100%"
                                        AutoPostBack="true"
                                        DefaultMessage="Select Type"
                                        OnItemSelected="chartOfAccountTypeDropDownList_ItemSelected"
                                        OnSelectedIndexChanged="chartOfAccountTypeDropDownList_SelectedIndexChanged"
                                        Skin="Bootstrap">
                                    </telerik1:RadDropDownList>

                                </telerik1:RadAjaxPanel>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="chartOfAccountGroupIdDropDownList" class="col-sm-4 control-label">Account Group</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik1:RadAjaxPanel ID="RadAjaxPanel3" runat="server">
                                    <telerik1:RadDropDownList ID="chartOfAccountGroupIdDropDownList"
                                        name="chartOfAccountGroupIdDropDownList"
                                        
                                        runat="server" padding-left="20px"
                                        Width="100%"
                                        AutoPostBack="true"
                                        DefaultMessage="Select Chart Of Account Group Id"
                                        OnItemSelected="chartOfAccountGroupIdDropDownList_ItemSelected"
                                        OnSelectedIndexChanged="chartOfAccountGroupIdDropDownList_SelectedIndexChanged"
                                        Skin="Bootstrap">
                                    </telerik1:RadDropDownList>

                                </telerik1:RadAjaxPanel>
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtBankNatxtChartOfAccountCodeme" class="col-sm-4 control-label">Accounts Code</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtChartOfAccountCode" id="txtChartOfAccountCode" placeholder="Code" runat="server" />
                            </div>

                        </div>
                    </div>


                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtChartOfAccountTitle" class="col-sm-4 control-label">Account Title</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtChartOfAccountTitle" id="txtChartOfAccountTitle" placeholder="Title" runat="server" />
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
                            <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Chart of Account Information" OnClick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                        </div>
                    </div>
                </div>

            </div>
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Chart Of Accounts</h3>
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
                                            <th>Account Type</th>
                                            <th>Account Group ID</th>
                                            <th>Account Code</th>
                                            <th>Account Title</th>
                                            <th>Update By</th>
                                            <th>Update Date</th>
                                            <th>Is Active</th>
                                           
                                        </tr>
                                    </thead>
                                    <div id="chartTableBody" runat="server">
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
