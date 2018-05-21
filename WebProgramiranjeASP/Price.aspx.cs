using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProgramiranjeASP.BusinessLayer;

namespace WebProgramiranjeASP
{
    public partial class Price : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpPriceSelect ohs = new OpPriceSelect();
            OperationResult obj = OperationManager.Singleton.executeOperation(ohs);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj.DbItems;
                PriceDb[] prices = items.Cast<PriceDb>().ToArray();

                price.InnerHtml += "<h1>"+prices[0].Title+"</h1><p>"+prices[0].Text+"</p>";
            }
        }
    }
}