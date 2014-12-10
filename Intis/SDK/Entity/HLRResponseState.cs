
namespace Intis.SDK.Entity
{
    public class HLRResponseState
    {
        /// <summary>
        /// Constant of the successful status
        /// </summary>
        /// <returns>integer</returns>
        const int SUCCESS = 1;

        /// <summary>
        /// Constant of the status error
        /// </summary>
        /// <returns>integer</returns>
        const int FAILED = 2;

        /// <summary>
        /// Analysis of the string of status by HLR request
        /// </summary>
        /// <param name="string">String representation of status</param>
        /// <returns>integer</returns>
        public static int parse(string str){
            if(str.ToLower() == "delivrd")
                return SUCCESS;
            return FAILED;
        }
    }
}
