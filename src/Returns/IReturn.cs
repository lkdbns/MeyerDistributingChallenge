using System.Collections.Generic;
using InterviewTest.Orders;

namespace InterviewTest.Returns
{
    public interface IReturn
    {
        IOrder OriginalOrder { get; }
        List<ReturnedProduct> ReturnedProducts { get; }
        string ReturnNumber { get; }

        void AddProduct(OrderedProduct product);
    }
}