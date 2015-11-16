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
    public partial class ChartOfAccounting : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users _user;
        private List<Company> allCompanyList = new List<Company>();
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
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
                _user = (Users)Session["user"];
            }
            this.LoadAllCompany();
            this.LoadAccountGroup();
            this.LoadChartTable();
            this.LoadType();
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
     
        private void LoadAllCompany()
        {
            Company company = new Company();
            allCompanyList = company.GetAllCompany(_company.CompanyId);
            List<string> nameList = new List<string>();
            foreach (Company com in allCompanyList)
            {
                nameList.Add(com.CompanyName);
            }
            

        }
        private List<ChartOfAccountGroup>accountGroups=new List<ChartOfAccountGroup>(); 
        private void LoadAccountGroup()
        {
            ChartOfAccountGroup group=new ChartOfAccountGroup();
            List<string> nameList =new List<string>();
            accountGroups = group.GetAllChartOfAccountGroup(_company.CompanyId);
            foreach (ChartOfAccountGroup acc in accountGroups)
            {
                nameList.Add(acc.CoaGroupName);
            }
            chartOfAccountGroupIdDropDownList.DataSource = nameList;
            chartOfAccountGroupIdDropDownList.DataBind();
        }

        void LoadChartTable()
        {
            try
            {
                chartTableBody.InnerHtml = "";
                string htmlContent = "";
                ChartOfAccount coa = new ChartOfAccount();
                List<ChartOfAccount>listGroup=new List<ChartOfAccount>();
                listGroup = coa.GetAllChartOfAccount(_company.CompanyId);
                foreach (ChartOfAccount acc in listGroup)
                {
                    htmlContent += "<tr>";
                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th>", acc.CoaType,acc.CoaGroupId,acc.CoaCode,acc.CoaTitle,acc.IsActive,acc.UpdateBy,acc.UpdateDate);
                    htmlContent += "</tr>";
                }

                chartTableBody.InnerHtml += htmlContent;
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }

        protected void chartOfAccountTypeDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void chartOfAccountTypeDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
         
        }

        protected void chartOfAccountGroupIdDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void chartOfAccountGroupIdDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void parentIdDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
          
        }

        protected void parentIdDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void companyIdRadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void companyIdRadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            ChartOfAccount objChartOfAccount=new ChartOfAccount();
            List<ChartOfAccount> myAccounts = objChartOfAccount.GetAllChartOfAccount(_company.CompanyId);

            objChartOfAccount.CoaId = myAccounts.Count;
            objChartOfAccount.CoaType = chartOfAccountTypeDropDownList.SelectedItem.ToString();
            objChartOfAccount.CoaGroupId = chartOfAccountGroupIdDropDownList.SelectedIndex;
            objChartOfAccount.CoaCode = txtChartOfAccountCode.Value;
            objChartOfAccount.CoaTitle = txtChartOfAccountTitle.Value;
            objChartOfAccount.ParentId = objChartOfAccount.CoaId;
            objChartOfAccount.IsActive = chkIsActive.Checked;
            objChartOfAccount.UpdateBy = _user.UserId;
            objChartOfAccount.UpdateDate = DateTime.Now;
            objChartOfAccount.CompanyId = _company.CompanyId;

            int success = 0;
            success = objChartOfAccount.InsertChartOfAccount();

            if (success > 0)
            {
                Alert.Show("Inserted sucessfully");
               
                this.LoadChartTable();
                this.Clear();
            }

        }

        void LoadType()
        {
            List<string>myList=new List<string>();
            myList.Add("Company Type");
            myList.Add("Employee Type");
            myList.Add("Customer Type");
            myList.Add("Supplier Type");

            chartOfAccountTypeDropDownList.DataSource = myList;
            chartOfAccountTypeDropDownList.DataBind();
        }
        private void Clear()
        {
            txtChartOfAccountCode.Value = "";
            txtChartOfAccountTitle.Value = "";
        }
        

        protected void btnClear_Click(object sender,EventArgs e)
        {
            
        }
    }
}