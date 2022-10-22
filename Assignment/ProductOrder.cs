namespace Assignment
{
    public class ProductOrder
    {
        public ProductOrder(Product product ,int quantity)
        {
            Quantity = quantity;
            Product = product;
        }

        public int Quantity { get; set; }
        public Product Product { get; set; }
        
    }
    
}
