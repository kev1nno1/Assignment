namespace Assignment
{
    public class Product
    {
        public int OrderID { get; set; }

        public int Quantity { get; set; }
        public ProductType ProductType { get; set; }
        public float RequiredBinWidth { get; set; }
    }
}
