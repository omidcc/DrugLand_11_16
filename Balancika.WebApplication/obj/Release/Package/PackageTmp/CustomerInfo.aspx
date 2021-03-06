﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs" Inherits="Balancika.CustomerInfo" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $(document).ready(function () {
            $('#departmentTable').DataTable({
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

                    '<%=txtCustomerName.UniqueID%>': {
                        required: true,


                    },

                  

                    '<%=txtCreditLimit.UniqueID%>': {
                        required: true
                    }
                    


                },
                messages: {


                    '<%=txtCustomerName.UniqueID%>': {
                        required: "Please enter customer name"
                    },
                
                    

                    

                    '<%=txtCreditLimit.UniqueID%>': {
                        required: "Enter credit limit"
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
                    <h3 class="box-title">Add Customer Information</h3>
                </div>
                <div class="box-body">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtCustomerName" class="col-sm-4 control-label">Customer Name</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" width="60px" id="txtCustomerName" name="txtCustomerName" placeholder="Customer Name" runat="server" clientidmode="Static" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtCustomerCategory" class="col-sm-4 control-label">Category</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" id="txtCustomerCategory" name="txtCustomerCategory" placeholder="Category " runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                    
                    
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="salesPersonDropDownList" class="col-sm-4 control-label">Sales Person</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                                    <telerik:RadDropDownList ID="salesPersonDropDownList"
                                        runat="server" padding-left="20px"
                                        Width="100%"
                                        AutoPostBack="true"
                                        DefaultMessage="Select Sales Person"
                                        Skin="Bootstrap">
                                    </telerik:RadDropDownList>

                                </telerik:RadAjaxPanel>
                            </div>

                        </div>
                    </div>
                  

                    <div class="clearfix"></div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtCreditLimit" class="col-sm-4 control-label">Credit Limit</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" id="txtCreditLimit" name="txtCreditLimit" placeholder="Credit Limit" runat="server" />
                            </div>

                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtPhoneNo" class="col-sm-4 control-label">Phone Number</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtPhoneNo" id="txtPhoneNo" placeholder="Phone Number" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                    


                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtAddressLine1" class="col-sm-4 control-label">Address Line 1</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtAddressLine1" id="txtAddressLine1" placeholder="Address Line 1" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtAddressLine2" class="col-sm-4 control-label">Address Line 2</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtAddressLine2" id="txtAddressLine2" placeholder="Address Line 2" runat="server" />
                            </div>

                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="countryDropDownList" class="col-sm-4 control-label">Country</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                                    <telerik:RadDropDownList ID="countryDropDownList"
                                        runat="server" padding-left="20px"
                                        Width="100%"
                                        AutoPostBack="true"
                                        DefaultMessage="Select Country"
                                        OnItemSelected="countryDropDownList_ItemSelected"
                                        OnSelectedIndexChanged="countryDropDownList_SelectedIndexChanged"
                                        Skin="Bootstrap">
                                    </telerik:RadDropDownList>

                                </telerik:RadAjaxPanel>
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtCity" class="col-sm-4 control-label">City</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtCity" id="txtCity" placeholder="City" runat="server" />
                            </div>

                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtZipCode" class="col-sm-4 control-label">Zip Code</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtZipCode" id="txtZipCode" placeholder="Zip Code" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtEmail" class="col-sm-4 control-label">Email</label>
                            <div class="col-xs-8">
                                <input type="email" class="form-control" name="txtEmail" id="txtEmail" data-error=" that email address is invalid" placeholder="Enter a valid email address" runat="server" />
                            </div>

                        </div>
                    </div>
                

                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtWeb" class="col-sm-4 control-label">Web Address</label>
                            <div class="col-lg-8">
                                <input type="text" class="form-control" width="60px" name="txtWeb" id="txtWeb" placeholder="Web Address" runat="server" />
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
                            <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Customer Information" OnClientClick="return validate()" OnClick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server" type="button" value="Clear Information" onserverclick="btnClear_Click" />

                        </div>
                    </div>
                </div>

            </div>

            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Customer List</h3>
                </div>
                <div class="box-body">
                    <div id="divCompanyTable" class="dataTables_wrapper form-inline dt-bootstrap">
                        <div class="row">
                            <div class="col-sm-6"></div>
                            <div class="col-sm-6"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <table id="departmentTable" class="table table-bordered table-hover dataTable">
                                    <thead>
                                        <tr role="row">
                                            <th>Customer Name</th>
                                            <th>Category</th>
                                            <th>Sales Person</th>
                                            <th>Credit Limit</th>
                                        
                                            <th>Update Date</th>
                                            
                                        </tr>
                                    </thead>
                                    <tbody id="customerTblBody" runat="server">
                                    
                                    </tbody>
                                    <tfoot>
                                        <tr role="row">
                                        </tr>
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
