using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.MessageRepository
{
    public interface IMessageRepo
    {
        Task<long> AddMessage(Message message);
        Task DeleteMessage(int id);
        Task<Message> GetMessage(int id);
        Task<IQueryable<Message>> GetUserMessages();
        Task<IEnumerable<Message>> GetMessageThread(int currentUserId, int recepientId);
        Task<IEnumerable<Message>> GetMessageForUser();
    }
}
