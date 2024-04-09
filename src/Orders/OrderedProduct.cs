using InterviewTest.Products;

namespace InterviewTest.Orders
{
    public class OrderedProduct
    {
        public OrderedProduct(IProduct product)
        {
            Product = product;
        }

        public IProduct Product { get; set; }
    }
}
