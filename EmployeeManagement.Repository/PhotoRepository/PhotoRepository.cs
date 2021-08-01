using Dapper;
using EmployeeManagement.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.PhotoRepository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ConnectionStrings _appSettings;

        public PhotoRepository(IOptions<ConnectionStrings> options)
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

        public  IEnumerable<Photos> GetUserPhotos(int userId)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetPhotosByUserId] @userId";
                var result =  conn.Query<Photos>(sql, new 
                {
                    userId
                });

                return result;
            }
        }
    }
}
