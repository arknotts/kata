using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kata.Models
{
    /// <summary>
    /// Represents an available item at the store.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The code identifying the item.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The price per unit of the item.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The quantity required to get the deal price.
        /// </summary>
        public int? DealQuantity { get; set; }

        /// <summary>
        /// The price of the deal (given enough DealQuantity).
        /// </summary>
        public decimal? DealPrice { get; set; }
    }
}