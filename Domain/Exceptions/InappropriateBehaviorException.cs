using System;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    /// <summary>
    /// This exception is raised when an action is attempted that doesn't make sense in context, like launching a rocket 1 mile underground.
    /// Not exactly what you were thinking, was it?
    /// </summary>
    public class InappropriateBehaviorException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the InappropriateBehaviorException class.
        /// </summary>
        public InappropriateBehaviorException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the InappropriateBehaviorException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error. </param>
        public InappropriateBehaviorException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the InappropriateBehaviorException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param><param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. </param>
        public InappropriateBehaviorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the InappropriateBehaviorException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data. </param><param name="context">The contextual information about the source or destination. </param>
        protected InappropriateBehaviorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
