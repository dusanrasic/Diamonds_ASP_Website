using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public class ContactDb : DbItem
    {
        #region Podaci
        private int idContact;
        private string text;
        private DateTime date;
        private string user;

        #endregion
        #region Svojstva
        public int IdContact
        {
            get
            {
                return this.idContact;
            }
            set
            {
                this.idContact = value;
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
        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        public string User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
            }
        }
        #endregion
    }
    public class CriteriaContact : CriteriaForSelection
    {
        public int idContact { get; set; }
        public string Text { get; set; }
    }

    public abstract class OpContactBase : Operation
    {
        public CriteriaContact Criteria { get; set; }
        public override OperationResult execute(BaseEntities entities)
        {
            IEnumerable<ContactDb> ieContacts;
            if ((this.Criteria == null) || (this.Criteria.idContact < 0)
                 && (this.Criteria.Text == null))
                ieContacts = from contact in entities.comments
                              select new ContactDb
                              {
                                  IdContact = contact.commentId,
                                  Text = contact.commentText,
                                  Date = contact.commentDate,
                                  User = contact.commentUser
                                  
                              };
            else
                ieContacts = from contact in entities.comments
                              where ((this.Criteria.idContact < 0) ? true :
                                            this.Criteria.idContact == contact.commentId) &&
                                     ((this.Criteria.Text == null) ? true :
                                            this.Criteria.Text == contact.commentText)
                              select new ContactDb
                              {
                                  IdContact = contact.commentId,
                                  Text = contact.commentText,
                                  Date = contact.commentDate,
                                  User = contact.commentUser
                              };
            ContactDb[] array = ieContacts.ToArray();


            OperationResult obj = new OperationResult();
            obj.DbItems = array;
            obj.Status = true;
            return obj;
        }
    }
    public class OpContactSelect : OpContactBase
    {
    }
    public class OpContactInsert : OpGalleryBase
    {
        private ContactDb contact;
        public ContactDb Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.contact != null) && !string.IsNullOrEmpty(this.contact.Text) &&
                !string.IsNullOrEmpty(this.contact.User))
                entities.CommentInsert(this.contact.Text,this.contact.Date,this.contact.User);
            return base.execute(entities);
        }
    }
 
    public class OpContactDelete : OpGalleryBase
    {
        private int idContact;
        public int IdContact
        {
            get { return idContact; }
            set { idContact = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if (this.idContact > 0)
                entities.CommentDelete(this.idContact);
            return base.execute(entities);
        }

    }
}