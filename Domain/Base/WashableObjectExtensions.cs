using System;

namespace Domain.Base
{
    /// <summary>
    /// Contains helper extensions used to add common functionality to IWashable implementations.
    /// </summary>
    /// <remarks>
    /// This class provides a way to avoid strict inheritance and re-use simple calculation code.
    /// </remarks>
    internal static class WashableObjectExtensions
    {
        /// <summary>
        /// Derive the Dirt Rating from the clean percentage
        /// </summary>
        /// <param name="washableObject">A washable object that has a clean percentage</param>
        /// <returns>The Dirt Rating</returns>
        internal static DirtRating CalculateDirtRating(this IWashableObject washableObject)
        {
            decimal percentClean = washableObject.PercentClean;
            return CalculateDirtRating(percentClean);
        }

        /// <summary>
        /// Derive the Dirt Rating from the clean percentage
        /// </summary>
        /// <param name="percentClean">The clean percentage</param>
        /// <returns>The Dirt Rating</returns>
        internal static DirtRating CalculateDirtRating(decimal percentClean)
        {
            if (percentClean >= 0 && percentClean <= 19)
            {
                return DirtRating.UtterlyFilthy;
            }
            if (percentClean > 19 && percentClean <= 39)
            {
                return DirtRating.PrettyDirty;
            }
            if (percentClean > 39 && percentClean <= 79)
            {
                return DirtRating.NominallyBesmirched;
            }
            if (percentClean > 79 && percentClean <= 89)
            {
                return DirtRating.Smudged;
            }
            if (percentClean > 89 && percentClean <= 99)
            {
                return DirtRating.SortaCleanButSmellsFunny;
            }
            return DirtRating.SqueakyClean;
        }

        /// <summary>
        /// Start washing the object.  After a certain number of minutes (varies by object type and soap factor), the object is clean.
        /// </summary>
        /// <param name="washableObject">A washable object that has a clean percentage</param>
        /// <param name="soapFactor">A scalar value that be used to magnify the effectiveness of washing</param>
        internal static decimal CalculateCleanPercentageAfterOneMinuteWash(this IWashableObject washableObject, decimal soapFactor)
        {
            decimal percentageCleanPerMinute = 100m / washableObject.MinutesRequiredToClean;
            return Math.Min(washableObject.PercentClean + percentageCleanPerMinute, 100m);
        }
    }
}
