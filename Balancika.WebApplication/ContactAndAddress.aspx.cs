using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class ContactAndAddress : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users user;
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            if (Session["savedAddressMessage"] != null)
            {
                string msg = Session["savedAddressMessage"].ToString();
                Alert.Show(msg);
                Session["savedAddressMessage"] = null;
            }
            if (Session["savedContactMessage"]!=null)
            {
                string msg = Session["savedContactMessage"].ToString();
                Alert.Show(msg);
                Session["savedContactMessage"] = null;
            }
            
            user = (Users) Session["user"];
                
            
            this.LoadBillingCountryDropDownList();
            this.LoadShippingCountryDropDownList();
            this.LoadContactInformationList();
            this.LoadDesignationDropDownList();
        }

        private void LoadDesignationDropDownList()
        {
            Designation aDeg=new Designation();
            List<Designation> designationList =aDeg.GetAllDesignation(_company.CompanyId);
            designationDropDownList.DataSource = designationList;
            designationDropDownList.DataTextField = "Designation";
            designationDropDownList.DataValueField = "DesignationId";
            designationDropDownList.DataBind();
        }

        protected void shippingCountryDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }

        public void LoadBillingCountryDropDownList()
        {
            billingCountryDropDownList.DataSource = Country.CountryList();
            billingCountryDropDownList.DataBind();
        }

        public void LoadShippingCountryDropDownList()
        {
            shippingCountryDropDownList.DataSource = Country.CountryList();
            shippingCountryDropDownList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
        }

        protected void btnBillingInformationSave_Click(object sender, EventArgs e)
        {
            // shippinhgAddressInformationBoxBody.Visible = false;
            //try
            //{

                Addresses billingAddress = new Addresses();
                List<Addresses> addressList = billingAddress.GetAllAddresses(_company.CompanyId);
                Addresses tempAddress = addressList[addressList.Count - 1];
                long id = tempAddress.AddressId + 1;
                billingAddress.AddressId = id;
                billingAddress.SourceId = user.UserId;
                billingAddress.SourceType = "Company";
                billingAddress.AddressType = "Billing Address";
                billingAddress.AddressLine1 = txtBillingAddressLine1.Value;
                billingAddress.AddressLine2 = txtBillingAddressLine2.Value;
                billingAddress.City = txtBillingCity.Value;
                billingAddress.ZipCode = txtBillingZipCode.Value;
                billingAddress.CountryId = int.Parse(billingCountryDropDownList.SelectedIndex.ToString());
                billingAddress.Phone = txtBillingPhone.Value;
                billingAddress.Mobile = txtBillingMobile.Value;
                billingAddress.Email = txtBillingEmail.Value;
                billingAddress.Web = txtBillingWeb.Value;
                billingAddress.CompanyId = _company.CompanyId;
                int save = billingAddress.InsertAddresses();
                if (save > 0)
                {
                    Session["savedAddressMessage"] = "Address saved successfully";
                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    Alert.Show("Error Occured while inserting a new user");
                }
           
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtBillingAddressLine1.Value =
                txtBillingAddressLine2.Value =
                    txtBillingCity.Value =
                        txtBillingMobile.Value =
                            txtBillingPhone.Value = txtBillingWeb.Value = txtBillingZipCode.Value = "";

        }

        protected void btnShippingClear_Click(object sender, EventArgs e)
        {
            txtShippingaddressLine1.Value =
                txtShippingaddressLine2.Value =
                    txtShippingCity.Value =
                        txtShippingMobile.Value =
                            txtShippingPhone.Value = txtShippingWeb.Value = txtShippingZipCode.Value = "";

        }

        protected void btnShippingInformationSave_Click(object sender, EventArgs e)
        {
            try
            {

                Addresses shippingAddress = new Addresses();
                List<Addresses> addressList = shippingAddress.GetAllAddresses(_company.CompanyId);
                Addresses tempAddress = addressList[addressList.Count - 1];
                long id = tempAddress.AddressId + 1;
                shippingAddress.AddressId = id;

                shippingAddress.SourceId = user.UserId;
                shippingAddress.SourceType = "Company";
                shippingAddress.AddressType = "Shipping Address";
                shippingAddress.AddressLine1 = txtShippingaddressLine1.Value;
                shippingAddress.AddressLine2 = txtShippingaddressLine2.Value;
                shippingAddress.City = txtShippingCity.Value;
                shippingAddress.ZipCode = txtShippingZipCode.Value;
                shippingAddress.CountryId = int.Parse(shippingCountryDropDownList.SelectedIndex.ToString());
                shippingAddress.Phone = txtShippingPhone.Value;
                shippingAddress.Mobile = txtShippingMobile.Value;
                shippingAddress.Email = txtShippingEmail.Value;
                shippingAddress.Web = txtShippingWeb.Value;
                shippingAddress.CompanyId = _company.CompanyId;
                int save = shippingAddress.InsertAddresses();
                if (save > 0)
                {
                    Session["savedAddressMessage"] = "Address saved successfully";
                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    Alert.Show("Error Occured while inserting a new user");
                }
            }
            catch (Exception exp)
            {

                Alert.Show(exp.Message);
            }
        }

        protected void billingCountryDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }

        protected void contactDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }

        protected void btnContactInformationSave_Click(object sender, EventArgs e)
        {
            try
            {
                ContactInformationSave();

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);

            }
        }

        protected void btnContactInformationSaveMore_Click(object sender, EventArgs e)
        {
            try
            {
                int res;
                res=ContactInformationSave();
                if (res > 0)
                {
                    Alert.Show("Contact Information Saved Successfully");
                    contactInformationBoxBody.Visible = false;
                }
                else
                {
                    Alert.Show("Error occured while saving contact information");
                }
            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }

        public int ContactInformationSave()
        {
            
            try
            {
                Contacts newContacts = new Contacts();
                List<Contacts> contactList = newContacts.GetAllContacts(_company.CompanyId);
                long ip=0;
                if (contactList.Count > 0)
                {
                    Contacts temcon = contactList[contactList.Count - 1];
                    ip = temcon.ContactId + 1;
                }
               
                newContacts.ContactId = ip;
                newContacts.CompanyId = _company.CompanyId;
                newContacts.SourceType = "Name";
                newContacts.SourceId = user.UserId;
                newContacts.ContactName = txtContactName.Value;
                newContacts.ContactDesignation = designationDropDownList.SelectedItem.Value;
                newContacts.IsMainContact = chkIsMain.Checked;
                newContacts.Phone = txtContactPhone.Value;
                newContacts.Mobile = txtContactMobile.Value;
                newContacts.Email = txtContactEmail.Value;
                int result = newContacts.InsertContacts();
                txtContactEmail.Value = txtContactName.Value = txtContactPhone.Value = txtContactMobile.Value = "";
                chkIsMain.Checked = false;
                if (result > 0)
                {
                    Session["savedContactMessage"] = "Contact saved successfully";
                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    Alert.Show("Error Occured while inserting a new user");
                }
                return 1;

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
                return 0;
            }
        }

        public void LoadContactInformationList()
        {
            try
            {
                Contacts aContact = new Contacts();
                string htmlContent = "";
                List<Contacts> aContactList = aContact.GetAllContacts(_company.CompanyId);

                contactInformationTable.InnerHtml = "";
                foreach (Contacts contact in aContactList)
                {
                    htmlContent +=
                        String.Format(
                            @"<tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th><th>{7}</th></tr>",
                            contact.SourceType, contact.SourceId, contact.ContactName, contact.ContactDesignation,
                            contact.IsMainContact, contact.Phone, contact.Mobile, contact.Email);

                }
                contactInformationTable.InnerHtml += htmlContent;

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }


    }
}
