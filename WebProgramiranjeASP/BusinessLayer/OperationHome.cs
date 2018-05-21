using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public class HomeDb : DbItem
    {
        #region Podaci
        private int idBlock;
        private string blockTitle;
        private string blockText;

        #endregion
        #region Svojstva
        public int IdBlock
        {
            get
            {
                return this.idBlock;
            }
            set
            {
                this.idBlock = value;
            }
        }
        public string BlockTitle
        {
            get
            {
                return this.blockTitle;
            }
            set
            {
                this.blockTitle = value;
            }
        }
        public string BlockText
        {
            get
            {
                return this.blockText;
            }
            set
            {
                this.blockText = value;
            }
        }
        #endregion
    }
    public class CriteriaHome : CriteriaForSelection
    {
        public int IdBlock { get; set; }
        public string BlockTitle { get; set; }
        public string BlockText { get; set; }
    }

    public abstract class OpHomeBase : Operation
    {
        public CriteriaHome Criteria { get; set; }
        public override OperationResult execute(BaseEntities entities)
        {
            IEnumerable<HomeDb> ieHomes;
            if ((this.Criteria == null) || (this.Criteria.IdBlock < 0)
                 && (this.Criteria.BlockTitle == null)
                 && (this.Criteria.BlockText == null))
                ieHomes = from home in entities.homes
                          select new HomeDb
                          {
                              IdBlock = home.homeId,
                              BlockTitle = home.block_title,
                              BlockText = home.block_text
                          };
            else
                ieHomes = from home in entities.homes                        
                          where ((this.Criteria.IdBlock < 0) ? true :
                                        this.Criteria.IdBlock == home.homeId) &&
                                 ((this.Criteria.BlockTitle == null) ? true :
                                        this.Criteria.BlockTitle == home.block_title) &&
                                 ((this.Criteria.BlockText == null) ? true :
                                        this.Criteria.BlockText == home.block_text)
                          select new HomeDb
                          {
                              IdBlock = home.homeId,
                              BlockTitle = home.block_title,
                              BlockText = home.block_text
                          };
            HomeDb[] array = ieHomes.ToArray();


            OperationResult obj = new OperationResult();
            obj.DbItems = array;
            obj.Status = true;
            return obj;
        }
    }
    public class OpHomeSelect : OpHomeBase
    {
    }
    public class OpHomeUpdate : OpHomeBase
    {
        private HomeDb home;
        public HomeDb Home
        {
            get { return home; }
            set { home = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.home != null) && (this.home.IdBlock) > 0 &&
                !string.IsNullOrEmpty(this.home.BlockTitle) &&
                !string.IsNullOrEmpty(this.home.BlockText))
                entities.HomeUpdate(this.home.IdBlock, this.home.BlockTitle, this.home.BlockText);
            return base.execute(entities);
        }

    }
}