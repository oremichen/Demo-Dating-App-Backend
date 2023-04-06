using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.MessagesAppService
{
    public interface IMessageService
    {
        Task<MessageDto> AddMessage(CreateMessageDto message);
        Task DeleteMessage(int id);
        Task<MessageDto> GetMessage(int id);
        Task<List<Message>> GetUserMessages();
        Task<List<MessageDto>> GetMessageThread(int currentUserId, int recepientId);
        Task<List<MessageDto>> GetMessageForUser(MessageParams messageParams);
    }
}
