using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kata.Models
{
    /// <summary>
    /// Represents an item in the current order, including its quantity
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// The item object
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// Quantity of the item in the order
        /// </summary>
        public int Quantity { get; set; }
    }
}