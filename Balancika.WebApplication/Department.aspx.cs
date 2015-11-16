using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IndentApplicationManagement.Bll.Base;
using Telerik.Web.UI;

namespace IndentApplicationManagement
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RadDropDownList1.DataSource = new List<string>() { "Asia", "Africa", "North America", "South America", "Europe", "Australia", "Antarctica" };
                RadDropDownList1.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DepartmentBase newDepartment=new DepartmentBase();
            newDepartment.DepartmentName = departmentNameTextBox.Value;
            newDepartment.ParentDepartmentId = int.Parse(parentDepartmentID.Value);
            newDepartment.UpdateBy = int.Parse(updateByTextBox.Value);
            newDepartment.UpdateDate = DateTime.Parse(datetimepicker.Value);


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }
        protected void RadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }
        protected void RadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            
        }
    }
}