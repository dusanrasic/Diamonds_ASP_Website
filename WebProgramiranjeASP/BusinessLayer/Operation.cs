using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public abstract class Operation
    {
        public abstract OperationResult execute(BaseEntities entities);
    }

    public class OperationResult
    {
        private string message;
        private DbItem[] dbItems;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public bool Status { get; set; }

        public DbItem[] DbItems
        {
            get { return dbItems; }
            set { dbItems = value; }
        }
    }

    public abstract class DbItem
    {
    }

    public abstract class CriteriaForSelection
    {
    }

}
