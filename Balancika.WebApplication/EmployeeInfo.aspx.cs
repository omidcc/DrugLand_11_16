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
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        private Users user;
        private Company _company;
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            user = (Users)Session["user"];
            this.LoadCountryDropDownList();
            if (Session["empMessage"] != null)
            {
                string message = Session["empMessage"].ToString();
                Session["empMessage"] = null;
                Alert.Show(message);
            }
            this.LoadCountryDropDownList();
            this.LoadDepartmentDropDownList();
            this.LoadDesignationDropDownList();
            this.Show();

        }

        private void LoadCountryDropDownList()
        {
            countryDropDownList.DataSource = Country.CountryList();

            countryDropDownList.DataBind();
        }

        public void LoadDesignationDropDownList()
        {
            Designation newDeg = new Designation();
            
            List<Designation> newDegList = newDeg.GetAllDesignation(_company.CompanyId);
            designationDropDownList.DataSource = newDegList;
            designationDropDownList.DataTextField = "Designation";
            designationDropDownList.DataValueField = "DesignationId";
            designationDropDownList.DataBind();
        }

        public void LoadDepartmentDropDownList()
        {
            Department newDeg = new Department();
            List<Department> newDegList = newDeg.GetAllDepartment(_company.CompanyId);
            departmentDropDownList.DataSource = newDegList;
            departmentDropDownList.DataTextField = "DepartmentName";
            departmentDropDownList.DataValueField = "DepartmentId";
            departmentDropDownList.DataBind();
        }

        protected void countryDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void countryDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            
        }

        public void Show()
        {


            try
            {
                CompanyTableBody.InnerHtml = "";
                string htmlContent = "";
                List<Employee> departmentList = new List<Employee>();
                Employee aDepartment = new Employee();
                departmentList = aDepartment.GetAllEmployee(_company.CompanyId);
                foreach (Employee aDepo in departmentList)
                {
                    
                    htmlContent += "<tr>";


                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th></tr>", aDepo.EmployeeCode, aDepo.EmployeeName, aDepo.Address, aDepo.DOB, aDepo.JoinDate, aDepo.IsActive);
                    htmlContent += "</tr>";
                }
                CompanyTableBody.InnerHtml += htmlContent;

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool chk = false;
                Employee aEmployee = new Employee();
                Addresses aAddresses=new Addresses();
                List<Employee> employeeListC =aEmployee.GetAllEmployee(_company.CompanyId);
                
                foreach (Employee anEmployee in employeeListC)
                {
                    if (anEmployee.EmployeeCode == txtEmployeeCode.Value)
                    {
                        Session["empMessage"] = "Employee Code is exist! Try Again";
                        chk = true;
                        break;
                    }
                }
                 if (chk == true)
                {
                    Response.Redirect(Request.RawUrl);
                }
                Employee tempEmployee = new Employee();
                int id;
                if (employeeListC.Count > 0)
                {
                    tempEmployee = (employeeListC[employeeListC.Count - 1]);
                      id= tempEmployee.EmployeeId + 1;
                }
                else
                {
                    id = 0;
                }
                 

               
                aEmployee.EmployeeId = id;
                aEmployee.EmployeeCode = txtEmployeeCode.Value;
                aEmployee.EmployeeName = txtEmployeeName.Value;
                aEmployee.DOB = RadDatePicker1.SelectedDate.ToString();
                aEmployee.JoinDate = JoinRadDatePicker.SelectedDate.ToString();
                aEmployee.DesignationId = int.Parse(designationDropDownList.SelectedItem.ToString());
                aEmployee.DepartmentId = int.Parse(departmentDropDownList.SelectedItem.ToString());
                aAddresses.SourceId = id;
                aEmployee.Address = "Main Address";
                aAddresses.SourceType = "Employee";
                aAddresses.AddressLine1 = txtAddressLine1.Value;
                aAddresses.AddressLine2 = txtAddressLine2.Value;
                aAddresses.AddressType = "Main Address";
                aAddresses.CountryId = int.Parse(countryDropDownList.SelectedIndex.ToString());
                aAddresses.City = txtCity.Value;
                aAddresses.ZipCode = txtZipCode.Value;
                aAddresses.Email = txtEmail.Value;
                aAddresses.CompanyId = _company.CompanyId;
                aEmployee.CompanyId = _company.CompanyId;
                aEmployee.IsActive = true;
                aEmployee.UpdateBy = user.UserId;
                aEmployee.UpdateDate = DateTime.Now;
                int chkEmployee = aEmployee.InsertEmployee();
                int chkAddress = aAddresses.InsertAddresses();
                if (chkAddress > 0 && chkEmployee > 0)
                {
                    Session["empMessage"] = "Saved Successfully";
                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    Alert.Show("Error occured while inserting employee information");
                }


            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
           
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }
    }
}