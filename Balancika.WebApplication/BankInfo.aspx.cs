using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class BankInfo : System.Web.UI.Page
    {
        private static bool isNewEntry = true;
        private static int userId;
        private Users _user;
        List<Bank> objBankList = new List<Bank>();
        private Company _company=new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company) Session["Company"];

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
            }
            this.LoadBankTable();
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
        private void LoadBankTable()
        {
            Bank objBank = new Bank();
            //tableBankBody.InnerHtml = "";
            string htmlContent = "";
            objBankList = objBank.GetAllBank(_company.CompanyId);
            
            RadGrid1.DataSource = objBankList;
            RadGrid1.Rebind();


            foreach (Bank bank in objBankList)
            {
                htmlContent += "<tr>";
                htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th><th>{7}</th><th>{8}</th>", bank.BankCode, bank.BankName, bank.ContactPerson, bank.ContactDesignation, bank.ContactNo, bank.ContactEmail, bank.IsActive, bank.UpdatedBy, bank.UpdatedDate);
                htmlContent += "</tr>";
            }

            //tableBankBody.InnerHtml += htmlContent;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            Bank objBank = new Bank();

            objBank.BankCode = txtBankCode.Value;
            objBank.BankName = txtBankName.Value;
            objBank.ContactPerson = txtContactPerson.Value;
            objBank.ContactDesignation = txtDesignation.Value;
            objBank.ContactNo = txtContactNo.Value;
            objBank.ContactEmail = txtEmail.Value;
            objBank.CompanyId = _company.CompanyId;
            objBank.UpdatedBy = _user.UserId;
            objBank.UpdatedDate = DateTime.Today;
            objBank.IsActive = chkIsActive.Checked;

            int sucess = 0;
            if (lblId.Text == "" || lblId.Text == "0")
            {
                objBank.BankId = new Bank().GetMaxBankId(objBank.CompanyId);
                objBank.BankId++;

                sucess = objBank.InsertBank();
            }
            else
            {
                objBank.BankId = int.Parse(lblId.Text==""?"0":lblId.Text);
                sucess = objBank.UpdateBank();
            }

            if (sucess > 0)
            {
                Alert.Show("Bank info saved successfully");
                this.Clear();
                this.LoadBankTable();
            }


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
            isNewEntry = true;
        }

        private void Clear()
        {
            lblId.Text = "";
            labelTxt.Text = "";
            txtBankCode.Value = "";
            txtBankName.Value = "";
            txtContactPerson.Value = "";
            txtDesignation.Value = "";
            txtContactNo.Value = "";
            txtEmail.Value = "";
            chkIsActive.Checked = false;

        }

        protected void RadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {

        }
        protected void RadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }

        protected void RadGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "btnSelect")
            {
                GridDataItem item = (GridDataItem)e.Item;

                lblId.Text = item["colId"].Text;
                txtBankName.Value = item["colName"].Text.Trim();
            }
            else if (e.CommandName == "btnDelete")
            {
                GridDataItem item = (GridDataItem)e.Item;

                lblId.Text = item["colId"].Text;

                int delete = new Bank().DeleteBankByBankId(int.Parse(lblId.Text));

                if (delete == 0)
                {
                    Alert.Show("Data was not delete..");
                }
                //else
                    //LoadListTable();
            }
        }
    }
}