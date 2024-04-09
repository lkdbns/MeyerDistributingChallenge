using InterviewTest.Orders;

namespace InterviewTest.Returns
{
    public class ReturnedProduct
    {
        public ReturnedProduct(OrderedProduct product)
        {
            OrderProduct = product;
        }

        public OrderedProduct OrderProduct { get; set; }
    }
}
