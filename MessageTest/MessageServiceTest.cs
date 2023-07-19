using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.MessagesAppService;
using NUnit.Framework;
using System;

namespace MessageTest
{
    public class Tests
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

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async void GetMessageTest()
        {
            MessageService messageService = new MessageService(null, null);
            var res = await messageService.GetMessage(200000);
            Assert.AreEqual(message, res);
        }

        [Test]
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