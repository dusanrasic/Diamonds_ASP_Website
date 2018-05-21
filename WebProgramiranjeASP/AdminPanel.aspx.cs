using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProgramiranjeASP.BusinessLayer;

namespace WebProgramiranjeASP
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["function"] == null)
            {
                Response.Redirect("~/Index.aspx");
            }

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            OpUserSelect ous = new OpUserSelect();
            OperationResult obj = OperationManager.Singleton.executeOperation(ous);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj.DbItems;
                UserDb[] users = items.Cast<UserDb>().ToArray();


                GridView1.DataSource = obj.DbItems;
                GridView1.DataBind();

            }
            OpContactSelect ocs = new OpContactSelect();
            OperationResult obj2 = OperationManager.Singleton.executeOperation(ocs);
            if ((obj2 == null) || (!obj2.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj2.DbItems;
                ContactDb[] contacts = items.Cast<ContactDb>().ToArray();


                GridView2.DataSource = obj2.DbItems;
                GridView2.DataBind();

            }
            OpGallerySelect ogs = new OpGallerySelect();
            OperationResult obj3 = OperationManager.Singleton.executeOperation(ogs);
            if ((obj3 == null) || (!obj3.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj3.DbItems;
                GalleryDb[] galleries = items.Cast<GalleryDb>().ToArray();


                GridView3.DataSource = obj3.DbItems;
                GridView3.DataBind();

            }
            OpAboutSelect oas = new OpAboutSelect();
            OperationResult obj4 = OperationManager.Singleton.executeOperation(oas);
            if ((obj4 == null) || (!obj4.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj4.DbItems;
                AboutDb[] abouts = items.Cast<AboutDb>().ToArray();


                GridView4.DataSource = obj4.DbItems;
                GridView4.DataBind();

            }
            OpHomeSelect ohs = new OpHomeSelect();
            OperationResult obj5 = OperationManager.Singleton.executeOperation(ohs);
            if ((obj5 == null) || (!obj5.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj5.DbItems;
                HomeDb[] homes = items.Cast<HomeDb>().ToArray();


                GridView5.DataSource = obj5.DbItems;
                GridView5.DataBind();

            }
            OpHistorySelect ohis = new OpHistorySelect();
            OperationResult obj6 = OperationManager.Singleton.executeOperation(ohis);
            if ((obj6 == null) || (!obj6.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj6.DbItems;
                HistoryDb[] histories = items.Cast<HistoryDb>().ToArray();


                GridView6.DataSource = obj6.DbItems;
                GridView6.DataBind();

            }
            OpPriceSelect ops = new OpPriceSelect();
            OperationResult obj7 = OperationManager.Singleton.executeOperation(ops);
            if ((obj7 == null) || (!obj7.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj7.DbItems;
                PriceDb[] prices = items.Cast<PriceDb>().ToArray();


                GridView7.DataSource = obj7.DbItems;
                GridView7.DataBind();

            }
            OpModernDaySelect omds = new OpModernDaySelect();
            OperationResult obj8 = OperationManager.Singleton.executeOperation(omds);
            if((obj8 == null) || (!obj8.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = obj8.DbItems;
                ModernDayDb[] moderns = items.Cast<ModernDayDb>().ToArray();

                GridView8.DataSource = obj8.DbItems;
                GridView8.DataBind();
            }
        }
        protected void btnUserUpdate_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Button taster = (Button)sender;
            string[] args = taster.CommandArgument.Split(';');

            tbIdUser.Text = args[0];
            tbUserName.Text = args[1];
            tbPassword.Text = args[2];
            tbMail.Text = args[3];
            ddlFunctionUser.SelectedValue = args[4];
            
        }
        protected void btnUserDelete_Click(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int args = Convert.ToInt32(taster.CommandArgument);

            OpUserDelete oud = new OpUserDelete();
            oud.IdUser = args;
            OperationResult obj = OperationManager.Singleton.executeOperation(oud);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView1.DataSource = obj.DbItems;
                GridView1.DataBind();
            }
        }
        protected void btnUserUpdateFunction_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbIdUser.Text);
            string user = tbUserName.Text;
            string pass = tbPassword.Text;
            string mail = tbMail.Text;
            int userFunction = Convert.ToInt32(ddlFunctionUser.SelectedValue);

            OpUserUpdate oud = new OpUserUpdate();
            oud.User = new UserDb { IdUser = id, UserName = user, Password =pass , Mail = mail , IdFunction = userFunction};
            OperationResult obj = OperationManager.Singleton.executeOperation(oud);
            if ((obj == null) || (!obj.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView1.DataSource = obj.DbItems;
                GridView1.DataBind();
            }
        }

        protected void btnDeleteComment_Click(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int id = Convert.ToInt32(taster.CommandArgument);

            OpContactDelete ocd = new OpContactDelete();
            ocd.IdContact = id;
            OperationResult obj2 = OperationManager.Singleton.executeOperation(ocd);
            if ((obj2 == null) || (!obj2.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView2.DataSource = obj2.DbItems;
                GridView2.DataBind();
            }
        }

        protected void btnUpdateGallery_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Button taster = (Button)sender;
            string[] args = taster.CommandArgument.Split(';');

            tbGalId.Text = args[0];
            tbGalName.Text = args[1];
            tbGalLoc.Text = args[2];
        }

        protected void btnUpdateGalleryFunction_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbGalId.Text);
            string name = tbGalName.Text;
            string image = tbGalLoc.Text;

            OpGalleryUpdate ogu = new OpGalleryUpdate();
            ogu.Gallery = new GalleryDb { IdGallery = id, Name = name, Image = image };
            OperationResult obj3 = OperationManager.Singleton.executeOperation(ogu);
            if ((obj3 == null) || (!obj3.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView3.DataSource = obj3.DbItems;
                GridView3.DataBind();
            }
        }
        protected void btnDeleteGallery_Click(object sender, EventArgs e)
        {
            Button taster = (Button)sender;
            int id = Convert.ToInt32(taster.CommandArgument);

            OpGalleryDelete ogd = new OpGalleryDelete();
            ogd.IdGallery = id;
            OperationResult obj3 = OperationManager.Singleton.executeOperation(ogd);
            if ((obj3 == null) || (!obj3.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView3.DataSource = obj3.DbItems;
                GridView3.DataBind();
            }
        }

        protected void btnUpdateAbout_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            Button taster = (Button)sender;
            string[] args = taster.CommandArgument.Split(';');

            tbAboutId.Text = args[0];
            tbAboutTitle.Text = args[1];
            tbAboutText.Text = args[2];
            tbAboutFacebook.Text = args[3];
            tbAboutInstagram.Text = args[4];
            tbAboutPlus.Text = args[5];
            tbAboutMail.Text = args[6];
        }

        protected void btnUpdateAboutFunction_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbAboutId.Text);
            string title = tbAboutTitle.Text;
            string text = tbAboutText.Text;
            string fb = tbAboutFacebook.Text;
            string insta = tbAboutInstagram.Text;
            string plus = tbAboutPlus.Text;
            string mail = tbAboutMail.Text;

            OpAboutUpdate oau = new OpAboutUpdate();
            oau.About = new AboutDb { IdAbout = id, Title = title, Text = text, Fb = fb, Insta = insta, Plus = plus, Mail = mail };
            OperationResult obj4 = OperationManager.Singleton.executeOperation(oau);
            if ((obj4 == null) || (!obj4.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView4.DataSource = obj4.DbItems;
                GridView4.DataBind();
            }
        }

        protected void btnUpdateHome_Click(object sender, EventArgs e)
        {
            Panel4.Visible = true;
            Button taster = (Button)sender;
            string[] args = taster.CommandArgument.Split(';');

            tbBlockId.Text = args[0];
            tbBlockTitle.Text = args[1];
            tbBlockText.Text = args[2];
        }

        protected void btnUpdateHomeFunction_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbAboutId.Text);
            string title = tbBlockTitle.Text;
            string text = tbBlockText.Text;

            OpHomeUpdate ohu = new OpHomeUpdate();
            ohu.Home = new HomeDb { IdBlock = id, BlockTitle = title, BlockText = text };
            OperationResult obj5 = OperationManager.Singleton.executeOperation(ohu);
            if ((obj5 == null) || (!obj5.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView5.DataSource = obj5.DbItems;
                GridView5.DataBind();
            }
        }

        protected void btnUpdateHistory_Click(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            Button taster = (Button)sender;
            string[] args = taster.CommandArgument.Split(';');

            tbHistoryId.Text = args[0];
            tbHistoryTitle.Text = args[1];
            tbHistoryText.Text = args[2];
        }

        protected void btnUpdateHistoryFunction_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbAboutId.Text);
            string title = tbHistoryTitle.Text;
            string text = tbHistoryText.Text;

            OpHistoryUpdate ohu = new OpHistoryUpdate();
            ohu.History = new HistoryDb { IdHistory = id, Title = title, Text = text };
            OperationResult obj6 = OperationManager.Singleton.executeOperation(ohu);
            if ((obj6 == null) || (!obj6.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView6.DataSource = obj6.DbItems;
                GridView6.DataBind();
            }
        }

        protected void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            Panel6.Visible = true;
            Button taster = (Button)sender;
            string[] args = taster.CommandArgument.Split(';');

            tbPriceId.Text = args[0];
            tbPriceTitle.Text = args[1];
            tbPriceText.Text = args[2];
        }

        protected void btnUpdatePriceFunction_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbAboutId.Text);
            string title = tbHistoryTitle.Text;
            string text = tbHistoryText.Text;

            OpPriceUpdate opu = new OpPriceUpdate();
            opu.Price = new PriceDb { IdPrice = id, Title = title, Text = text };
            OperationResult obj7 = OperationManager.Singleton.executeOperation(opu);
            if ((obj7 == null) || (!obj7.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView7.DataSource = obj7.DbItems;
                GridView7.DataBind();
            }
        }

        protected void btnUpdateModern_Click(object sender, EventArgs e)
        {
            Panel7.Visible = true;
            Button taster = (Button)sender;
            string[] args = taster.CommandArgument.Split(';');

            tbModernId.Text = args[0];
            tbModernTitle.Text = args[1];
            tbModernText.Text = args[2];
        }

        protected void btnUpdateModernFunction_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbAboutId.Text);
            string title = tbModernTitle.Text;
            string text = tbModernText.Text;

            OpModernDayUpdate omdu = new OpModernDayUpdate();
            omdu.Modern = new ModernDayDb { IdModernDay = id, Title = title, Text = text };
            OperationResult obj8 = OperationManager.Singleton.executeOperation(omdu);
            if ((obj8 == null) || (!obj8.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView8.DataSource = obj8.DbItems;
                GridView8.DataBind();
            }
        }

        protected void btnAddGallery_Click(object sender, EventArgs e)
        {
            string title = tbAddGallery.Text;
            
                if ((FileUploadImage.PostedFile != null) && (FileUploadImage.PostedFile.ContentLength > 0))
                {
                    string fn = System.IO.Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("img") + "\\" + fn;
                    try
                    {
                        FileUploadImage.PostedFile.SaveAs(SaveLocation);

                        OpGalleryInsert op = new OpGalleryInsert();
                        op.Gallery = new GalleryDb
                        {
                            Name = title,
                            Image = "img/" + fn
                        };
                        OperationResult res = OperationManager.Singleton.executeOperation(op);
                        if ((res == null) || (!res.Status))
                        {
                            return;
                        }
                        else
                        {
                            Response.Redirect(Request.RawUrl);
                            tbAddGallery.Text = "";
                            GridView3.DataBind();
                        }
                        lbAddGallery.Text = "Succsessfully aded.";
                    }
                    catch (Exception ex)
                    {
                        lbAddGallery.Text = "Error: " + ex.Message;
                        //Note: Exception.Message returns a detailed message that describes the current exception. 
                        //For security reasons, we do not recommend that you return Exception.Message to end users in 
                        //production environments. It would be better to put a generic error message. 
                    }
                }
                else
                {
                    lbAddGallery.Text = "Please select a file to upload.";
                }

        }

        protected void btnUserAdd_Click(object sender, EventArgs e)
        {
            string username = tbUserNameAdd.Text;
            string pass = tbPasswordAdd.Text;
            string mail = tbMailAdd.Text;
            int function = Convert.ToInt32(ddlFunctionAdd.SelectedValue);

            OpUserInsert osi = new OpUserInsert();
            osi.User = new UserDb { UserName = username, Password = pass, Mail = mail, IdFunction = function };
            OperationResult obj10 = OperationManager.Singleton.executeOperation(osi);
            if ((obj10 == null) || (!obj10.Status))
            {
                return;
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                GridView1.DataSource = obj10.DbItems;
                GridView1.DataBind();
            }
        }
    }
}