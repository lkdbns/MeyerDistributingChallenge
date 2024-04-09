using System.Reflection;
using InterviewTest.Customers;
using InterviewTest.Orders;
using InterviewTest.Products;
using InterviewTest.Returns;

namespace InterviewTests.Tests
{
    public class OrderTests
    {
        [Fact]
        public void BasicOrderTest()
        {
            // Create repositories
            OrderRepository orderRepo = new OrderRepository();
            ReturnRepository returnRepo = new ReturnRepository();

            // Create customer
            ICustomer customer = new TruckAccessoriesCustomer(orderRepo, returnRepo);

            // Create order
            string orderNumber = "123";
            var order = new Order(orderNumber, customer);

            // Create and add product
            IProduct product = new ReplacementBumper();
            order.AddProduct(product);

            // Assert
            Assert.Equal(orderNumber, order.OrderNumber);
            Assert.Equal(customer.GetName(), order.Customer.GetName());
            Assert.True(DateTime.UtcNow > order.OrderDate);
            Assert.Equal(1, order.Products.Count);
            Assert.Equal(product.GetProductNumber(), order.Products.First().Product.GetProductNumber());
        }
    }
}