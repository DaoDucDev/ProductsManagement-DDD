using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Models
{
    public class ProductDto
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

    }
}
