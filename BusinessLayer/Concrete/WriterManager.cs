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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetByID(id);
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterBYID(int id)
        {
          return _writerDal.GetListAll(x=>x.WriterID==id);
        }

        public void TAdd(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }
        public int GetWriterID(string useridentity)
        {
            return _writerDal.GetWriterID(useridentity);
        }

        //public void WriterAdd(Writer writer)
        //{
        //    _writerDal.Insert(writer);
        //}
    }
}
