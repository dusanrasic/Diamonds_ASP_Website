using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public class HistoryDb : DbItem
    {
        #region Podaci
        private int idHistory;
        private string title;
        private string text;

        #endregion
        #region Svojstva
        public int IdHistory
        {
            get
            {
                return this.idHistory;
            }
            set
            {
                this.idHistory = value;
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
    public class CriteriaHistory : CriteriaForSelection
    {
        public int IdHistory { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }

    public abstract class OpHistoryBase : Operation
    {
        public CriteriaHistory Criteria { get; set; }
        public override OperationResult execute(BaseEntities entities)
        {
            IEnumerable<HistoryDb> ieHistories;
            if ((this.Criteria == null) || (this.Criteria.IdHistory < 0)
                 && (this.Criteria.Title == null)
                 && (this.Criteria.Text == null))
                ieHistories = from history in entities.firsts
                                select new HistoryDb
                                {
                                    IdHistory = history.fId,
                                    Title = history.fTitle,
                                    Text = history.fText
                                };
            else
                ieHistories = from history in entities.firsts
                                where ((this.Criteria.IdHistory < 0) ? true :
                                              this.Criteria.IdHistory == history.fId) &&
                                       ((this.Criteria.Title == null) ? true :
                                              this.Criteria.Title == history.fTitle) &&
                                       ((this.Criteria.Text == null) ? true :
                                              this.Criteria.Text == history.fText)
                                select new HistoryDb
                                {
                                    IdHistory = history.fId,
                                    Title = history.fTitle,
                                    Text = history.fText
                                };
            HistoryDb[] array = ieHistories.ToArray();


            OperationResult obj = new OperationResult();
            obj.DbItems = array;
            obj.Status = true;
            return obj;
        }
    }
    public class OpHistorySelect : OpHistoryBase
    {
    }
    public class OpHistoryUpdate : OpHistoryBase
    {
        private HistoryDb history;
        public HistoryDb History
        {
            get { return history; }
            set { history = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.history != null) && (this.history.IdHistory) > 0 &&
                !string.IsNullOrEmpty(this.history.Title) &&
                !string.IsNullOrEmpty(this.history.Text))
                entities.FirstUpdate(this.history.IdHistory, this.history.Title, this.history.Text);
            return base.execute(entities);
        }
    }
}