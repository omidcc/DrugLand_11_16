using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class DesignationInformation : System.Web.UI.Page
    {

        private bool isNewEntry;
        private Users user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user = (Users)Session["user"];

                this.Clear();
                
                this.LoadCompanyDropDownList();
               
            }
            
        }
        protected void RadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }
        protected void RadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            this.LoadDepartmentDropDownList();
        }
        protected void departmentIdRadDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
           

        }
        protected void departmentIdRadDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveDesignation();

            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
            }


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();

        }

        private void SaveDesignation()
        {
            try
            {
                Designation aDesignation = new Designation();
                aDesignation.Designation = txtDesignation.Value;
                aDesignation.CompanyId = int.Parse(companyIdRadDropDownList1.SelectedItem.Value);
                aDesignation.DepartmentId = int.Parse(departmentIdRadDropDownList.SelectedItem.Value);
                aDesignation.UpdateDate = DateTime.Now;
                //aDesignation.UpdateBy = user.UserId;
                aDesignation.UpdateBy = 1;
                aDesignation.IsActive = chkIsActive.Checked;
               int success= aDesignation.InsertDesignation();
                Alert.Show(success>0?"Designation Saved Successfully":"Something Error Happened");



            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
            }

        }

        public void Clear()
        {

        }

        public void LoadCompanyDropDownList()
        {
            List<Company> companyList=new List<Company>();
            Company aCompany=new Company();
            companyList = aCompany.GetAllCompany(0);
            companyIdRadDropDownList1.DataSource = companyList;
            companyIdRadDropDownList1.DataTextField = "CompanyName";
            companyIdRadDropDownList1.DataValueField = "CompanyId";
            companyIdRadDropDownList1.DataBind();
        }
        
        public void LoadDepartmentDropDownList()
        {
            List<Department> departmentList=new List<Department>();
            Department aDepartment=new Department();
            
            departmentList= aDepartment.GetAllDepartment(0);
            departmentIdRadDropDownList.DataSource = departmentList;
            departmentIdRadDropDownList.DataTextField = "DepartmentName";
            departmentIdRadDropDownList.DataValueField = "DepartmentId";
            departmentIdRadDropDownList.DataBind();
        }
    }
}