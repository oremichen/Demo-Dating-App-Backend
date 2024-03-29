﻿using Dapper;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.IStorage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                     $"@recipientDeleted, @senderDeleted, @content, @dateRead";
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

        public async Task UpdateMessage(Message message)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[UpdateMessage] @id, @messageSent, @recepientId, @recepientName, @senderId, @senderUsername, " +
                    $"@recipientDeleted, @senderDeleted, @content, @dateRead";
                conn.ExecuteScalar<long>(sql, new
                {
                    message.Id,
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
            }
        }
        
        public async Task DeleteMessage(int id)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[DeleteMessage] @id";
                var result = conn.ExecuteScalar(sql, new
                {
                    id
                });
            }
        }

        public async Task<Message> GetMessage(int id)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetMessage] @id";
                var result = await conn.QueryFirstOrDefaultAsync<Message>(sql, new
                {
                    id
                });

                return result;
            }
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int currentUserId, int recepientId)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetMessageThread] @currentUserId, @recepientId";
                var result = await conn.QueryAsync<Message>(sql, new
                {
                    currentUserId,
                    recepientId
                });

                return result;
            }
        }

        public Task<IEnumerable<Message>> GetMessageForUser()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Message>> GetUserMessages()
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetMessages]";
                var result = await conn.QueryAsync<Message>(sql);
                return result.AsQueryable();
            }
        }
    }
}
