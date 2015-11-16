using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;

namespace Balancika
{
    public partial class BankInfoDetails : System.Web.UI.Page
    {
        private static bool isNewEntry = true;
        private static int userId;
        private Users _user;
        List<Bank> objBankList = new List<Bank>();
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];

            AccountInfoPageDiv.Disabled = true;
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=default.aspx");
                else
                    Response.Redirect("LogIn.aspx?refPage=default.aspx?" + str);
            }
            this.LoadAccountTypeDropDown();
            this.LoadBankTable();

            this.LoadBankNames();
            this.LoadAccountsTable();
        }
        private void LoadAccountsTable()
        {
            try
            {
                tableBody.InnerHtml = "";
                string htmlContent = "";
                BankAccounts accounts = new BankAccounts();
                List<BankAccounts> allaAccountses = accounts.GetAllBankAccounts(_company.CompanyId);
                foreach (BankAccounts acc in allaAccountses)
                {

                    htmlContent += "<tr>";
                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th>",  acc.BranchName, acc.AccountNo, acc.AccountTitle, acc.AccountType, acc.OpeningDate, acc.IsActive);
                    htmlContent += "</tr>";
                }

                tableBody.InnerHtml += htmlContent;
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }
        void LoadBankNames()
        {

            List<Bank> allBanks = new Bank().GetAllBank(1);
            List<string> nameList = new List<string>();
            foreach (Bank bank in allBanks)
            {
                nameList.Add(bank.BankName);
            }
            bankIdRadDropDownList1.DataSource = nameList;
            bankIdRadDropDownList1.DataBind();
        }
        void LoadAccountTypeDropDown()
        {
            List<string> myList = new List<string>();

            myList.Add("Current");
            myList.Add("Savings");
            myList.Add("Marchent");

            accountTypeRadDropDownList1.DataSource = myList;
            accountTypeRadDropDownList1.DataBind();
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

        protected void btnSaveAccount_Click(object sender, EventArgs e)
        {
            BankAccounts objAccounts = new BankAccounts();

            List<BankAccounts> myList = objAccounts.GetAllBankAccounts(_user.CompanyId);

            objAccounts.BankAccountId = myList.Count+1;
            objAccounts.BranchName = txtBranchName.Value;
            objAccounts.AccountNo = txtAccountNo.Value;
            objAccounts.AccountTitle = txtTitle.Value;
            objAccounts.AccountType = accountTypeRadDropDownList1.SelectedItem.Text;
            objAccounts.OpeningDate = (RadDatePicker2.SelectedDate.ToString());
            objAccounts.CompanyId = _company.CompanyId;
            objAccounts.IsActive = chkIsActive.Checked;

            int success = objAccounts.InsertBankAccounts();

            if (success > 0)
            {
                this.LoadAccountsTable();
                Session["saveBankAccountInfo"] = ("Accounts info Saved successfully");
                Response.Redirect(Request.RawUrl);


                //
                this.Clear();
            }
            else
            {
                Alert.Show("Error occured");
            }
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnBankInfoClear_Click(object sender, EventArgs e)
        {
        }

        protected void btnSaveBankInfo_Click(object sender, EventArgs e)
        {
            Bank objBank = new Bank();

            List<Bank> myList = objBank.GetAllBank(_company.CompanyId);
            int bankId = myList.Count;

            objBank.BankId = bankId;
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
            sucess = objBank.InsertBank();

            if (sucess > 0)
            {
                Alert.Show("Bank info Saved successfully");
                this.Clear();
                this.LoadBankTable();
                this.LoadBankNames();
                AccountInfoPageDiv.Disabled = false;
            }
        }
        private void LoadBankTable()
        {
            Bank objBank = new Bank();
            tableBankBody.InnerHtml = "";
            string htmlContent = "";
            objBankList = objBank.GetAllBank(_company.CompanyId);
            foreach (Bank bank in objBankList)
            {
                htmlContent += "<tr>";
                htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th><th>{7}</th><th>{8}</th>", bank.BankCode, bank.BankName, bank.ContactPerson, bank.ContactDesignation, bank.ContactNo, bank.ContactEmail, bank.IsActive, bank.UpdatedBy, bank.UpdatedDate);
                htmlContent += "</tr>";
            }

            tableBankBody.InnerHtml += htmlContent;
        }
        private void Clear()
        {
            labelTxt.Text = "";
            txtBankCode.Value = "";
            txtBankName.Value = "";
            txtContactPerson.Value = "";
            txtDesignation.Value = "";
            txtContactNo.Value = "";
            txtEmail.Value = "";
            chkIsActive.Checked = false;

        }

    }
}