using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Orders
{
    public class OrderRepository
    {
        private List<IOrder> orders;
        public OrderRepository()
        {
            orders = new List<IOrder>();
        }

        public void Add(IOrder newOrder)
        {
            orders.Add(newOrder);
        }

        public void Remove(IOrder removedOrder)
        {
            orders = orders.Where(o => !string.Equals(removedOrder.OrderNumber, o.OrderNumber)).ToList();
        }

        public List<IOrder> Get()
        {
            return orders;
        }

        /*
            This overloaded Get function is used to get the list of orders 
            for a specific customer. I iterate over the orders using the FindAll 
            method to filter out any order not matching the specified customer name.
        */
        public List<IOrder> Get(String customerName) {
            return orders.FindAll(
                delegate(IOrder order) {
                    return order.Customer.GetName().Equals(customerName);
                }
            );
        }
    }
}
