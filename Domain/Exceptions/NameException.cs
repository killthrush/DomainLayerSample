using System;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    /// <summary>
    /// An exception raised when we try to give something an invalid name
    /// </summary>
    public class NameException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the NameException class.
        /// </summary>
        public NameException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the NameException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error. </param>
        public NameException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NameException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param><param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. </param>
        public NameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NameException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data. </param><param name="context">The contextual information about the source or destination. </param>
        protected NameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
