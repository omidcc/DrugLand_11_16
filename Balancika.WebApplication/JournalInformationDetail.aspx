<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="JournalInformationDetail.aspx.cs" Inherits="Balancika.JournalInformationDetail" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
    <h1>Journal Information</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <section class="form-horizontal">
            <div class="box">
                <div id="journalMasterInformationDiv" class="box box-primary" style="width: auto" runat="server">
                    <div class="box-header with-border" style="width: 100%">
                        <h1 style="font-size: 20px; font-weight: bold; color: green">Add New Journal Information </h1>

                    </div>
                    <div id="journalMasterInformationBoxBody" class="box-body" runat="server">

                        <div class="col-sm-6">
                            <div class="form-group ">
                                <label for="RadDatePicker1" class="col-sm-4 control-label">Journal Date</label>
                                <div class="col-xs-8">
                                    <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                            --%>
                                    <telerik:RadDatePicker Skin="Bootstrap" ID="RadDatePicker1" runat="server" Width="100%" SelectedDate='<%# System.DateTime.Today %>'></telerik:RadDatePicker>
                                </div>

                            </div>

                        </div>

                        <div class="col-sm-6">
                            <div class="form-group ">
                                <label for="journalTypeDropDownList" class="col-sm-4 control-label">Journal Type</label>
                                <div class="col-xs-8">
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                                        <telerik:RadDropDownList ID="journalTypeDropDownList"
                                            Skin="Bootstrap"
                                            runat="server" padding-left="20px"
                                            Width="100%"
                                            AutoPostBack="true"
                                            DefaultMessage="Select Journal Type">
                                        </telerik:RadDropDownList>

                                    </telerik:RadAjaxPanel>
                                </div>

                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-sm-6">

                            <div class="form-group">
                                <label for="txtJournalDescription" class="col-sm-4 control-label">Journal Description</label>
                                <div class="col-sm-8">
                                    <textarea type="text" class="form-control" width="60px" name="txtJournalDescription" id="txtJournalDescription" placeholder="Address" runat="server"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group ">
                                <label for="costCenterDropDownList" class="col-sm-4 control-label">Cost Center</label>
                                <div class="col-xs-8">
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                                        <telerik:RadDropDownList ID="costCenterDropDownList"
                                            Skin="Bootstrap"
                                            runat="server" padding-left="20px"
                                            Width="100%"
                                            AutoPostBack="true"
                                            DefaultMessage="Select Cost Center">
                                        </telerik:RadDropDownList>

                                    </telerik:RadAjaxPanel>
                                </div>

                            </div>
                        </div>
                         <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSaveNewJournalMasterInformation" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Add New Journal" OnClick="btnSaveNewJournalMasterInformation_Click" />
                                
                            </div>
                        </div>

                        


                    </div>

                </div>
                <div id="journalDetailsInformationDiv" class="box box-primary" style="width: auto" runat="server">
                    <div class="box-header with-border" style="width: 100%">
                        <h1 style="font-size: 20px; font-weight: bold; color: navy">Journal Details Information</h1>
                    </div>
                    <div id="journalDetailsInformationBoxBody" class="box-body">
                        <div class="col-sm-6">
                            <div class="form-group ">
                                <label for="accountNoDropDownList" class="col-sm-4 control-label">Account Title</label>
                                <div class="col-xs-8">
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel4" runat="server">
                                        <telerik:RadDropDownList ID="accountNoDropDownList"
                                            Skin="Bootstrap"
                                            runat="server" padding-left="20px"
                                            Width="100%"
                                            AutoPostBack="true"
                                            DefaultMessage="Select Account No">
                                        </telerik:RadDropDownList>

                                    </telerik:RadAjaxPanel>
                                </div>

                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="txtJorunalDetailsDescription" class="col-sm-4 control-label">Description</label>
                                <div class="col-sm-8">
                                    <textarea type="text" class="form-control" width="60px" name="txtJorunalDetailsDescription" id="txtJorunalDetailsDescription" placeholder="Description" runat="server" clientidmode="Static"></textarea>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtJournalDetailsDebit" class="col-sm-4 control-label">Debit</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtJournalDetailsDebit" id="txtJournalDetailsDebit" placeholder="Debit" runat="server" clientidmode="Static"/> 
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtJournalDetailsCredit" class="col-sm-4 control-label">Credit</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtJournalDetailsCredit"  id="txtJournalDetailsCredit" placeholder="Credit" runat="server" clientidmode="Static" />
                                </div>

                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSaveJournalSingleDetails" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Add Journal Item" OnClick="btnSaveJournalSingleDetails_Click" />
                                 <asp:Button Class="clearButton" ID="btnClearJournalDetailsInformation" runat="server" ClientIDMode="Static" CssClass="btn btn-warning" Text="Clear Information" OnClick="btnClearJournalDetailsInformation_Click" />
                            </div>
                        </div>
                        
                        <div class="box">
                           
                            <div class="box-body">
                                <div id="divJournalDetailsTable" class="dataTables_wrapper form-inline dt-bootstrap">
                                    <div class="row">
                                        <div class="col-sm-6"></div>
                                        <div class="col-sm-6"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <table id="journalDetailsTable" class="table table-bordered table-hover dataTable">
                                                <thead>
                                                    <tr role="row">
                                                        <th>Account No</th>
                                                        <th>Account Title</th>
                                                        <th>Debit</th>
                                                        <th>Credit</th>
                                                        <th>Description</th>
                                                          <th>Voucer No</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="journalDetailsTableBody" runat="server">
                                                </tbody>
                                                <tfoot>
                                                <tr role="row">
                                                 <th></th>
                                                    <th>Total</th>
                                                     <th id="totalDebit" runat="server"></th>
                                                     <th id="totalCredit" runat="server"></th>
                                                   <th></th>
                                                    <th></th>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSaveJournalDetailsInformation" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Journal Master Information" OnClick="btnSaveJournalDetailsInformation_Click" />
                              
                                 <input class="btn btn-warning" runat="server" onserverclick="btnJournalMasterClear_Click" type="button" value="Clear All Information" />
                            </div>
                        </div>
                    </div>
                      
                </div>
                
              

            </div>

        </section>
    </form>
    <script>
        $(document).ready(function () {

            $("#journalDetailsTable").DataTable({
                "paging": true,
                "lengthChange": true,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": true,
                "scrollX": true
            });
            console.log("ready");
            $("#btnClearJournalDetailsInformation").click(function (e) {

                e.preventDefault();
                $("#txtJorunalDetailsDescription").val("");
                $("#txtJournalDetailsDebit").val("");
                $("#txtJournalDetailsCredit").val("");
               
            });
        });
    </script>

</asp:Content>
