<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BankInfoDetails.aspx.cs" Inherits="Balancika.BankInfoDetails" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <form runat="server" id="form1">
        
        
        
        
         <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        

        

   
    <div class="demo-container no-bg">
        <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Silk">
            <Tabs>
                <telerik:RadTab Text="Bank Information" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Bank Account Information" Width="200px"></telerik:RadTab>
           
            </Tabs>
        </telerik:RadTabStrip>
         <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView runat="server" ID="RadPageView1">
                <section class="form-horizontal">
            <div class="box">
                  <div id="bankInfoPageDiv" class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Add /Edit Bank Information</h3>
                        <asp:Label ID="labelTxt" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="bankInfoSaveDiv" class="box-body">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="txtBankCode" class="col-sm-4 control-label">Bank Code</label>
                                <div class="col-sm-8">
                                    <input type="text" class="form-control" width="60px" name="txtBankInfoCode" id="txtBankCode" placeholder="Bank Code" runat="server" />
                                </div>
                            </div>
                        </div>
                        <%--<telerik:RadDropDownList ID="RadDropDownList1" runat="server"></telerik:RadDropDownList>--%>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="txtBankName" class="col-sm-4 control-label">Bank Name</label>
                                <div class="col-xs-8">
                                    <input type="text" class="form-control" width="60px" name="txtBankInfoName" id="txtBankName" placeholder="Bank Name" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="clearfix"></div>

                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtContactPerson" class="col-sm-4 control-label">Contact Person</label>
                                <div class="col-xs-8">
                                    <input type="text" class="form-control" width="60px" name="txtContactPerson" id="txtContactPerson" placeholder="Contact Person" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtDesignation" class="col-sm-4 control-label">Contact Designation</label>
                                <div class="col-xs-8">
                                    <input type="text" class="form-control" width="60px" name="txtDesignation" id="txtDesignation" placeholder="Designation" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtContactNo" class="col-sm-4 control-label">Contact No</label>
                                <div class="col-xs-8">
                                    <input type="text" class="form-control" width="60px" name="txtContactNo" id="txtContactNo" placeholder="Contact No" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtEmail" class="col-sm-4 control-label">Email</label>
                                <div class="col-xs-8">
                                    <input type="email" class="form-control" name="txtEmail" id="txtEmail" data-error=" that email address is invalid" placeholder="Email" runat="server" />
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
                        <div class="clearfix"></div>


                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Bank Information" OnClick="btnSaveBankInfo_Click" />
                                <input class="btn btn-warning" runat="server" onserverclick="btnBankInfoClear_Click" type="button" value="Clear Information" />
                            </div>
                        </div>
                    </div>
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Show Bank List</h3>
                            <asp:Label ID="label1" runat="server" Text=""></asp:Label>
                        </div>
                        <div id="bankInfoShowDiv" class="box-body">
                            <div id="divBankInfoTableDiv" class="dataTables_wrapper form-inline dt-bootstrap">
                                <div class="row">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-6"></div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <table id="bankTable" class="table table-bordered table-hover dataTable">
                                            <thead>
                                                <tr role="row">
                                                    <th>BankInfo Code</th>
                                                    <th>BankInfo Name</th>
                                                    <th>Contact Person</th>
                                                    <th>Designation</th>
                                                    <th>Contact No</th>
                                                    <th>Email</th>
                                                    <th>Is Active</th>
                                                    <th>Update By</th>
                                                    <th>Update Date</th>
                                                </tr>
                                            </thead>
                                            <div id="tableBankBody" runat="server">
                                            </div>
                                            <tfoot>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                </div>
                 </section>
                 </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView2">
                         <section class="form-horizontal">
            <div class="box">
            <div id="AccountInfoPageDiv" class="box box-primary" runat="server">
                    <div class="box-header with-border">
                        <h3 class="box-title">Add /Edit Accounts Information</h3>
                        <asp:Label ID="label2" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="AccountInfoSaveDiv" class="box-body">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="bankIdRadDropDownList1" class="col-sm-4 control-label">Bank Info Id</label>
                                <div class="col-xs-8">
                                    <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                                        <telerik:RadDropDownList ID="bankIdRadDropDownList1"
                                            name="bankIdRadDropDownList1"
                                            runat="server" padding-left="20px"
                                            Width="100%"
                                            AutoPostBack="true"
                                            DefaultMessage="Select BankInfo Id"
                                            Skin="Bootstrap">
                                        </telerik:RadDropDownList>

                                    </telerik:RadAjaxPanel>
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
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel3" runat="server">
                                        <telerik:RadDropDownList ID="accountTypeRadDropDownList1"
                                            name="accountTypeRadDropDownList1"
                                            runat="server" padding-left="20px"
                                            Width="100%"
                                            AutoPostBack="true"
                                            DefaultMessage="Select Account Type"
                                            Skin="Bootstrap">
                                        </telerik:RadDropDownList>

                                    </telerik:RadAjaxPanel>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="RadDatePicker2" class="col-sm-4 control-label">Openning Date</label>
                                <div class="col-xs-8">
                                    <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                    <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Width="100%" Skin="Bootstrap" SelectedDate='<%# System.DateTime.Today %>'></telerik:RadDatePicker>
                                </div>

                            </div>
                        </div>



                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="col-sm-offset-4 col-sm-8">
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" id="Checkbox1" runat="server" value="false" />
                                            <strong>Is Active</strong>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>


                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="saveAccountsButton" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Accounts Information" OnClick="btnSaveAccount_Click" />
                                <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                            </div>
                        </div>
                    </div>
                     <div class="box box-primary" id="dontshow">

                    <div class="box-header with-border">
                        <h3 class="box-title">Show Account List</h3>
                        <asp:Label ID="label3" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="AccountInfoShowDiv" class="box-body">
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
                                                
                                                <th>Branch Name</th>
                                                <th>Bank Account No</th>
                                                <th>Account Title</th>
                                                <th>Account Type</th>
                                                <th>Opening Date</th>
                                                <th>Is Active</th>
                                            </tr>
                                        </thead>
                                        <div id="tableBody" runat="server">
                                        </div>
                                        <tfoot>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                </div>
        </div>
                             </section>
                         </telerik:RadPageView>
        </telerik:RadMultiPage>
        
        </div>
    </form>
        <script>
            $(document).ready(function () {
                $('#bankTable').DataTable({
                    "paging": true,
                    "lengthChange": true,
                    "searching": true,
                    "ordering": true,
                    "info": true,
                    "autoWidth": true,
                    "scrollX": true
                });
                $('#bankAccountsTable').DataTable({
                    "paging": true,
                    "lengthChange": true,
                    "searching": true,
                    "ordering": true,
                    "info": true,
                    "autoWidth": true,
                    "scrollX": true
                });



            });
    </script>
</asp:Content>
