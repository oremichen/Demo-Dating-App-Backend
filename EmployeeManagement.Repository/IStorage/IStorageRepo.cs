using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeeManagement.Repository.IStorage
{
   
        public interface IStorageRepo
        {
            // ANQ Data
            void UseConnection(Action<IDbConnection> action);
            T UseConnection<T>(Func<IDbConnection, T> func);
            IDbConnection CreateAndOpenConnection();
            void ReleaseConnection(IDbConnection connection);

        }
    
}
