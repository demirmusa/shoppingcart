using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Business.Campaigns;
using ShoppingCart.Business.Categories;
using ShoppingCart.Business.Coupons;
using ShoppingCart.Business.Products;

namespace ShoppingCart.Business.Carts
{
    public class Cart
    {
        private readonly Dictionary<Product, int> _products = new Dictionary<Product, int>();

        private List<Campaign> _campaigns = new List<Campaign>();
        private List<Coupon> _coupons = new List<Coupon>();

        private Dictionary<Category, double> _campaignDiscount;

        private double _couponDiscount;

        private double _deliveryCost;

        private double _totalAmountAfterDiscounts;

        public Dictionary<Product, int> GetProducts() =>//return copy of items
            _products.ToDictionary(x => x.Key, y => y.Value);

        public void AddItem(Product product, int quantity)
        {
            if (_products.ContainsKey(product))
            {
                _products[product] += quantity;
            }
            else
            {
                _products.Add(product, quantity);
            }
        }

        public List<Campaign> GetCampaigns() =>//return copy of items
            _campaigns.ToList();

        public void ApplyDiscounts(params Campaign[] campaigns)
        {
            _campaigns.AddRange(campaigns);

            _campaignDiscount = new CampaignDiscountCalculator().CalculateDiscount(this);
        }

        public List<Coupon> GetCoupons() =>
            _coupons.ToList();

        public void ApplyCoupons(params Coupon[] coupon)
        {
            _coupons.AddRange(coupon);
        }

        public double GetTotalAmountAfterDiscounts()
        {
            throw new NotImplementedException();
        }

        public double GetCouponDiscount()
        {
            throw new NotImplementedException();
        }

        public double GetCampaignDiscount()
        {
            throw new NotImplementedException();
        }

        public double GetDeliveryCost()
        {
            throw new NotImplementedException();
        }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }
}
