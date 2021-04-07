using System;
using BaseApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaseApi.Tests
{

    public class DatabaseTests : IDisposable
    {

        private readonly IDbContextTransaction _transaction;
        protected DatabaseContext DatabaseContext { get; }

        public DatabaseTests()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(ConnectionString.TestDatabase());
            DatabaseContext = new DatabaseContext(builder.Options);
            DatabaseContext.Database.EnsureCreated();
            _transaction = DatabaseContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

    }

}
