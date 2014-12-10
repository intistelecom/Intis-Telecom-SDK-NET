
namespace Intis.SDK.Entity
{
    public class Gender
    {
        /// <summary>
        /// Constant for male
        /// </summary>
        /// <returns>integer</returns>
        const int MALE = 1;

        /// <summary>
        /// Constant for female
        /// </summary>
        /// <returns>integer</returns>
        const int FEMALE = 2;

        /// <summary>
        /// Constant for undefined gender
        /// </summary>
        /// <returns>integer</returns>
        const int UNDEFINED = 3;

        /// <summary>
        /// Parsing a string for getting gender of subscriber
        /// </summary>
        /// <param name="string">String representation of subscriber gender</param>
        /// <returns>integer</returns>
        public static int parse(string str){
            if (str == "m")
                return MALE;
            if (str == "f")
                return FEMALE;

            return UNDEFINED;
        }
    }
}
