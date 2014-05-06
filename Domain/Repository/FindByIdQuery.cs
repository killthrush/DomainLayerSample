using System.Data;
using Dapper;

namespace Domain.Repository
{
    /// <summary>
    /// Shortcut query for finding entities by ID
    /// </summary>
    internal class FindByIdQuery : ISqlQuery
    {
        private readonly int _entityId;

        /// <summary>
        /// Initializes a new instance of the FindByIdQuery class.
        /// </summary>
        public FindByIdQuery(int entityId)
        {
            _entityId = entityId;
        }

        /// <summary>
        /// A set of parameters that will be used with the query
        /// </summary>
        public DynamicParameters Parameters
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// The SQL statement to execute
        /// </summary>
        public string Sql
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// The type of SQL query (stored proc, text, etc)
        /// </summary>
        public CommandType CommandType
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
