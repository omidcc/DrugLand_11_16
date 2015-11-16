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
    public partial class JournalInformationDetail : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users user;
        private Company _company=new Company();
        protected void Page_Load(object sender, EventArgs e)    
        {

            user = (Users)Session["user"];
            _company = (Company)Session["Company"];
            if (Session["JournalInformationMessage"]!=null)
            {
                string message = (string) Session["JournalInformationMessage"];
                Session["JournalInformationMessage"] = null;
                Alert.Show(message);
            }

            
            _company = (Company)Session["Company"];
            if (!IsPostBack)
            {
                LoadFirstTime();

            }
        }

        public void LoadFirstTime()
        {
            
            this.LoadJournalDropDownList();
            this.LoadCostCenterDropDownList();
            this.LoadJournalAccountNo();
            Session["JournalMaster"] = null;
            Session["JournalDetailsInformation"] = null;
            journalDetailsInformationDiv.Visible = false;
            journalMasterInformationDiv.Visible = true;
            
        }

        private void LoadJournalDetailsDataTable()
        {
            try
            {
                
                string htmlContent = "";
                totalCredit.InnerHtml = "";
                totalDebit.InnerHtml = "";
                BankAccounts aBankAccount = new BankAccounts();
                List<BankAccounts> aBankAccountList = aBankAccount.GetAllBankAccounts(_company.CompanyId);
                List<JournalDetails> aJournalList =(List<JournalDetails>)Session["JournalDetailsInformation"];

                journalDetailsTableBody.InnerHtml = "";
                foreach (JournalDetails Journal in aJournalList)
                {
                    BankAccounts newBankAccounts = new BankAccounts();
                    foreach (var bank in aBankAccountList)
                    {
                        if (bank.BankAccountId == Journal.AccountNo)
                        {
                            newBankAccounts = bank;
                            break;
                        }
                    }
                   
                    htmlContent += String.Format(@"<tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th></tr>", newBankAccounts.AccountNo, newBankAccounts.AccountTitle, Journal.Debit, Journal.Credit, Journal.Description, Journal.VoucherNo);

                }
                var totalCredi = from n in aJournalList select n.Credit;
                var totalDebi = from n in aJournalList select n.Debit;
                Decimal totalCreditbalance = totalCredi.Sum();
                Decimal totalDebitbalance = totalDebi.Sum();
                journalDetailsTableBody.InnerHtml += htmlContent;
                totalDebit.InnerHtml += totalDebitbalance.ToString();
                totalCredit.InnerHtml += totalCreditbalance.ToString();


            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }

        

        private void LoadJournalAccountNo()
        {
            BankAccounts anAccount=new BankAccounts();
            List<BankAccounts> accountList = anAccount.GetAllBankAccounts(_company.CompanyId);
            accountNoDropDownList.DataSource = accountList;
            accountNoDropDownList.DataTextField = "AccountTitle";
            accountNoDropDownList.DataValueField = "BankAccountId";
            accountNoDropDownList.DataBind();


        }

        private void LoadJournalDropDownList()
        {
            try
            {
                ListTable aNewListTable = new ListTable();
                List<ListTable> myList = aNewListTable.GetAllListTable(_company.CompanyId);
                journalTypeDropDownList.DataSource = myList;
                journalTypeDropDownList.DataTextField = "ListType";
                journalTypeDropDownList.DataValueField = "ListType";
                journalTypeDropDownList.DataBind();

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }
        private void LoadCostCenterDropDownList()
        {
            try
            {
                CostCenter aCost = new CostCenter();
                List<CostCenter> costCenterList = aCost.GetAllCostCenter(_company.CompanyId);
                costCenterDropDownList.DataSource = costCenterList;
                costCenterDropDownList.DataTextField = "CostCenterName";
                costCenterDropDownList.DataValueField = "CostCenterId";
                costCenterDropDownList.DataBind();

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }

        protected void journalTypeDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void btnJournalMasterClear_Click(object sender, EventArgs e)
        {
            txtJournalDescription.Value = "";
            
        }

       

       

        protected void btnJournalDetailsInformationClear_Click(object sender, EventArgs e)
        {
            txtJournalDetailsCredit.Value = "";
            txtJournalDetailsDebit.Value = "";
            txtJorunalDetailsDescription.Value = "";
        }

        protected void btnClearJournalDetailsInformation_Click(object sender, EventArgs e)
        {
            LoadFirstTime();
        }

        protected void btnSaveJournalDetailsInformation_Click(object sender, EventArgs e)
        {
            JournalMaster aJournalMaster = (JournalMaster) Session["JournalMaster"];
            List<JournalDetails> aJournalList = (List<JournalDetails>)Session["JournalDetailsInformation"];
            var totalCredi = from n in aJournalList select n.Credit;
            var totalDebi = from n in aJournalList select n.Debit;
            Decimal totalCreditbalance = totalCredi.Sum();
            Decimal totalDebitbalance = totalDebi.Sum();
            if (totalCreditbalance != totalDebitbalance)
            {
                Alert.Show("Total Debit and Credit Balance is not same! Please check again!");
            }
            else
            {
                int chk1=aJournalMaster.InsertJournalMaster();
                bool checker=true;
                string message;
                foreach (JournalDetails journal in aJournalList)
                {
                    int chk2=journal.InsertJournalDetails();
                    if (chk2 < 0)
                    {
                       
                        checker = false;
                        break;
                    }

                }
               message =(checker?"Saved all journal information successfully":"Error occured while saving journal information");
                Session["JournalInformationMessage"] = message;
                LoadFirstTime();
                Response.Redirect(Request.RawUrl);


            }
            
        }

        protected void btnSaveNewJournalMasterInformation_Click(object sender, EventArgs e)
        {
            JournalMaster newJournalMaster = new JournalMaster();
            List<JournalMaster> journalMasterList = newJournalMaster.GetAllJournalMaster(_company.CompanyId);
            JournalMaster tempJournalMaster = journalMasterList.Count > 0
                ? journalMasterList[journalMasterList.Count - 1]
                : new JournalMaster();
            long id = tempJournalMaster.JournalId + 1;
            newJournalMaster.JournalId = id;
            newJournalMaster.JournalDate = (RadDatePicker1.SelectedDate.ToString());
            newJournalMaster.JournalType = journalTypeDropDownList.SelectedText.ToString();
            newJournalMaster.JournalDescription = txtJournalDescription.Value;
            newJournalMaster.UpdateDate = DateTime.Now;
            newJournalMaster.UpdateBy = user.UserId;
            newJournalMaster.CompanyId = _company.CompanyId;

            newJournalMaster.CostCenterId = int.Parse(costCenterDropDownList.SelectedItem.Value);
            Session["JournalMaster"] = newJournalMaster;

            journalMasterInformationDiv.Visible = false;
            journalDetailsInformationDiv.Visible = true;



        }

        protected void btnSaveJournalSingleDetails_Click(object sender, EventArgs e)
        {
            try
            {
                long id;
                JournalDetails aJournal = new JournalDetails();
                JournalMaster aJournalMaster = (JournalMaster) Session["JournalMaster"];
                List<JournalDetails> journalDetailsList=new List<JournalDetails>();
                JournalDetails lastJournal;
                if (Session["JournalDetailsInformation"] != null)
                {
                    List<JournalDetails> journalList = (List<JournalDetails>)Session["JournalDetailsInformation"];
                    journalDetailsList = journalList;
                    lastJournal = journalList[journalList.Count - 1];
                    id = lastJournal.JournalDetailsId + 1;
                }
                else
                {
                    List<JournalDetails> journalList = aJournal.GetAllJournalDetails(_company.CompanyId);
                    lastJournal = journalList.Count>0?(JournalDetails)journalList[journalList.Count - 1]:new JournalDetails();
                   id = lastJournal.JournalDetailsId + 1;
                }
                
                
                aJournal.MasterId = aJournalMaster.JournalId;
                aJournal.JournalDetailsId = id;
                aJournal.AccountNo = int.Parse(accountNoDropDownList.SelectedItem.Value);
                aJournal.Debit = Convert.ToDecimal(txtJournalDetailsDebit.Value!=null?txtJournalDetailsDebit.Value:"0");
                aJournal.Credit = Convert.ToDecimal(txtJournalDetailsCredit.Value!=null?txtJournalDetailsCredit.Value:"0");
                aJournal.Description = txtJorunalDetailsDescription.Value;
                aJournal.VoucherNo = "JV-" + Convert.ToString(lastJournal.JournalDetailsId + 1) + "-" + DateTime.Now.Year.ToString();
                journalDetailsList.Add(aJournal);
                Session["JournalDetailsInformation"] = journalDetailsList;
                LoadJournalDetailsDataTable();
                int success = 1;


                Alert.Show(success > 0 ? "Saved Journal Details Information Successfully" : "Error occured while saving journal information");


            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }

        public void JournalDetailsClear()
        {
            txtJournalDescription.Value = txtJournalDetailsCredit.Value = txtJournalDetailsDebit.Value = "";
        }
    }
}