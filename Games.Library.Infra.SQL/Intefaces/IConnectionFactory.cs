using Games.Library.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Games.Library.Infra.SQL.Intefaces
{
    public interface IConnectionFactory 
    {
        DbConnection Connection();
    }
}
