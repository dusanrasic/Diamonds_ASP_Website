using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public class UserDb : DbItem
    {
        #region Podaci
        private int idUser;
        private int idFunction;
        private string userName;
        private string password;
        private string mail;
        #endregion
        #region Svojstva
        public int IdUser
        {
            get
            {
                return this.idUser;
            }
            set
            {
                this.idUser = value;
            }
        }
        public int IdFunction
        {
            get
            {
                return this.idFunction;
            }
            set
            {
                this.idFunction = value;
            }
        }
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
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
    public class CriteriaUser : CriteriaForSelection
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public abstract class OpUserBase : Operation
    {
        public CriteriaUser Criteria { get; set; }
        public override OperationResult execute(BaseEntities entities)
        {
            IEnumerable<UserDb> ieUsers;
            if ((this.Criteria == null) || (this.Criteria.UserName == null)&& 
                (this.Criteria.Password == null))
                ieUsers = from user in entities.users
                          join userFunction in entities.userFunctions on user.userId equals userFunction.id_user
                           select new UserDb
                           {
                               IdUser = user.userId,
                               IdFunction = userFunction.id_function,
                               UserName = user.user_name,
                               Password = user.password,
                               Mail = user.mail
                           };
            else
                ieUsers = from user in entities.users
                          join userFunction in entities.userFunctions on user.userId equals userFunction.id_user
                          where ((this.Criteria.UserName == null) ? true :
                                        this.Criteria.UserName == user.user_name) &&
                                 ((this.Criteria.Password == null) ? true :
                                        this.Criteria.Password == user.password) 
                          select new UserDb
                           {
                               IdUser = user.userId,
                               IdFunction = userFunction.id_function,
                               UserName = user.user_name,
                               Password = user.password,
                               Mail = user.mail
                           };
            UserDb[] array = ieUsers.ToArray();


            OperationResult obj = new OperationResult();
            obj.DbItems = array;
            obj.Status = true;
            return obj;
        }
    }
    public class OpUserSelect : OpUserBase
    {
    }
    public class OpUserInsert : OpUserBase
    {
        private UserDb user;
        public UserDb User
        {
            get { return user; }
            set { user = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.user != null) && !string.IsNullOrEmpty(this.user.UserName) &&
                !string.IsNullOrEmpty(this.user.Password) &&
                !string.IsNullOrEmpty(this.user.Mail) &&
                (this.user.IdFunction) > 0)
                entities.UserInsert(this.user.UserName, this.user.Password,this.user.Mail,this.user.IdFunction);
            return base.execute(entities);
        }
    }
    public class OpUserUpdate : OpUserBase
    {
        private UserDb user;
        public UserDb User
        {
            get { return user; }
            set { user = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.user != null) && (this.user.IdUser) > 0 &&
                !string.IsNullOrEmpty(this.user.UserName) &&
                !string.IsNullOrEmpty(this.user.Password) &&
                !string.IsNullOrEmpty(this.user.Mail) &&
                (this.user.IdFunction) > 0)
                entities.UserUpdate(this.user.IdUser, this.user.UserName, this.user.Password, this.user.Mail,this.user.IdFunction);
            return base.execute(entities);
        }

    }
    public class OpUserDelete : OpUserBase
    {
        private int idUser;
        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if (this.IdUser > 0)
                entities.UserDelete(this.idUser);
            return base.execute(entities);
        }

    }
}
