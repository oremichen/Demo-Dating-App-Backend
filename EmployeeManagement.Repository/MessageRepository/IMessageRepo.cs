using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.MessageRepository
{
    public interface IMessageRepo
    {
        Task AddMessage(Message message);
        Task DeleteMessage(Message message);
        Task<Message> GetMessage(int id);
        Task<List<Message>> GetUserMessages();
        Task<IEnumerable<Message>> GetMessageThread();
    }
}
