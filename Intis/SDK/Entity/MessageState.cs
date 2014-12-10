
namespace Intis.SDK.Entity
{
    public class MessageState
    {
        /// <summary>
        /// Constant for scheduled message
        /// </summary>
        /// <returns>integer</returns>
        const int SCHEDULED = 0;

        /// <summary>
        /// Constant for message with ENROUT status
        /// </summary>
        /// <returns>integer</returns>
        const int ENROUTE = 1;

        /// <summary>
        /// Constant for delivered message
        /// </summary>
        /// <returns>integer</returns>
        const int DELIVERED = 2;

        /// <summary>
        /// Constant for expired message
        /// </summary>
        /// <returns>integer</returns>
        const int EXPIRED = 3;

        /// <summary>
        /// Constant for deleted message
        /// </summary>
        /// <returns>integer</returns>
        const int DELETED = 4;

        /// <summary>
        /// Constant for undelivered message
        /// </summary>
        /// <returns>integer</returns>
        const int UNDELIVERABLE = 5;

        /// <summary>
        /// Constant for sent message
        /// </summary>
        /// <returns>integer</returns>
        const int ACCEPTED = 6;

        /// <summary>
        /// Constant for unknown message
        /// </summary>
        /// <returns>integer</returns>
        const int UNKNOWN = 7;

        /// <summary>
        /// Constant for rejected message
        /// </summary>
        /// <returns>integer</returns>
        const int REJECTED = 8;

        /// <summary>
        /// Constant for missed message
        /// </summary>
        /// <returns>integer</returns>
        const int SKIPPED = 9;

        /// <summary>
        /// Analysis of the string of message status
        /// </summary>
        /// <param name="string">String presentation of message status</param>
        /// <returns>integer</returns>
        public static int? parse(string state)
        {
            switch (state)
            {
                case "deliver":
                    return DELIVERED;
                case "expired":
                    return EXPIRED;
                case "not_deliver":
                    return UNDELIVERABLE;
                case "partly_deliver":
                    return ACCEPTED;
                default:
                    return null;
            }
        }
    }
}
