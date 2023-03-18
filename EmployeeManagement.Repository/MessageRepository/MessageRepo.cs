using Dapper;
using EmployeeManagement.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.MessageRepository
{
    public class MessageRepo : IMessageRepo
    {
        private readonly ConnectionStrings _appSettings;

        public MessageRepo(IOptions<ConnectionStrings> options)
        {
            _appSettings = options.Value;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_appSettings.EmployeeConnection);
            }
        }

        public async Task<long> AddMessage(Message message)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[AddMessage] @messageSent, @recepientId, @recepientName, @senderId, @senderUsername, " +
                    $"@recipientDeleted, @senderDeleted, @content, @deateRead" ;
                var result = await conn.ExecuteScalarAsync<long>(sql, new
                {
                    message.MessageSent,
                    message.RecepientId,
                    message.RecepientName,
                    message.SenderId,
                    message.SenderUsername,
                    message.RecipientDeleted,
                    message.SenderDeleted,
                    message.Content,
                    message.DateRead

                });
                return result;
            }
        }
        
        public Task DeleteMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetMessage(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetMessageThread()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Message>> GetUserMessages()
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetMessages]";
                var result = await conn.QueryAsync<Message>(sql);
                return result.AsList();
            }
        }
    }
}
