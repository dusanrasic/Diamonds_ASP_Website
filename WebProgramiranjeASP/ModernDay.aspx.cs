using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProgramiranjeASP.BusinessLayer;

namespace WebProgramiranjeASP
{
    public partial class ModernDay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpModernDaySelect ohs = new OpModernDaySelect();
            OperationResult obj = OperationManager.Singleton.executeOperation(ohs);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj.DbItems;
                ModernDayDb[] moderns = items.Cast<ModernDayDb>().ToArray();

                modern.InnerHtml += "<h1>" + moderns[0].Title + "</h1><p>" + moderns[0].Text + "</p>";

            }
        }
    }
}