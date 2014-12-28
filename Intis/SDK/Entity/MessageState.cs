
namespace Intis.SDK.Entity
{
    public class MessageState
    {
        /// <summary>
        /// Constant for scheduled message
        /// </summary>
        /// <returns>integer</returns>
        const int Scheduled = 0;

        /// <summary>
        /// Constant for message with ENROUT status
        /// </summary>
        /// <returns>integer</returns>
        const int Enroute = 1;

        /// <summary>
        /// Constant for delivered message
        /// </summary>
        /// <returns>integer</returns>
        const int Delivered = 2;

        /// <summary>
        /// Constant for expired message
        /// </summary>
        /// <returns>integer</returns>
        const int Expired = 3;

        /// <summary>
        /// Constant for deleted message
        /// </summary>
        /// <returns>integer</returns>
        const int Deleted = 4;

        /// <summary>
        /// Constant for undelivered message
        /// </summary>
        /// <returns>integer</returns>
        const int Undeliverable = 5;

        /// <summary>
        /// Constant for sent message
        /// </summary>
        /// <returns>integer</returns>
        const int Accepted = 6;

        /// <summary>
        /// Constant for unknown message
        /// </summary>
        /// <returns>integer</returns>
        const int Unknown = 7;

        /// <summary>
        /// Constant for rejected message
        /// </summary>
        /// <returns>integer</returns>
        const int Rejected = 8;

        /// <summary>
        /// Constant for missed message
        /// </summary>
        /// <returns>integer</returns>
        const int Skipped = 9;

        /// <summary>
        /// Analysis of the string of message status
        /// </summary>
        /// <param name="state">String presentation of message status</param>
        /// <returns>integer</returns>
        public static int? Parse(string state)
        {
            switch (state)
            {
                case "deliver":
                    return Delivered;
                case "expired":
                    return Expired;
                case "not_deliver":
                    return Undeliverable;
                case "partly_deliver":
                    return Accepted;
                default:
                    return null;
            }
        }
    }
}
