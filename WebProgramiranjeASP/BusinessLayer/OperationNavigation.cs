using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public class NavigationDb : DbItem
    {
        #region Podaci
        private int idNavigation;
        private string name;
        private string location;

        #endregion
        #region Svojstva
        public int IdNavigation
        {
            get
            {
                return this.idNavigation;
            }
            set
            {
                this.idNavigation = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }
        #endregion
    }
    public class CriteriaNavigation : CriteriaForSelection
    {
        public int IdNavigation { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public abstract class OpNavigationBase : Operation
    {
        public CriteriaNavigation Criteria { get; set; }
        public override OperationResult execute(BaseEntities entities)
        {
            IEnumerable<NavigationDb> ieNavigations;
            if ((this.Criteria == null) || (this.Criteria.IdNavigation < 0)
                 && (this.Criteria.Name == null)
                 && (this.Criteria.Location == null))
                ieNavigations = from navigation in entities.navigations
                              select new NavigationDb
                              {
                                  IdNavigation = navigation.IdNavigation,
                                  Name = navigation.name,
                                  Location = navigation.location
                              };
            else
                ieNavigations = from navigation in entities.navigations
                              where ((this.Criteria.IdNavigation < 0) ? true :
                                            this.Criteria.IdNavigation == navigation.IdNavigation) &&
                                     ((this.Criteria.Name == null) ? true :
                                            this.Criteria.Name == navigation.name) &&
                                     ((this.Criteria.Location == null) ? true :
                                            this.Criteria.Location == navigation.location)
                              select new NavigationDb
                              {
                                  IdNavigation = navigation.IdNavigation,
                                  Name = navigation.name,
                                  Location = navigation.location
                              };
            NavigationDb[] array = ieNavigations.ToArray();


            OperationResult obj = new OperationResult();
            obj.DbItems = array;
            obj.Status = true;
            return obj;
        }
    }
    public class OpNavigationSelect : OpNavigationBase
    {
    }
    public class OpNavigationUpdate : OpNavigationBase
    {
        private NavigationDb navigation;
        public NavigationDb Navigation
        {
            get { return navigation; }
            set { navigation = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.navigation != null) && (this.navigation.IdNavigation) > 0 &&
                !string.IsNullOrEmpty(this.navigation.Name) &&
                !string.IsNullOrEmpty(this.navigation.Location))
                entities.NavigationUpdate(this.navigation.IdNavigation, this.navigation.Name, this.navigation.Location);
            return base.execute(entities);
        }
    }
}