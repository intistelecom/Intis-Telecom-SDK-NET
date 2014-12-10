
namespace Intis.SDK.Entity
{
    public class OriginatorState
    {
        /// <summary>
        /// Constant for approved sender
        /// </summary>
        /// <returns>integer</returns>
        const int COMPLETED = 1;

        /// <summary>
        /// Constant for sender in moderation queue
        /// </summary>
        /// <returns>integer</returns>
        const int MODERATION = 2;

        /// <summary>
        /// Constant for rejected sender
        /// </summary>
        /// <returns>integer</returns>
        const int REJECTED = 3;

        /// <summary>
        /// Analysis of the string of sender status
        /// </summary>
        /// <param name="string">String presentation of sender status</param>
        /// <returns>integer</returns>
        public static int? parse(string str){
              if (str == "completed"){
                    return COMPLETED;
              }
              else if (str == "order"){
                    return MODERATION;
              }
              else if (str == "rejected"){
                    return REJECTED;
              }
              return null;
        }
    }
}
