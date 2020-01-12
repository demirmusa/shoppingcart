using System;

namespace ShoppingCart.Business.Categories
{
    public class Category 
    {
        public string Title { get; set; }

        public Category ParentCategory { get; set; }

        public Category(string title)
        {
            Title = title;
        }

        public Category(string title, Category parentCategory)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            Title = title;
            ParentCategory = parentCategory;
        }
    }
}
