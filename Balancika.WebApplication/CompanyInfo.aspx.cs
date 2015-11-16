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
    public partial class CompanyInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users _user;
        private static int userId;
        List<Company> companyList = new List<Company>();

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=default.aspx");
                else
                    Response.Redirect("LogIn.aspx?refPage=default.aspx?" + str);
            }
            if (!IsPostBack)
            {
                userId = 1;

                this.LoadAllCompany();
                this.Clear();
                this.LoadCompanyTable();

            }
            this.LoadCountryDropdown();
            this.LoadCompanyTable();
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
        public void LoadAllCompany()
        {
            try
            {
                Company aCompany = new Company();
                companyList = aCompany.GetAllCompany(0);
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }

        public void LoadCompanyTable()
        {
            try
            {
                companyTableBody.InnerHtml = "";
                string htmlContent = "";
                foreach (Company comp in companyList)
                {
                    htmlContent += "<tr>";
                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th><th>{7}</th><th>{8}</th>", comp.CompanyName, comp.Address, comp.Phone, comp.Email, comp.Web, comp.LogoPath, comp.UpdateBy, comp.UpdateDate, comp.IsActive);
                    htmlContent += "</tr>";
                }

                companyTableBody.InnerHtml += htmlContent;
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }



        public void LoadTable()
        {
            try
            {
                string tableData = "";


                foreach (Company company in companyList)
                {
                    tableData += "<tbody><tr><td>'" + company.CompanyName + "'</td><td>'" + company.Address + "'</td><td>'" + company.Phone + "'<td><td>'" + company.Email + "'<td><td>'" + company.Web + "'<td><td>'" + company.LogoPath + "'<td><td>'" + company.UpdateBy + "'<td><td>'" + company.UpdateDate + "'<td><td>'" + company.IsActive + "'<td></tr></tbody>";
                }
                // tableBody.InnerHtml = tableData;
            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (txtCompanyName.Value == string.Empty)
            {
                Alert.Show("Please enter the company name.");
                txtCompanyName.Focus();
                return;
            }

            Company newCompany = new Company();

            newCompany.CompanyName = txtCompanyName.Value;

            newCompany.Address = txtAddress.Value;
            newCompany.Phone = txtPhoneNo.Value;
            newCompany.Email = txtEmail.Value;
            newCompany.Web = txtWeb.Value;
            newCompany.LogoPath = txtLogoPath.Value;


            // newCompany.UpdateBy = user.UserId;
            newCompany.UpdateBy = _user.UserId;
            newCompany.UpdateDate = DateTime.Now;
            newCompany.IsActive = chkIsActive.Checked;

            Addresses address = new Addresses();
            address.SourceType = "Company";
            address.SourceId = _user.CompanyId;
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
            address.CompanyId = _user.CompanyId;

           

            int success = newCompany.InsertCompany();
            //address.InsertAddresses();
            if (success > 0)
            {
                Alert.Show("Saved Company Information Successfully!");
                this.LoadAllCompany();
                this.Clear();
                this.LoadCompanyTable();
            }
            else
            {
                Alert.Show("Error occured !");
            }
            //}
            //catch (Exception ex)
            //{
            //    Alert.Show(ex.Message);
            //}
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();

        }
        protected void btnNext_Click(object sender, EventArgs e)
        {

        }

        protected void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            txtCompanyName.Value = "";
            txtAddress.Value = "";
            txtEmail.Value = "";
            txtWeb.Value = "";
            txtPhoneNo.Value = "";
            txtLogoPath.Value = "";
            chkIsActive.Checked = false;
            isNewEntry = true;
        }

        protected void countryDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {

        }

        protected void countryDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }

        protected void cityDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
        }

        protected void cityDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }
    }
}
