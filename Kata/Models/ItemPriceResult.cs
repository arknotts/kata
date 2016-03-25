using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kata.Models
{
    public class ItemPriceResult
    {
        public decimal TotalPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }
}