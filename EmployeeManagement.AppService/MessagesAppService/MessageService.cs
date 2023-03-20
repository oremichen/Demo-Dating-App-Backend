using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.UsersAppServices;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.MessageRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.MessagesAppService
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepo _messageRepo;
        private readonly IUserAppService _userAppService;

        public MessageService(IMessageRepo messageRepo, IUserAppService userAppService)
        {
            _messageRepo = messageRepo;
            _userAppService = userAppService;
        }

        public async Task<long> AddMessage(CreateMessageDto message)
        {
            var sender = await _userAppService.GetUsersById(message.SenderId);
            var recepient = await _userAppService.GetUsersById(message.RecepientId);

            var mess = new Message
            {
                Content = message.Content,
                SenderId = message.SenderId,
                RecepientId = message.RecepientId,
                RecepientName = recepient.Name,
                SenderUsername = sender.Name,
                RecipientDeleted = false,
                SenderDeleted = false,
            };
            return await _messageRepo.AddMessage(mess);
        }

        public async Task DeleteMessage(int id)
        {
            await _messageRepo.DeleteMessage(id);
        }

        public async Task<MessageDto> GetMessage(int id)
        {
            var message = await _messageRepo.GetMessage(id);
            return new MessageDto
            {
                RecepientId = message.RecepientId,
                SenderDeleted = message.SenderDeleted,
                SenderId = message.SenderId,
                Content = message.Content,
                DateRead = message.DateRead,
                RecepientName = message.RecepientName,
                Id = message.Id,
                RecipientDeleted = message.RecipientDeleted,
                MessageSent = message.MessageSent,
                SenderUsername = message.SenderUsername,
                SenderPhotoUrl = _userAppService.GetPhotoUrl(message.SenderId)
            };
        }

        public async Task<List<MessageDto>> GetMessageThread(int currentUserId, int recepientId)
        {
            var messages = await _messageRepo.GetMessageThread(currentUserId, recepientId);
            var unreadMessages = messages.Where(m => m.DateRead == null && m.RecepientId == recepientId).ToList();

            if (unreadMessages.Any())
            {
                foreach (var message in unreadMessages)
                {
                    message.DateRead = DateTime.Now;
                    await _messageRepo.UpdateMessage(message);
                }
            }

            var msgs = messages.Select(m => new MessageDto
            {

                RecepientId = m.RecepientId,
                SenderDeleted = m.SenderDeleted,
                SenderId = m.SenderId,
                Content = m.Content,
                DateRead = m.DateRead,
                RecepientName = m.RecepientName,
                Id = m.Id,
                RecipientDeleted = m.RecipientDeleted,
                MessageSent = m.MessageSent,
                SenderUsername = m.SenderUsername,
                SenderPhotoUrl = _userAppService.GetPhotoUrl(m.SenderId)
            });

            return msgs.ToList();
        }

        public Task<List<Message>> GetUserMessages()
        {
            throw new NotImplementedException();
        }

        public async Task<List<MessageDto>> GetMessageForUser(MessageParams messageParams)
        {
            var mess = await _messageRepo.GetUserMessages();
            mess = mess.OrderByDescending(x => x.MessageSent)
                .AsQueryable();

            mess = messageParams.Container switch
            {
                "Inbox" => mess.Where(u => u.RecepientName == messageParams.Username),
                "Outbox" => mess.Where(u => u.SenderUsername == messageParams.Username),
                _ => mess.Where(u => u.RecepientName == messageParams.Username && u.DateRead == null)
            };

            var messages = mess.Select(m => new MessageDto
            {

                RecepientId = m.RecepientId,
                SenderDeleted = m.SenderDeleted,
                SenderId = m.SenderId,
                Content = m.Content,
                DateRead = m.DateRead,
                RecepientName = m.RecepientName,
                Id = m.Id,
                RecipientDeleted = m.RecipientDeleted,
                MessageSent = m.MessageSent,
                SenderUsername = m.SenderUsername,
                SenderPhotoUrl = _userAppService.GetPhotoUrl(m.SenderId)
            });

            return messages.ToList();
        }
    }
}
