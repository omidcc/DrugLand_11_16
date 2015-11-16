<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CompanyInfo.aspx.cs" Inherits="Balancika.CompanyInfo" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<asp:Content runat="server" ContentPlaceHolderID="MainHeader">
    <h1>Company Information</h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $('#CompanyTable').DataTable({
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
                    '<%=txtCompanyName.UniqueID%>': {
                        required: true
                    },
                    '<%=txtEmail.UniqueID%>': {
                        email: true
                    },
                    '<%=txtAddress.UniqueID%>': {
                        required: true
                    }
                    
                },
                messages: {
                    '<%=txtCompanyName.UniqueID%>': {
                        required: "Company Name is required"
                    },
                    '<%=txtEmail.UniqueID%>': {
                        email: "Please enter valid email address"
                    },
                    '<%=txtAddress.UniqueID%>': {
                        required: "Please enter company address"
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
                    <h3 class="box-title">Add /Edit Company Information</h3>
                </div>
                <div class="box-body">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtCompanyName" class="col-sm-4 control-label">Company Name</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" width="60px" name="txtCompanyName" id="txtCompanyName" placeholder="Name" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtAddress" class="col-sm-4 control-label">Address</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtAddress" id="txtAddress" placeholder="Address" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
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
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtAddressLine2" class="col-sm-4 control-label">Address Line 2</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtAddressLine2" id="txtAddressLine2" placeholder="Address Line 2" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
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
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtCity" class="col-sm-4 control-label">City</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtCity" id="txtCity" placeholder="City" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtZipCode" class="col-sm-4 control-label">Zip Code</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtZipCode" id="txtZipCode" placeholder="Zip Code" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtEmail" class="col-sm-4 control-label">Email</label>
                            <div class="col-xs-8">
                                <input type="email" class="form-control" name="txtEmail" id="txtEmail" data-error=" that email address is invalid" placeholder="Enter a valid email address" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>

                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtWeb" class="col-sm-4 control-label">Web Address</label>
                            <div class="col-lg-8">
                                <input type="text" class="form-control" width="60px" name="txtWeb" id="txtWeb" placeholder="Web Address" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtLogoPath" class="col-sm-4 control-label">Logo Path</label>
                            <div class="col-lg-8">
                                <input type="text" class="form-control" width="60px" name="txtLogoPath" id="txtLogoPath" placeholder="" runat="server" />
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
                            <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Company Information" OnClick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                        </div>
                    </div>
                </div>

            </div>
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Comapny List</h3>
                </div>
                <div class="box-body">
                    <div id="divCompanyTable" class="dataTables_wrapper form-inline dt-bootstrap">
                        <div class="row">
                            <div class="col-sm-6"></div>
                            <div class="col-sm-6"></div>
                        </div>
                        <div class="box-body">
                            <div class="col-sm-12">
                                <table id="CompanyTable" class="table table-bordered table-hover dataTable">
                                    <thead>
                                        <tr role="row">
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
                                    <tbody id="companyTableBody" runat="server">
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




