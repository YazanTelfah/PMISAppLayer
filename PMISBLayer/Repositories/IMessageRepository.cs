using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
     public interface IMessageRepository
    {
        public List<Message> GetAllMessages();

        public void InsertMessage(Message message);

        public void Delete(int messageid);

    }
}
