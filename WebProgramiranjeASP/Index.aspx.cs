using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProgramiranjeASP.BusinessLayer;

namespace WebProgramiranjeASP
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpHomeSelect ohs = new OpHomeSelect();
            OperationResult obj = OperationManager.Singleton.executeOperation(ohs);
            if((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj.DbItems;
                HomeDb[] blocks = items.Cast<HomeDb>().ToArray();

                box1.InnerHtml = "<h1>" + blocks[0].BlockTitle + "</h1><p>" + blocks[0].BlockText + "<p>";
                box2.InnerHtml = "<h1>" + blocks[1].BlockTitle + "</h1><p>" + blocks[1].BlockText + "<p>";
                box3.InnerHtml = "<h1>" + blocks[2].BlockTitle + "</h1><p>" + blocks[2].BlockText + "<p>";
                box4.InnerHtml = "<h1>" + blocks[3].BlockTitle + "</h1><p>" + blocks[3].BlockText + "<p>";
                box5.InnerHtml = "<h1>" + blocks[4].BlockTitle + "</h1><p>" + blocks[4].BlockText + "<p>";
                box6.InnerHtml = "<h1>" + blocks[5].BlockTitle + "</h1><p>" + blocks[5].BlockText + "<p>";

            }
        }
    }
}