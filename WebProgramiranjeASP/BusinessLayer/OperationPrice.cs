using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public class PriceDb : DbItem
    {
        #region Podaci
        private int idPrice;
        private string title;
        private string text;

        #endregion
        #region Svojstva
        public int IdPrice
        {
            get
            {
                return this.idPrice;
            }
            set
            {
                this.idPrice = value;
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
    public class CriteriaPrice : CriteriaForSelection
    {
        public int IdPrice { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }

    public abstract class OpPriceBase : Operation
    {
        public CriteriaPrice Criteria { get; set; }
        public override OperationResult execute(BaseEntities entities)
        {
            IEnumerable<PriceDb> iePrice;
            if ((this.Criteria == null) || (this.Criteria.IdPrice < 0)
                 && (this.Criteria.Title == null)
                 && (this.Criteria.Text == null))
                iePrice = from price in entities.sixes
                              select new PriceDb
                              {
                                  IdPrice = price.sId,
                                  Title = price.sTitle,
                                  Text = price.sText
                              };
            else
                iePrice = from price in entities.sixes
                              where ((this.Criteria.IdPrice < 0) ? true :
                                            this.Criteria.IdPrice == price.sId) &&
                                     ((this.Criteria.Title == null) ? true :
                                            this.Criteria.Title == price.sTitle) &&
                                     ((this.Criteria.Text == null) ? true :
                                            this.Criteria.Text == price.sText)
                              select new PriceDb
                              {
                                  IdPrice = price.sId,
                                  Title = price.sTitle,
                                  Text = price.sText
                              };
            PriceDb[] array = iePrice.ToArray();


            OperationResult obj = new OperationResult();
            obj.DbItems = array;
            obj.Status = true;
            return obj;
        }
    }
    public class OpPriceSelect : OpPriceBase
    {
    }
    public class OpPriceUpdate : OpPriceBase
    {
        private PriceDb price;
        public PriceDb Price
        {
            get { return price; }
            set { price = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.price != null) && (this.price.IdPrice) > 0 &&
                !string.IsNullOrEmpty(this.price.Title) &&
                !string.IsNullOrEmpty(this.price.Text))
                entities.SixUpdate(this.price.IdPrice, this.price.Title, this.price.Text);
            return base.execute(entities);
        }
    }
}