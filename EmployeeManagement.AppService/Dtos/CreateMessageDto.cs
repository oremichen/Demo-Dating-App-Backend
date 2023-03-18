using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.AppService.Dtos
{
    public class CreateMessageDto
    {
        public int RecepientId { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
    }
}
