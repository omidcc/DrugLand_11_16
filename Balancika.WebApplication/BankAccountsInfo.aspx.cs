using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using BALANCIKA.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class BankAccountsInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users _user;
        private static int userId;
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            if (Session["saveBankAccountInfo"] != null)
            {
                string msg = Session["saveBankAccountInfo"].ToString();
                Session["saveBankAccountInfo"] = null;
                Alert.Show(msg);
            }
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

            this.LoadAccountTypeDropDown();
         
            this.LoadBankNames();
           this.LoadAccountsTable();
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
        void LoadBankNames()
        {
            
            List<Bank>allBanks=new Bank().GetAllBank(1);
            List<string>nameList=new List<string>();
            foreach (Bank bank in allBanks)
            {
                nameList.Add(bank.BankName);
            }
            bankIdRadDropDownList1.DataSource = nameList;
            bankIdRadDropDownList1.DataBind();
        }
        void LoadAccountTypeDropDown()
        {
            List<string>myList=new List<string>();

            myList.Add("Current");
            myList.Add("Savings");
            myList.Add("Marchent");

            accountTypeRadDropDownList1.DataSource = myList;
            accountTypeRadDropDownList1.DataBind();
        }

       
        
        protected void accountTypeRadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void accountTypeRadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            BankAccounts objAccounts=new BankAccounts();

            List<BankAccounts> myList = objAccounts.GetAllBankAccounts(_user.CompanyId);

            objAccounts.BankAccountId = myList.Count;
            objAccounts.BranchName = txtBranchName.Value;
            objAccounts.AccountNo = txtAccountNo.Value;
            objAccounts.AccountTitle = txtTitle.Value;
            objAccounts.AccountType = accountTypeRadDropDownList1.SelectedItem.Text;
            objAccounts.OpeningDate =(RadDatePicker2.SelectedDate.ToString());
            objAccounts.CompanyId = _company.CompanyId;
            objAccounts.IsActive = chkIsActive.Checked;

            int success = objAccounts.InsertBankAccounts();

            if (success > 0)
            {
                Session["saveBankAccountInfo"]=("Accounts info Saved successfully");
                Response.Redirect(Request.RawUrl);
                this.LoadAccountsTable();
               
            
                //
                this.Clear();
            }
            else
            {
                Alert.Show("Error occured");
            }


        }

        private void Clear()
        {
            txtBranchName.Value = "";
            txtAccountNo.Value = "";
            txtTitle.Value = "";
            chkIsActive.Checked = false;

        }

        private void LoadAccountsTable()
        {
            try
            {
                tableBody.InnerHtml = "";
                string htmlContent = "";
                BankAccounts accounts=new BankAccounts();
                List<BankAccounts> allaAccountses = accounts.GetAllBankAccounts(_company.CompanyId);
                foreach (BankAccounts acc in allaAccountses)
                {
                    
                    htmlContent += "<tr>";
                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th>", acc.BankId,acc.BranchName, acc.AccountNo, acc.AccountTitle, acc.AccountType, acc.OpeningDate, acc.IsActive);
                    htmlContent += "</tr>";
                }

                tableBody.InnerHtml += htmlContent;
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
           
        }

        protected void bankIdRadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void bankIdRadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
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