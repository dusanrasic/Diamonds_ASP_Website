using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProgramiranjeASP.BusinessLayer;

namespace WebProgramiranjeASP
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:contactForm();", true);
            if(Session["username"] == null)
            {
                comForm.Visible = false;
                notice.Visible = true;
                awesomeForm.Visible = true;
            }
            else
            {
                comForm.Visible = true;
                notice.Visible = false;
                awesomeForm.Visible = false;
            }
            
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            string text = commText.Text;
            string user = Session["username"].ToString();

            OpContactInsert oui = new OpContactInsert();
            oui.Contact = new ContactDb { Text = text, User=user };
            OperationResult obj = OperationManager.Singleton.executeOperation(oui);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
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
                

                comForm.Visible = true;
                notice.Visible = false;
                awesomeForm.Visible = false;

                if (users[0].IdFunction == 1) {
                    Session["function"] = users[0].IdFunction;
                }
                Response.Redirect(Request.RawUrl);
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;
            string mail = email.Text;
            OpUserInsert oui = new OpUserInsert();
            oui.User = new UserDb { UserName = user, Password = pass, Mail = mail, IdFunction = 2 };
            OperationResult obj = OperationManager.Singleton.executeOperation(oui);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                OpUserSelect ohs = new OpUserSelect();
                ohs.Criteria = new CriteriaUser { UserName = user, Password = pass };
                OperationResult res = OperationManager.Singleton.executeOperation(ohs);
                if ((res == null) || (!res.Status))
                {
                    return;
                }
                else
                {
                    DbItem[] items = res.DbItems;
                    UserDb[] users = items.Cast<UserDb>().ToArray();

                    Session["username"] = users[0].UserName;
                    Session["function"] = users[0].IdFunction;

                    comForm.Visible = true;
                    notice.Visible = false;
                    awesomeForm.Visible = false;

                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
}