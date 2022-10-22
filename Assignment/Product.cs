namespace Assignment
{
    public class Product
    {
        public Product(ProductType productType, float requiredBinWidth)
        {
            ProductType = productType;
            RequiredBinWidth = requiredBinWidth;
        }
        public ProductType ProductType { get; set; }
        public float RequiredBinWidth { get; set; }
    }
}
