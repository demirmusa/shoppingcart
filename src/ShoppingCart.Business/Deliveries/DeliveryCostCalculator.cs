using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Business.Carts;

namespace ShoppingCart.Business.Deliveries
{
    public class DeliveryCostCalculator
    {
        public double CostPerDelivery { get; set; }

        public double CostPerProduct { get; }

        public double FixedCost { get; }

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            CostPerDelivery = costPerDelivery;
            CostPerProduct = costPerProduct;
            FixedCost = fixedCost;
        }

        public double CalculateFor(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
