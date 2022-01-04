using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogByID(int id);
        List<Blog> GetBlogListByWriter(int id);
        
    }
}
//NOTES:IGENERİCDAL DA CRUD İMZALARI, GENERICREPOSITORY IMPLEMENT EDER
//MANAGER ISERVICE IMZALARIYLA IMPLEMENTE EDILIR.
//FIELD KULLANARAK TREPOSITORY CAGRILIR
//FIELD _BLOGDAL SADECE EfBlogRepositorydan implemente ediliyor fakat ekstra teknoloji eklenebilir.
//Aşğıda iki implementeden biri seçiliyor.
//(efblogreposity, genericrepository<Blog> tarafından implemente ediliyor. EF burada devreye giriyor.)

//ORNEK 
//IGENERIC VOID SIL VOID UPDATE VOID YAZDIR
//2 MANAGER IMPLEMENTE (VOID YAZDIR CW1, VOID YAZDIR CW2)
//MAIN MANAGERDA INTERFACE FIELDIYLE REFERANS TUTUCU OZELIGIYLE CTOR
//_FIELD.METHOD(). ====> METHOD VERILEN REFE GORE CALISIR
//NEW MANAGER=NEW MANAGER(MANAGER1);
//

