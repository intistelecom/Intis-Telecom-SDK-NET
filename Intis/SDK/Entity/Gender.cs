// The MIT License (MIT)
// Copyright (c) 2015 Intis Telecom
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace Intis.SDK.Entity
{
    /// <summary>
    /// Class Gender
    /// Getting gender of subscriber
    /// </summary>
    public static class Gender
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
