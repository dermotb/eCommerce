
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.Models
{
    public class Product
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }

    public class CartItem : Product
    {
        public int Quantity { get; set; }

        public CartItem(Product p)
        {
            Code = p.Code;
            Description = p.Description;
            Price = p.Price;
            Quantity = 1;
        }
    }

    public class ShoppingCart
    {
        public List<CartItem> ItemsList { get; }

        public ShoppingCart()
        {
            ItemsList = new List<CartItem>();
        }

        public void AddItem(Product p)
        {
            var match = ItemsList.FirstOrDefault(x => x.Code.Equals(p.Code));
            if (match == null)
            {
                ItemsList.Add(new CartItem(p));
            }
            else
            {
                match.Quantity++;
            }
        }

        public double CalculateTotalPrice()
        {
            return ItemsList.Sum(item=>item.Price * item.Quantity);
        }
    }
}