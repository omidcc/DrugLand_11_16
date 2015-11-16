<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListTableInfo.aspx.cs" Inherits="Balancika.ListTableInfo" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <script>
        $(document).ready(function () {
            $('#listTable').DataTable({
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
                    '<%=txtListType.UniqueID%>': {
                          required: true
                      }
                      ,
                      '<%=txtListValue.UniqueID%>': {
                          required: true
                      }


                  },
                  messages: {
                      '<%=txtListType.UniqueID%>': {
                        required: "Enter  List type"
                    },
                    '<%=txtListValue.UniqueID%>': {
                        required: "Please enter List Value"
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
                    <h3 class="box-title">Lists</h3>
                </div>
                <div class="box-body">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtListType" class="col-sm-4 control-label">List Type</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" width="60px" name="txtListType" id="txtListType" placeholder="Type" runat="server" />
                            </div>
                        </div>
                    </div>
                   
                    <div class="clearfix"></div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtListValue" class="col-sm-4 control-label">List Value</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtListValue" id="txtListValue" placeholder="Value" runat="server" />
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
                            <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save List Table Information" OnClick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                        </div>
                    </div>
                </div>

            </div>
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Lists</h3>
                </div>
                <div class="box-body">
                    <div id="divListTable" class="dataTables_wrapper form-inline dt-bootstrap">
                        <div class="row">
                            <div class="col-sm-6"></div>
                            <div class="col-sm-6"></div>
                        </div>
                        <div class="box-body">
                            <div class="col-sm-12">
                                <table id="listTable" class="table table-bordered table-hover dataTable">
                                    <thead>
                                        <tr role="row">
                                            <th>List Type</th>
                                            <th>List Id</th>
                                            <th>List Value</th>
                                            <th>Is Active</th>
                                            <th>Update Date</th>
                                        </tr>
                                    </thead>
                                    <tbody id="ListTableBody" runat="server">
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
