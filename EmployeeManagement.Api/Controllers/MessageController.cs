using EmployeeManagement.Api.ControllerBase;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.MessagesAppService;
using EmployeeManagement.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<long>> AddMessage(CreateMessageDto createMessageDto)
        {
            var response = await _messageService.AddMessage(createMessageDto);
            if (response > 0)
                return Ok(response);

            else return BadRequest("Failed to send message");
        }

        
        [HttpGet]
        [Route("messages")]
        public async Task<ActionResult<List<MessageDto>>> GetMessageForUser([FromQuery] MessageParams messageParams)
        {
            try
            {
                var res = await _messageService.GetMessageForUser(messageParams);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("messageThread/{currentUserId}/{recepientId}")]
        public async Task<ActionResult<List<MessageDto>>> GetMessageThread(int currentUserId, int recepientId)
        {
            var res = await _messageService.GetMessageThread(currentUserId, recepientId);
            return Ok(res);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
