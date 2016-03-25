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

        /// <summary>
        /// Calculates the total price of an item at a given quantity.
        /// </summary>
        /// <param name="code">Code of the item.</param>
        /// <param name="quantity">Quantity of the item.</param>
        /// <returns></returns>
        public ItemPriceResult GetTotalItemPrice(string code, int quantity)
        {
            ItemPriceResult itemPriceResult = new ItemPriceResult();

            //Find the item that matches the passed code
            Item item = items.FirstOrDefault(i => i.Code == code);

            if(item != null)
            {
                if(quantity >= item.DealQuantity  //make sure it has met the minimum quantity
                    && item.DealPrice.HasValue) //and that it actually has a deal
                {
                    //calculate price based on number of "groups" at the deal price plus the remainder at regular price
                    decimal totalDealPrice = (quantity / item.DealQuantity.Value) * item.DealPrice.Value;
                    decimal remainderPrice = (quantity % item.DealQuantity.Value) * item.Price;
                    itemPriceResult.TotalPrice = totalDealPrice + remainderPrice;

                    itemPriceResult.DiscountApplied = true;
                }
                else
                {
                    //calculate it simply off of regular price
                    itemPriceResult.TotalPrice = quantity * item.Price;
                }

                return itemPriceResult;
            }

            return null;
        }
    }
}
