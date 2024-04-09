using System.Collections.Generic;
using InterviewTest.Orders;

namespace InterviewTest.Returns
{
    public class Return : IReturn
    {
        public Return(string returnNumber, IOrder originalOrder)
        {
            ReturnNumber = returnNumber;
            OriginalOrder = originalOrder;
            ReturnedProducts = new List<ReturnedProduct>();
        }

        public string ReturnNumber { get; }
        public IOrder OriginalOrder { get; }
        public List<ReturnedProduct> ReturnedProducts { get; }

        public void AddProduct(OrderedProduct product)
        {
            ReturnedProducts.Add(new ReturnedProduct(product));
        }
    }
}
