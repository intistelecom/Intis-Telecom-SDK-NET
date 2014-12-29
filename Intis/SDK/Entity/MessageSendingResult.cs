using System;

namespace Intis.SDK.Entity
{
    public class MessageSendingResult
    {
        /// <summary>
        /// Phone number
        /// </summary>
        /// <returns>integer</returns>
		public Int64 Phone { get; set; }

		/// <summary>
		/// Success result
		/// </summary>
		/// <returns>bool</returns>
		public bool IsOk { get; set; }
    }
}
