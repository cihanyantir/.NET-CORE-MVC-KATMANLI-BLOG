using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        //EFBLOGREPOSITORY= GenericRepository<Blog>+Kendi metotların.
        //IBlogDal= GenericDal+Kendi metod imzaların
        //Controllerdan service alanı yazıldığında, çalışacak servisin EfBlogRepository'dir.
        //Yani hepsi burada. Bu yüzden
        //.AddServices<EfBlogRepository,IBlogDal> yazılabilir.


        //Bu yüzden Controllerda BlogManager =new BlogManager EfBlogRepository diye çağırıyorsun.
        //Managerdaki metotları çalıştıracak interfacenin(IBlogDal) servisi EfBlogRepository...
        // Controllerda IBlogService alanından BlogManagera erişebilirsin


        public List<Blog> GetListWithCategory() //Get info about category of blogs
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).ToList();//blogs with category
            } 

            }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Where(x=>x.WriterID==id).ToList();//blogs with category
            }

        }
        public Blog UpdateBlogSelectedID(Blog blog)
        {
            using (var c = new Context())
            {
                return c.Blogs.SingleOrDefault(x => x.BlogID == blog.BlogID);
               
            }
        }
    }

    }


