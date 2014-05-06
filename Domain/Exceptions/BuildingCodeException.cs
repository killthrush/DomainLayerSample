﻿using System;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    /// <summary>
    /// An exception raised when we violate the building code by adding too many structures to a plot of land.
    /// </summary>
    public class BuildingCodeException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the BuildingCodeException class.
        /// </summary>
        public BuildingCodeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BuildingCodeException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error. </param>
        public BuildingCodeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BuildingCodeException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param><param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. </param>
        public BuildingCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BuildingCodeException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data. </param><param name="context">The contextual information about the source or destination. </param>
        protected BuildingCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
