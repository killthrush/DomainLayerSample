using System.Data;
using Dapper;

namespace Domain.Repository
{
    /// <summary>
    /// Defines operations for repository queries of different varieties
    /// </summary>
    public interface ISqlQuery
    {
        /// <summary>
        /// A set of parameters that will be used with the query
        /// </summary>
        DynamicParameters Parameters { get; }

        /// <summary>
        /// The SQL statement to execute
        /// </summary>
        string Sql { get; }

        /// <summary>
        /// The type of SQL query (stored proc, text, etc)
        /// </summary>
        CommandType CommandType { get; }
    }
}
