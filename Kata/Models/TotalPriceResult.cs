using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kata.Models
{
    /// <summary>
    /// The result of calculating the total price for an order.
    /// </summary>
    public class TotalPriceResult
    {
        /// <summary>
        /// The total price of the order
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}