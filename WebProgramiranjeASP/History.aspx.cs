using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProgramiranjeASP.BusinessLayer;

namespace WebProgramiranjeASP
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpHistorySelect ohs = new OpHistorySelect();
            OperationResult obj = OperationManager.Singleton.executeOperation(ohs);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj.DbItems;
                HistoryDb[] histories = items.Cast<HistoryDb>().ToArray();

                history.InnerHtml += "<h1>" + histories[0].Title + "</h1><p>" + histories[0].Text + "</p>";

            }
        }
    }
}