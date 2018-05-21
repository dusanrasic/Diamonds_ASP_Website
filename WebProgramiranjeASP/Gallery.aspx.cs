using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProgramiranjeASP.BusinessLayer;

namespace WebProgramiranjeASP
{
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpGallerySelect ogs = new OpGallerySelect();
            OperationResult obj = OperationManager.Singleton.executeOperation(ogs);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj.DbItems;
                GalleryDb[] galleries = items.Cast<GalleryDb>().ToArray();

                foreach(GalleryDb item in galleries)
                {
                    rslides.InnerHtml += "<li><img src='" + item.Image + "' /></li>";
                }
            }
        }
    }
}