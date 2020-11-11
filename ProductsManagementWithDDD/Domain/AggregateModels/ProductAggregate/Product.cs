using Domain.SeedWork;
using Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.AggregateModels.ProductAggregate
{
    public class Product: Entity, IAggregateRoot
    {
        
        private Guid _productId;
        [Column("product_id")]
        public Guid ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        
        private string _productName;
        [Column("product_name")]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        
        private int _quantity;
        [Column("quantity")]
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        
        private double _price;
        [Column("price")]
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public Product(string productName, int quantity, double price)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}
