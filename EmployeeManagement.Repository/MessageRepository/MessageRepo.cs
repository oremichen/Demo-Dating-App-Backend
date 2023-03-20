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
        private readonly IStorageRepo _storageRepo;

        public MessageRepo(IStorageRepo storageRepo)
        {
            _storageRepo = storageRepo;
        }

       
        public async Task<long> AddMessage(Message message)
        {
            var res = await _storageRepo.UseConnection(conn =>
            {
                var sql = $"[dbo].[AddMessage] @messageSent, @recepientId, @recepientName, @senderId, @senderUsername, " +
                    $"@recipientDeleted, @senderDeleted, @content, @dateRead";
                var result = conn.ExecuteScalarAsync<long>(sql, new
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
            });

            return await Task.FromResult(res);
           
        }

        public async Task UpdateMessage(Message message)
        {
             _storageRepo.UseConnection(conn =>
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

            });
            await Task.CompletedTask;
        }
        
        public async Task DeleteMessage(int id)
        {
            _storageRepo.UseConnection(conn =>
            {
                var sql = $"[dbo].[DeleteMessage] @id";
                var result = conn.ExecuteScalar(sql, new
                {
                    id
                });
            });
            await Task.CompletedTask;
        }

        public async Task<Message> GetMessage(int id)
        {
            var message = await _storageRepo.UseConnection(conn =>
            {
                var sql = $"[dbo].[GetMessage] @id";
                var result = conn.QueryFirstOrDefaultAsync<Message>(sql, new
                {
                    id
                });

                return result;
            });

            return await Task.FromResult(message);
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int currentUserId, int recepientId)
        {
            var messages = await _storageRepo.UseConnection(conn =>
            {
                var sql = $"[dbo].[GetMessageThread] @currentUserId, @recepientId";
                var result = conn.QueryAsync<Message>(sql, new
                {
                    currentUserId,
                    recepientId
                });

                return result;
            });

            return await Task.FromResult(messages);
        }

        public Task<IEnumerable<Message>> GetMessageForUser()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Message>> GetUserMessages()
        {
            var models = await _storageRepo.UseConnection(conn =>
            {
                var sql = $"[dbo].[GetMessages]";
                var result = conn.QueryAsync<Message>(sql);
                return result;
            });

            return models.AsQueryable();
        }
    }
}
