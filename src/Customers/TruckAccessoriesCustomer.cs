using InterviewTest.Orders;
using InterviewTest.Returns;

namespace InterviewTest.Customers
{
    public class TruckAccessoriesCustomer : CustomerBase
    {
        public TruckAccessoriesCustomer(OrderRepository orderRepo, ReturnRepository returnRepo)
            : base(orderRepo, returnRepo)
        {

        }

        public override string GetName()
        {
            return "Meyer Truck Equipment";
        }
    }
}
