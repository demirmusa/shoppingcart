using System;
using ShoppingCart.Business.Categories;

namespace ShoppingCart.Business.Campaigns
{
    public class Campaign
    {
        public Category Category { get; set; }

        public double Discount { get; set; }

        public int MinimumNumberOfItems { get; set; }
        
        public DiscountType DiscountType { get; set; }

        public Campaign(Category category, double discount, int minimumNumberOfItems, DiscountType discountType)
        {
            if (discount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(discount), $"{nameof(discount)} should be more than 0 (zero)");
            }

            if (discount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minimumNumberOfItems), $"{nameof(minimumNumberOfItems)} should be more than 0 (zero)");
            }

            Category = category;
            Discount = discount;
            DiscountType = discountType;
            MinimumNumberOfItems = minimumNumberOfItems;
        }
    }
}
