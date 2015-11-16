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
    public partial class UserInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users user;
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            user = (Users)Session["user"];
            if (!IsPostBack)
            {
                if (Session["savedMessage"]!=null)
                {
                    Alert.Show("Successfully saved information");
                    Session["savedMessage"] = null;

                }
                this.LoadCompanyIdDropDown();
                this.LoadUserInfoTable();
            }


        }

        private void LoadUserInfoTable()
        {
            Users newUsers = new Users();
            List<Users> userList = new List<Users>();
            userList = newUsers.GetAllUsersList();
            Company aCompanyList = new Company();

            List<Company> companyNameList = aCompanyList.GetAllCompany(_company.CompanyId);


            string htmlContent = "";
           

            foreach (Users aUserInfo in userList)
            {
                if ((aUserInfo.UserName == "Super") || (aUserInfo.UserName == "Admin"))
                {
                    continue;
                }
                else
                {
                    string companyName = "";
                    foreach (Company aCompany in companyNameList)
                    {
                        if (aCompany.CompanyId == aUserInfo.CompanyId)
                            companyName = aCompany.CompanyName;
                    }
                    htmlContent +=
                        String.Format(
                            @"<tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th></tr>", aUserInfo.UserName,
                            aUserInfo.UpdateBy, aUserInfo.UpdateDate,  aUserInfo.IsActive
                            );
                }
              
            }
            userInformationTableBody.InnerHtml += htmlContent;

        }
        void LoadCompanyIdDropDown()
        {
            try
            {
                List<Company> companyList = new List<Company>();
                Company aCompany = new Company();

                companyList = aCompany.GetAllCompany(_company.CompanyId);

                CompanyNameDropDownList.DataSource = companyList;
                CompanyNameDropDownList.DataTextField = "CompanyName";
                CompanyNameDropDownList.DataValueField = "CompanyId";
                CompanyNameDropDownList.DataBind();
            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Users aUsers=new Users();
                List<Users> userList = aUsers.GetAllUsersActiceInactive(_company.CompanyId);
                Users newU = userList[userList.Count - 1];
                int id = (newU.UserId) + 1;
                Users aUser = new Users();
                aUser.UserId = id;
                aUser.UserName = txtUsername.Value;
                aUser.UserPassword = txtPassword.Value;
                aUser.UpdateBy = user.UserId;
                aUser.UpdateDate = DateTime.Now;
                aUser.IsActive = (chkIsActive.Checked);
                aUser.CompanyId = int.Parse(CompanyNameDropDownList.SelectedItem.Value);
                int chk = aUser.InsertUsers();
                
                //Response.Redirect(Request.RawUrl);
                if (chk > 0)
                {
                    Session["savedMessage"] = true;
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

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void companyIdDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {

        }

        protected void companyIdDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }
    }
}