using System;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    /// <summary>
    /// An exception raised when we try to add too many things to a container
    /// </summary>
    public class CapacityException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the CapacityException class.
        /// </summary>
        public CapacityException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CapacityException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error. </param>
        public CapacityException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CapacityException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param><param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. </param>
        public CapacityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CapacityException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data. </param><param name="context">The contextual information about the source or destination. </param>
        protected CapacityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
