using System;
using System.Data;
using System.Data.Common;
using WeatherAPI.Core.Common.InfraOperations;

namespace WeatherAPI.Application.BaseOperations
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbConnection _dbConnection = null;
        private IDbTransaction _transaction = null;
        private Guid _id = Guid.Empty;

        public UnitOfWork()
        {
            _id = Guid.NewGuid();
        }

        public Guid Id { get { return _id; } }

        public DbConnection Connection { get { return _dbConnection; } }

        public IDbTransaction Transaction { get { return _transaction; } }

        public void BeginScope(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;

            _dbConnection.Open();

            _transaction = _dbConnection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            if (_dbConnection != null && _dbConnection.State == ConnectionState.Open)
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }

            _transaction = null;
            _dbConnection = null;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }
    }
}
