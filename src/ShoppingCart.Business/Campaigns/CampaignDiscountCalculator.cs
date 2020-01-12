using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Business.Carts;
using ShoppingCart.Business.Categories;
using ShoppingCart.Business.Products;

namespace ShoppingCart.Business.Campaigns
{
    public class CampaignDiscountCalculator
    {
        public Dictionary<Category, double> CalculateDiscount(Cart cart)
        {
            Dictionary<Category, double> discounts = new Dictionary<Category, double>();

            var products = cart.GetProducts();
            var campaigns = cart.GetCampaigns();

            var campaignsByCategory = campaigns.GroupBy(x => x.Category).ToList();

            foreach (var campaignGroupByCategory in campaignsByCategory)
            {
                var maxDiscount = GetMaxDiscountByCategory(
                    campaignGroupByCategory.Key,
                    products.Where(p => p.Key.Category == campaignGroupByCategory.Key).ToDictionary(x => x.Key, y => y.Value),
                    campaignGroupByCategory.ToList()
                );

                discounts.Add(campaignGroupByCategory.Key, maxDiscount);
            }

            return discounts;
        }

        private double GetMaxDiscountByCategory(Category category, Dictionary<Product, int> productsByCategory, List<Campaign> campaignsByCategory)
        {
            double maxDiscount = 0;

            var productCount = productsByCategory.Sum(d => d.Value);

            foreach (var campaign in campaignsByCategory)
            {
                if (productCount < campaign.MinimumNumberOfItems)
                {
                    continue;
                }

                switch (campaign.DiscountType)
                {
                    case DiscountType.Rate:
                        {
                            var totalPriceOfProductsByCategory = productsByCategory
                                .Sum(p => p.Key.Price * p.Value);

                            var discount = totalPriceOfProductsByCategory * campaign.Discount / 100;

                            if (discount > maxDiscount)
                            {
                                maxDiscount = discount;
                            }
                        }
                        break;
                    case DiscountType.Amount:
                        {
                            if (campaign.Discount > maxDiscount)
                            {
                                maxDiscount = campaign.Discount;
                            }
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return maxDiscount;
        }
    }
}
