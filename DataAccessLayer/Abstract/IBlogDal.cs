using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal
    {
        List<Blog> ListAllCategory();
        void AddCategory(Blog Blog);
        void DeleteCategory(Blog Blog);
        void UpdateCategory(Blog category);
        Blog GetById(int id);
    }
}
