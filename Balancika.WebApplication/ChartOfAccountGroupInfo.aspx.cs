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
    public partial class ChartOfAccountGroupInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users _user;
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
            this.GetAllCompany();
            this.LoadAccountGroupTable();
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
        protected void companyIdRadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void companyIdRadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            
        }
      ChartOfAccountGroup agroup=new ChartOfAccountGroup();
        List<ChartOfAccountGroup> coaList=new List<ChartOfAccountGroup>();
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChartOfAccountGroup coaGroup=new ChartOfAccountGroup();
            List<ChartOfAccountGroup> coaList = coaGroup.GetAllChartOfAccountGroup(_company.CompanyId);
            int id = 0;
            if (coaList.Count > 0)
            {
                id = coaList.Count;
            }

            coaGroup.CoaGroupId = id+1;
            coaGroup.CoaGroupName = txtGroupName.Value;
            coaGroup.ParentId = coaGroup.CoaGroupId;
            coaGroup.IsActive = true;
            coaGroup.UpdateBy = _user.UserId;
            coaGroup.UpdateDate=DateTime.Now;
            coaGroup.CompanyId = _user.CompanyId;

            int sucess = coaGroup.InsertChartOfAccountGroup();

            if (sucess > 0)
            {
                Alert.Show("Accounts group Insert sucessfully");
                this.Clear();
                this.LoadAccountGroupTable();
            }

        }

        private List<Company> allCompany = new List<Company>();

        void GetAllCompany()
        {
            Company company = new Company();
            allCompany = company.GetAllCompany(_company.CompanyId);
            List<string>nameList=new List<string>();
            foreach (Company com in allCompany)
            {
                nameList.Add(com.CompanyName);
            }
           
        }
        private void Clear()
        {
            txtGroupName.Value = "";
        }

        private void LoadAccountGroupTable()
        {
            try
            {
                coaTableBody.InnerHtml = "";
                string htmlContent = "";
                ChartOfAccountGroup accountGroup = new ChartOfAccountGroup();
                List<ChartOfAccountGroup> allAccountGroups = accountGroup.GetAllChartOfAccountGroup(_company.CompanyId);
                foreach (ChartOfAccountGroup coa in allAccountGroups)
                {
                    htmlContent += "<tr>";
                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th>", coa.CoaGroupName, coa.ParentId, coa.IsActive,  coa.UpdateBy, coa.UpdateDate,coa.CompanyId);
                    htmlContent += "</tr>";
                }

                coaTableBody.InnerHtml += htmlContent;
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }
    }
}