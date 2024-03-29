﻿using Dapper;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.IStorage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.PhotoRepository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IStorageRepo _storageRepo;

        public PhotoRepository(IStorageRepo storageRepo)
        {
            _storageRepo = storageRepo;
        }

        public async Task DeletePhoto(int id)
        {
              _storageRepo.UseConnection(conn =>
            {
                var sql = $"[dbo].[DeletePhoto] @id";
                var result = conn.ExecuteScalar(sql, new
                {
                    id
                });
            });
            await Task.CompletedTask;

        }

        public async Task<Photos> GetPhotoById(int id)
        {
            var models = _storageRepo.UseConnection(conn =>
            {
                var sql = $"[dbo].[GetPhotoById] @id";
                var result = conn.QueryFirstOrDefault<Photos>(sql, new
                {
                    id
                });

                return result;
            });

            return await Task.FromResult(models);
        }

        public  IEnumerable<Photos> GetUserPhotos(int userId)
        {
            var models = _storageRepo.UseConnection(conn =>
            {
                var sql = $"[dbo].[GetPhotosByUserId] @userId";
                var result = conn.Query<Photos>(sql, new
                {
                    userId
                });

                return result;
            });

            return models;
        }

        public async Task InsertPhotos(Photos photo)
        {
               _storageRepo.UseConnection(conn =>
            {
               
                var sql = $"[dbo].[InsertPhotos] @url, @ismain, @publicId, @userId";
                    conn.ExecuteScalar<long>(sql, new
                {
                    photo.Url,
                    photo.IsMain,
                    photo.PublicId,
                    photo.UserId

                });
               
            });
            await Task.CompletedTask;
        }

        public async Task UpdatePhoto(Photos photo)
        {
              _storageRepo.UseConnection(conn =>
            {

                var sql = $"[dbo].[UpdatePhoto] @id, @url, @ismain, @publicId, @userId";
                conn.ExecuteScalar<long>(sql, new
                {
                    photo.Id,
                    photo.Url,
                    photo.IsMain,
                    photo.PublicId,
                    photo.UserId

                });

            });
            await Task.CompletedTask;
        }
    }
}
