using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        //public void BlogAdd(Blog blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public void BlogDelete(Blog blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public void BlogUpdate(Blog blog)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id); 
            //x öyleki, controllerdan gelen değer, x nesnesinin BlogID'sine eşit.
            
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id); //Func<T,bool> lambda T Blog to access table
        }


        //Last update for CategoryByWriter need id
        public List<Blog> Test(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }
        public Blog UpdateBlogWithID(Blog t)
        {
            return _blogDal.UpdateBlogSelectedID(t);
        }


        public List<Blog> GetBlogListWithCategory()
        {
            
            return _blogDal.GetListWithCategory();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetByID(id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }
        public List<Blog> GetLastSelectedValueBlog(int id)
        {
            return _blogDal.GetListAll().Take(id).ToList();
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }
    }
}
//IBlogDal imzaları çağırılıyor. Controllerda IBlogDal referans tutuculuğuyla
//IGenericDaldan inherit almış GenericRepo new EfBlogRepository ile kullanılıyor.

//Zaten IBlogDal'da IgenericDal'dan aldı, GenericRepo'da.
//O yüzden ilk imzaları BlogDal ile çağırıp,ondan sonra Ef ile işliyorsun.
//Bir daha tutucu ile işlenmesi için yazmıyorsun