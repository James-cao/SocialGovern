using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PDL.SocialGovern.Infrastructure
{
    public abstract class BaseConnectionFactory : IBaseConnectionFactory, IDisposable
    {
        ~BaseConnectionFactory()
        {
            Dispose(false);
        }
        private IDbConnection dbConnection;
        public IDbConnection DbConnection
        {
            get
            {
                if (dbConnection != null)
                    return dbConnection;


                if (ConfigurationManager.ConnectionStrings["PDLConnection"].ConnectionString != null)
                {
                    var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PDLConnection"].ConnectionString);
                    dbConnection = new ProfiledDbConnection(connection as DbConnection, MiniProfiler.Current);
                }

                dbConnection.Open();

                return dbConnection;
            }
        }

        private IDbTransaction dbTransaction;
        public IDbTransaction DbTransaction
        {
            get
            {
                return dbTransaction ?? (dbTransaction = DbConnection.BeginTransaction());
            }
        }

        public void Commit()
        {
            try
            {
                if (dbConnection == null || dbTransaction == null)
                    return;

                var profiledConnection = dbConnection as ProfiledDbConnection;
                if (profiledConnection != null && profiledConnection.WrappedConnection == null)
                    return;

                var profiledTransaction = dbTransaction as ProfiledDbTransaction;
                if (profiledTransaction != null && profiledTransaction.WrappedTransaction.Connection == null)
                    return;

                if (dbConnection.State == ConnectionState.Closed)
                    return;

                if (dbTransaction.Connection != null)
                    dbTransaction.Commit();

                if (dbConnection.State != ConnectionState.Closed)
                    dbConnection.Close();
            }
            catch (Exception e)
            {
                if (e is ObjectDisposedException || e is InvalidOperationException)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            try
            {
                if (dbConnection == null || dbTransaction == null)
                    return;

                var profiledConnection = dbConnection as ProfiledDbConnection;
                if (profiledConnection != null && profiledConnection.WrappedConnection == null)
                    return;

                var profiledTransaction = dbTransaction as ProfiledDbTransaction;
                if (profiledTransaction != null && profiledTransaction.WrappedTransaction.Connection == null)
                    return;

                if (dbTransaction.Connection != null)
                    dbTransaction.Rollback();
                if (dbConnection.State != ConnectionState.Closed)
                    dbConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #region Helper dispose
        private bool disposed;
        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                Commit();
                if (dbTransaction != null)
                    dbTransaction.Dispose();
                if (dbConnection != null)
                    dbConnection.Dispose();
            }
            dbConnection = null;
            dbTransaction = null;

            disposed = true;
        }
        #endregion
    }
}
