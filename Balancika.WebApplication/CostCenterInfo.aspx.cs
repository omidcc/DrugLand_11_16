using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using BALANCIKA.BLL;

namespace Balancika
{
    public partial class CostCenterInfo : System.Web.UI.Page
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
            this.GetAllCostCentre();
            this.LoadCostCentreTable();
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

        private List<CostCenter> listCenter=new List<CostCenter>();

        void GetAllCostCentre()
        {
            CostCenter center=new CostCenter();
            listCenter = center.GetAllCostCenter(_user.CompanyId);


        }

        void LoadCostCentreTable()
        {
            try
            {
                costTableBody.InnerHtml = "";
                string htmlContent = "";
                foreach (CostCenter center in listCenter)
                {
                    htmlContent += "<tr>";
                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th>",center.CostCenterType,center.CostCenterName,center.IsActive,center.UpdateBy,center.UpdateDate );
                    htmlContent += "</tr>";
                }

                costTableBody.InnerHtml += htmlContent;
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            CostCenter objCenter=new CostCenter();

            objCenter.CostCenterId = listCenter.Count;
            objCenter.CostCenterType = txtCostCenterType.Value;
            objCenter.CostCenterName = txtCostCentreName.Value;
            objCenter.IsActive = chkIsActive.Checked;
            objCenter.CompanyId = _company.CompanyId;
            objCenter.UpdateBy = _user.UserId;
            objCenter.UpdateDate=DateTime.Now.Date;

            int success = objCenter.InsertCostCenter();

            if (success > 0)
            {
                Alert.Show("Cost Center Inserted");
                this.GetAllCostCentre();
                this.LoadCostCentreTable();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }
    }
}