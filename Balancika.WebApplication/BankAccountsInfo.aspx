<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BankAccountsInfo.aspx.cs" Inherits="Balancika.BankAccountsInfo" %>

<%@ Register TagPrefix="telerik1" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script>

        $(document).ready(function () {
            $('#bankAccountsTable').DataTable({
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

                    '<%=txtBranchName.UniqueID%>': {
                        required: true,


                    },
                    '<%=txtAccountNo.UniqueID%>': {
                        required: true
                    },
                    '<%=txtTitle.UniqueID%>': {
                        required: true
                    }




                },
                messages: {

                    '<%=txtBranchName.UniqueID%>': {
                        required: "Please Enter Code",


                    },
                    '<%=txtAccountNo.UniqueID%>': {
                        required: "Enter Parent BankInfo Name"
                    },
                    '<%=txtTitle.UniqueID%>': {
                        required: "Please enter designation"
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
                    <h3 class="box-title">Add /Edit BankInfo Information</h3>
                </div>
                <div class="box-body">
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="bankIdRadDropDownList1" class="col-sm-4 control-label">Bank Info Id</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik1:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                                    <telerik1:RadDropDownList ID="bankIdRadDropDownList1"
                                        name="bankIdRadDropDownList1"
                                        
                                        runat="server" padding-left="20px"
                                        Width="100%"
                                        AutoPostBack="true"
                                        DefaultMessage="Select BankInfo Id"
                                        OnItemSelected="bankIdRadDropDownList1_ItemSelected"
                                        OnSelectedIndexChanged="bankIdRadDropDownList1_SelectedIndexChanged" Skin="Bootstrap">
                                    </telerik1:RadDropDownList>

                                </telerik1:RadAjaxPanel>
                            </div>

                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtBranchName" class="col-sm-4 control-label">Branch Name</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtBranchName" id="txtBranchName" placeholder="Branch Name" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>

                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtAccountNo" class="col-sm-4 control-label">Account No</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtAccountNo" id="txtAccountNo" placeholder="Account Number" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtTitle" class="col-sm-4 control-label">Account Title</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtTitle" id="txtTitle" placeholder="Title" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="accountTypeRadDropDownList1" class="col-sm-4 control-label">Account Type</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik1:RadAjaxPanel ID="RadAjaxPanel3" runat="server">
                                    <telerik1:RadDropDownList ID="accountTypeRadDropDownList1"
                                        name="accountTypeRadDropDownList1"
                                        runat="server" padding-left="20px"
                                        Width="100%"
                                        AutoPostBack="true"
                                        DefaultMessage="Select Account Type"
                                        OnItemSelected="accountTypeRadDropDownList1_ItemSelected"
                                        OnSelectedIndexChanged="accountTypeRadDropDownList1_SelectedIndexChanged"
                                        Skin="Bootstrap">
                                    </telerik1:RadDropDownList>

                                </telerik1:RadAjaxPanel>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="RadDatePicker2" class="col-sm-4 control-label">Openning Date</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik1:RadDatePicker  ID="RadDatePicker2" runat="server" Width="100%" Skin="Bootstrap" SelectedDate='<%# System.DateTime.Today %>'></telerik1:RadDatePicker>
                            </div>

                        </div>
                    </div>

                   

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
                            <asp:Button ID="saveAccountsButton" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Accounts Information" OnClick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                        </div>
                    </div>
                </div>

            </div>
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Bank Accounts Info</h3>
                </div>
                <div class="box-body">
                    <div id="divCompanyTable" class="dataTables_wrapper form-inline dt-bootstrap">
                        <div class="row">
                            <div class="col-sm-6"></div>
                            <div class="col-sm-6"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <table id="bankAccountsTable" class="table table-bordered table-hover dataTable">
                                    <thead>
                                        <tr role="row">
                                            <th>Bank Id</th>
                                            <th>Branch Name</th>
                                            <th>Account No</th>
                                            <th>Account Title</th>
                                            <th>Account type</th>
                                            <th>Opening Date</th>
                                           <th>Is Active</th>

                                        </tr>
                                    </thead>
                                    <tbody id="tableBody" runat="server">
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
