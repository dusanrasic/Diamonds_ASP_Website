using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public class ModernDayDb : DbItem
    {
        #region Podaci
        private int idModernDay;
        private string title;
        private string text;

        #endregion
        #region Svojstva
        public int IdModernDay
        {
            get
            {
                return this.idModernDay;
            }
            set
            {
                this.idModernDay = value;
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
        #endregion
    }
    public class CriteriaModernDay : CriteriaForSelection
    {
        public int IdModernDay { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }

    public abstract class OpModernDayBase : Operation
    {
        public CriteriaModernDay Criteria { get; set; }
        public override OperationResult execute(BaseEntities entities)
        {
            IEnumerable<ModernDayDb> ieModernDay;
            if ((this.Criteria == null) || (this.Criteria.IdModernDay < 0)
                 && (this.Criteria.Title == null)
                 && (this.Criteria.Text == null))
                ieModernDay = from modern in entities.sevenths
                             select new ModernDayDb
                             {
                                 IdModernDay = modern.seId,
                                 Title = modern.seTitle,
                                 Text = modern.seText
                             };
            else
                ieModernDay = from modern in entities.sevenths
                             where ((this.Criteria.IdModernDay < 0) ? true :
                                           this.Criteria.IdModernDay == modern.seId) &&
                                    ((this.Criteria.Title == null) ? true :
                                           this.Criteria.Title == modern.seTitle) &&
                                    ((this.Criteria.Text == null) ? true :
                                           this.Criteria.Text == modern.seText)
                             select new ModernDayDb
                             {
                                 IdModernDay = modern.seId,
                                 Title = modern.seTitle,
                                 Text = modern.seText
                             };
            ModernDayDb[] array = ieModernDay.ToArray();


            OperationResult obj = new OperationResult();
            obj.DbItems = array;
            obj.Status = true;
            return obj;
        }
    }
    public class OpModernDaySelect : OpModernDayBase
    {
    }
    public class OpModernDayUpdate : OpModernDayBase
    {
        private ModernDayDb modern;
        public ModernDayDb Modern
        {
            get { return modern; }
            set { modern = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.modern != null) && (this.modern.IdModernDay) > 0 &&
                !string.IsNullOrEmpty(this.modern.Title) &&
                !string.IsNullOrEmpty(this.modern.Text))
                entities.SeventhUpdate(this.modern.IdModernDay, this.modern.Title, this.modern.Text);
            return base.execute(entities);
        }
    }
}