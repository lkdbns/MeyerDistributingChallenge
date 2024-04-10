using System;
using System.Collections.Generic;
using InterviewTest.Orders;
using InterviewTest.Products;
using InterviewTest.Returns;

namespace InterviewTest.Customers
{
    public abstract class CustomerBase : ICustomer
    {
        private readonly OrderRepository _orderRepository;
        private readonly ReturnRepository _returnRepository;

        protected CustomerBase(OrderRepository orderRepo, ReturnRepository returnRepo)
        {
            _orderRepository = orderRepo;
            _returnRepository = returnRepo;
        }

        public abstract string GetName();
        
        public void CreateOrder(IOrder order)
        {
            _orderRepository.Add(order);
        }

        public List<IOrder> GetOrders()
        {
            return _orderRepository.Get();
        }

        public void CreateReturn(IReturn rga)
        {
            _returnRepository.Add(rga);
        }

        public List<IReturn> GetReturns()
        {
            return _returnRepository.Get();
        }

        /*
            I utilize a foreach loop to iterate over the list of orders.
            For each order I need to loop through the product list and 
            retrieve the selling price adding it to the totalSales variable.
            The method has O(n^2) time complexity and O(n) space complexity.
        */
        public float GetTotalSales()
        {
            float totalSales = 0;
            List<IOrder> orders = _orderRepository.Get(GetName());

            orders.ForEach(
                delegate(IOrder order) {
                    order.Products.ForEach(
                        delegate(OrderedProduct product) {
                            totalSales += product.Product.GetSellingPrice();
                        }
                    );
                }
            );

            return totalSales;
        }

        /*
            I utilize a foreach loop to iterate over the list of returns.
            For each return I need to loop through the product list and
            retrieve the selling price adding it to the totalReturn variable.
            The method has O(n^2) time complexity and O(n) space complexity.
        */
        public float GetTotalReturns()
        {
            float totalReturns = 0;
            List<IReturn> returns = _returnRepository.Get(GetName());

            returns.ForEach(
                delegate(IReturn returnItem) {
                    returnItem.ReturnedProducts.ForEach(
                        delegate(ReturnedProduct product) {
                            totalReturns += product.OrderProduct.Product.GetSellingPrice();
                        }
                    );
                }
            );

            return totalReturns;
        }

        /*
            Since there is no manufactruing cost for a product I assume the calculation for 
            profit is sales-retuns. For my implementation, I simply call GetTotalSales and 
            subtract GetTotalReturns.
        */
        public float GetTotalProfit()
        {
            return GetTotalSales() - GetTotalReturns();
        }
    }
}
