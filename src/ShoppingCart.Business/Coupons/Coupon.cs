using System;

namespace ShoppingCart.Business.Coupons
{
    public class Coupon
    {
        public double MinimumAmount { get; set; }

        public double Discount { get; set; }

        public DiscountType DiscountType { get; set; }

        public Coupon(double minimumAmount, double discount, DiscountType discountType)
        {
            if (minimumAmount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minimumAmount), $"{nameof(minimumAmount)} should be more than 0 (zero)");
            }

            if (discount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(discount), $"{nameof(discount)} should be more than 0 (zero)");
            }

            MinimumAmount = minimumAmount;
            Discount = discount;
            DiscountType = discountType;
        }
    }
}
