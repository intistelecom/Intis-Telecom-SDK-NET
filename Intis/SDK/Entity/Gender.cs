
namespace Intis.SDK.Entity
{
    public class Gender
    {
        /// <summary>
        /// Constant for male
        /// </summary>
        /// <returns>integer</returns>
        const int Male = 1;

        /// <summary>
        /// Constant for female
        /// </summary>
        /// <returns>integer</returns>
        const int Female = 2;

        /// <summary>
        /// Constant for undefined gender
        /// </summary>
        /// <returns>integer</returns>
        const int Undefined = 3;

        /// <summary>
        /// Parsing a string for getting gender of subscriber
        /// </summary>
        /// <param name="str">String representation of subscriber gender</param>
        /// <returns>integer</returns>
        public static int Parse(string str){
            switch (str)
            {
                case "m":
                    return Male;
                case "f":
                    return Female;
            }

            return Undefined;
        }
    }
}
