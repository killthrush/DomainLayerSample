using System;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    /// <summary>
    /// An exception raised by the Awesome-O Model 2000 Smart Dishwasher.
    /// </summary>
    public class DishwasherException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the DishwasherException class.
        /// </summary>
        public DishwasherException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DishwasherException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error. </param>
        public DishwasherException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DishwasherException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param><param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. </param>
        public DishwasherException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DishwasherException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data. </param><param name="context">The contextual information about the source or destination. </param>
        protected DishwasherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
