using Games.Library.Domain.Configurations;
using Games.Library.Infra.SQL.Intefaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Games.Library.Infra.SQL.Factory
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly DBConfiguration _dbConfiguration;

        public ConnectionFactory(DBConfiguration dbConfiguration)
        {
            _dbConfiguration = dbConfiguration;
        }

        private DbConnection connection;
        DbConnection IConnectionFactory.Connection()
        {          
            connection = this.connection ?? new SqlConnection(_dbConfiguration.ConnectionString);
            connection.Open();
            return connection;
            
        }
    }
}
