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
    public partial class CustomerInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users _user;
        private static int userId;
        List<Company> companyList = new List<Company>();
        private Company _company = new Company();

        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];

            if (Session["savedCutomerMessage"] != null)
            {
                string msg = Session["savedCutomerMessage"].ToString();
                Alert.Show(msg);
                Session["savedCutomerMessage"] = null;
            }
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=default.aspx");
                else
                    Response.Redirect("LogIn.aspx?refPage=default.aspx?" + str);
            }
           
            this.LoadCountryDropdown();
            this.LoadSalesPersonDropDown();
            this.LoadCustomerTable();
        }
        private bool isValidSession()
        {
            if (Session["user"] == null)
            {
                return false;
            }

            _user = (Users)Session["user"];

            return _user.UserId != 0;
        }
        void LoadCountryDropdown()
        {
            countryDropDownList.DataSource = Country.CountryList();
            countryDropDownList.DataBind();
        }

        public void LoadSalesPersonDropDown()
        {
            Employee newEmp = new Employee();
            List<Employee> empList = newEmp.GetAllEmployee(_company.CompanyId);
            salesPersonDropDownList.DataSource = empList;
            salesPersonDropDownList.DataTextField = "EmployeeName";
            salesPersonDropDownList.DataValueField = "EmployeeId";
            salesPersonDropDownList.DataBind();

        }
       

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Customer objCustomer = new Customer();

            List<Customer> myList = objCustomer.GetAllCustomer(_company.CompanyId);

            objCustomer.CustomerId = myList.Count;
            objCustomer.CustomerName = txtCustomerName.Value;
            objCustomer.CustomerCategoryId =int.Parse(txtCustomerCategory.Value);
            objCustomer.SalesPersonId = int.Parse(salesPersonDropDownList.SelectedItem.Value);
            objCustomer.IsActive = chkIsActive.Checked;
            objCustomer.CompanyId = _company.CompanyId;
            objCustomer.CreditLimit = int.Parse(txtCreditLimit.Value);
            objCustomer.UpdateBy = _user.UserId;
            objCustomer.UpdateDate=DateTime.Now;



            Addresses address = new Addresses();
            List<Addresses> addresseses = address.GetAllAddresses(_company.CompanyId);
            address.AddressId = addresseses.Count;
            address.SourceType = "Customer";
            address.SourceId = _user.UserId;
            address.AddressType = "Main Address";
            address.AddressLine1 = txtAddressLine1.Value;
            address.AddressLine2 = txtAddressLine2.Value;
            address.CountryId = countryDropDownList.SelectedIndex;
            address.City = txtCity.Value;
            address.ZipCode = txtZipCode.Value;
            address.Phone = txtPhoneNo.Value;
            address.Mobile = txtPhoneNo.Value;
            address.Email = txtEmail.Value;
            address.Web = txtWeb.Value;
            address.CompanyId = _company.CompanyId;


            int chk1 = objCustomer.InsertCustomer();
            int chk2=address.InsertAddresses();
            if (chk1 > 0 && chk2 > 0)
                {
                    Session["savedCutomerMessage"] = "Saved Successfully";
                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    Alert.Show("Error occured while inserting customer information");
                }
            
        }
      
        private void LoadCustomerTable()
        {
            try
            {
                customerTblBody.InnerHtml = "";
                string htmlContent = "";
                Customer customer=new Customer();
                List<Customer> allCustomers = customer.GetAllCustomer(_company.CompanyId);
                foreach (Customer cust in allCustomers)
                {
                    htmlContent += "<tr>";
                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th>", cust.CustomerName, cust.CustomerCategoryId, cust.SalesPersonId,cust.CreditLimit, cust.UpdateDate);
                    htmlContent += "</tr>";
                }

                customerTblBody.InnerHtml += htmlContent;
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }

        private void Clear()
        {
           
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        protected void companyIdDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void companyIdDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void countryDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void countryDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           
        }
    }
}