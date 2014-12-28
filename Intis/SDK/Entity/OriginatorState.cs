
namespace Intis.SDK.Entity
{
    public class OriginatorState
    {
        /// <summary>
        /// Constant for approved sender
        /// </summary>
        /// <returns>integer</returns>
        const int Completed = 1;

        /// <summary>
        /// Constant for sender in moderation queue
        /// </summary>
        /// <returns>integer</returns>
        const int Moderation = 2;

        /// <summary>
        /// Constant for rejected sender
        /// </summary>
        /// <returns>integer</returns>
        const int Rejected = 3;

        /// <summary>
        /// Analysis of the string of sender status
        /// </summary>
        /// <param name="str">String presentation of sender status</param>
        /// <returns>integer</returns>
        public static int? Parse(string str)
        {
            switch (str)
            {
                case "completed":
                    return Completed;
                case "order":
                    return Moderation;
                case "rejected":
                    return Rejected;
            }
            return null;
        }
    }
}
