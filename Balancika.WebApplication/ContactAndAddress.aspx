<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ContactAndAddress.aspx.cs" Inherits="Balancika.ContactAndAddress" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
    <h1>Address and Contact Information</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <section class="form-horizontal">
            <div class="box">
                <%--  <button id="addressDiv" type="submit" class="btn bg-olive btn-flat margin" onclick="this.disable=true">Address Information </button>--%>
                <asp:Button ID="addressDiv" runat="server" ClientIDMode="Static" CssClass="btn bg-olive btn-flat margin" Text="Address Information Save" OnClientClick="return false" UseSubmitBehavior="false" />
                <%-- <button id="contactDiv" type="submit" class="btn bg-purple btn-flat margin">Contact Information</button>--%>
                <asp:Button ID="contactDiv" runat="server" ClientIDMode="Static" CssClass="btn bg-purple btn-flat margin" Text="Contact Information Save" OnClientClick="return false" UseSubmitBehavior="false" OnClick="btnSave_Click" />
                <div id="addressInformationDiv" class="box box-primary" style="width: auto">
                    <div class="box-header with-border" style="width: 100%">
                        <h1 style="font-size: 20px; font-weight: bold; color: green">Billing Address </h1>
                    </div>
                    <div id="billingAddressInformationBoxBody" class="box-body">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="txtBillingAddressLine1" class="col-sm-4 control-label">Address Line 1</label>
                                <div class="col-sm-8">
                                    <textarea type="text" class="form-control" width="60px" name="txtBillingAddressLine1" id="txtBillingAddressLine1" placeholder="Address" runat="server"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">

                            <div class="form-group">
                                <label for="txtBillingAddressLine2" class="col-sm-4 control-label">Address Line 2</label>
                                <div class="col-sm-8">
                                    <textarea type="text" class="form-control" width="60px" name="txtBillingAddressLine2" id="txtBillingAddressLine2" placeholder="Address" runat="server"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group ">
                                <label for="billingCountryDropDownList" class="col-sm-4 control-label">Country</label>
                                <div class="col-xs-8">
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                                        <telerik:RadDropDownList ID="billingCountryDropDownList"
                                            runat="server" padding-left="20px"
                                            Width="100%"
                                            AutoPostBack="true"
                                            DefaultMessage="Select Country"
                                            OnSelectedIndexChanged="billingCountryDropDownList_SelectedIndexChanged"
                                            Skin="Bootstrap">
                                        </telerik:RadDropDownList>

                                    </telerik:RadAjaxPanel>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtBillingCity" class="col-sm-4 control-label">City</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtBillingCity" id="txtBillingCity" placeholder="City" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtBillingZipCode" class="col-sm-4 control-label">Zip Code</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtBillingZipCode" id="txtBillingZipCode" placeholder="Zip Code" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtBillingPhone" class="col-sm-4 control-label">Phone Number</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtBillingPhone" id="txtBillingPhone" placeholder="Phone Number" runat="server" />
                                </div>

                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtBillingMobile" class="col-sm-4 control-label">Mobile</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtBillingMobile" id="txtBillingMobile" placeholder="Mobile" runat="server" />
                                </div>

                            </div>
                        </div>
                         <div class="col-md-6">
                                <div class="form-group ">
                                    <label for="txtBillingEmail" class="col-sm-4 control-label">Email</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" width="60px" name="txtBillingEmail" id="txtBillingEmail" placeholder="Mobile" runat="server" />
                                    </div>

                                </div>
                            </div>

                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtBillingWeb" class="col-sm-4 control-label">Web</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtBillingWeb" id="txtBillingWeb" placeholder="Web" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Billing Address" OnClick="btnBillingInformationSave_Click" />
                                <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                            </div>
                        </div>
                    </div>
                    <div id="shippingAddressInformationDiv" class="box box-primary" style="width: auto">
                        <div class="box-header with-border" style="width: 100%">
                            <h1 style="font-size: 20px; font-weight: bold; color: green">Shipping Address </h1>
                        </div>
                        <div id="shippinhgAddressInformationBoxBody" class="box-body" runat="server">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label for="txtShippingaddressLine1" class="col-sm-4 control-label">Address Line 1</label>
                                    <div class="col-sm-8">
                                        <textarea type="text" class="form-control" width="60px" name="txtShippingaddressLine1" id="txtShippingaddressLine1" placeholder="Address" runat="server"></textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">

                                <div class="form-group">
                                    <label for="txtShippingaddressLine2" class="col-sm-4 control-label">Address Line 2</label>
                                    <div class="col-sm-8">
                                        <textarea type="text" class="form-control" width="60px" name="txtShippingaddressLine2" id="txtShippingaddressLine2" placeholder="Address" runat="server"></textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group ">
                                    <label for="shippingCountryDropDownList" class="col-sm-4 control-label">Country</label>
                                    <div class="col-xs-8">
                                        <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                                            <telerik:RadDropDownList ID="shippingCountryDropDownList"

                                                runat="server" padding-left="20px"
                                                Width="100%"
                                                AutoPostBack="true"
                                                DefaultMessage="Select Country"
                                                OnSelectedIndexChanged="shippingCountryDropDownList_SelectedIndexChanged"
                                                Skin="Bootstrap">
                                            </telerik:RadDropDownList>

                                        </telerik:RadAjaxPanel>
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label for="txtShippingCity" class="col-sm-4 control-label">City</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" width="60px" name="txtShippingCity" id="txtShippingCity" placeholder="City" runat="server" />
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label for="txtShippingZipCode" class="col-sm-4 control-label">Zip Code</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" width="60px" name="txtShippingZipCode" id="txtShippingZipCode" placeholder="Zip Code" runat="server" />
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label for="txtShippingPhone" class="col-sm-4 control-label">Phone Number</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" width="60px" name="txtShippingPhone" id="txtShippingPhone" placeholder="Phone Number" runat="server" />
                                    </div>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label for="txtShippingMobile" class="col-sm-4 control-label">Mobile</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" width="60px" name="txtShippingMobile" id="txtShippingMobile" placeholder="Mobile" runat="server" />
                                    </div>

                                </div>
                            </div>
                              <div class="col-md-6">
                                <div class="form-group ">
                                    <label for="txtShippingEmail" class="col-sm-4 control-label">Email</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" width="60px" name="txtShippingEmail" id="txtShippingEmail" placeholder="Mobile" runat="server" />
                                    </div>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label for="txtShippingWeb" class="col-sm-4 control-label">Web</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" width="60px" name="txtShippingWeb" id="txtShippingWeb" placeholder="Web" runat="server" />
                                    </div>

                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="shippingSave" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Shipping Address" OnClick="btnShippingInformationSave_Click" />
                                    <input class="btn btn-warning" runat="server" onserverclick="btnShippingClear_Click" type="button" value="Clear Information" />

                                </div>
                        </div>
                        </div>
                    </div>


                </div>

                <div id="contactInformationDiv" class="box box-primary">
                    <div class="box-header with-border" style="width: 100%">
                        <h1 style="font-size: 20px; font-weight: bold; color: green">Contact Information </h1>
                    </div>
                    <div id="contactInformationBoxBody" class="box-body" runat="server">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtContactName" class="col-sm-4 control-label">Contact Name</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtContactName" id="txtContactName" placeholder="Contact Name" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="designationDropDownList" class="col-sm-4 control-label">Designation</label>
                                <div class="col-xs-8">
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel3" runat="server">
                                        <telerik:RadDropDownList ID="designationDropDownList"

                                            runat="server" padding-left="20px"
                                            Width="100%"
                                            AutoPostBack="true"
                                            DefaultMessage="Select Designation"
                                            Skin="Bootstrap">
                                        </telerik:RadDropDownList>

                                    </telerik:RadAjaxPanel>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtContactPhone" class="col-sm-4 control-label">Phone Number</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtContactPhone" id="txtContactPhone" placeholder="Phone Number" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtContactMobile" class="col-sm-4 control-label">Mobile Number</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtContactMobile" id="txtContactMobile" placeholder="Mobile Number" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label for="txtContactEmail" class="col-sm-4 control-label">Email</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" width="60px" name="txtContactEmail" id="txtContactEmail" placeholder="Email" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-8">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="chkIsMain" runat="server" value="false" />
                                        <strong>Is Main</strong>
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>

                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnContactInformationSaveMore" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Contact Information & Add Another" OnClick="btnContactInformationSaveMore_Click" />
                                <asp:Button ID="btnContactInformationSave" runat="server" ClientIDMode="Static" CssClass="btn bg-navy" Text="Save Contact Information" OnClick="btnContactInformationSave_Click" />
                            </div>
                        </div>


                    </div>
                       <div class="box box-primary">
                    
                    <div id="contactInformationTableBody" class="box-body">
                        <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title" style="font-size: 20px; font-weight: bold; color: navy">Contact Information List</h3>
                </div>
                <div class="box-body">
                    <div id="divContactTable" class="dataTables_wrapper form-inline dt-bootstrap">
                        <div class="row">
                            <div class="col-sm-6"></div>
                            <div class="col-sm-6"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <table id="contactTable" class="table table-bordered table-hover dataTable">
                                    <thead>
                                        <tr role="row">
                                             <th>Source Type</th>
                                             <th>Source Id</th>
                                            <th>Contact Name</th>
                                            <th>Contact Designation</th>
                                            <th>Is Main</th>
                                            <th>Phone</th>
                                            <th>Mobile</th>
                                            <th>Email</th>
                                        </tr>
                                    </thead>
                                    <tbody id="contactInformationTable" runat="server">
                                        </tbody>
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

                </div>
             

            </div>



        </section>

    </form>
    <script>
        $(document).ready(function () {
            $('#contactTable').DataTable({
                "paging": true,
                "lengthChange": true,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": true,
                "scrollX": true
            });
            $("#addressInformationDiv").hide();
            $("#contactInformationDiv").hide();
            $("#addressDiv").click(function () {
                $("#contactInformationDiv").hide(200);
                $("#addressInformationDiv").show(200);

            });
            $("#contactDiv").click(function () {
                $("#addressInformationDiv").hide(200);
                $("#contactInformationDiv").show(200);
            });
            $("#form1").validate({

            });

        });
    </script>
</asp:Content>
