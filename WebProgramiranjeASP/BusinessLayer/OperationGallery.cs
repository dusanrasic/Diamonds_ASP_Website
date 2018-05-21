using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public class GalleryDb : DbItem
    {
        #region Podaci
        private int idGallery;
        private string name;
        private string image;

        #endregion
        #region Svojstva
        public int IdGallery
        {
            get
            {
                return this.idGallery;
            }
            set
            {
                this.idGallery = value;
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
        public string Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }
        #endregion
    }
    public class CriteriaGallery : CriteriaForSelection
    {
        public int IdGallery { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public abstract class OpGalleryBase : Operation
    {
        public CriteriaGallery Criteria { get; set; }
        public override OperationResult execute(BaseEntities entities)
        {
            IEnumerable<GalleryDb> ieGalleries;
            if ((this.Criteria == null) || (this.Criteria.IdGallery < 0)
                 && (this.Criteria.Name == null)
                 && (this.Criteria.Image == null))
                ieGalleries = from gallery in entities.galleries
                          select new GalleryDb
                          {
                              IdGallery = gallery.galId,
                              Name = gallery.galName,
                              Image = gallery.galImg
                          };
            else
                ieGalleries = from gallery in entities.galleries
                          where ((this.Criteria.IdGallery < 0) ? true :
                                        this.Criteria.IdGallery == gallery.galId) &&
                                 ((this.Criteria.Name == null) ? true :
                                        this.Criteria.Name == gallery.galName) &&
                                 ((this.Criteria.Image == null) ? true :
                                        this.Criteria.Image == gallery.galImg)
                              select new GalleryDb
                              {
                                  IdGallery = gallery.galId,
                                  Name = gallery.galName,
                                  Image = gallery.galImg
                              };
            GalleryDb[] array = ieGalleries.ToArray();


            OperationResult obj = new OperationResult();
            obj.DbItems = array;
            obj.Status = true;
            return obj;
        }
    }
    public class OpGallerySelect : OpGalleryBase
    {
    }
    public class OpGalleryInsert : OpGalleryBase
    {
        private GalleryDb gallery;
        public GalleryDb Gallery
        {
            get { return gallery; }
            set { gallery = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.gallery != null) && !string.IsNullOrEmpty(this.gallery.Name) &&
                !string.IsNullOrEmpty(this.gallery.Image))
                entities.GalleryInsert(this.gallery.Name, this.gallery.Image);
            return base.execute(entities);
        }
    }
    public class OpGalleryUpdate : OpGalleryBase
    {
        private GalleryDb gallery;
        public GalleryDb Gallery
        {
            get { return gallery; }
            set { gallery = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if ((this.gallery != null) && (this.gallery.IdGallery) > 0 &&
                !string.IsNullOrEmpty(this.gallery.Name) &&
                !string.IsNullOrEmpty(this.gallery.Image))
                entities.GalleryUpdate(this.gallery.IdGallery,this.gallery.Name, this.gallery.Image);
            return base.execute(entities);
        }
    }
    public class OpGalleryDelete : OpGalleryBase
    {
        private int idGallery;
        public int IdGallery
        {
            get { return idGallery; }
            set { idGallery = value; }
        }
        public override OperationResult execute(BaseEntities entities)
        {
            if (this.idGallery > 0)
                entities.GalleryDelete(this.idGallery);
            return base.execute(entities);
        }

    }
}