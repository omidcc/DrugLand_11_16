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
    public partial class JournalMasterList : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users user;
        private Company _company=new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            if (!IsPostBack)
            {
                user = (Users)Session["user"];
            }
         
            this.LoadJournalTable();
        }
       
        
        void LoadJournalTable()
        {
            try
            {
                journalMasterTableBody.InnerHtml = "";
                List<JournalMaster> myJournalMasters = new List<JournalMaster>(); 
                JournalMaster aJournalMaster=new JournalMaster();
                myJournalMasters = aJournalMaster.GetAllJournalMaster(_company.CompanyId);
                string htmlContent = "";
                foreach (JournalMaster objMaster in myJournalMasters)
                {
                    htmlContent += "<tr>";
                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th>",objMaster.JournalDate,objMaster.JournalType,objMaster.JournalDescription,objMaster.UpdateBy,objMaster.UpdateDate,objMaster.ApprovedBy,objMaster.ApprovedDate );
                    htmlContent += "</tr>";
                }

                journalMasterTableBody.InnerHtml += htmlContent;
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }
    }
}