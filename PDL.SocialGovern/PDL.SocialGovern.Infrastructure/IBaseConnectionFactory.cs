using System.Data;

namespace PDL.SocialGovern.Infrastructure
{

    /// <summary>
    /// The base connection factory
    /// </summary>
    public interface IBaseConnectionFactory
    {
        /// <summary>
        /// Gets the database connection
        /// </summary>
        IDbConnection DbConnection { get; }

        /// <summary>
        /// Gets the database transaction
        /// </summary>
        IDbTransaction DbTransaction { get; }

        /// <summary>
        /// commits this instance
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks this inatance
        /// </summary>
        void Rollback();
    }
}
