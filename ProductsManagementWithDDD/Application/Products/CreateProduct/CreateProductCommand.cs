using Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.CreateProduct
{
    public class CreateProductCommand: CommandBase<ProductDto>
    {
        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public CreateProductCommand(string productName, int quantity, double price)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public bool? Verified { get; private set; }
    }
}
