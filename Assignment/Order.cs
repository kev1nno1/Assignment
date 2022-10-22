namespace Assignment
{
    public class Order
    {
        public Order(int orderID, IEnumerable<ProductOrder> products)
        {
            OrderID = orderID;
            Products = products;
        }


        public int OrderID { get; set; }
        public IEnumerable<ProductOrder> Products { get; set; }

        public float TotalBinWidth { get; set; }

        public float CalculateWidth(IEnumerable<ProductOrder> pruducts)
        {
            var x = new float();
            return x;
        }
    }

}
