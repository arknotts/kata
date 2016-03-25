using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kata.Models
{
    /// <summary>
    /// The result of calculating the price for a single item at a given quantity.
    /// </summary>
    public class ItemPriceResult
    {
        /// <summary>
        /// Total price of the item at the given quantity.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Whether a discount was applied or not.
        /// </summary>
        public bool DiscountApplied { get; set; }
    }
}