using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProgramiranjeASP.BusinessLayer;

namespace WebProgramiranjeASP
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            linkAdminPanel.Visible = false;
            linkLogOut.Visible = false;
            string[] file = Request.CurrentExecutionFilePath.Split('/');
            string fileName = file[file.Length - 1];
            if(fileName == "Contact.aspx")
            {
                formLogFooter.Visible = false;

            }
            if (fileName == "AdminPanel.aspx")
            {
                formLogFooter.Visible = false;
            }
            OpNavigationSelect ohs = new OpNavigationSelect();
            OperationResult obj = OperationManager.Singleton.executeOperation(ohs);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj.DbItems;
                NavigationDb[] menus = items.Cast<NavigationDb>().ToArray();

                menu.InnerHtml += "<li><a href='" + menus[0].Location + "'>" + menus[0].Name + "</a></li>" +
                    "<li><a href='" + menus[1].Location + "'>" + menus[1].Name + "</a></li>" +
                    "<li><a href='" + menus[4].Location + "'>" + menus[4].Name + "</a></li>" +
                    "<li><a href='" + menus[5].Location + "'>" + menus[5].Name + "</a></li>" +
                    "<li><a href='" + menus[2].Location + "'>" + menus[2].Name + "</a></li>" +
                    "<li><a href='" + menus[3].Location + "'>" + menus[3].Name + "</a></li>";
                if ((Session["username"] != null) && (Session["function"] == null))
                {

                    menu.InnerHtml += "<li><a href='LogOut.aspx'>LogOut</a></li>";
                }
                if((Session["username"] != null) && (Session["function"] != null))
                {
                    menu.InnerHtml += "<li><a href='AdminPanel.aspx'>AdminPanel</a></li>" +
                    "<li><a href='LogOut.aspx'>LogOut</a></li>";
                }
            }
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            string user;
            string pass;

            user = username.Text;
            pass = password.Text;

            OpUserSelect ohs = new OpUserSelect();
            ohs.Criteria = new CriteriaUser { UserName = user, Password = pass };
            OperationResult obj = OperationManager.Singleton.executeOperation(ohs);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj.DbItems;
                UserDb[] users = items.Cast<UserDb>().ToArray();

                Session["username"] = users[0].UserName;

                

                if (users[0].IdFunction == 1)
                {
                    Session["function"] = users[0].IdFunction;
                    Response.Redirect("AdminPanel.aspx");
                    
                }
                else
                {
                    Response.Redirect("Index.aspx");
                    
                }

            }
        }
    }
}