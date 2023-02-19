namespace Product.Models
{
    public class OrderModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        private int productID;
        private decimal price;
        ProductModel productModel = new ProductModel();
        public int ProductID
        {
            get { return productID; }
            set { productID = productModel.ID; }
        }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get { return price; }
            set { price = (productModel.Price * Quantity); }
        }


    }
}
