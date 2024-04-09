using System;
using System.Collections.Generic;
using InterviewTest.Customers;

namespace InterviewTest.Orders
{
    public interface IOrder
    {
        ICustomer Customer { get; }
        string OrderNumber { get; }
        DateTime OrderDate { get; }
        List<OrderedProduct> Products { get; }

        void AddProduct(Products.IProduct product);
    }
}