using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeManagement.Repository.IStorage
{
    public class StorageRepo : IStorageRepo
    {
        private readonly ConnectionStrings _appSettings;

        public StorageRepo(IOptions<ConnectionStrings> options)
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

        public void UseConnection(Action<IDbConnection> action)
        {
            UseConnection(connection =>
            {
                action(connection);
                return true;
            });
        }

        public T UseConnection<T>(Func<IDbConnection, T> func)
        {
            IDbConnection connection = null;

            try
            {
                connection = CreateAndOpenConnection();
                return func(connection);
            }
            finally
            {
                ReleaseConnection(connection);
            }
        }

        public IDbConnection CreateAndOpenConnection()
        {
            var connection = Connection;
            connection.Open();

            return connection;
        }
        public void ReleaseConnection(IDbConnection connection)
        {
            if (connection != null)
            {
                connection.Dispose();
            }
        }

    }
}
