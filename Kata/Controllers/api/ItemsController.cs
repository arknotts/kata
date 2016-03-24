using Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kata.Controllers
{
    /// <summary>
    /// API controller that handles transactions related to items.
    /// </summary>
    public class ItemsController : ApiController
    {
        /// <summary>
        /// The available items in stock at the store. Ideally this would be stored in a database.
        /// </summary>
        Item[] items = new Item[]
        {
            new Item() { Code = "A", Price = 1.25M, DealQuantity = 2, DealPrice = 2M },
            new Item() { Code = "B", Price = 3.99M },
            new Item() { Code = "C", Price = 4.0M, DealQuantity = 3, DealPrice = 10M },
            new Item() { Code = "D", Price = 2.50M },
            new Item() { Code = "E", Price = 0.99M, DealQuantity = 3, DealPrice = 2M },
        };

        /// <summary>
        /// Retrieves all items available.
        /// </summary>
        /// <returns>A list of all available items.</returns>
        public IEnumerable<Item> GetAllItems()
        {
            return items;
        }
    }
}
