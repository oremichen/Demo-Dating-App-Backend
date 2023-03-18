using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.MessageRepository
{
    public interface IMessageRepo
    {
        Task<long> AddMessage(Message message);
        Task DeleteMessage(int id);
        Task<Message> GetMessage(int id);
        Task<IEnumerable<Message>> GetUserMessages();
        Task<List<Message>> GetMessageThread();
        Task<IEnumerable<Message>> GetMessageForUser();
    }
}
