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
    public partial class SupplierInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users user;
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            user = (Users)Session["user"];
            if (Session["savedSupplicerMessage"] != null)
            {
                string msg = Session["savedSupplicerMessage"].ToString();
                Alert.Show(msg);
                Session["savedSupplicerMessage"] = null;
            }
            this.LoadCountryDropDownList();
            this.Show();
        }

        private void LoadCountryDropDownList()
        {
            countryDropDownList.DataSource = Country.CountryList();
            countryDropDownList.DataBind();
        }

        public void Show()
        {
             


            try
            {
                suplierTableBody.InnerHtml = "";
                string htmlContent = "";
                List<Supplier> departmentList = new List<Supplier>();
                Supplier aDepartment = new Supplier();
                departmentList = aDepartment.GetAllSupplier(_company.CompanyId);
                foreach (Supplier aDepo in departmentList)
                {
                    
                    htmlContent += "<tr>";


                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th></tr>", aDepo.SupplierName, aDepo.IsActive, aDepo.UpdateDate, aDepo.TotalDebit, aDepo.TotalCredit);
                    htmlContent += "</tr>";
                }
                suplierTableBody.InnerHtml += htmlContent;

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
                Supplier aSupply = new Supplier();
                List<Supplier> aSuppierList = aSupply.GetAllSupplier(_company.CompanyId);
                long id;
                if (aSuppierList.Count > 0)
                {
                    aSupply = aSuppierList[aSuppierList.Count - 1];
                    id = aSupply.SupplierId + 1;
                }

                else
                    id = 1;
                    
                
                Supplier newSupply = new Supplier();
                newSupply.SupplierId = id;
                newSupply.SupplierName = txtSupplierName.Value;
                newSupply.IsActive = true;
                newSupply.CompanyId = _company.CompanyId;
                newSupply.UpdateBy = user.UserId;
                newSupply.UpdateDate = DateTime.Now;
                newSupply.TotalDebit = int.Parse(txtTotalDebit.Value);
                newSupply.TotalCredit = int.Parse(txtTotalCredit.Value);
                newSupply.Balance = newSupply.TotalCredit - newSupply.TotalDebit;
                Addresses aAddresses = new Addresses();
                aAddresses.SourceType = "Supplier";
                aAddresses.SourceId = id;
                aAddresses.AddressType = "Main Address";
                aAddresses.AddressLine1 = txtAddressLine1.Value;
                aAddresses.AddressLine2 = txtAddressLine2.Value;
                aAddresses.CountryId = int.Parse(countryDropDownList.SelectedIndex.ToString());
                aAddresses.City = txtCity.Value;
                aAddresses.ZipCode = txtZipCode.Value;
                
                aAddresses.CompanyId = _company.CompanyId;
                int chk1 = newSupply.InsertSupplier();
                int chk2 = aAddresses.InsertAddresses();
                if (chk1 > 0 && chk2 > 0)
                {
                    Session["savedSupplicerMessage"] = "Saved Successfully";
                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    Alert.Show("Error occured while inserting supplier information,please check the input data again. Don't use special character in Debit or Credit Section . Use the amount number there.");
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