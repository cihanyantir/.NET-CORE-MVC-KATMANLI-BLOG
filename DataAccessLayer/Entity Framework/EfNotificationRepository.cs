using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
    public class EfNotificationRepository :GenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetNotificationWithValueAndDescending(int id) //Get info about category of blogs
        {
            using (var c = new Context())
            {
                return c.Notifications.Where(x => x.NotificationStatus == true).OrderByDescending(x => x.NotificationID).Take(id).ToList();
            }
         
        }
    }
}
