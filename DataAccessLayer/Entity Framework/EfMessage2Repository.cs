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
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListMessageByWriter(int id) //list of receiverid all messages
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
                //List of ReceiverUser by ReceiverID
            }
        }
        public Message2 GetOneMessageWithSender(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).SingleOrDefault();
                //List of ReceiverUser by ReceiverID
            }
           

        }
        public Message2 GetOneMessageWithSenderByID(int id)
            {
                using (var c = new Context())
                {
                    return c.Message2s.Include(x => x.SenderUser).FirstOrDefault(x => x.MessageID == id);
            }
            }
    }
}
