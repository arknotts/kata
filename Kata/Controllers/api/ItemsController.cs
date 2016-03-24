using Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kata.Controllers
{
    public class ItemsController : ApiController
    {
        //ideally this would be stored in a database in the future
        Item[] items = new Item[]
        {
            new Item() { Code = "A", Price = 1.25M },
            new Item() { Code = "B", Price = 3.99M },
        };

        public IEnumerable<Item> GetAllItems()
        {
            return items;
        }
    }
}
