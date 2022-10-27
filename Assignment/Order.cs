

using System.Text.Json.Serialization;

namespace Assignment
{
    public class Order
    {
        [JsonConstructor]
        public Order(ProductOrder[] products)
        {
            OrderID = Guid.NewGuid().ToString();
            Products = products;
            TotalBinWidth= 0;
            CalculateTotalWidth();
        }
        
        public Order(ProductOrder product)
        {
            OrderID = Guid.NewGuid().ToString();
            Products = new ProductOrder[1];
            Products[0] = product;
            TotalBinWidth = 0;
            CalculateTotalWidth();
        }

        
        public string OrderID { get; set; }
      
        public ProductOrder[] Products { get; set; }

        public double TotalBinWidth { get; set; }

        public double CalculateTotalWidth()
        {
            foreach (var product in Products)
            {
                product.CalculateBinWidth();
                TotalBinWidth += product.RequiredBinWidth;
            }

            return TotalBinWidth;
        }

        public string info()
        {
            var info1 = "The Products for is order are:\n";
            foreach (var product in Products)
            {
                info1 += product.Product + " | ";
            }

            info1 += "\nOrder ID is: ";
            info1 += OrderID + "\n";
            info1 += "Binwidth required: ";
            info1 += TotalBinWidth;
            return info1;

        }
    }

}
