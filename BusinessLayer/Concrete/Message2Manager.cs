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

    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _msgdAL;

        public Message2Manager(IMessage2Dal msgdAL)
        {
            _msgdAL = msgdAL;
        }

        public Message2 GetById(int id)
        {
            return _msgdAL.GetByID(id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _msgdAL.GetListMessageByWriter(id);
        }
        public Message2 GetMessage(int id)
        {
            return _msgdAL.GetOneMessageWithSender(id);
        }
        public Message2 GetMessageByID (int id)
        {
            return _msgdAL.GetOneMessageWithSenderByID(id);

        }

        public List<Message2> GetList()
        {
            return _msgdAL.GetListAll();
        }

        public void TAdd(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}

