using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework.Internal;
using EmployeeManagement.AppService.Dtos;

namespace EmployeeManagement.AppService.MessagesAppService.Tests
{
    [TestClass()]
    public class MessageServiceTests
    {
        MessageDto message = new MessageDto()
        {
            RecepientId = 3,
            SenderDeleted = false,
            SenderId = 4,
            Content = "",
            DateRead = DateTime.Now,
            RecepientName = "",
            Id = 10,
            RecipientDeleted = false,
            MessageSent = DateTime.Now,
            SenderUsername = "",
            SenderPhotoUrl = ""
        };

        [TestMethod()]
        public async void GetMessageTest()
        {
            MessageService messageService = new MessageService(null, null);
            var res = await messageService.GetMessage(200000);
            Assert.AreEqual(message, res);
        }

        [TestMethod()]
        public async void AddMessageTest()
        {
            CreateMessageDto createMessage = new CreateMessageDto()
            {
                RecepientId = 3,
                SenderId = 4,
                Content = "",
            };

            MessageService messageService = new MessageService(null, null);
            var res = await messageService.AddMessage(createMessage);
            Assert.AreNotEqual(message, res);
        }
    }
}