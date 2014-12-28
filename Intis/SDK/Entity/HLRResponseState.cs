
namespace Intis.SDK.Entity
{
    public class HlrResponseState
    {
        /// <summary>
        /// Constant of the successful status
        /// </summary>
        /// <returns>integer</returns>
        const int Success = 1;

        /// <summary>
        /// Constant of the status error
        /// </summary>
        /// <returns>integer</returns>
        const int Failed = 2;

        /// <summary>
        /// Analysis of the string of status by HLR request
        /// </summary>
        /// <param name="str">String representation of status</param>
        /// <returns>integer</returns>
        public static int Parse(string str)
        {
            return str.ToLower() == "delivrd" ? Success : Failed;
        }
    }
}
