using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Balancika
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Menu"] != null)
                {
                    string menu = Session["Menu"].ToString();
                    ltrlMenu.Text = menu;
                }


            }
        }
    }

}