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
    public partial class ListTableInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users user;
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
              user =(Users) Session["user"];
              if (Session["savedListMessage"] !=null)
              {
                  string msg = Session["savedListMessage"].ToString();
                  Alert.Show(msg);
                  Session["savedListMessage"] = null;
              }
            
            this.GetAllListTable();
            this.LoadListTable();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                ListTable myListTable = new ListTable();
                List<ListTable> aList = myListTable.GetAllListTable(_company.CompanyId);
                
                    ListTable tempListTable = aList[aList.Count - 1];
                   int id = tempListTable.Id + 1;
               
               


                myListTable.ListType = txtListType.Value;
                myListTable.ListId = id ;
                
                myListTable.ListValue = txtListValue.Value;
                myListTable.CompanyId = _company.CompanyId;

                myListTable.IsActive = true;
                myListTable.UpdateBy = user.UserId;
                myListTable.UpdateDate = DateTime.Now;

                int success = myListTable.InsertListTable();

                if (success > 0)
                {
                    Session["savedListMessage"] = "Saved List Table Successfully";
                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    Alert.Show("Error Occured while inserting a new List Table");
                }
            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }



        }

       List<ListTable>myList=new List<ListTable>();
        void GetAllListTable()
        {
            ListTable listTable = new ListTable();
            myList = listTable.GetAllListTable(_company.CompanyId);
        }

        void LoadListTable()
        {
            try
            {
                ListTableBody.InnerHtml = "";
                string htmlContent = "";
                foreach (ListTable list in myList)
                {
                    htmlContent += "<tr>";
                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th>",list.ListType,list.ListId,list.ListValue,list.IsActive,list.UpdateDate );
                    htmlContent += "</tr>";
                }

                ListTableBody.InnerHtml += htmlContent;
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        protected void listIdDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void listIdDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           
        }
    }
}