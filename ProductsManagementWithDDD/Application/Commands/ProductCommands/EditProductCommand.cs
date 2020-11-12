using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ProductCommands
{
    public class EditProductCommand: IRequest
    {
        private Guid _productId;
        public Guid ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }


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

        public EditProductCommand(Guid productId, string productName, int quantity, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}
