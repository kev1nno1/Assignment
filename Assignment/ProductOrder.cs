using Newtonsoft.Json;

namespace Assignment
{
    public class ProductOrder
    {
        public ProductOrder(int quantity,string product)
        {
            Quantity = quantity;
            Product = product;
            CalculateBinWidth();
        }

        [JsonProperty("Quantity")]
        public int Quantity { get; set; }

        [JsonProperty("Product")]
        public string Product { get; set; }

        public double RequiredBinWidth { get; set; }

        public double CardWidth = 4.7;
        public double PhotobookWidth = 10;
        public double CalendarWidth = 16;
        public double CanvasWidth = 4.7;
        public double MugWidth = 94;

        public void CalculateBinWidth()
        {
            if (Product == "photobook")
            {
                RequiredBinWidth = PhotobookWidth * Quantity;
            }
            else if (Product == "calendar")
            {
                RequiredBinWidth = CalendarWidth * Quantity;

            }
            else if (Product == "canvas")
            {
                RequiredBinWidth = CanvasWidth * Quantity;
            }
            else if (Product == "card")
            {
                RequiredBinWidth = CardWidth * Quantity;
            }
            else if (Product == "mug")
            {
                if(Quantity%2 == 0)//check if even
                {
                    RequiredBinWidth = MugWidth * (Quantity/2);
                }
                else
                {
                    if (Quantity == 1)
                    {
                        RequiredBinWidth = MugWidth;
                    }
                    else
                    {
                        RequiredBinWidth = MugWidth*((Quantity+1)/2);
                    }
                }
            }
        }

    }
    
}
