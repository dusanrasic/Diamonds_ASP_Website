using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public class AboutDb : DbItem
    {
        #region Podaci
        private int idAbout;
        private string title;
        private string text;
        private string fb;
        private string insta;
        private string plus;
        private string mail;

        #endregion
        #region Svojstva
        public int IdAbout
        {
            get
            {
                return this.idAbout;
            }
            set
            {
                this.idAbout = value;
            }
        }
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }
        public string Fb
        {
            get
            {
                return this.fb;
            }
            set
            {
                this.fb = value;
            }
        }
        public string Insta
        {
            get
            {
                return this.insta;
            }
            set
            {
                this.insta = value;
            }
        }
        public string Plus
        {
            get
            {
                return this.plus;
            }
            set
            {
                this.plus = value;
            }
        }
        public string Mail
        {
            get
            {
                return this.mail;
            }
            set
            {
                this.mail = value;
            }
        }
        #endregion
    }
    public class CriteriaAbout : CriteriaForSelection
    {
        public int IdAbout { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Fb { get; set; }
        public string Insta { get; set; }
        public string Plus { get; set; }
        public string Mail { get; set; }
    }

    public abstract class OpAboutBase : Operation
    {
        public CriteriaAbout Criteria { get; set; }
        public override OperationResult execute(BaseEntities entities)
        {
            IEnumerable<AboutDb> ieAbout;
            if ((this.Criteria == null) || (this.Criteria.IdAbout < 0)
                 && (this.Criteria.Title == null)
                 && (this.Criteria.Text == null)
                 && (this.Criteria.Fb == null)
                 && (this.Criteria.Insta == null)
                 && (this.Criteria.Plus == null)
                 && (this.Criteria.Mail == null))
                ieAbout = from about in entities.aboutmes
                          select new AboutDb
                          {
                              IdAbout = about.abId,
                              Title = about.aboutTitle,
                              Text = about.aboutText,
                              Fb = about.aboutFB,
                              Insta = about.aboutInsta,
                              Plus = about.aboutG,
                              Mail = about.aboutOut
                          };
            else
                ieAbout = from about in entities.aboutmes
                          where ((this.Criteria.IdAbout < 0) ? true :
                                        this.Criteria.IdAbout == about.abId) &&
                                 ((this.Criteria.Title == null) ? true :
                                        this.Criteria.Title == about.aboutTitle) &&
                                 ((this.Criteria.Text == null) ? true :
                                        this.Criteria.Text == about.aboutText) &&
                                 ((this.Criteria.Fb == null) ? true :
                                        this.Criteria.Fb == about.aboutFB) &&
                                 ((this.Criteria.Insta == null) ? true :
                                        this.Criteria.Insta == about.aboutInsta) &&
                                 ((this.Criteria.Plus == null) ? true :
                                        this.Criteria.Plus == about.aboutG) &&
                                 ((this.Criteria.Mail == null) ? true :
                                        this.Criteria.Mail == about.aboutOut)
                          select new AboutDb
                          {
                              IdAbout = about.abId,
                              Title = about.aboutTitle,
                              Text = about.aboutText,
                              Fb = about.aboutFB,
                              Insta = about.aboutInsta,
                              Plus = about.aboutG,
                              Mail = about.aboutOut
                          };
            AboutDb[] array = ieAbout.ToArray();


            OperationResult obj = new OperationResult();
            obj.DbItems = array;
            obj.Status = true;
            return obj;
        }
    }
    public class OpAboutSelect : OpAboutBase
    {
    }
    public class OpAboutUpdate : OpAboutBase
    {
        private AboutDb about;
        public AboutDb About
        {
            get { return about; }
            set { about = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.about != null) && (this.about.IdAbout) > 0 &&
                !string.IsNullOrEmpty(this.about.Title) &&
                !string.IsNullOrEmpty(this.about.Text) &&
                !string.IsNullOrEmpty(this.about.Fb) &&
                !string.IsNullOrEmpty(this.about.Insta) &&
                !string.IsNullOrEmpty(this.about.Plus) &&
                !string.IsNullOrEmpty(this.about.Mail))
                entities.AboutUpdate(this.about.IdAbout, this.about.Title, this.about.Text,this.about.Fb,this.about.Insta,this.about.Plus,this.about.Mail);
            return base.execute(entities);
        }
    }
}