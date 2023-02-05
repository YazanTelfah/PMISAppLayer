using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
  public  class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext dbContext;
        public MessageRepository(ApplicationDbContext MassageInfo )
        {
            this.dbContext = MassageInfo;
        }
        public List<Message> GetAllMessages ()
        {
            return dbContext.Messages.ToList();
        }

        public void InsertMessage(Message message)
        {
            dbContext.Messages.Add(message);
            dbContext.SaveChanges();
        }


        public void Delete(int messageid)
        {
            var msg = dbContext.Messages.SingleOrDefault(i => i.MessageId == messageid);
            dbContext.Remove(msg);
            dbContext.SaveChanges();

        }


    }
}
