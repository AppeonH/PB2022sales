using System;
using SnapObjects.Data;
using SnapObjects.Data.Odbc;

namespace Appeon.DataStoreDemo.SqlAnywhere
{
    public class OrderContext : OdbcSqlAnywhereDataContext
	{
        public OrderContext(string connectionString)
            : this(new OdbcSqlAnywhereDataContextOptions<OrderContext>(connectionString))
        {
        }

        public OrderContext(IDataContextOptions<OrderContext> options)
            : base(options)
        {
        }
        
        public OrderContext(IDataContextOptions options)
            : base(options)
        {
        }
    }
}
