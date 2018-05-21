using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProgramiranjeASP.BusinessLayer;

namespace WebProgramiranjeASP
{
    public partial class AboutMe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpAboutSelect ohs = new OpAboutSelect();
            OperationResult obj = OperationManager.Singleton.executeOperation(ohs);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj.DbItems;
                AboutDb[] abouts = items.Cast<AboutDb>().ToArray();

                aboutText.InnerHtml += "<h1>"+abouts[0].Title+"</h1><p>"+abouts[0].Text+"</p>";
                aboutMeSocial.InnerHtml += "<div class='links link_fb'><a href=" + abouts[0].Fb + "><img src='img/Facebook.png'/></a></div>";
                aboutMeSocial.InnerHtml += "<div class='links link_in'><a href=" + abouts[0].Insta + "><img src='img/Instagram.png'/></a></div>";
                aboutMeSocial.InnerHtml += "<div class='links link_gp'><a href=" + abouts[0].Plus + "><img src='img/Googleplus.png'/></a></div>";
                aboutMeSocial.InnerHtml += "<div class='links link_ou'><a href=" + abouts[0].Mail + "><img src='img/Outlook.png'/></a></div>";
            }
        }
    }
}